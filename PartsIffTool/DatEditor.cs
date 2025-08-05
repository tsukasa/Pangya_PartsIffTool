using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;

namespace PartsIffTool
{
    public partial class DatEditor : Form
    {
        public DatEditor()
        {
            InitializeComponent();
            shitList = new List<string>();
            cmbTypeChooser.SelectedIndex = 0;
        }

        private string thisFileContents = string.Empty;

        private int recordLen = 30;
        private int prefixLen = 4;

        private List<string> shitList = new List<string>();

        private void ShiftBytes(ref byte[] obytes)
        {
            for (int i = 0; i < obytes.Length; i++)
            {
                obytes[i] = (byte)(255 - obytes[i]);
            }
        }

        private void ShiftBytes(string fileName)
        {
            /* Open the file, read it in... */
            BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read));

            byte[] dataBytes = new byte[reader.BaseStream.Length];

            for (int i = 0; i < reader.BaseStream.Length; i++)
            {
                dataBytes[i] = reader.ReadByte();
            }

            reader.Close();

            /* Shift the bytes to encrypt or decrypt it... */
            ShiftBytes(ref dataBytes);

            /* ...and write the results back into the file */
            BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create, FileAccess.Write));

            foreach (Byte b in dataBytes)
            {
                writer.Write(b);
            }

            writer.Close();
        }

        private void SetContentType()
        {
            if (cmbTypeChooser.SelectedIndex == 0)
            {
                recordLen = 30;
                prefixLen = 4;
            }
            else if (cmbTypeChooser.SelectedIndex == 1)
            {
                recordLen = 31;
                prefixLen = 5;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Shitlist";
            ofd.Filter = "Pangya Shitlists (nick.bin, chat.bin)|*.bin";
            DialogResult dialogResult = ofd.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                if (ZipFile.IsZipFile(ofd.FileName))
                {
                    thisFileContents = Path.GetTempFileName();
                    bool unpackedProperly = false;

                    /* Yeah, this is kind of clunky, but who gives a damn? */
                    using (ZipFile zip = ZipFile.Read(ofd.FileName))
                    {
                        if (File.Exists(thisFileContents))
                            File.Delete(thisFileContents);

                        zip.ExtractSelectedEntries("contents.dat", null, Path.GetTempPath(), ExtractExistingFileAction.OverwriteSilently);

                        if (File.Exists(Path.GetTempPath() + @"\contents.dat"))
                        {
                            File.Move(Path.GetTempPath() + @"\contents.dat", thisFileContents);
                            unpackedProperly = true;
                        }
                    }

                    if (unpackedProperly)
                    {
                        SetContentType();

                        shitList = new List<string>();
                        BinaryReader reader = new BinaryReader(File.Open(thisFileContents, FileMode.Open, FileAccess.Read));

                        byte[] dataBytes = new byte[reader.BaseStream.Length];

                        for (int i = 0; i < reader.BaseStream.Length; i++)
                        {
                            dataBytes[i] = reader.ReadByte();
                        }

                        reader.Close();

                        ShiftBytes(ref dataBytes);

                        int counter = 0;
                        for (int i = prefixLen; i < dataBytes.Length; i += recordLen)
                        {
                            string shitword = IffFile.FileEncoding(IffFile.IFF_REGION.Default).GetString(dataBytes, i, recordLen - 1);

                            shitList.Add(shitword);
                            counter++;
                        }

                        UpdateWordList();
                        Text = String.Format("Pangya $%*§ Editor [{0}] ({1} words)", ofd.FileName, counter.ToString());
                    }
                }
            }
        }

        private void UpdateWordList()
        {
            lstWords.Items.Clear();

            foreach (string word in shitList)
            {
                lstWords.Items.Add(word);
            }
        }

        private void lstWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstWords.SelectedItems.Count > 0)
            {
                txtWord.Text = lstWords.SelectedItems[0].Text;
            }
        }

        private void btnDeleteWord_Click(object sender, EventArgs e)
        {
            if (lstWords.SelectedItems.Count > 0)
            {
                shitList.Remove(lstWords.SelectedItems[0].Text);
                txtWord.Text = string.Empty;
                UpdateWordList();
            }
        }

        private void btnAddNewWord_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtWord.Text))
            {
                shitList.Add(txtWord.Text);
                txtWord.Text = string.Empty;
                UpdateWordList();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            shitList = new List<string>();
            UpdateWordList();
        }

        private void txtWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddNewWord.PerformClick();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Shitlist";
            sfd.Filter = "Pangya Shitlists (nick.bin, chat.bin)|*.bin";
            DialogResult result = sfd.ShowDialog();

            if (result == DialogResult.OK)
            {
                SetContentType();

                string tempFileName = Path.GetTempFileName();

                if (File.Exists(tempFileName))
                    File.Delete(tempFileName);

                byte[] buffer = new byte[(shitList.Count * recordLen) + prefixLen];
                using (BinaryWriter writer = new BinaryWriter(File.Open(tempFileName, FileMode.Create, FileAccess.Write), IffFile.FileEncoding(IffFile.IFF_REGION.Default)))
                {
                    writer.Write(buffer);

                    writer.Seek(0, SeekOrigin.Begin);
                    UInt16 numberOfWords = UInt16.Parse(shitList.Count.ToString());
                    writer.Write(numberOfWords);

                    // Seek to the first record...
                    writer.Seek(prefixLen, SeekOrigin.Begin);

                    foreach (string word in shitList)
                    {
                        if (word.Length >= recordLen)
                            word.Substring(0, recordLen - 1);
                        writer.Write(word.ToCharArray());
                        writer.Seek(recordLen - word.Length, SeekOrigin.Current);
                    }
                }

                ShiftBytes(tempFileName);

                using (ZipFile zip = new ZipFile(sfd.FileName))
                {
                    string nameForFileInZip = Path.GetTempPath() + @"\contents.dat";
                    if (File.Exists(nameForFileInZip))
                        File.Delete(nameForFileInZip);
                    File.Move(tempFileName, nameForFileInZip);

                    zip.AddFile(nameForFileInZip, string.Empty);

                    zip.Save();

                    File.Delete(nameForFileInZip);
                }

                MessageBox.Show("File written", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void picHorizBadge_Paint(object sender, PaintEventArgs e)
        {
            string strActionTitle = "Pangya $%*§ Editor";

            Rectangle baseRectangle = new Rectangle(0, 0, picHorizBadge.Width, picHorizBadge.Height);
            Brush gradientBrush = new LinearGradientBrush(baseRectangle, SystemColors.ControlDarkDark,
                                                          SystemColors.Control, LinearGradientMode.Horizontal);

            e.Graphics.FillRectangle(gradientBrush, baseRectangle);

            e.Graphics.DrawString(strActionTitle, new Font(SystemFonts.DialogFont.FontFamily, 16, FontStyle.Bold),
                                  new SolidBrush(SystemColors.ControlText), 6, 6);
            e.Graphics.DrawString(strActionTitle, new Font(SystemFonts.DialogFont.FontFamily, 16, FontStyle.Bold),
                                  new SolidBrush(SystemColors.ControlLightLight), 5, 5);
        }

        private void DatEditor_Resize(object sender, EventArgs e)
        {
            picHorizBadge.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BinaryReader reader = new BinaryReader(File.Open(@"C:\Users\Tsukasa\Desktop\nu\data\pangya_th.iff", FileMode.Open, FileAccess.Read));

            byte[] dataBytes = new byte[reader.BaseStream.Length];

            for (int i = 0; i < reader.BaseStream.Length; i++)
            {
                dataBytes[i] = reader.ReadByte();
            }

            reader.Close();

            ShiftBytes(ref dataBytes);

            using (BinaryWriter writer = new BinaryWriter(File.Open(@"C:\USers\Tsukasa\Desktop\nu\data\pangya_th.zip", FileMode.Create, FileAccess.Write), IffFile.FileEncoding(IffFile.IFF_REGION.Default)))
            {
                writer.Write(dataBytes);
            }
        }
    }
}
