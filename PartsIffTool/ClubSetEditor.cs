using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using PartsIffTool.Properties;

namespace PartsIffTool
{
    public partial class ClubSetEditor : Form
    {
        private enum eEditType
        {
            CLUBSET = 0,
            CLUB = 1,
        }

        public List<ClubSetRecord> clubsetList;
        public List<ClubRecord> clubList;

        private eEditType onEdit = new eEditType();

        private List<ClubSetRecord> _clubset_Parent;
        private List<ClubRecord> _club_Parent;
        private ClubSetRecord itemOnEdit;
        private ClubRecord clubOnEdit;

        public ClubSetEditor()
        {
            InitializeComponent();

            InitEditor();

            clubsetList = new List<ClubSetRecord>();
            clubList = new List<ClubRecord>();
        }

        public ClubSetEditor(List<ClubSetRecord> itemRecordList, List<ClubRecord> clubRecordList)
        {
            InitializeComponent();
            InitEditor();

            _clubset_Parent = itemRecordList;
            _club_Parent = clubRecordList;
        }

        public void InitEditor()
        {
            onEdit = eEditType.CLUBSET;

            clubsetList = new List<ClubSetRecord>();
            //_texModelsToCopy = new List<KeyValuePair<string, uint>>();

            cmbFilterBy.SelectedIndex = 0;

            InitOutputRegionList();
        }

        public void InitOutputRegionList()
        {
            foreach (IffFile.IFF_REGION region in Enum.GetValues(typeof(IffFile.IFF_REGION)))
            {
                cmbOutputRegion.Items.Add(region);
            }

            if (cmbOutputRegion.Items.Count > 0)
                cmbOutputRegion.SelectedIndex = 0;
        }

        private void GetItemCommonProperties(IffItemCommon item)
        {
            if (item != null)
            {
                // --- Basic Properties ---
                #region Basic Properties
                txtItemName.Text = item.Name;
                txtItemId.Text = item.TypeId.ToString();
                txtItemIcon.Text = item.Icon.ToString();

                if (item.Final == 0)
                    chkItemActive.Checked = false;
                else
                    chkItemActive.Checked = true;

                GetTypeIdValues(item);

                if (item.IsMaximumLevel)
                    rbMaxLevel.Checked = true;
                else
                    rbMinLevel.Checked = true;

                cmbItemMinLevel.SelectedIndex = item.Level;
                #endregion
                // --- /Basic Properties ---

                // --- Shop Properties ---
                #region Shop Properties
                txtItemCost.Text = item.Price.ToString();
                txtItemStallPrice.Text = item.SalePrice.ToString();
                txtItemUsedPrice.Text = item.UsedPrice.ToString();

                chkItemIsHot.Checked = item.IsHot;
                chkItemIsNew.Checked = item.IsNew;
                chkItemIsInStock.Checked = item.IsInStock;
                chkItemIsReserve.Checked = item.IsReserve;

                // Item costs Pang
                if (item.MoneyType == 0x02)
                {
                    rbItemCostsPang.Checked = true;
                    rbItemCostsCookies.Checked = false;
                    rbItemCostsSpecial.Checked = false;
                }
                // Item costs Cookies
                else if (item.MoneyType == 0x01)
                {
                    rbItemCostsCookies.Checked = true;
                    rbItemCostsPang.Checked = false;
                    rbItemCostsSpecial.Checked = false;
                }
                // Special/Event item
                else if (item.MoneyType == 0x00)
                {
                    rbItemCostsSpecial.Checked = true;
                    rbItemCostsCookies.Checked = false;
                    rbItemCostsPang.Checked = false;
                }

                if (item.SaleEnd.wYear != 0 && item.SaleEnd.wDay != 0)
                {
                    chkSaleEnd.Checked = true;
                    dateSaleEnd.Value = new DateTime(item.SaleEnd.wYear,
                                                         item.SaleEnd.wMonth,
                                                         item.SaleEnd.wDay,
                                                         item.SaleEnd.wHour,
                                                         item.SaleEnd.wMinute,
                                                         item.SaleEnd.wSecond,
                                                         item.SaleEnd.wMilliseconds);
                }
                else
                {
                    chkSaleEnd.Checked = false;
                    dateSaleEnd.Value = DateTime.Now.AddDays(10);
                }

                if (item.SaleStart.wYear != 0 && item.SaleStart.wDay != 0)
                {
                    chkSaleStart.Checked = true;
                    dateSaleStart.Value = new DateTime(item.SaleStart.wYear,
                                                         item.SaleStart.wMonth,
                                                         item.SaleStart.wDay,
                                                         item.SaleStart.wHour,
                                                         item.SaleStart.wMinute,
                                                         item.SaleStart.wSecond,
                                                         item.SaleStart.wMilliseconds);
                }
                else
                {
                    chkSaleStart.Checked = false;
                    dateSaleStart.Value = DateTime.Now;
                }
                #endregion
                // --- /Shop Properties ---
            }
        }

