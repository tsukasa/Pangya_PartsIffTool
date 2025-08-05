using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PartsIffTool
{
    public partial class DescEditor : Form
    {
        public List<DescRecord> descriptionList;
        private List<DescRecord> _translation_Parent;
        private DescRecord objectOnEdit;

        public DescEditor()
        {
            InitializeComponent();
            descriptionList = new List<DescRecord>();
            txtObjDescription.MaxLength = DescRecord.DescriptionLen;
        }

        public DescEditor(List<DescRecord> _translation_Parent_Descs)
        {
            InitializeComponent();
            descriptionList = new List<DescRecord>();
            txtObjDescription.MaxLength = DescRecord.DescriptionLen;

            btnNew.Enabled = false;
            btnSave.Enabled = false;

            _translation_Parent = _translation_Parent_Descs;
            btnTranslateFile.Text = "Edit Parent";
        }

        private bool UpdateItem(DescRecord item)
        {
            if (item != null)
            {
                item.ReferencedObject = UInt32.Parse(txtObjId.Text);
                item.Description = txtObjDescription.Text.Replace("\r\n", "\\n");
                return true;
            }
            return false;
        }

        private void LoadObjectFromList(UInt32 index)
        {
            var selectedItem = from u in descriptionList
                               where u.ReferencedObject == index
                               select u;

            foreach (DescRecord recordToDisplay in selectedItem)
            {
                if (recordToDisplay != null)
                {
                    objectOnEdit = recordToDisplay;

                    txtObjId.Text = recordToDisplay.ReferencedObject.ToString();
                    txtObjDescription.Text = recordToDisplay.Description.Replace("\\n", "\r\n");
                }
            }
        }

        private void CompareFilesAndCopyTranslation()
        {
            if (_translation_Parent != null)
            {
                foreach (DescRecord d in descriptionList)
                {
                    var result = from r in _translation_Parent
                                 where r.ReferencedObject == d.ReferencedObject
                                 select r;

                    foreach (DescRecord d2 in result)
                    {
                        if (!string.IsNullOrEmpty(d.Description))
                            d2.Description = d.Description;
                    }
                }
            }
        }

        private void lstParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstParts.SelectedIndices.Count > 0)
            {
                ListViewItem tmpItem = (ListViewItem)lstParts.SelectedItems[0];
                LoadObjectFromList((UInt32)tmpItem.Tag);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            lstParts.Items.Clear();

            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                foreach (DescRecord p in descriptionList)
                {
                    Wildcard wildcard = new Wildcard(txtFilter.Text, RegexOptions.IgnoreCase);
                    if (wildcard.IsMatch(p.ReferencedObject.ToString()))
                    {
                        ListViewItem tmpLItem = new ListViewItem(p.ReferencedObject.ToString());
                        tmpLItem.Tag = p.ReferencedObject;
                        lstParts.Items.Add(tmpLItem);
                    }
                }
            }
            else
            {
                foreach (DescRecord p in descriptionList)
                {
                    ListViewItem tmpLItem = new ListViewItem(p.ReferencedObject.ToString());
                    tmpLItem.Tag = p.ReferencedObject;
                    lstParts.Items.Add(tmpLItem);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lstParts.Items.Clear();
            descriptionList = new List<DescRecord>();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pangya IFF File (*.iff)|*.iff";
            ofd.Title = "Open IFF File";
            DialogResult ofdResult = ofd.ShowDialog();

            if (ofdResult == DialogResult.OK)
            {
                descriptionList = new List<DescRecord>();
                lstParts.Items.Clear();

                descriptionList = DescRecord.LoadDescFile(ofd.FileName);

                Text = String.Format("Pangya Desc Editor [{0}] ({1} items loaded)", ofd.FileName, descriptionList.Count);

                foreach (DescRecord d in descriptionList)
                {
                    ListViewItem tmpListItem = new ListViewItem(d.ReferencedObject.ToString());
                    tmpListItem.Tag = d.ReferencedObject;

                    lstParts.Items.Add(tmpListItem);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Pangya IFF File";
            sfd.Filter = "Pangya IFF File (*.iff)|*.iff";

            DialogResult sfdResult = sfd.ShowDialog();

            if (sfdResult == DialogResult.OK)
            {
                bool success = DescRecord.SaveDescFile(sfd.FileName, descriptionList);

                if (success)
                    MessageBox.Show("File written!");
                else
                    MessageBox.Show("Error while writing the file.");
            }
        }

        private void btnAddNewObj_Click(object sender, EventArgs e)
        {
            DescRecord newItem = new DescRecord();
            if (UpdateItem(newItem))
            {
                descriptionList.Add(newItem);

                ListViewItem newItemListView = new ListViewItem(newItem.ReferencedObject.ToString());
                newItemListView.Tag = newItem.ReferencedObject;
                lstParts.Items.Add(newItemListView);
                lstParts.Items[lstParts.Items.Count - 1].Selected = true;
                lstParts.Items[lstParts.Items.Count - 1].Focused = true;
                lstParts.Focus();
                lstParts.Select();
            }
            else
            {
                MessageBox.Show("Error adding new item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteObj_Click(object sender, EventArgs e)
        {
            DialogResult delResult = MessageBox.Show("Are you sure you want to delete the description for object '" + objectOnEdit.ReferencedObject.ToString() + "'?",
                            "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);

            if (delResult == DialogResult.Yes)
            {
                lstParts.Items.RemoveAt(lstParts.SelectedIndices[0]);
                descriptionList.Remove(objectOnEdit);
            }
        }

        private void btnApplyObjChange_Click(object sender, EventArgs e)
        {
            if (UpdateItem(objectOnEdit))
                lstParts.SelectedItems[0].Text = objectOnEdit.ReferencedObject.ToString();
        }

        private void btnDiscardObjChange_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to discard the changes you made to this object?",
                                                  "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                LoadObjectFromList(objectOnEdit.ReferencedObject);
        }

        private void txtObjDescription_TextChanged(object sender, EventArgs e)
        {
            lblDescription.Text = String.Format("Description: (using {0} of {1} characters)",
                                                txtObjDescription.Text.Length, DescRecord.DescriptionLen);
        }

        private void picHorizBadge_Paint(object sender, PaintEventArgs e)
        {
            string strActionTitle = "Desc.iff Editor";

            Rectangle baseRectangle = new Rectangle(0, 0, picHorizBadge.Width, picHorizBadge.Height);
            Brush gradientBrush = new LinearGradientBrush(baseRectangle, SystemColors.ControlDarkDark,
                                                          SystemColors.Control, LinearGradientMode.Horizontal);

            e.Graphics.FillRectangle(gradientBrush, baseRectangle);

            e.Graphics.DrawString(strActionTitle, new Font(SystemFonts.DialogFont.FontFamily, 16, FontStyle.Bold),
                                  new SolidBrush(SystemColors.ControlText), 6, 6);
            e.Graphics.DrawString(strActionTitle, new Font(SystemFonts.DialogFont.FontFamily, 16, FontStyle.Bold),
                                  new SolidBrush(SystemColors.ControlLightLight), 5, 5);
        }

        private void DescEditor_Resize(object sender, EventArgs e)
        {
            picHorizBadge.Invalidate();
        }

        private void btnTranslateFile_Click(object sender, EventArgs e)
        {
            if (descriptionList != null && descriptionList.Count > 0)
            {
                if (_translation_Parent == null)
                {
                    MessageBox.Show(
                        "In the new window please open the Desc.iff from which you want to copy the translation to your currently opened file.", "How to proceed:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DescEditor translatedFileEditor = new DescEditor(descriptionList);
                    translatedFileEditor.Show();
                }
                else
                {
                    CompareFilesAndCopyTranslation();
                    Close();
                }
            }
            else
                MessageBox.Show("Please load a file before continuing.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static string ColorToHexString(Color color)
        {
            char[] hexDigits = {
                '0', '1', '2', '3', '4', '5', '6', '7',
                '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'
            };

            byte[] bytes = new byte[3];
            bytes[0] = color.R;
            bytes[1] = color.G;
            bytes[2] = color.B;
            char[] chars = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }
            return new string(chars);
        }

        private void btnInsertColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;

            if (colorDialog.ShowDialog() == DialogResult.OK)
                txtObjDescription.Text += @"\c0x" + ColorToHexString(colorDialog.Color) + "FF" + @"\c";
        }
    }
}
