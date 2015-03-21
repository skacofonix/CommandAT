namespace CommandAT.Views
{
    partial class HomeForm
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
            this.buttonCommand = new System.Windows.Forms.Button();
            this.buttonNetwork = new System.Windows.Forms.Button();
            this.buttonMeasure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCommand
            // 
            this.buttonCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCommand.Location = new System.Drawing.Point(0, 0);
            this.buttonCommand.Name = "buttonCommand";
            this.buttonCommand.Size = new System.Drawing.Size(480, 80);
            this.buttonCommand.TabIndex = 0;
            this.buttonCommand.Text = "Command AT";
            this.buttonCommand.Click += new System.EventHandler(this.buttonCommand_Click);
            // 
            // buttonNetwork
            // 
            this.buttonNetwork.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNetwork.Location = new System.Drawing.Point(0, 80);
            this.buttonNetwork.Name = "buttonNetwork";
            this.buttonNetwork.Size = new System.Drawing.Size(480, 80);
            this.buttonNetwork.TabIndex = 3;
            this.buttonNetwork.Text = "Network";
            this.buttonNetwork.Click += new System.EventHandler(this.buttonChangeNetwork_Click);
            // 
            // buttonMeasure
            // 
            this.buttonMeasure.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonMeasure.Location = new System.Drawing.Point(0, 160);
            this.buttonMeasure.Name = "buttonMeasure";
            this.buttonMeasure.Size = new System.Drawing.Size(480, 80);
            this.buttonMeasure.TabIndex = 4;
            this.buttonMeasure.Text = "Measure";
            this.buttonMeasure.Click += new System.EventHandler(this.buttonMeasure_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(480, 588);
            this.Controls.Add(this.buttonMeasure);
            this.Controls.Add(this.buttonNetwork);
            this.Controls.Add(this.buttonCommand);
            this.Location = new System.Drawing.Point(0, 52);
            this.MinimizeBox = false;
            this.Name = "HomeForm";
            this.Text = "CommandAT";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCommand;
        private System.Windows.Forms.Button buttonNetwork;
        private System.Windows.Forms.Button buttonMeasure;
    }
}