        private void SetItemCommonProperties(IffItemCommon item)
        {
            if (item != null)
            {
                if (chkItemActive.Checked)
                    item.Final = 1;
                else
                    item.Final = 0;

                item.Name = txtItemName.Text;
                item.TypeId = UInt32.Parse(txtItemId.Text);
                item.Icon = txtItemIcon.Text;
                item.Level = byte.Parse(cmbItemMinLevel.SelectedIndex.ToString());

                if (rbMaxLevel.Checked)
                    item.IsMaximumLevel = true;
                else
                    item.IsMaximumLevel = false;


                item.Price = UInt32.Parse(txtItemCost.Text);
                item.SalePrice = UInt32.Parse(txtItemStallPrice.Text);
                item.UsedPrice = UInt32.Parse(txtItemUsedPrice.Text);

                if (rbItemCostsCookies.Checked)
                {
                    item.MoneyType = 0x01;
                    item.IsCash = true;
                    item.IsCashSpecial = false;
                }
                if (rbItemCostsPang.Checked)
                {
                    item.MoneyType = 0x02;
                    item.IsCash = false;
                    item.IsCashSpecial = false;
                }
                if (rbItemCostsSpecial.Checked)
                {
                    item.MoneyType = 0x00;
                    item.IsCash = false;
                    item.IsCashSpecial = true;
                }

                item.IsInStock = chkItemIsInStock.Checked;
                item.IsReserve = chkItemIsReserve.Checked;
                item.IsHot = chkItemIsHot.Checked;
                item.IsNew = chkItemIsNew.Checked;

                // Only write back dates if they've been set
                IffCommonMethods.SetSystemTimeValue(ref item.SaleStart, dateSaleStart.Value, chkSaleStart.Checked);
                IffCommonMethods.SetSystemTimeValue(ref item.SaleEnd, dateSaleEnd.Value, chkSaleEnd.Checked);
            }
        }

        private bool UpdateClub(ClubRecord item)
        {
            if (item != null)
            {
                SetItemCommonProperties(item.Base);

                item.Type = (ClubRecord.eClubType)cmbClubType.SelectedIndex;

                item.Power = UInt16.Parse(txtItemPower.Text);
                item.Control = UInt16.Parse(txtItemControl.Text);
                item.Impact = UInt16.Parse(txtItemImpact.Text);
                item.Spin = UInt16.Parse(txtItemSpin.Text);
                item.Curve = UInt16.Parse(txtItemCurve.Text);

                item.Model = txtItemModel.Text;

                // Special set, SetItemCommonProperties doesn't do that.
                item.Base.Icon = txtItemTex.Text;

                return true;
            }
            return false;
        }

        private bool UpdateItem(ClubSetRecord item)
        {
            if (item != null)
            {
                SetItemCommonProperties(item.Base);

                ClubRecord tmpClubWood = cmbClubSetWood.SelectedItem as ClubRecord;
                ClubRecord tmpClubIron = cmbClubSetIron.SelectedItem as ClubRecord;
                ClubRecord tmpClubWedge = cmbClubSetWedge.SelectedItem as ClubRecord;
                ClubRecord tmpClubPutter = cmbClubSetPutter.SelectedItem as ClubRecord;
                item.ClubIds.Wood = tmpClubWood.Base.TypeId;
                item.ClubIds.Iron = tmpClubIron.Base.TypeId;
                item.ClubIds.Wedge = tmpClubWedge.Base.TypeId;
                item.ClubIds.Putter = tmpClubPutter.Base.TypeId;

                int powerSlot = int.Parse(txtItemPower.Text) + int.Parse(txtItemPowerSlot.Text);
                item.Power = UInt16.Parse(txtItemPower.Text);
                item.PowerSlot = UInt16.Parse(powerSlot.ToString());

                int controlSlot = int.Parse(txtItemControl.Text) + int.Parse(txtItemControlSlot.Text);
                item.Control = UInt16.Parse(txtItemControl.Text);
                item.ControlSlot = UInt16.Parse(controlSlot.ToString());

                int impactSlot = int.Parse(txtItemImpact.Text) + int.Parse(txtItemImpactSlot.Text);
                item.Impact = UInt16.Parse(txtItemImpact.Text);
                item.ImpactSlot = UInt16.Parse(impactSlot.ToString());

                int spinSlot = int.Parse(txtItemSpin.Text) + int.Parse(txtItemSpinSlot.Text);
                item.Spin = UInt16.Parse(txtItemSpin.Text);
                item.SpinSlot = UInt16.Parse(spinSlot.ToString());

                int curveSlot = int.Parse(txtItemCurve.Text) + int.Parse(txtItemCurveSlot.Text);
                item.Curve = UInt16.Parse(txtItemCurve.Text);
                item.CurveSlot = UInt16.Parse(curveSlot.ToString());

                return true;
            }
            return false;
        }

