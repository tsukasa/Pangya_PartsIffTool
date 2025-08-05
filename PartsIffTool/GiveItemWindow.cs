using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PartsIffTool
{
    public partial class GiveItemWindow : Form
    {
        public string itemId = "";
        public string itemName = "";

        private ProgramConfiguration databaseConnection;

        public GiveItemWindow()
        {
            InitializeComponent();

            Init();
        }

        public GiveItemWindow(string item_id, string item_name)
        {
            InitializeComponent();
            itemId = item_id;
            itemName = item_name;

            Init();
        }

        private void Init()
        {
            cmbMethod.SelectedIndex = 0;

            databaseConnection = ProgramConfiguration.DeserializeConfiguration();

            txtDbConDsn.Text = databaseConnection.SystemDsn;
            txtDbConUsername.Text = databaseConnection.DsnUsername;
            txtDbConPassword.Text = databaseConnection.DsnPassword;

            foreach (string nick in databaseConnection.RecentNicks)
            {
                txtUsername.Items.Add(nick);
            }

            txtUsername.Focus();
        }

        private void btnGiveItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                using (OdbcConnection DbConnection = new OdbcConnection(String.Format("DSN={0};UID={1};PWD={2};", txtDbConDsn.Text, txtDbConUsername.Text, txtDbConPassword.Text)))
                {
                    DbConnection.Open();
                    OdbcCommand DbCommand = DbConnection.CreateCommand();

                    DbCommand.CommandText = String.Format("EXEC {2} '{0}', {1}", txtUsername.Text, itemId, cmbMethod.Text);
                    OdbcDataReader DbReader = DbCommand.ExecuteReader();

                    DbReader.Close();
                    DbCommand.Dispose();

                    /* Update connection info */
                    if (databaseConnection == null)
                        databaseConnection = new ProgramConfiguration();

                    databaseConnection.SystemDsn = txtDbConDsn.Text;
                    databaseConnection.DsnUsername = txtDbConUsername.Text;
                    databaseConnection.DsnPassword = txtDbConPassword.Text;

                    if (!databaseConnection.RecentNicks.Contains(txtUsername.Text))
                        databaseConnection.RecentNicks.Add(txtUsername.Text);

                    ProgramConfiguration.SerializeConfiguration(databaseConnection);
                }
                Close();
            }
        }

        private void btnGive_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnGiveItem.PerformClick();
        }
    }
}
