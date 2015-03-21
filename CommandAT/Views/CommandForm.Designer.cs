namespace CommandAT.Views
{
    partial class CommandForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxCommandSelector = new System.Windows.Forms.ComboBox();
            this.panelCommandSelector = new System.Windows.Forms.Panel();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.numericUpDownDelay = new System.Windows.Forms.NumericUpDown();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelDelay = new System.Windows.Forms.Label();
            this.labelNumberOfLoop = new System.Windows.Forms.Label();
            this.numericUpDownNumberOfLoop = new System.Windows.Forms.NumericUpDown();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.labelCommand = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.checkBoxLoopEnabled = new System.Windows.Forms.CheckBox();
            this.panelCommandResult = new System.Windows.Forms.Panel();
            this.checkBoxExpandCollapse = new System.Windows.Forms.CheckBox();
            this.buttonFlush = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.checkBoxPause = new System.Windows.Forms.CheckBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panelCommandSelector.SuspendLayout();
            this.panelCommandResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxCommandSelector
            // 
            this.comboBoxCommandSelector.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboBoxCommandSelector.Location = new System.Drawing.Point(125, 4);
            this.comboBoxCommandSelector.Name = "comboBoxCommandSelector";
            this.comboBoxCommandSelector.Size = new System.Drawing.Size(352, 38);
            this.comboBoxCommandSelector.TabIndex = 0;
            this.comboBoxCommandSelector.SelectedIndexChanged += new System.EventHandler(this.comboBoxCommandSelector_SelectedIndexChanged);
            // 
            // panelCommandSelector
            // 
            this.panelCommandSelector.Controls.Add(this.buttonRemove);
            this.panelCommandSelector.Controls.Add(this.panelSeparator);
            this.panelCommandSelector.Controls.Add(this.numericUpDownDelay);
            this.panelCommandSelector.Controls.Add(this.buttonStop);
            this.panelCommandSelector.Controls.Add(this.buttonSend);
            this.panelCommandSelector.Controls.Add(this.textBoxName);
            this.panelCommandSelector.Controls.Add(this.buttonSave);
            this.panelCommandSelector.Controls.Add(this.labelDelay);
            this.panelCommandSelector.Controls.Add(this.labelNumberOfLoop);
            this.panelCommandSelector.Controls.Add(this.numericUpDownNumberOfLoop);
            this.panelCommandSelector.Controls.Add(this.textBoxContent);
            this.panelCommandSelector.Controls.Add(this.comboBoxCommandSelector);
            this.panelCommandSelector.Controls.Add(this.labelCommand);
            this.panelCommandSelector.Controls.Add(this.labelName);
            this.panelCommandSelector.Controls.Add(this.checkBoxLoopEnabled);
            this.panelCommandSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCommandSelector.Location = new System.Drawing.Point(0, 0);
            this.panelCommandSelector.Name = "panelCommandSelector";
            this.panelCommandSelector.Size = new System.Drawing.Size(480, 263);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonRemove.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonRemove.Location = new System.Drawing.Point(271, 217);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(100, 40);
            this.buttonRemove.TabIndex = 20;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // panelSeparator
            // 
            this.panelSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelSeparator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSeparator.Location = new System.Drawing.Point(0, 261);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(480, 2);
            // 
            // numericUpDownDelay
            // 
            this.numericUpDownDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownDelay.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownDelay.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDownDelay.Location = new System.Drawing.Point(352, 182);
            this.numericUpDownDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownDelay.Name = "numericUpDownDelay";
            this.numericUpDownDelay.Size = new System.Drawing.Size(125, 33);
            this.numericUpDownDelay.TabIndex = 18;
            this.numericUpDownDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonStop.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonStop.Location = new System.Drawing.Point(109, 217);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(100, 40);
            this.buttonStop.TabIndex = 13;
            this.buttonStop.Text = "Stop";
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSend.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonSend.Location = new System.Drawing.Point(3, 217);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(100, 40);
            this.buttonSend.TabIndex = 12;
            this.buttonSend.Text = "Send";
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxName.Location = new System.Drawing.Point(125, 43);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(352, 38);
            this.textBoxName.TabIndex = 11;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonSave.Location = new System.Drawing.Point(377, 217);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 40);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelDelay
            // 
            this.labelDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDelay.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelDelay.Location = new System.Drawing.Point(287, 184);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(82, 40);
            this.labelDelay.Text = "Delay";
            // 
            // labelNumberOfLoop
            // 
            this.labelNumberOfLoop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelNumberOfLoop.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelNumberOfLoop.Location = new System.Drawing.Point(132, 184);
            this.labelNumberOfLoop.Name = "labelNumberOfLoop";
            this.labelNumberOfLoop.Size = new System.Drawing.Size(46, 40);
            this.labelNumberOfLoop.Text = "Nb";
            // 
            // numericUpDownNumberOfLoop
            // 
            this.numericUpDownNumberOfLoop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownNumberOfLoop.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownNumberOfLoop.Location = new System.Drawing.Point(177, 182);
            this.numericUpDownNumberOfLoop.Name = "numericUpDownNumberOfLoop";
            this.numericUpDownNumberOfLoop.Size = new System.Drawing.Size(90, 33);
            this.numericUpDownNumberOfLoop.TabIndex = 4;
            this.numericUpDownNumberOfLoop.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBoxContent
            // 
            this.textBoxContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxContent.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxContent.Location = new System.Drawing.Point(3, 83);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(474, 98);
            this.textBoxContent.TabIndex = 2;
            // 
            // labelCommand
            // 
            this.labelCommand.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelCommand.Location = new System.Drawing.Point(3, 8);
            this.labelCommand.Name = "labelCommand";
            this.labelCommand.Size = new System.Drawing.Size(159, 40);
            this.labelCommand.Text = "Command:";
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelName.Location = new System.Drawing.Point(3, 44);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(159, 40);
            this.labelName.Text = "Name:";
            // 
            // checkBoxLoopEnabled
            // 
            this.checkBoxLoopEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxLoopEnabled.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.checkBoxLoopEnabled.Location = new System.Drawing.Point(3, 178);
            this.checkBoxLoopEnabled.Name = "checkBoxLoopEnabled";
            this.checkBoxLoopEnabled.Size = new System.Drawing.Size(109, 40);
            this.checkBoxLoopEnabled.TabIndex = 3;
            this.checkBoxLoopEnabled.Text = "Loop";
            this.checkBoxLoopEnabled.CheckStateChanged += new System.EventHandler(this.checkBoxLoopEnabled_CheckStateChanged);
            // 
            // panelCommandResult
            // 
            this.panelCommandResult.Controls.Add(this.checkBoxExpandCollapse);
            this.panelCommandResult.Controls.Add(this.buttonFlush);
            this.panelCommandResult.Controls.Add(this.textBoxResult);
            this.panelCommandResult.Controls.Add(this.checkBoxPause);
            this.panelCommandResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCommandResult.Location = new System.Drawing.Point(0, 263);
            this.panelCommandResult.Name = "panelCommandResult";
            this.panelCommandResult.Size = new System.Drawing.Size(480, 273);
            // 
            // checkBoxExpandCollapse
            // 
            this.checkBoxExpandCollapse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxExpandCollapse.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.checkBoxExpandCollapse.Location = new System.Drawing.Point(3, 3);
            this.checkBoxExpandCollapse.Name = "checkBoxExpandCollapse";
            this.checkBoxExpandCollapse.Size = new System.Drawing.Size(135, 40);
            this.checkBoxExpandCollapse.TabIndex = 15;
            this.checkBoxExpandCollapse.Text = "Expand";
            this.checkBoxExpandCollapse.CheckStateChanged += new System.EventHandler(this.checkBoxExpandCollapse_CheckStateChanged);
            // 
            // buttonFlush
            // 
            this.buttonFlush.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonFlush.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonFlush.Location = new System.Drawing.Point(377, 3);
            this.buttonFlush.Name = "buttonFlush";
            this.buttonFlush.Size = new System.Drawing.Size(100, 40);
            this.buttonFlush.TabIndex = 14;
            this.buttonFlush.Text = "Flush";
            this.buttonFlush.Click += new System.EventHandler(this.buttonFlush_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResult.Font = new System.Drawing.Font("Courier New", 6F, System.Drawing.FontStyle.Regular);
            this.textBoxResult.Location = new System.Drawing.Point(3, 46);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxResult.Size = new System.Drawing.Size(474, 229);
            this.textBoxResult.TabIndex = 13;
            this.textBoxResult.WordWrap = false;
            // 
            // checkBoxPause
            // 
            this.checkBoxPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxPause.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.checkBoxPause.Location = new System.Drawing.Point(138, 3);
            this.checkBoxPause.Name = "checkBoxPause";
            this.checkBoxPause.Size = new System.Drawing.Size(129, 40);
            this.checkBoxPause.TabIndex = 13;
            this.checkBoxPause.Text = "Pause";
            // 
            // CommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(480, 536);
            this.Controls.Add(this.panelCommandResult);
            this.Controls.Add(this.panelCommandSelector);
            this.Location = new System.Drawing.Point(0, 52);
            this.Menu = this.mainMenu1;
            this.Name = "CommandForm";
            this.Text = "CommandAT";
            this.Load += new System.EventHandler(this.CommandView_Load);
            this.panelCommandSelector.ResumeLayout(false);
            this.panelCommandResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCommandSelector;
        private System.Windows.Forms.Panel panelCommandSelector;
        private System.Windows.Forms.CheckBox checkBoxLoopEnabled;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.Label labelCommand;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.Label labelNumberOfLoop;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfLoop;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panelCommandResult;
        private System.Windows.Forms.CheckBox checkBoxPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button buttonFlush;
        private System.Windows.Forms.NumericUpDown numericUpDownDelay;
        private System.Windows.Forms.CheckBox checkBoxExpandCollapse;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.Button buttonRemove;
    }
}