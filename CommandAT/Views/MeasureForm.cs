using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommandAT.Tools.GSM;
using System.Collections;
using System.Threading;

namespace CommandAT.Views
{
    public partial class MeasureForm : Form
    {
        internal class Measure
        {
            public decimal Value { get; set; }

            public string Techno { get; set; }

            public string Mnc { get; set; }

            public override string ToString()
            {
                return string.Format("Value:{0}, Techno:{1}, MNC:{2}",
                    Value,
                    Techno,
                    Mnc);
            }
        }

        public MeasureForm()
        {
            InitializeComponent();
        }

        private bool flagMeasureEnded = false;
        private int delay;
        private int windowSize;

        private void StartMeasure()
        {
            flagMeasureEnded = false;

            // Identificate model
            var result = RIL.SendAtCommand("AT+GMM");
            bool isHc25Modem = result.Contains("HC25");

            var measures = new Queue<Measure>(windowSize);
            measures.TrimExcess();

            var measureThread = new Thread(new ThreadStart(() =>
            {
                do
                {
                    result = RIL.SendAtCommand("AT^SMONI");
                    var smoni = AtCommandManager.ManageSMONI(result);

                    if (smoni != null)
                    {
                        decimal measureValue = 0;
                        if (smoni.ACT == "2G")
                        {
                            measureValue = Convert.ToDecimal(smoni.BCCH, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            decimal ecn0Temp = Convert.ToDecimal(smoni.ECn0, System.Globalization.CultureInfo.InvariantCulture);
                            measureValue = isHc25Modem ? (ecn0Temp / 2m) - 24.5m : ecn0Temp;
                        }

                        measures.Enqueue(new Measure
                        {
                            Value = measureValue,
                            Techno = smoni.ACT,
                            Mnc = smoni.MCC + smoni.MNC
                        });
                    }

                    if (!flagMeasureEnded)
                        Thread.Sleep(delay);

                } while (!flagMeasureEnded);

            }));
            measureThread.Name = "MeasureThread";
            measureThread.Start();

            var displayThread = new Thread(new ThreadStart(() =>
            {
                decimal average = 0;
                string techno = string.Empty;
                string mnc = string.Empty;

                do
                {
                    if (measures.Count >= windowSize)
                        measures.Dequeue();

                    if (measures.Any())
                    {
                        average = measures.Average(m => m.Value);
                        techno = measures.LastOrDefault().Techno;
                        mnc = measures.LastOrDefault().Mnc;
                    }

                    Invoke(new Action(() =>
                    {
                        textBoxMeasure.Text = average.ToString();
                        textBoxTechno.Text = techno;
                        if (measures.Any())
                            listBoxResult.Items.Insert(0, measures.LastOrDefault().ToString());
                    }));

                    if (!flagMeasureEnded)
                        Thread.Sleep(delay);

                } while (!flagMeasureEnded);

            }));
            displayThread.Name = "DisplayThread";
            displayThread.Start();
        }

        private bool IsRunning = false;

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!IsRunning)
            {
                Busy(true);

                delay = Convert.ToInt32(numericUpDownDelay.Value);
                windowSize = Convert.ToInt32(numericUpDownWindowSize.Value);

                StartMeasure();

                IsRunning = true;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (IsRunning)
            {
                Busy(false);
                flagMeasureEnded = true;

                IsRunning = false;
            }
        }

        private void Busy(bool busy)
        {
            numericUpDownDelay.Enabled = !busy;
            numericUpDownWindowSize.Enabled = !busy;
            buttonStart.Enabled = !busy;
            buttonStop.Enabled = busy;

            Cursor.Current = busy ? Cursors.WaitCursor : Cursors.Default;
        }

        private void MeasureForm_Load(object sender, EventArgs e)
        {
            Busy(false);
        }

        private void buttonFlush_Click(object sender, EventArgs e)
        {
            listBoxResult.Items.Clear();
        }
    }
}