        private void CheckEncyclopediaImage(Image imageToSet, string iconname, string type)
        {
            Thread GrabThread = new Thread(delegate()
            {
                Image img = Properties.Resources.item_no_preview;

                MethodInvoker setLoadImage = new MethodInvoker(delegate()
                {
                    picItemIcon.Image =
                        Properties.Resources.ajax_loader;
                });
                Invoke(setLoadImage);

                try
                {
                    WebClient client = new WebClient();
                    string encodedImageName = System.Web.HttpUtility.UrlEncode(iconname.Replace("\0", "").Replace("#", "~"));
                    string imageUrl = String.Format("http://pyp.tsukasa.eu/encyclopedia/api/geticon/{1}/{0}.png", encodedImageName, type);
                    Stream stream = client.OpenRead(imageUrl);
                    img = Image.FromStream(stream);
                    stream.Flush();
                    stream.Close();
                }
                catch (Exception)
                {
                    picItemIcon.Image = Properties.Resources.item_no_preview;
                }

                MethodInvoker setImage = new MethodInvoker(delegate()
                {
                    picItemIcon.Image = img;
                });
                Invoke(setImage);
            });
            GrabThread.Start();
        }

        private void ShowHideEditTypeSpecificItems()
        {
            if (onEdit == eEditType.CLUBSET)
            {
                panelClubSetClubs.Visible = true;
                panelClubType.Visible = false;
                panelClubSetIcon.Visible = true;

                if (!tabProperties.TabPages.Contains(tabShopProperties))
                    tabProperties.TabPages.Insert(1, tabShopProperties);

                if (tabProperties.TabPages.Contains(tabModelProperties))
                    tabProperties.TabPages.Remove(tabModelProperties);
            }
            else
            {
                panelClubSetClubs.Visible = false;
                panelClubType.Visible = true;
                panelClubSetIcon.Visible = false;

                if (!tabProperties.TabPages.Contains(tabModelProperties))
                    tabProperties.TabPages.Insert(3, tabModelProperties);

                if (tabProperties.TabPages.Contains(tabShopProperties))
                    tabProperties.TabPages.Remove(tabShopProperties);
            }
        }

        private void GetTypeIdValues(IffItemCommon recordToDisplay)
        {
            txtItemType.Text = recordToDisplay.TypeIdValues.Type.ToString();

            txtItemPos.Text = (recordToDisplay.TypeIdValues.Pos).ToString();
            txtItemSerial.Text = (recordToDisplay.TypeIdValues.Serial).ToString();
        }

