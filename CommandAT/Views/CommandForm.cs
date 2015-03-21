using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommandAT.Tools;
using System.Reflection;
using CommandAT.Models;
using System.IO;
using System.Threading;
using CommandAT.Tools.GSM;

namespace CommandAT.Views
{
    public partial class CommandForm : Form
    {
        private Repository commandRepository = new Repository
        {
            Root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName),
            Name = "Commands"
        };

        private List<Command> commands;

        public CommandForm()
        {
            InitializeComponent();
        }

        private void CommandView_Load(object sender, EventArgs e)
        {
            LoadModel();

            RefreshCommandList();

            RefreshLoopOptions();
        }

        private void RefreshCommandList()
        {
            comboBoxCommandSelector.BeginUpdate();

            comboBoxCommandSelector.Items.Clear();

            foreach (var command in commands.OrderBy(cmd => cmd.Name))
                comboBoxCommandSelector.Items.Add(command);

            comboBoxCommandSelector.EndUpdate();
        }

        private void comboBoxCommandSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCommandSelector.SelectedIndex == 0)
            {
                ModelToUI(new Command());
            }

            var command = comboBoxCommandSelector.SelectedItem as Command;
            if (command != null)
            {
                ModelToUI(command);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var newCommand = UIToModel();

            var existingCommand = commands.FirstOrDefault(c => c.Name.Equals(newCommand.Name));
            if (existingCommand != null)
            {
                existingCommand.Content = newCommand.Content;
                existingCommand.DelayBetweenLoop = newCommand.DelayBetweenLoop;
                existingCommand.EnableLoop = newCommand.EnableLoop;
                existingCommand.NumberOfLoop = newCommand.NumberOfLoop;
            }
            else
            {
                commands.Add(newCommand);
                RefreshCommandList();
                comboBoxCommandSelector.SelectedItem = newCommand;
            }

            SaveModel();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            var selectedCommand = comboBoxCommandSelector.SelectedItem as Command;
            if (selectedCommand != null)
            {
                commands.Remove(selectedCommand);
                RefreshCommandList();
                SaveModel();
            }

            ModelToUI(new Command());
        }

        private void checkBoxLoopEnabled_CheckStateChanged(object sender, EventArgs e)
        {
            RefreshLoopOptions();
        }

        private void RefreshLoopOptions()
        {
            numericUpDownNumberOfLoop.Enabled = checkBoxLoopEnabled.Checked;
            numericUpDownDelay.Enabled = checkBoxLoopEnabled.Checked;
        }

        private void checkBoxExpandCollapse_CheckStateChanged(object sender, EventArgs e)
        {
            panelCommandSelector.Visible = !checkBoxExpandCollapse.Checked;
        }

        private void buttonFlush_Click(object sender, EventArgs e)
        {
            FlushResult();
        }

        private void FlushResult()
        {
            textBoxResult.Text = string.Empty;
        }

        #region Persistence

        private void LoadModel()
        {
            var readedCommand = commandRepository.Read<List<Command>>();

            if(readedCommand != null)
                commands = readedCommand;
            else
                commands = new List<Command>();
        }

        private void SaveModel()
        {
            commandRepository.Write(commands);
        }

        #endregion

        #region "DataBinding"

        private Command UIToModel()
        {
            var command = new Command();
            command.Name = textBoxName.Text;
            command.Content = textBoxContent.Text;
            command.EnableLoop = checkBoxLoopEnabled.Checked;
            try
            {
                command.NumberOfLoop = Convert.ToInt32(numericUpDownNumberOfLoop.Value);
            }
            catch
            {
                command.NumberOfLoop = 1;
                numericUpDownNumberOfLoop.Value = command.NumberOfLoop;
            }
            try
            {
                command.DelayBetweenLoop = Convert.ToInt32(numericUpDownDelay.Value);
            }
            catch
            {
                command.DelayBetweenLoop = 1000;
                numericUpDownDelay.Value = command.DelayBetweenLoop;
            }
            return command;
        }

        private void ModelToUI(Command command)
        {
            textBoxName.Text = command.Name;
            textBoxContent.Text = command.Content;
            checkBoxLoopEnabled.Checked = command.EnableLoop;
            numericUpDownNumberOfLoop.Value = command.NumberOfLoop;
            numericUpDownDelay.Value = command.DelayBetweenLoop;
        }

        #endregion

        #region ExecuteCommand

        bool commandRunning = false;
        private Thread threadCommand;

        private void buttonSend_Click(object sender, EventArgs e)
        {
            var command = UIToModel();

            if (!commandRunning)
            {
                commandRunning = true;

                if (threadCommand == null)
                {
                    threadCommand = new Thread(() =>
                    {
                        ExecuteCommand(command);
                    });
                    threadCommand.Name = "ExecuteCommand";
                }

                threadCommand.Start();

                buttonSend.Enabled = false;
                buttonStop.Enabled = true;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (commandRunning && threadCommand != null)
            {
                threadCommand.Abort();
            }
            CommandEnded();
        }

        private void ExecuteCommand(Command command)
        {
            var loopRemaining = command.EnableLoop ? command.NumberOfLoop : 1;

            bool loopIsEnding = false;

            do
            {
                var result = RIL.SendAtCommand(command.Content);

                Invoke(new Action(() =>
                {
                    textBoxResult.Text += result;
                    if (!checkBoxPause.Checked)
                    {
                        textBoxResult.Select(textBoxResult.Text.Length, 0);
                        textBoxResult.ScrollToCaret();
                    }
                }));

                if (command.NumberOfLoop > 0)
                {
                    loopRemaining--;

                    if (loopRemaining <= 0)
                        loopIsEnding = true;
                }

                if (!loopIsEnding)
                {
                    Thread.Sleep(command.DelayBetweenLoop);
                }

            } while (!loopIsEnding);

            Invoke(new Action(() => CommandEnded()));
        }

        private void CommandEnded()
        {
            if (threadCommand != null)
                threadCommand = null;

            buttonSend.Enabled = true;
            buttonStop.Enabled = false;

            commandRunning = false;
        }

        #endregion
    }
}