using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PartsIffTool
{
    public partial class StringTableEditor : Form
    {
        private List<LocaleString> basicLocale;
        private LocaleString stringOnEdit;

        public StringTableEditor()
        {
            InitializeComponent();
            basicLocale = new List<LocaleString>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "thailand.dat|thailand.dat";

            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                basicLocale = new List<LocaleString>();

                using (BinaryReader reader = new BinaryReader(File.Open(ofd.FileName, FileMode.Open, FileAccess.Read), IffFile.FileEncoding(IffFile.IFF_REGION.Default)))
                {
                    int stringNum = 0;
                    StringBuilder content = new StringBuilder();

                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        if (reader.PeekChar() != (char)0x00)
                        {
                            content.Append(reader.ReadChar());
                        }
                        else
                        {
                            LocaleString tmpLocale = new LocaleString();
                            tmpLocale.Locale = content.ToString();
                            tmpLocale.Index = stringNum;

                            basicLocale.Add(tmpLocale);
                            content = new StringBuilder();
                            reader.BaseStream.Seek(1, SeekOrigin.Current);
                            stringNum++;
                        }
                    }
                }

                UpdateStringList();
            }
        }

        private void UpdateStringList()
        {
            lstStrings.Items.Clear();
            foreach (LocaleString str in basicLocale)
            {
                ListViewItem tmpLstItem = new ListViewItem(str.Locale);
                tmpLstItem.Tag = str.Index;

                lstStrings.Items.Add(tmpLstItem);
            }
        }

        private void lstStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStrings.SelectedItems.Count > 0)
            {
                stringOnEdit = basicLocale[(int)lstStrings.SelectedItems[0].Tag];
                txtString.Text = stringOnEdit.Locale.Replace("\n", "\r\n");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "thailand.dat|thailand.dat";

            DialogResult result = sfd.ShowDialog();

            if (result == DialogResult.OK)
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(sfd.FileName, FileMode.Create, FileAccess.Write), IffFile.FileEncoding(IffFile.IFF_REGION.Default)))
                {
                    foreach (LocaleString locale in basicLocale)
                    {
                        char[] stringToWrite = locale.Locale.ToCharArray();
                        char endOfString = (char)0x00;

                        writer.Write(stringToWrite);
                        writer.Write(endOfString);
                    }
                }
                MessageBox.Show("File written", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (stringOnEdit != null)
            {
                stringOnEdit.Locale = txtString.Text.Replace("\r\n", "\n");
                UpdateStringList();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            lstStrings.Items.Clear();

            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                foreach (LocaleString s in basicLocale)
                {
                    Wildcard wildcard = new Wildcard(txtFilter.Text, RegexOptions.IgnoreCase);
                    if (wildcard.IsMatch(s.Locale))
                    {
                        ListViewItem tmpLItem = new ListViewItem(s.Locale);
                        tmpLItem.Tag = s.Index;
                        lstStrings.Items.Add(tmpLItem);
                    }
                }
            }
            else
            {
                foreach (LocaleString s in basicLocale)
                {
                    ListViewItem tmpLItem = new ListViewItem(s.Locale);
                    tmpLItem.Tag = s.Index;
                    lstStrings.Items.Add(tmpLItem);
                }
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnFilter.PerformClick();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtString.Text = IffCommonMethods.GetTranslatedItemName(txtString.Text, 0, "th", "en");
        }
    }
}