        private void LoadDetailFromClubSetList(uint index)
        {
            var selectedItem = from u in clubsetList
                               where u.Base.TypeId == index
                               select u;

            foreach (ClubSetRecord recordToDisplay in selectedItem)
            {
                if (recordToDisplay != null)
                {
                    itemOnEdit = recordToDisplay;
                    onEdit = eEditType.CLUBSET;

                    ShowHideEditTypeSpecificItems();
                    lblRecordRegion.Text = "Region/MagicNum: " + recordToDisplay.Base.Region;

                    GetItemCommonProperties(recordToDisplay.Base);

                    GetTypeIdValues(recordToDisplay.Base);

                    CheckEncyclopediaImage(picItemIcon.Image, recordToDisplay.Base.Icon, "clubset");

                    // --- Get all available clubs of a certain type ---
                    var linq_ClubSet_Wood = (from w in clubList
                                             where w.Type == ClubRecord.eClubType.WOOD
                                             select w).ToList<ClubRecord>();

                    var linq_ClubSet_Iron = (from w in clubList
                                             where w.Type == ClubRecord.eClubType.IRON
                                             select w).ToList<ClubRecord>();

                    var linq_ClubSet_Wedge = (from w in clubList
                                              where w.Type == ClubRecord.eClubType.WEDGE
                                              select w).ToList<ClubRecord>();

                    var linq_ClubSet_Putter = (from w in clubList
                                               where w.Type == ClubRecord.eClubType.PUTTER
                                               select w).ToList<ClubRecord>();

                    // Fill the clublist for Woods
                    cmbClubSetWood.DataSource = linq_ClubSet_Wood;
                    var set_ClubSet_Wood = from s in linq_ClubSet_Wood
                                           where s.Base.TypeId == itemOnEdit.ClubIds.Wood
                                           select s;
                    if (set_ClubSet_Wood.Count() > 0)
                        cmbClubSetWood.SelectedItem = set_ClubSet_Wood.First();

                    // Fill the clublist for Irons
                    cmbClubSetIron.DataSource = linq_ClubSet_Iron;
                    var set_ClubSet_Iron = from s in linq_ClubSet_Iron
                                           where s.Base.TypeId == itemOnEdit.ClubIds.Iron
                                           select s;
                    if (set_ClubSet_Iron.Count() > 0)
                        cmbClubSetIron.SelectedItem = set_ClubSet_Iron.First();

                    // Fill the clublist for Wedges
                    cmbClubSetWedge.DataSource = linq_ClubSet_Wedge;
                    var set_ClubSet_Wedge = from s in linq_ClubSet_Wedge
                                            where s.Base.TypeId == itemOnEdit.ClubIds.Wedge
                                            select s;
                    if (set_ClubSet_Wedge.Count() > 0)
                        cmbClubSetWedge.SelectedItem = set_ClubSet_Wedge.First();

                    // Fill the clublist for Putters
                    cmbClubSetPutter.DataSource = linq_ClubSet_Putter;
                    var set_ClubSet_Putter = from s in linq_ClubSet_Putter
                                             where s.Base.TypeId == itemOnEdit.ClubIds.Putter
                                             select s;
                    if (set_ClubSet_Putter.Count() > 0)
                        cmbClubSetPutter.SelectedItem = set_ClubSet_Putter.First();

                    txtItemPower.Text = recordToDisplay.Power.ToString();
                    txtItemCurve.Text = recordToDisplay.Curve.ToString();
                    txtItemSpin.Text = recordToDisplay.Spin.ToString();
                    txtItemControl.Text = recordToDisplay.Control.ToString();
                    txtItemImpact.Text = recordToDisplay.Impact.ToString();

                    txtItemPowerSlot.Text = (recordToDisplay.PowerSlot - recordToDisplay.Power).ToString();
                    txtItemCurveSlot.Text = (recordToDisplay.CurveSlot - recordToDisplay.Curve).ToString();
                    txtItemSpinSlot.Text = (recordToDisplay.SpinSlot - recordToDisplay.Spin).ToString();
                    txtItemControlSlot.Text = (recordToDisplay.ControlSlot - recordToDisplay.Control).ToString();
                    txtItemImpactSlot.Text = (recordToDisplay.ImpactSlot - recordToDisplay.Impact).ToString();
                }
            }
        }

