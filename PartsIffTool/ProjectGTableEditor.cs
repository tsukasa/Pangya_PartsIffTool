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
    public partial class ProjectGTableEditor : Form
    {
        public ProjectGTableEditor()
        {
            InitializeComponent();
        }

        private int FindInByteArray(byte[] Haystack, byte[] Needle)
        {
            int lFoundPosition = -1;
            int lMayHaveFoundIt = -1;
            int lMiniCounter = 0;

            for (int lCounter = 0; lCounter < Haystack.Length; lCounter++)
            {
                if (Haystack[lCounter] == Needle[lMiniCounter])
                {
                    if (lMiniCounter == 0)
                        lMayHaveFoundIt = lCounter;
                    if (lMiniCounter == Needle.Length - 1)
                    {
                        return lMayHaveFoundIt;
                    }
                    lMiniCounter++;
                }
                else
                {
                    lMayHaveFoundIt = -1;
                    lMiniCounter = 0;
                }
            }

            return lFoundPosition;
        }

        private int FindStringBeginEnd(int Handicap, bool GoForward)
        {
            int realHandicap = Handicap;
            if (!GoForward)
                realHandicap = (realHandicap * -1);

            return 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BinaryReader reader = new BinaryReader(File.Open(@"C:\NtreevSoft\PangYa_Th - Kopie\ProjectP.exe", FileMode.Open, FileAccess.ReadWrite));

            byte[] contents = reader.ReadBytes((int)reader.BaseStream.Length);

            textBox1.Text += FindInByteArray(contents, Encoding.ASCII.GetBytes("card_remove\0FrSupplyPackDlg"));
        }
    }
}
