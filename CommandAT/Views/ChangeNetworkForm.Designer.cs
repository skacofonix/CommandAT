namespace CommandAT.Views
{
    partial class ChangeNetworkForm
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
            this.buttonSearchNetwork = new System.Windows.Forms.Button();
            this.listViewNetwork = new System.Windows.Forms.ListView();
            this.buttonConnectToNetwork = new System.Windows.Forms.Button();
            this.statusBarNetwork = new System.Windows.Forms.StatusBar();
            this.panelCurrentNetwork = new System.Windows.Forms.Panel();
            this.labelCurrentNetworkValue = new System.Windows.Forms.Label();
            this.labelCurrentNetwork = new System.Windows.Forms.Label();
            this.panelCurrentNetwork.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSearchNetwork
            // 
            this.buttonSearchNetwork.Location = new System.Drawing.Point(3, 41);
            this.buttonSearchNetwork.Name = "buttonSearchNetwork";
            this.buttonSearchNetwork.Size = new System.Drawing.Size(474, 80);
            this.buttonSearchNetwork.TabIndex = 0;
            this.buttonSearchNetwork.Text = "List network";
            this.buttonSearchNetwork.Click += new System.EventHandler(this.buttonSearchNetwork_Click);
            // 
            // listViewNetwork
            // 
            this.listViewNetwork.Location = new System.Drawing.Point(3, 127);
            this.listViewNetwork.Name = "listViewNetwork";
            this.listViewNetwork.Size = new System.Drawing.Size(474, 332);
            this.listViewNetwork.TabIndex = 1;
            // 
            // buttonConnectToNetwork
            // 
            this.buttonConnectToNetwork.Location = new System.Drawing.Point(3, 464);
            this.buttonConnectToNetwork.Name = "buttonConnectToNetwork";
            this.buttonConnectToNetwork.Size = new System.Drawing.Size(474, 80);
            this.buttonConnectToNetwork.TabIndex = 2;
            this.buttonConnectToNetwork.Text = "Change network";
            this.buttonConnectToNetwork.Click += new System.EventHandler(this.buttonConnectToNetwork_Click);
            // 
            // statusBarNetwork
            // 
            this.statusBarNetwork.Location = new System.Drawing.Point(0, 550);
            this.statusBarNetwork.Name = "statusBarNetwork";
            this.statusBarNetwork.Size = new System.Drawing.Size(480, 38);
            // 
            // panelCurrentNetwork
            // 
            this.panelCurrentNetwork.Controls.Add(this.labelCurrentNetworkValue);
            this.panelCurrentNetwork.Controls.Add(this.labelCurrentNetwork);
            this.panelCurrentNetwork.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCurrentNetwork.Location = new System.Drawing.Point(0, 0);
            this.panelCurrentNetwork.Name = "panelCurrentNetwork";
            this.panelCurrentNetwork.Size = new System.Drawing.Size(480, 35);
            // 
            // labelCurrentNetworkValue
            // 
            this.labelCurrentNetworkValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCurrentNetworkValue.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelCurrentNetworkValue.Location = new System.Drawing.Point(221, 0);
            this.labelCurrentNetworkValue.Name = "labelCurrentNetworkValue";
            this.labelCurrentNetworkValue.Size = new System.Drawing.Size(259, 35);
            // 
            // labelCurrentNetwork
            // 
            this.labelCurrentNetwork.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelCurrentNetwork.Location = new System.Drawing.Point(0, 0);
            this.labelCurrentNetwork.Name = "labelCurrentNetwork";
            this.labelCurrentNetwork.Size = new System.Drawing.Size(221, 35);
            this.labelCurrentNetwork.Text = "Current Network :";
            // 
            // ChangeNetworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(480, 588);
            this.Controls.Add(this.panelCurrentNetwork);
            this.Controls.Add(this.statusBarNetwork);
            this.Controls.Add(this.buttonConnectToNetwork);
            this.Controls.Add(this.listViewNetwork);
            this.Controls.Add(this.buttonSearchNetwork);
            this.Location = new System.Drawing.Point(0, 52);
            this.Name = "ChangeNetworkForm";
            this.Text = "Change Network";
            this.panelCurrentNetwork.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSearchNetwork;
        private System.Windows.Forms.ListView listViewNetwork;
        private System.Windows.Forms.Button buttonConnectToNetwork;
        private System.Windows.Forms.StatusBar statusBarNetwork;
        private System.Windows.Forms.Panel panelCurrentNetwork;
        private System.Windows.Forms.Label labelCurrentNetworkValue;
        private System.Windows.Forms.Label labelCurrentNetwork;
    }
}