using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommandAT.Tools;
using System.Threading;
using System.Collections;
using CommandAT.Tools.GSM;

namespace CommandAT.Views
{
    public partial class ChangeNetworkForm : Form
    {
        public ChangeNetworkForm()
        {
            InitializeComponent();

            listViewNetwork.Columns.Clear();
            listViewNetwork.Columns.Add("#", 50, HorizontalAlignment.Left);
            listViewNetwork.Columns.Add("Name", 300, HorizontalAlignment.Left);
            listViewNetwork.Columns.Add("MNC", 100, HorizontalAlignment.Left);
            listViewNetwork.FullRowSelect = true;
            listViewNetwork.View = View.Details;

            buttonConnectToNetwork.Enabled = false;

            var t = new Thread(() =>
            {
                Invoke(new Action(() => statusBarNetwork.Text = "Read current network in progress..."));
                var network = GetCurrentNetwork();
                Invoke(new Action(() => statusBarNetwork.Text = "Current network readed"));
                RefreshUICurrentNetwork(network);
            });
            t.Start();
        }

        private void Busy(bool busy)
        {
            buttonSearchNetwork.Enabled = !busy;
            buttonConnectToNetwork.Enabled = !busy && listViewNetwork.Items.Count > 0;
            listViewNetwork.Enabled = !busy;

            if (busy)
            {
                Cursor.Current = Cursors.WaitCursor;
                Cursor.Show();
            }
            else
            {
                Cursor.Current = Cursors.Default;
                Cursor.Hide();
            }
        }

        private void buttonSearchNetwork_Click(object sender, EventArgs e)
        {
            try
            {
                Busy(true);

                Invoke(new Action(() =>
                {
                    statusBarNetwork.Text = "Seaching network...";
                }));

                var networks = RIL.GetNetworksList();

                Invoke(new Action(() =>
                {
                    statusBarNetwork.Text = networks.Count + " networks founded";

                    listViewNetwork.BeginUpdate();

                    listViewNetwork.Items.Clear();

                    int counter = 0;
                    foreach (var network in networks)
                    {
                        counter++;

                        var newItem = new ListViewItem(new string[] {
                            counter.ToString(),
                            network.BroadcastName,
                            network.NetworkCode});
                        newItem.Tag = network;

                        listViewNetwork.Items.Add(newItem);
                    }

                    listViewNetwork.EndUpdate();
                }));
            }
            finally
            {
                Busy(false);
            }
        }

        private void buttonConnectToNetwork_Click(object sender, EventArgs e)
        {
            GSMNetwork selectedNetwork = null;
            foreach (ListViewItem item in listViewNetwork.Items)
	        {
                if (!item.Selected)
                    continue;

                selectedNetwork = item.Tag as GSMNetwork;
                break;
	        }

            if (selectedNetwork == null)
                return;

            var currentNetwork = GetCurrentNetwork();
            if (selectedNetwork.NetworkCode == currentNetwork.NetworkCode)
                return;

            try
            {
                Busy(true);

                Invoke(new Action(() =>
                {
                    statusBarNetwork.Text = "Connecting to " + selectedNetwork.BroadcastName + " in progress...";
                }));

                RIL.SwitchOperator(selectedNetwork);

                Invoke(new Action(() =>
                {
                    statusBarNetwork.Text = "Connection to " + selectedNetwork.BroadcastName + " ended";
                }));

                currentNetwork = GetCurrentNetwork();
                RefreshUICurrentNetwork(currentNetwork);
            }
            finally
            {
                Busy(false);
            }
        }

        private void RefreshUICurrentNetwork(GSMNetwork network)
        {
            Invoke(new Action(() => {
                labelCurrentNetworkValue.Text = string.Format("{0} ({1})", network.NetworkCode, network.Generation);
            }));
        }

        public GSMNetwork GetCurrentNetwork()
        {
            GSMNetwork network = new GSMNetwork();

            string response = null;
            for (int i = 0; i < 3; i++)
            {
                response = RIL.SendAtCommand("AT^SMONI");

                if (!string.IsNullOrEmpty(response) && !response.Contains("SEARCH") && response.Contains("^SMONI"))
                    break;

                Thread.Sleep(1000);
            }

            Hashtable hash_smoni = new Hashtable();

            if (!string.IsNullOrEmpty(response) && !response.Contains("SEARCH") && response.Contains("^SMONI"))
            {
                var smoni = AtCommandManager.ManageSMONI(response);

                if (smoni != null)
                {
                    network.Generation = smoni.ACT;
                    network.NetworkCode = string.Concat(smoni.MCC, smoni.MNC);
                }
            }

            return network;
        }
    }
}