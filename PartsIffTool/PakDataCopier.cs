using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace PartsIffTool
{
    public partial class PakDataCopier : Form
    {
        public List<KeyValuePair<string, uint>> FileNamesToCopy = new List<KeyValuePair<string, uint>>();
        private List<KeyValuePair<string, uint>> FileNamesToCopyRemove = new List<KeyValuePair<string, uint>>();

        public PartEditor parent;

        // Dictionaries for holding the filenames and paths...
        public Dictionary<string, string> source1Files = new Dictionary<string, string>();
        public Dictionary<string, string> source2Files = new Dictionary<string, string>();
        public Dictionary<string, string> source3Files = new Dictionary<string, string>();
        public Dictionary<string, string> source4Files = new Dictionary<string, string>();

        private ProgramConfiguration config;

        private int intLastColumn = 0;
        private Thread lookThread;

        public PakDataCopier()
        {
            InitializeComponent();
            FileNamesToCopy = new List<KeyValuePair<string, uint>>();

            config = ProgramConfiguration.DeserializeConfiguration();

            if (!string.IsNullOrEmpty(config.PangyaTHunpackedPath) && Directory.Exists(config.PangyaTHunpackedPath))
                txtSource1.Text = config.PangyaTHunpackedPath;
            if (!string.IsNullOrEmpty(config.PangyaUSunpackedPath) && Directory.Exists(config.PangyaUSunpackedPath))
                txtSource2.Text = config.PangyaUSunpackedPath;
            if (!string.IsNullOrEmpty(config.PangyaJPunpackedPath) && Directory.Exists(config.PangyaJPunpackedPath))
                txtSource3.Text = config.PangyaJPunpackedPath;
            if (!string.IsNullOrEmpty(config.PangyaKRunpackedPath) && Directory.Exists(config.PangyaKRunpackedPath))
                txtSource4.Text = config.PangyaKRunpackedPath;
            if (!string.IsNullOrEmpty(config.PangyaNewPakPath))
                txtNewOutput.Text = config.PangyaNewPakPath;
        }

        public void LookupAndCopyFilesDictionary(string basePath, ref Dictionary<string, string> index, bool runInitialScan)
        {
            if (index.Count == 0)
            {
                if (runInitialScan)
                {
                    if (!string.IsNullOrEmpty(basePath) && Directory.Exists(basePath))
                    {
                        // Let's save the configuration so we don't have to fill in the
                        // fields next time...
                        config.PangyaNewPakPath = txtNewOutput.Text;
                        config.PangyaTHunpackedPath = txtSource1.Text;
                        config.PangyaUSunpackedPath = txtSource2.Text;
                        config.PangyaJPunpackedPath = txtSource3.Text;
                        config.PangyaKRunpackedPath = txtSource4.Text;

                        // Moved here from LookupAndCopyFiles because of locking issues.
                        ProgramConfiguration.SerializeConfiguration(config);

                        string[] files = Directory.GetFiles(basePath,
                               "*.*", SearchOption.AllDirectories);

                        foreach (string file in files)
                        {
                            FileInfo fInfo = new FileInfo(file);

                            // Item not yet in list
                            if (!index.ContainsKey(fInfo.Name.ToLower()))
                                index.Add(fInfo.Name.ToLower(), fInfo.FullName);
                            // Item already in list but we might have a newer version here...
                            else
                                index[fInfo.Name.ToLower()] = fInfo.FullName;
                        }

                        // Call it again, dood!
                        LookupAndCopyFilesDictionary(basePath, ref index, false);
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<string, uint> fileToCopy in FileNamesToCopy)
                {
                    if (index.ContainsKey(fileToCopy.Key.ToLower()))
                    {
                        FileInfo fInfo = new FileInfo(index[fileToCopy.Key.ToLower()]);
                        string fInfoNewBase = fInfo.DirectoryName.Replace(basePath, txtNewOutput.Text);
                        DirectoryInfo fInfoDirInfo = new DirectoryInfo(fInfoNewBase);
                        CreateDirectory(fInfoDirInfo);

                        File.Copy(fInfo.FullName, fInfo.FullName.Replace(fInfo.DirectoryName, fInfoNewBase), true);

                        MethodInvoker addLogEntry = delegate()
                        {
                            foreach (ListViewItem item in lstFileNames.Items)
                            {
                                if ((string)item.Tag == fileToCopy.Key)
                                {
                                    item.ImageKey = "found";
                                    item.ForeColor = Color.DarkGreen;
                                    item.SubItems[3].Text = "Copied";

                                    // Remove entry from the list
                                    FileNamesToCopyRemove.Add(fileToCopy);
                                }
                            }
                        };

                        try
                        {
                            Invoke(addLogEntry);
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }
        }

        public void SetStatus(int statusCode)
        {
            if (statusCode == 1)
            {
                MethodInvoker lockControls = delegate()
                {
                    btnGo.Enabled = false;
                    //btnCancel.Enabled = false;

                    tabPage1.Enabled = false;

                    progressBar1.Style = ProgressBarStyle.Marquee;
                };
                Invoke(lockControls);
            }
            else
            {
                MethodInvoker unlockControls = delegate()
                {
                    lstFileNames.BeginUpdate();
                    foreach (ListViewItem item in lstFileNames.Items)
                    {
                        if (item.ImageKey != "found")
                        {
                            item.ImageKey = "nope";
                            item.ForeColor = Color.Red;
                            item.SubItems[3].Text = "Not found";
                        }
                    }
                    lstFileNames.EndUpdate();

                    progressBar1.Style = ProgressBarStyle.Blocks;

                    btnGo.Enabled = true;
                    btnCancel.Enabled = true;

                    tabPage1.Enabled = true;
                };

                try
                {
                    Invoke(unlockControls);
                }
                catch (Exception)
                {

                }
            }
        }

        public void CreateDirectory(DirectoryInfo dirInfo)
        {
            if (dirInfo.Parent != null && !dirInfo.Exists)
                CreateDirectory(dirInfo.Parent);
            if (!dirInfo.Exists)
                dirInfo.Create();
        }

        private void btnBrowseSource1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
                txtSource1.Text = fbd.SelectedPath;
        }

        private void btnBrowseSource2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
                txtSource2.Text = fbd.SelectedPath;
        }

        private void btnBrowseSource3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
                txtSource3.Text = fbd.SelectedPath;
        }

        private void btnBrowseSource4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
                txtSource4.Text = fbd.SelectedPath;
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
                txtNewOutput.Text = fbd.SelectedPath;
        }

        private void PakDataCopier_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, uint> item in FileNamesToCopy)
            {
                ListViewItem tmpItem = new ListViewItem();
                tmpItem.Tag = item.Key;
                tmpItem.ImageKey = "pending";
                tmpItem.SubItems.Add(item.Key);
                tmpItem.SubItems.Add(item.Value.ToString());
                tmpItem.SubItems.Add("Pending");
                lstFileNames.Items.Add(tmpItem);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DirectoryInfo finalDir = new DirectoryInfo(txtNewOutput.Text);
            CreateDirectory(finalDir);


            lookThread = new Thread(delegate()
            {
                try
                {
                    SetStatus(1);

                    LookupAndCopyFilesDictionary(txtSource1.Text, ref source1Files, true);
                    LookupAndCopyFilesDictionary(txtSource2.Text, ref source2Files, true);
                    LookupAndCopyFilesDictionary(txtSource3.Text, ref source3Files, true);
                    LookupAndCopyFilesDictionary(txtSource4.Text, ref source4Files, true);

                    // Now send back the new index to the calling Part editor window
                    foreach (KeyValuePair<string, uint> item in FileNamesToCopyRemove)
                    {
                        FileNamesToCopy.Remove(item);
                    }

                    SetStatus(0);
                }
                catch (Exception)
                {

                }
                finally
                {
                    SetStatus(0);
                }
            });

            lookThread.Start();
        }

        private void copyFilenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;

            foreach (ListViewItem item in lstFileNames.SelectedItems)
            {
                sb.Append(item.SubItems[1].Text);

                if (i >= 1)
                    sb.Append("\r\n");

                i++;
            }

            Clipboard.SetText(sb.ToString());
        }

        private void copyTypeIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;

            foreach (ListViewItem item in lstFileNames.SelectedItems)
            {
                sb.Append(item.SubItems[2].Text);

                if (i >= 1)
                    sb.Append("\r\n");

                i++;
            }

            Clipboard.SetText(sb.ToString());
        }

        private void copyFilenameAndTypeIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;

            foreach (ListViewItem item in lstFileNames.SelectedItems)
            {
                sb.Append(item.SubItems[2].Text + "\t" + item.SubItems[3].Text);

                if (i >= 1)
                    sb.Append("\r\n");

                i++;
            }

            Clipboard.SetText(sb.ToString());

        }

        private void lstFileNames_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // TODO: Throws exception when sorting while content changes
            try
            {
                Cursor = Cursors.WaitCursor;

                if (e.Column != intLastColumn)
                {
                    lstFileNames.Sorting = SortOrder.Descending;
                    intLastColumn = e.Column;
                }
                else
                {
                    if (lstFileNames.Sorting == SortOrder.Ascending)
                        lstFileNames.Sorting = SortOrder.Descending;
                    else
                        lstFileNames.Sorting = SortOrder.Ascending;

                    lstFileNames.Sort();
                    lstFileNames.ListViewItemSorter = new ColumnsSorter(e.Column, lstFileNames.Sorting);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void CloseCopierWindow()
        {
            try
            {
                if (parent != null)
                    parent.ClearModelQueue();

                // Close only when thread not alive
                if (lookThread == null || !lookThread.IsAlive)
                    Close();

                // ...otherwise just abort the thread and give a message.
                if (lookThread != null && lookThread.IsAlive)
                {
                    lookThread.Abort();
                    MessageBox.Show("Operation canceled by user.", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseCopierWindow();
        }
    }
}
