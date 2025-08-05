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
    public partial class GenericDumper : Form
    {
        public GenericDumper()
        {
            InitializeComponent();
            itemList = new List<IffItemCommon>();
            cmbFilterBy.SelectedIndex = 0;
        }

        private List<IffItemCommon> itemList;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pangya IFF File (*.iff)|*.iff";
            ofd.Title = "Open IFF File";
            DialogResult ofdResult = ofd.ShowDialog();

            if (ofdResult == DialogResult.OK)
            {
                using (BinaryReader reader = new BinaryReader(File.Open(ofd.FileName, FileMode.Open, FileAccess.Read), IffFile.FileEncoding(IffFile.IFF_REGION.Default)))
                {
                    itemList = new List<IffItemCommon>();

                    IffFile inIffFile = new IffFile();
                    long numRecords = inIffFile.GetNumberOfRecords(reader);
                    long recordLen = inIffFile.GetRecordLength(reader);

                    inIffFile.JumpToFirstRecord(reader);
                    for (int i = 0; i < numRecords; i++)
                    {
                        int curPos = 0;

                        IffItemCommon tmpRecord = new IffItemCommon();
                        tmpRecord.Final = reader.ReadUInt32();
                        curPos += 4;

                        tmpRecord.TypeId = reader.ReadUInt32();
                        curPos += 4;

                        byte[] byteItemName = reader.ReadBytes(40);
                        tmpRecord.Name = IffFile.FileEncoding(tmpRecord.Region).GetString(byteItemName);
                        curPos += 40;

                        reader.BaseStream.Seek(recordLen - curPos, SeekOrigin.Current);

                        tmpRecord.Price = 1000;
                        tmpRecord.MoneyType = 0x02;

                        itemList.Add(tmpRecord);
                    }
                }

                lstParts.Items.Clear();
                Text = String.Format("Pangya Generic Dumper [{0}] ({1} entries loaded)", ofd.FileName, itemList.Count);

                foreach (IffItemCommon p in itemList)
                {
                    ListViewItem tmpLItem = new ListViewItem(p.Name);
                    tmpLItem.Tag = p.TypeId;
                    lstParts.Items.Add(tmpLItem);
                }
            }
        }

        private void LoadObjectDetail(uint index)
        {
            var selectedItem = from u in itemList
                               where u.TypeId == index
                               select u;

            foreach (IffItemCommon recordToDisplay in selectedItem)
            {
                if (recordToDisplay != null)
                {
                    txtItemName.Text = recordToDisplay.Name;
                    txtItemId.Text = recordToDisplay.TypeId.ToString();
                }
            }
        }

        private void lstParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstParts.SelectedItems.Count > 0)
                LoadObjectDetail((uint)lstParts.SelectedItems[0].Tag);
        }

        private void btnGenerateSql_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save SQL Query";
            sfd.Filter = "SQL Queries (*.sql)|*.sql";
            DialogResult sfdResult = sfd.ShowDialog();

            if (sfdResult == DialogResult.OK)
            {
                IffItemCommon.GenerateSqlFile(itemList, sfd.FileName);
                MessageBox.Show("File written!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGiveItem_Click(object sender, EventArgs e)
        {
            if (lstParts.SelectedItems.Count > 0)
            {
                GiveItemWindow giveItemWindow = new GiveItemWindow(txtItemId.Text, txtItemName.Text);
                giveItemWindow.ShowDialog();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            lstParts.Items.Clear();

            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                foreach (IffItemCommon p in itemList)
                {
                    Wildcard wildcard = new Wildcard(txtFilter.Text, RegexOptions.IgnoreCase);
                    if (cmbFilterBy.SelectedIndex == 0)
                    {
                        if (wildcard.IsMatch(p.Name))
                        {
                            ListViewItem tmpLItem = new ListViewItem(p.Name);
                            tmpLItem.Tag = p.TypeId;
                            lstParts.Items.Add(tmpLItem);
                        }
                    }
                    else if (cmbFilterBy.SelectedIndex == 1)
                    {
                        if (wildcard.IsMatch(p.TypeId.ToString()))
                        {
                            ListViewItem tmpLItem = new ListViewItem(p.Name);
                            tmpLItem.Tag = p.TypeId;
                            lstParts.Items.Add(tmpLItem);
                        }
                    }
                }
            }
            else
            {
                foreach (IffItemCommon p in itemList)
                {
                    ListViewItem tmpLItem = new ListViewItem(p.Name);
                    tmpLItem.Tag = p.TypeId;
                    lstParts.Items.Add(tmpLItem);
                }
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnFilter.PerformClick();
        }
    }
}
