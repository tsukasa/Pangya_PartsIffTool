using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PartsIffTool
{
    public partial class CardEditor : Form
    {
        public List<CardRecord> cardList;

        private List<CardRecord> _card_Parent;
        private CardRecord itemOnEdit;

        public CardEditor()
        {
            InitializeComponent();
            InitEditor();

            cardList = new List<CardRecord>();
            cmbFilterBy.SelectedIndex = 0;
        }

        private void InitEditor()
        {
            foreach (CardRecord.eCardRareType rareType in Enum.GetValues(typeof(CardRecord.eCardRareType)))
            {
                cmbRareType.Items.Add(rareType);
            }

            if (cmbRareType.Items.Count > 0)
                cmbRareType.SelectedIndex = 0;
        }

        private void LoadCardDetailFromCardList(uint index)
        {
            var selectedItem = from u in cardList
                               where u.Base.TypeId == index
                               select u;

            foreach (CardRecord recordToDisplay in selectedItem)
            {
                if (recordToDisplay != null)
                {
                    itemOnEdit = recordToDisplay;

                    txtItemName.Text = recordToDisplay.Base.Name;
                    txtItemId.Text = recordToDisplay.Base.TypeId.ToString();

                    txtItemIcon.Text = recordToDisplay.Base.Icon;
                    txtCardImage.Text = recordToDisplay.Image;
                    txtCardBuffImage.Text = recordToDisplay.BuffImg;
                    txtCardSlotImage.Text = recordToDisplay.SlotImg;
                    txtCardSubIcon.Text = recordToDisplay.SubIcon;

                    cmbRareType.SelectedIndex = (int)recordToDisplay.RareTypeRaw;

                    cmbEffect.Text = recordToDisplay.Ability.ToString();
                    txtEffectValue.Text = recordToDisplay.AbilityValue.ToString();
                    txtEffectDuration.Text = recordToDisplay.UseTime.ToString();

                    txtCardNo.Text = recordToDisplay.CardIndex.ToString();
                    txtCardVolume.Text = recordToDisplay.Volume.ToString();

                    txtItemPowerSlot.Text = recordToDisplay.Power.ToString();
                    txtItemControlSlot.Text = recordToDisplay.Control.ToString();
                    txtItemImpactSlot.Text = recordToDisplay.Impact.ToString();
                    txtItemCurveSlot.Text = recordToDisplay.Curve.ToString();
                    txtItemSpinSlot.Text = recordToDisplay.Spin.ToString();

                    chkItemActive.Checked = Convert.ToBoolean(recordToDisplay.Base.Final);
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pangya IFF File (*.iff)|*.iff";
            ofd.Title = "Open IFF File";
            DialogResult ofdResult = ofd.ShowDialog();

            if (ofdResult == DialogResult.OK)
            {
                cardList = CardRecord.LoadCardFile(ofd.FileName);
                lstParts.Items.Clear();

                Text = String.Format("Pangya Card Editor [{0}] ({1} items loaded)", ofd.FileName, cardList.Count);

                foreach (CardRecord p in cardList)
                {
                    ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                    tmpLItem.Tag = p.Base.TypeId;
                    lstParts.Items.Add(tmpLItem);
                }
            }
        }

        private void lstParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstParts.SelectedIndices.Count > 0)
            {
                ListViewItem tmpItem = (ListViewItem)lstParts.SelectedItems[0];
                LoadCardDetailFromCardList((uint)tmpItem.Tag);
            }
        }

        private bool UpdateItem(CardRecord item)
        {
            if (item != null)
            {


                return true;
            }
            return false;
        }

        private void btnApplyItemChange_Click(object sender, EventArgs e)
        {
            if (UpdateItem(itemOnEdit))
                lstParts.SelectedItems[0].Text = itemOnEdit.Base.Name;
        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            lstParts.Items.Clear();

            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                foreach (CardRecord p in cardList)
                {
                    Wildcard wildcard = new Wildcard(txtFilter.Text, RegexOptions.IgnoreCase);
                    if (cmbFilterBy.SelectedIndex == 0)
                    {
                        if (wildcard.IsMatch(p.Base.Name))
                        {
                            ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                            tmpLItem.Tag = p.Base.TypeId;
                            lstParts.Items.Add(tmpLItem);
                        }
                    }
                    else if (cmbFilterBy.SelectedIndex == 1)
                    {
                        if (wildcard.IsMatch(p.Base.TypeId.ToString()))
                        {
                            ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                            tmpLItem.Tag = p.Base.TypeId;
                            lstParts.Items.Add(tmpLItem);
                        }
                    }
                }
            }
            else
            {
                foreach (CardRecord p in cardList)
                {
                    ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                    tmpLItem.Tag = p.Base.TypeId;
                    lstParts.Items.Add(tmpLItem);
                }
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnFilter.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Pangya IFF File";
            sfd.Filter = "Pangya IFF File (*.iff)|*.iff";

            DialogResult sfdResult = sfd.ShowDialog();

            if (sfdResult == DialogResult.OK)
            {
                bool success = CardRecord.SaveCardFile(sfd.FileName, cardList);

                if (success)
                    MessageBox.Show("File written!", "Eureka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGenerateSql_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save SQL Query";
            sfd.Filter = "SQL Queries (*.sql)|*.sql";
            DialogResult sfdResult = sfd.ShowDialog();

            if (sfdResult == DialogResult.OK)
            {
                //CardRecord.GenerateSqlFile(cardList, sfd.FileName);
                MessageBox.Show("File written!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
