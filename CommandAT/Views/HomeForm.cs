using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommandAT.Views
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void buttonCommand_Click(object sender, EventArgs e)
        {
            var form = new CommandForm();
            form.ShowDialog();
        }

        private void buttonChangeNetwork_Click(object sender, EventArgs e)
        {
            var form = new ChangeNetworkForm();
            form.ShowDialog();
        }

        private void buttonMeasure_Click(object sender, EventArgs e)
        {
            var form = new MeasureForm();
            form.ShowDialog();
        }
    }
}