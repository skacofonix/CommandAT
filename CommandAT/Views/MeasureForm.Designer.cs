namespace CommandAT.Views
{
    partial class MeasureForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panelCommand = new System.Windows.Forms.Panel();
            this.listBoxResult = new System.Windows.Forms.ListBox();
            this.textBoxTechno = new System.Windows.Forms.TextBox();
            this.textBoxMeasure = new System.Windows.Forms.TextBox();
            this.buttonFlush = new System.Windows.Forms.Button();
            this.labelMeasure = new System.Windows.Forms.Label();
            this.labelTechno = new System.Windows.Forms.Label();
            this.panelResult = new System.Windows.Forms.Panel();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelWindowSize = new System.Windows.Forms.Label();
            this.labelDelay = new System.Windows.Forms.Label();
            this.numericUpDownWindowSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDelay = new System.Windows.Forms.NumericUpDown();
            this.panelCommand.SuspendLayout();
            this.panelResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.listBoxResult);
            this.panelCommand.Controls.Add(this.textBoxTechno);
            this.panelCommand.Controls.Add(this.textBoxMeasure);
            this.panelCommand.Controls.Add(this.buttonFlush);
            this.panelCommand.Controls.Add(this.labelMeasure);
            this.panelCommand.Controls.Add(this.labelTechno);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCommand.Location = new System.Drawing.Point(0, 154);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Size = new System.Drawing.Size(480, 382);
            // 
            // listBoxResult
            // 
            this.listBoxResult.Location = new System.Drawing.Point(3, 53);
            this.listBoxResult.Name = "listBoxResult";
            this.listBoxResult.Size = new System.Drawing.Size(474, 321);
            this.listBoxResult.TabIndex = 6;
            // 
            // textBoxTechno
            // 
            this.textBoxTechno.Location = new System.Drawing.Point(90, 6);
            this.textBoxTechno.Name = "textBoxTechno";
            this.textBoxTechno.ReadOnly = true;
            this.textBoxTechno.Size = new System.Drawing.Size(84, 41);
            this.textBoxTechno.TabIndex = 3;
            // 
            // textBoxMeasure
            // 
            this.textBoxMeasure.Location = new System.Drawing.Point(303, 5);
            this.textBoxMeasure.Name = "textBoxMeasure";
            this.textBoxMeasure.Size = new System.Drawing.Size(84, 41);
            this.textBoxMeasure.TabIndex = 1;
            // 
            // buttonFlush
            // 
            this.buttonFlush.Location = new System.Drawing.Point(393, 6);
            this.buttonFlush.Name = "buttonFlush";
            this.buttonFlush.Size = new System.Drawing.Size(84, 40);
            this.buttonFlush.TabIndex = 0;
            this.buttonFlush.Text = "Flush";
            this.buttonFlush.Click += new System.EventHandler(this.buttonFlush_Click);
            // 
            // labelMeasure
            // 
            this.labelMeasure.Location = new System.Drawing.Point(191, 5);
            this.labelMeasure.Name = "labelMeasure";
            this.labelMeasure.Size = new System.Drawing.Size(106, 40);
            this.labelMeasure.Text = "Measure";
            // 
            // labelTechno
            // 
            this.labelTechno.Location = new System.Drawing.Point(3, 6);
            this.labelTechno.Name = "labelTechno";
            this.labelTechno.Size = new System.Drawing.Size(99, 40);
            this.labelTechno.Text = "Techno";
            // 
            // panelResult
            // 
            this.panelResult.Controls.Add(this.buttonStop);
            this.panelResult.Controls.Add(this.buttonStart);
            this.panelResult.Controls.Add(this.labelWindowSize);
            this.panelResult.Controls.Add(this.labelDelay);
            this.panelResult.Controls.Add(this.numericUpDownWindowSize);
            this.panelResult.Controls.Add(this.numericUpDownDelay);
            this.panelResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelResult.Location = new System.Drawing.Point(0, 0);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(480, 154);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(153, 108);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(144, 40);
            this.buttonStop.TabIndex = 9;
            this.buttonStop.Text = "Stop";
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(3, 108);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(144, 40);
            this.buttonStart.TabIndex = 8;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelWindowSize
            // 
            this.labelWindowSize.Location = new System.Drawing.Point(3, 43);
            this.labelWindowSize.Name = "labelWindowSize";
            this.labelWindowSize.Size = new System.Drawing.Size(200, 40);
            this.labelWindowSize.Text = "Window size";
            // 
            // labelDelay
            // 
            this.labelDelay.Location = new System.Drawing.Point(3, 3);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(200, 40);
            this.labelDelay.Text = "Delay (ms)";
            // 
            // numericUpDownWindowSize
            // 
            this.numericUpDownWindowSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownWindowSize.Location = new System.Drawing.Point(277, 43);
            this.numericUpDownWindowSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWindowSize.Name = "numericUpDownWindowSize";
            this.numericUpDownWindowSize.Size = new System.Drawing.Size(200, 36);
            this.numericUpDownWindowSize.TabIndex = 1;
            this.numericUpDownWindowSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownDelay
            // 
            this.numericUpDownDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownDelay.Location = new System.Drawing.Point(277, 3);
            this.numericUpDownDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownDelay.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownDelay.Name = "numericUpDownDelay";
            this.numericUpDownDelay.Size = new System.Drawing.Size(200, 36);
            this.numericUpDownDelay.TabIndex = 0;
            this.numericUpDownDelay.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // MeasureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(480, 536);
            this.Controls.Add(this.panelCommand);
            this.Controls.Add(this.panelResult);
            this.Location = new System.Drawing.Point(0, 52);
            this.Menu = this.mainMenu1;
            this.Name = "MeasureForm";
            this.Text = "MeasureForm";
            this.Load += new System.EventHandler(this.MeasureForm_Load);
            this.panelCommand.ResumeLayout(false);
            this.panelResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCommand;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.Label labelWindowSize;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.NumericUpDown numericUpDownWindowSize;
        private System.Windows.Forms.NumericUpDown numericUpDownDelay;
        private System.Windows.Forms.Button buttonFlush;
        private System.Windows.Forms.TextBox textBoxMeasure;
        private System.Windows.Forms.TextBox textBoxTechno;
        private System.Windows.Forms.Label labelMeasure;
        private System.Windows.Forms.Label labelTechno;
        private System.Windows.Forms.ListBox listBoxResult;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
    }
}