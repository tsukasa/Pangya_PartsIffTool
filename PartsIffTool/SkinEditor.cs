using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PartsIffTool
{
    public partial class SkinEditor : Form
    {
        private enum eEditType
        {
            SKIN = 0,
            CUTIN = 1,
        }

        public List<SkinRecord> skinList;
        public List<SetItemRecord> cutinList;

        private int selectMode = 0;
        private eEditType onEdit = new eEditType();

        private List<SkinRecord> _skin_Parent;
        private SkinRecord itemOnEdit;

        private List<SetItemRecord> _cutin_Parent;
        private SetItemRecord setOnEdit;

        public SkinEditor()
        {
            InitializeComponent();
        }

        private void tbsOpenSkinIff_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pangya IFF File (*.iff)|*.iff";
            ofd.Title = "Open IFF File";
            DialogResult ofdResult = ofd.ShowDialog();

            if (ofdResult == DialogResult.OK)
            {
                DirectoryInfo diParts = Directory.GetParent(ofd.FileName);
                string setIffPath = diParts.FullName + "\\CutinInfomation.iff";

                if (File.Exists(setIffPath))
                {
                    this.Enabled = false;
                    Thread loadPartsThread = new Thread(delegate()
                    {
                        skinList = SkinRecord.LoadSkinFile(ofd.FileName);
                        //setList = SetItemRecord.LoadSetItemFile(setIffPath);

                        MethodInvoker addItemsToGui = delegate()
                        {
                            lstParts.BeginUpdate();
                            Text = String.Format("Pangya Skin Editor [{0}] ({1} items loaded)", ofd.FileName, skinList.Count);

                            lstParts.Items.Clear();
                            lstSets.Items.Clear();

                            foreach (SkinRecord s in skinList)
                            {
                                ListViewItem tmpLItem = new ListViewItem(s.Base.Name);
                                tmpLItem.Tag = s.Base.TypeId;
                                lstParts.Items.Add(tmpLItem);
                            }

                            /*
                            foreach (SetItemRecord s in setList)
                            {
                                ListViewItem tmpLItem = new ListViewItem(s.Base.Name);
                                tmpLItem.Tag = s.Base.TypeId;
                                lstSets.Items.Add(tmpLItem);
                            }*/

                            lstParts.EndUpdate();
                            this.Enabled = true;
                        };

                        Invoke(addItemsToGui);
                    });
                    loadPartsThread.Start();
                }
                else
                {
                    MessageBox.Show("CutinInfomation.iff not found in the same directory, aborting!", "CutinInfomation.iff not found.",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
