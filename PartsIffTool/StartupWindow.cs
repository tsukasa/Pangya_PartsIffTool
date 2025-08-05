using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeKing.Native;

namespace PartsIffTool
{
    public partial class StartupWindow : Form
    {
        public StartupWindow()
        {
            InitializeComponent();
        }

        private void StartupWindow_Load(object sender, EventArgs e)
        {
            Left = Screen.PrimaryScreen.WorkingArea.Width - (Width + 5);
            Top = Screen.PrimaryScreen.WorkingArea.Height - (Height + 5);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPartEditor_Click(object sender, EventArgs e)
        {
            PartEditor part = new PartEditor();
            part.Show();
        }

        private void btnClubSetEditor_Click(object sender, EventArgs e)
        {
            ClubSetEditor club = new ClubSetEditor();
            club.Show();
        }

        private void btnDescEditor_Click(object sender, EventArgs e)
        {
            DescEditor desc = new DescEditor();
            desc.Show();
        }

        private void btnSkinEditor_Click(object sender, EventArgs e)
        {
            SkinEditor skin = new SkinEditor();
            skin.Show();
        }

        private void btnShitListEditor_Click(object sender, EventArgs e)
        {
            DatEditor dat = new DatEditor();
            dat.Show();
        }

        private void btnGenericDumper_Click(object sender, EventArgs e)
        {
            GenericDumper dumper = new GenericDumper();
            dumper.Show();
        }

        private void btnCardEditor_Click(object sender, EventArgs e)
        {
            CardEditor card = new CardEditor();
            card.Show();
        }

        private void btnThailandEditor_Click(object sender, EventArgs e)
        {
            StringTableEditor stringTableEditor = new StringTableEditor();
            stringTableEditor.Show();
        }

        private void btnProjectGTable_Click(object sender, EventArgs e)
        {
            ProjectGTableEditor projectGTableEditor = new ProjectGTableEditor();
            projectGTableEditor.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }
    }
}