        private void LoadDetailFromClubList(uint index)
        {
            var selectedItem = from u in clubList
                               where u.Base.TypeId == index
                               select u;

            foreach (ClubRecord recordToDisplay in selectedItem)
            {
                if (recordToDisplay != null)
                {
                    clubOnEdit = recordToDisplay;
                    onEdit = eEditType.CLUB;

                    cmbClubType.SelectedIndex = (UInt16)recordToDisplay.Type;
                    ShowHideEditTypeSpecificItems();

                    GetItemCommonProperties(recordToDisplay.Base);

                    GetTypeIdValues(recordToDisplay.Base);

                    picItemIcon.Image = Resources.item_no_preview;

                    lblRecordRegion.Text = "Region/MagicNum: " + recordToDisplay.Base.Region;

                    txtItemPower.Text = recordToDisplay.Power.ToString();
                    txtItemCurve.Text = recordToDisplay.Curve.ToString();
                    txtItemSpin.Text = recordToDisplay.Spin.ToString();
                    txtItemControl.Text = recordToDisplay.Control.ToString();
                    txtItemImpact.Text = recordToDisplay.Impact.ToString();

                    txtItemTex.Text = recordToDisplay.Base.Icon;
                    txtItemModel.Text = recordToDisplay.Model;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lstClubSets.Items.Clear();
            clubsetList = new List<ClubSetRecord>();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd_clubset = new OpenFileDialog();
            ofd_clubset.Filter = "Pangya ClubSet IFF File (ClubSet.iff)|ClubSet.iff";
            ofd_clubset.Title = "Open ClubSet IFF File";
            DialogResult ofdResult = ofd_clubset.ShowDialog();

            if (ofdResult == DialogResult.OK)
            {
                DirectoryInfo diClubSetIff = Directory.GetParent(ofd_clubset.FileName);
                string clubFile = diClubSetIff.FullName + "\\Club.iff";

                // For this editor we need both ClubSet.iff and Club.iff to be present.
                if (File.Exists(clubFile))
                {
                    clubsetList = ClubSetRecord.LoadClubSetFile(ofd_clubset.FileName);
                    clubList = ClubRecord.LoadClubFile(clubFile);

                    lstClubSets.Items.Clear();

                    Text = String.Format("Pangya ClubSet Editor [{0}] ({1} items loaded)", ofd_clubset.FileName, clubsetList.Count);

                    foreach (ClubSetRecord c in clubsetList)
                    {
                        ListViewItem tmpLItem = new ListViewItem(c.Base.Name);
                        tmpLItem.Tag = c.Base.TypeId;
                        lstClubSets.Items.Add(tmpLItem);
                    }

                    foreach (ClubRecord c in clubList)
                    {
                        ListViewItem tmpLItem = new ListViewItem(c.Base.Name);
                        tmpLItem.Tag = c.Base.TypeId;
                        lstClubs.Items.Add(tmpLItem);
                    }
                }
                else
                {
                    MessageBox.Show(
                        "ClubSet.iff and Club.iff must reside in the same directory for this editor to work.",
                        "Club.iff not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void lstParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClubSets.SelectedItems.Count > 0)
            {
                LoadDetailFromClubSetList((uint)lstClubSets.SelectedItems[0].Tag);
            }
        }

        public bool CheckClubSetExists(uint typeid, List<ClubSetRecord> list, ref ClubSetRecord record)
        {
            IEnumerable<ClubSetRecord> item = from p in list
                                              where p.Base.TypeId == typeid
                                              select p;

            if (item.Count() == 1)
            {
                record = item.First();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckClubExists(uint typeid, List<ClubRecord> list, ref ClubRecord record)
        {
            IEnumerable<ClubRecord> item = from p in list
                                           where p.Base.TypeId == typeid
                                           select p;

            if (item.Count() == 1)
            {
                record = item.First();
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ImportItem(uint typeid)
        {
            switch (onEdit)
            {
                case (eEditType.CLUBSET):
                    return ImportItem_ClubSet(typeid);
                case (eEditType.CLUB):
                    return ImportItem_Club(typeid, false);
            }
            return 1;
        }

        public int ImportItem_Club(uint typeid, bool isUnderProcess)
        {
            ClubRecord existingItemNameInParent = new ClubRecord();
            ClubRecord foundRecord = new ClubRecord();

            // Don't start the party if the item is already present in the parent and make sure we don't
            // loop into oblivion here.
            if (!CheckClubExists(typeid, _club_Parent, ref existingItemNameInParent))
            {
                // Okay, so it's not there... now check again whether this is a valid record
                if (CheckClubExists(typeid, clubList, ref foundRecord))
                {
                    // ...we will add the Part and return success
                    //AddModelsTexturesToCopyQueue(foundRecord);
                    _club_Parent.Add(foundRecord);
                    return 0;
                }
                return 1;
            }
            else
            {
                if (!isUnderProcess)
                {
                    // Only show "already present" message if it's not a subpart
                    MessageBox.Show(
                        "Parent already contains item \"" + itemOnEdit.Base.Name.Replace("\0", "") +
                        "\"\r\nunder the name \"" + existingItemNameInParent.Base.Name.Replace("\0", "") +
                        "\".\r\n\r\nNot importing.", "Item already present",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                return 2;
            }
        }

        public int ImportItem_ClubSet(uint typeid)
        {
            ClubSetRecord existingItemNameInParent = new ClubSetRecord();
            ClubSetRecord foundRecord = new ClubSetRecord();

            ClubRecord existingClubNameInParent = new ClubRecord();

            // Don't start the party if the item is already present in the parent and make sure we don't
            // loop into oblivion here.
            if (!CheckClubSetExists(typeid, _clubset_Parent, ref existingItemNameInParent))
            {
                // Okay, so it's not there... now check again whether this is a valid record
                if (CheckClubSetExists(typeid, clubsetList, ref foundRecord))
                {
                    // ...we will add the Part and return success
                    //AddModelsTexturesToCopyQueue(foundRecord);

                    if (!CheckClubExists(foundRecord.ClubIds.Wood, _club_Parent, ref existingClubNameInParent))
                        ImportItem_Club(foundRecord.ClubIds.Wood, true);

                    if (!CheckClubExists(foundRecord.ClubIds.Iron, _club_Parent, ref existingClubNameInParent))
                        ImportItem_Club(foundRecord.ClubIds.Iron, true);

                    if (!CheckClubExists(foundRecord.ClubIds.Wedge, _club_Parent, ref existingClubNameInParent))
                        ImportItem_Club(foundRecord.ClubIds.Wedge, true);

                    if (!CheckClubExists(foundRecord.ClubIds.Putter, _club_Parent, ref existingClubNameInParent))
                        ImportItem_Club(foundRecord.ClubIds.Putter, true);

                    _clubset_Parent.Add(foundRecord);
                    return 0;
                }
                return 1;
            }
            else
            {
                // Only show "already present" message if it's not a subpart
                MessageBox.Show(
                    "Parent already contains item \"" + itemOnEdit.Base.Name.Replace("\0", "") +
                    "\"\r\nunder the name \"" + existingItemNameInParent.Base.Name.Replace("\0", "") +
                    "\".\r\n\r\nNot importing.", "Item already present",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return 2;
            }
        }

        private void FilterClubs()
        {
            lstClubs.Items.Clear();

            var foundItems = from u in clubList select u;

            // Filter by not present in parent
            if (chkOnlyItemsNotInParent.Checked)
            {
                HashSet<uint> parentIds = new HashSet<uint>(_club_Parent.Select(p => p.Base.TypeId));
                foundItems = foundItems.Where(i => !parentIds.Contains(i.Base.TypeId));
            }

            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                lstClubs.BeginUpdate();

                foreach (ClubRecord p in foundItems)
                {
                    Wildcard wildcard = new Wildcard(txtFilter.Text, RegexOptions.IgnoreCase);
                    if (cmbFilterBy.SelectedIndex == 0)
                    {
                        if (wildcard.IsMatch(p.Base.Name))
                        {
                            ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                            tmpLItem.Tag = p.Base.TypeId;
                            lstClubs.Items.Add(tmpLItem);
                        }
                    }
                    else if (cmbFilterBy.SelectedIndex == 1)
                    {
                        if (wildcard.IsMatch(p.Base.TypeId.ToString()))
                        {
                            ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                            tmpLItem.Tag = p.Base.TypeId;
                            lstClubs.Items.Add(tmpLItem);
                        }
                    }
                }
                lstClubs.EndUpdate();
            }
            else
            {
                lstClubs.BeginUpdate();
                foreach (ClubRecord p in foundItems)
                {
                    ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                    tmpLItem.Tag = p.Base.TypeId;
                    lstClubs.Items.Add(tmpLItem);
                }
                lstClubs.EndUpdate();
            }
        }

        private void FilterClubSets()
        {
            lstClubSets.Items.Clear();

            var foundItems = from u in clubsetList select u;

            // Filter by not present in parent
            if (chkOnlyItemsNotInParent.Checked)
            {
                HashSet<uint> parentIds = new HashSet<uint>(_clubset_Parent.Select(p => p.Base.TypeId));
                foundItems = foundItems.Where(i => !parentIds.Contains(i.Base.TypeId));
            }

            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                lstClubSets.BeginUpdate();

                foreach (ClubSetRecord p in foundItems)
                {
                    Wildcard wildcard = new Wildcard(txtFilter.Text, RegexOptions.IgnoreCase);
                    if (cmbFilterBy.SelectedIndex == 0)
                    {
                        if (wildcard.IsMatch(p.Base.Name))
                        {
                            ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                            tmpLItem.Tag = p.Base.TypeId;
                            lstClubSets.Items.Add(tmpLItem);
                        }
                    }
                    else if (cmbFilterBy.SelectedIndex == 1)
                    {
                        if (wildcard.IsMatch(p.Base.TypeId.ToString()))
                        {
                            ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                            tmpLItem.Tag = p.Base.TypeId;
                            lstClubSets.Items.Add(tmpLItem);
                        }
                    }
                }
                lstClubSets.EndUpdate();
            }
            else
            {
                lstClubSets.BeginUpdate();
                foreach (ClubSetRecord p in foundItems)
                {
                    ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                    tmpLItem.Tag = p.Base.TypeId;
                    lstClubSets.Items.Add(tmpLItem);
                }
                lstClubSets.EndUpdate();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Filter by active tab instead of onEdit to ensure
            // the correct filter will launch.
            // We don't switch onEdit contexts on tabList.SelectedIndex changes,
            // keep that in mind!
            if (tabLists.SelectedIndex == 0)
                FilterClubSets();
            else
                FilterClubs();
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnFilter.PerformClick();
        }

        private void btnApplyItemChange_Click(object sender, EventArgs e)
        {
            switch (onEdit)
            {
                case (eEditType.CLUBSET):
                    if (UpdateItem(itemOnEdit))
                        lstClubSets.SelectedItems[0].Text = itemOnEdit.Base.Name;
                    break;

                case (eEditType.CLUB):
                    if (UpdateClub(clubOnEdit))
                        lstClubs.SelectedItems[0].Text = clubOnEdit.Base.Name;
                    break;
            }
        }

        private void btnDiscardItemChange_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to discard the changes you made to this item?",
                                                  "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                LoadDetailFromClubSetList(itemOnEdit.Base.TypeId);
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult delResult = MessageBox.Show("Are you sure you want to delete the clubset '" + itemOnEdit.Base.Name + "'?",
                            "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);

            if (delResult == DialogResult.Yes)
            {
                lstClubSets.Items.RemoveAt(lstClubSets.SelectedIndices[0]);
                clubsetList.Remove(itemOnEdit);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save ClubSet.iff
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Pangya IFF File";
            sfd.Filter = "Pangya IFF File (*.iff)|*.iff";
            sfd.FileName = "ClubSet.iff";

            DialogResult sfdResult = sfd.ShowDialog();

            if (sfdResult == DialogResult.OK)
            {
                bool success = ClubSetRecord.SaveClubSetFile(sfd.FileName, clubsetList, IffFile.IFF_REGION.Default);

                if (success)
                    MessageBox.Show("File written!", "Eureka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Save Club.iff afterwards
            sfd.FileName = "Club.iff";
            sfdResult = sfd.ShowDialog();
            if (sfdResult == DialogResult.OK)
            {
                bool success = ClubRecord.SaveClubFile(sfd.FileName, clubList, IffFile.IFF_REGION.Default);

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
                ClubSetRecord.GenerateSqlFile(clubsetList, sfd.FileName);
                MessageBox.Show("File written!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGiveItem_Click(object sender, EventArgs e)
        {
            if (itemOnEdit != null)
            {
                GiveItemWindow giveItemWindow = new GiveItemWindow(itemOnEdit.Base.TypeId.ToString(), itemOnEdit.Base.Name);
                giveItemWindow.ShowDialog();
            }
        }

        private void picHorizBadge_Paint(object sender, PaintEventArgs e)
        {
            string strActionTitle = "ClubSet.iff Editor";

            Rectangle baseRectangle = new Rectangle(0, 0, picHorizBadge.Width, picHorizBadge.Height);
            Brush gradientBrush = new LinearGradientBrush(baseRectangle, SystemColors.ControlDarkDark,
                                                          SystemColors.Control, LinearGradientMode.Horizontal);

            e.Graphics.FillRectangle(gradientBrush, baseRectangle);

            e.Graphics.DrawString(strActionTitle, new Font(SystemFonts.DialogFont.FontFamily, 16, FontStyle.Bold),
                                  new SolidBrush(SystemColors.ControlText), 6, 6);
            e.Graphics.DrawString(strActionTitle, new Font(SystemFonts.DialogFont.FontFamily, 16, FontStyle.Bold),
                                  new SolidBrush(SystemColors.ControlLightLight), 5, 5);
        }

        private void ClubSetEditor_Resize(object sender, EventArgs e)
        {
            picHorizBadge.Invalidate();
        }

        private void lstClubs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClubs.SelectedItems.Count > 0)
            {
                LoadDetailFromClubList((uint)lstClubs.SelectedItems[0].Tag);
            }
        }

        private void cmbClubSetWood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            if (onEdit == eEditType.CLUBSET)
                itemOnEdit = new ClubSetRecord();
            else
                clubOnEdit = new ClubRecord();
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            int maxLen = 40;
            Encoding iffEncoding;

            IffItemCommon baseProps = new IffItemCommon();

            if (onEdit == eEditType.CLUBSET)
                baseProps = itemOnEdit.Base;
            else
                baseProps = clubOnEdit.Base;

            iffEncoding = IffFile.FileEncoding(baseProps.Region);
            maxLen = baseProps.NameMaxLength;

            int textLen = iffEncoding.GetBytes(txtItemName.Text).Length;

            if (textLen > (maxLen - 5))
                lblNameLen.ForeColor = Color.Red;
            else
                lblNameLen.ForeColor = SystemColors.ControlText;

            lblNameLen.Text = string.Format("{0}/{1}", textLen, maxLen);
        }

        private void ImportClubSet()
        {
            if (clubsetList != null && clubsetList.Count > 0)
            {
                if (_clubset_Parent == null)
                {
                    MessageBox.Show(
                        "In the new window please open the ClubSet.iff from which you want to copy the item to your currently opened file.", "How to proceed:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClubSetEditor cloneFileEditor = new ClubSetEditor(clubsetList, clubList);
                    cloneFileEditor.Owner = this;
                    cloneFileEditor.BackColor = SystemColors.ControlDark;
                    cloneFileEditor.tbsImportItems.Text = "Import selected to Parent";
                    cloneFileEditor.useItemnamesFromThisFileToolStripMenuItem.Enabled = true;

                    cloneFileEditor.chkOnlyItemsNotInParent.Enabled = true;
                    cloneFileEditor.chkOnlyItemsNotInParent.Visible = true;

                    cloneFileEditor.Show();
                }
                else
                {
                    // Auto translate name to English or revert to default "Item <TypeId>" name...
                    switch (itemOnEdit.Base.Region)
                    {
                        case (IffFile.IFF_REGION.Japan):
                        case (IffFile.IFF_REGION.Japan_52428):
                        case (IffFile.IFF_REGION.Japan_8960):
                            itemOnEdit.Base.Name = IffCommonMethods.GetTranslatedItemName(itemOnEdit.Base.Name,
                                                                                          itemOnEdit.Base.TypeId, "ja",
                                                                                          "en");
                            break;

                        case (IffFile.IFF_REGION.Korea_30395):
                            itemOnEdit.Base.Name = IffCommonMethods.GetTranslatedItemName(itemOnEdit.Base.Name,
                                                                                          itemOnEdit.Base.TypeId, "kr",
                                                                                          "en");
                            break;
                    }

                    int result = ImportItem(itemOnEdit.Base.TypeId);

                    if (result == 0)
                    {
                        MessageBox.Show("Item \"" + itemOnEdit.Base.Name.Replace("\0", "") + "\" imported!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Please load a file before continuing.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void ImportClub()
        {
            if (clubList != null && clubList.Count > 0)
            {
                if (_club_Parent == null)
                {
                    MessageBox.Show(
                        "In the new window please open the ClubSet.iff from which you want to copy the item to your currently opened file.", "How to proceed:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClubSetEditor cloneFileEditor = new ClubSetEditor(clubsetList, clubList);
                    cloneFileEditor.Owner = this;
                    cloneFileEditor.BackColor = SystemColors.ControlDark;
                    cloneFileEditor.tbsImportItems.Text = "Import selected to Parent";
                    cloneFileEditor.useItemnamesFromThisFileToolStripMenuItem.Enabled = true;

                    cloneFileEditor.chkOnlyItemsNotInParent.Enabled = true;
                    cloneFileEditor.chkOnlyItemsNotInParent.Visible = true;

                    cloneFileEditor.Show();
                }
                else
                {
                    // Auto translate name to English or revert to default "Item <TypeId>" name...
                    switch (clubOnEdit.Base.Region)
                    {
                        case (IffFile.IFF_REGION.Japan):
                        case (IffFile.IFF_REGION.Japan_52428):
                        case (IffFile.IFF_REGION.Japan_8960):
                            clubOnEdit.Base.Name = IffCommonMethods.GetTranslatedItemName(clubOnEdit.Base.Name,
                                                                                          clubOnEdit.Base.TypeId, "ja",
                                                                                          "en");
                            break;

                        case (IffFile.IFF_REGION.Korea_30395):
                            clubOnEdit.Base.Name = IffCommonMethods.GetTranslatedItemName(clubOnEdit.Base.Name,
                                                                                          clubOnEdit.Base.TypeId, "kr",
                                                                                          "en");
                            break;
                    }

                    int result = ImportItem(clubOnEdit.Base.TypeId);

                    if (result == 0)
                    {
                        MessageBox.Show("Item \"" + clubOnEdit.Base.Name.Replace("\0", "") + "\" imported!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Please load a file before continuing.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void tbsImportItems_Click(object sender, EventArgs e)
        {
            switch (onEdit)
            {
                case (eEditType.CLUBSET):
                    ImportClubSet();
                    break;
                case (eEditType.CLUB):
                    ImportClub();
                    break;
            }
        }
    }
}
