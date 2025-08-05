using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PartsIffTool
{
    public partial class IffDoctor : Form
    {
        public IffDoctor()
        {
            InitializeComponent();
        }

        private void tsbOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Pangya IFF File";
            ofd.Filter = "Pangya IFF Files|*.iff";

            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                BinaryReader reader = new BinaryReader(File.OpenRead(ofd.FileName));

                UInt16 recordsOfIndex = reader.ReadUInt16();
                UInt16 revisionOfFile = reader.ReadUInt16();
                UInt16 magicNumber = reader.ReadUInt16();

                reader.BaseStream.Seek(2, SeekOrigin.Current);

                txtIndexRecords.Text = recordsOfIndex.ToString();
                txtRevision.Text = revisionOfFile.ToString();
                txtMagicNumber.Text = magicNumber.ToString();
            }
        }
    }
}
