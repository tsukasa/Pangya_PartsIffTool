using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace PartsIffTool
{
    public partial class PartEditor : Form
    {
        private enum eEditType
        {
            PART = 0,
            SET = 1,
        }

        public List<PartsRecord> partsList;
        public List<SetItemRecord> setList;

        private int selectMode = 0;
        private eEditType onEdit = new eEditType();

        private List<PartsRecord> _part_Parent;
        private PartsRecord itemOnEdit;

        private List<SetItemRecord> _set_Parent;
        private SetItemRecord setOnEdit;

        private List<KeyValuePair<string, uint>> _texModelsToCopy;

        public PartEditor()
        {
            InitializeComponent();
            KeyPreview = true;

            InitEditor();
        }

        public PartEditor(List<PartsRecord> itemRecordList, List<SetItemRecord> setRecordList)
        {
            InitializeComponent();
            InitEditor();

            _part_Parent = itemRecordList;
            _set_Parent = setRecordList;
        }

        public void InitEditor()
        {
            onEdit = eEditType.PART;

            partsList = new List<PartsRecord>();
            _texModelsToCopy = new List<KeyValuePair<string, uint>>();

            cmbFilterBy.SelectedIndex = 0;
            cmbFilterByCharacter.SelectedIndex = 0;
            cmbFilterByCategory.SelectedIndex = 0;

            tabProperties.TabPages.Remove(tabSetItems);

            InitOutputRegionList();
            InitCharacterList();
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

        public void InitCharacterList()
        {
            foreach (IffItemCommon.eCharacter character in Enum.GetValues(typeof(IffItemCommon.eCharacter)))
            {
                cmbFilterByCharacter.Items.Add(character);
                cmbPartCharacter.Items.Add(character);
            }

            if (cmbFilterByCharacter.Items.Count > 0)
                cmbFilterByCharacter.SelectedIndex = 0;
        }

        private void GetTypeIdValues(IffItemCommon recordToDisplay)
        {
            // It seems that some sets don't like this too much...
            try
            {
                if (onEdit == eEditType.PART)
                    cmbPartCharacter.SelectedIndex = (UInt16)recordToDisplay.TypeIdValues.Character;
                else
                    cmbPartCharacter.SelectedIndex = recordToDisplay.TypeIdValues.Pos;
            }
            catch (Exception)
            {
                cmbPartCharacter.SelectedIndex = 0;
            }

            txtItemGroup.Text = (recordToDisplay.TypeIdValues.Group).ToString();
            txtItemType.Text = recordToDisplay.TypeIdValues.Type.ToString();

            txtItemPos.Text = (recordToDisplay.TypeIdValues.Pos).ToString();
            txtItemSerial.Text = (recordToDisplay.TypeIdValues.Serial).ToString();
        }

        private void ShowHideEditTypeSpecificItems()
        {
            bool showHide = true;

            if (onEdit == eEditType.PART)
            {
                showHide = true;

                if (!tabProperties.TabPages.Contains(tabModelProperties))
                    tabProperties.TabPages.Insert(3, tabModelProperties);

                if (tabProperties.TabPages.Contains(tabSetItems))
                    tabProperties.TabPages.Remove(tabSetItems);
            }
            else
            {
                showHide = false;

                if (tabProperties.TabPages.Contains(tabModelProperties))
                    tabProperties.TabPages.Remove(tabModelProperties);

                if (!tabProperties.TabPages.Contains(tabSetItems))
                    tabProperties.TabPages.Insert(3, tabSetItems);
            }

            lblHideMaskLabel.Visible = showHide;
            lblPosMaskLabel.Visible = showHide;
            lblEquippableWithLabel.Visible = showHide;
            lblItemCategoryLabel.Visible = showHide;
            txtItemPosMask.Visible = showHide;
            txtItemHideMask.Visible = showHide;
            txtItemEquippableWith.Visible = showHide;
            cmbItemCategory.Visible = showHide;

            lblCaddyCardSlotsLabel.Visible = showHide;
            txtCaddySlots.Visible = showHide;
            lblCharCardSlotsLabel.Visible = showHide;
            txtCharSlots.Visible = showHide;
        }

        public bool CheckSetItemExists(uint typeid, List<SetItemRecord> list, ref SetItemRecord record)
        {
            IEnumerable<SetItemRecord> item = from s in list
                                              where s.Base.TypeId == typeid
                                              select s;

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

        public bool CheckItemExists(uint typeid, List<PartsRecord> list, ref PartsRecord record)
        {
            IEnumerable<PartsRecord> item = from p in list
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

        public void ClearModelQueue()
        {
            tbsModelTextureCopy.Text = "Copy Models/Textures";
            _texModelsToCopy = new List<KeyValuePair<string, uint>>();
        }

        /// <summary>
        /// Imports an item and it's subparts
        /// 
        /// Return values:
        /// 0 - Success
        /// 1 - Failure
        /// 2 - Item already present (item)
        /// 3 - Subpart already present (subpart)
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public int ImportItem(uint typeid, bool isSubpart, int depth)
        {
            PartsRecord existingItemNameInParent = new PartsRecord();
            PartsRecord foundRecord = new PartsRecord();

            // Don't start the party if the item is already present in the parent and make sure we don't
            // loop into oblivion here.
            if (!CheckItemExists(typeid, _part_Parent, ref existingItemNameInParent) && (depth < 3))
            {
                // Okay, so it's not there... now check again whether this is a valid record
                if (CheckItemExists(typeid, partsList, ref foundRecord))
                {
                    // Prepare the return values for subpart copying
                    int s1Ok = 0;
                    int s2Ok = 0;

                    // Automatically copy the subparts, recursive method
                    if (foundRecord.SubParts.SubPart1 != 0)
                        s1Ok = ImportItem(foundRecord.SubParts.SubPart1, true, depth + 1);
                    if (foundRecord.SubParts.SubPart2 != 0)
                        s2Ok = ImportItem(foundRecord.SubParts.SubPart2, true, depth + 1);

                    if (
                        // If subpart 1 was copied or is already present...
                        (s1Ok == 0 || s1Ok == 3)
                            &&
                        // ...and if subpart 2 was copied or is alreay present...
                        (s2Ok == 0 || s2Ok == 3)
                        )
                    {
                        // ...we will add the Part and return success
                        AddModelsTexturesToCopyQueue(foundRecord);

                        IffItemCommon.TranslateItemName(ref foundRecord.Base);
                        _part_Parent.Add(foundRecord);
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                return 1;
            }
            else
            {
                // Only show "already present" message if it's not a subpart
                if (!isSubpart)
                {
                    MessageBox.Show(
                        "Parent already contains item \"" + itemOnEdit.Base.Name.Replace("\0", "") +
                        "\"\r\nunder the name \"" + existingItemNameInParent.Base.Name.Replace("\0", "") +
                        "\".\r\n\r\nNot importing.", "Item already present",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return 2;
                }
                else
                    return 3;
            }
        }

        public int ImportSet(uint typeid, bool isSubprocess)
        {
            SetItemRecord existingItemNameInParent = new SetItemRecord();
            SetItemRecord foundRecord = new SetItemRecord();

            // Don't start the party if the item is already present in the parent and make sure we don't
            // loop into oblivion here.
            if (!CheckSetItemExists(typeid, _set_Parent, ref existingItemNameInParent))
            {
                // Okay, so it's not there... now check again whether this is a valid record
                if (CheckSetItemExists(typeid, setList, ref foundRecord))
                {
                    //AddModelsTexturesToCopyQueue(foundRecord);
                    for (int i = 0; i < foundRecord.ElementIds.Count; i++)
                    {
                        ImportItem(foundRecord.ElementIds[i], true, 0);
                    }

                    IffItemCommon.TranslateItemName(ref foundRecord.Base);
                    _set_Parent.Add(foundRecord);
                    return 0;
                }
                return 1;
            }
            else
            {
                MessageBox.Show(
                    "Parent already contains item \"" + itemOnEdit.Base.Name.Replace("\0", "") +
                    "\"\r\nunder the name \"" + existingItemNameInParent.Base.Name.Replace("\0", "") +
                    "\".\r\n\r\nNot importing.", "Item already present",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return 2;
            }
        }

        public void AddModelsTexturesToCopyQueue(PartsRecord record)
        {
            // Add entry for the model
            if (!string.IsNullOrEmpty(CleanStringFromZero(record.Model)))
                AddTextureToCopyQueue(record.Model, "mpet", record.Base.TypeId, false);
            //_texModelsToCopy.Add(new KeyValuePair<string, uint>(CleanStringFromZero(record.Model) + ".mpet", record.Base.TypeId));

            // Add entry for the icon
            if (!string.IsNullOrEmpty(CleanStringFromZero(record.Base.Icon)))
                AddTextureToCopyQueue(record.Base.Icon, "tga", record.Base.TypeId, false);
            //_texModelsToCopy.Add(new KeyValuePair<string, uint>(CleanStringFromZero(record.Base.Icon) + ".tga", record.Base.TypeId));

            // Add Tex1-3
            if (!string.IsNullOrEmpty(CleanStringFromZero(record.Tex.Tex1)))
                AddTextureToCopyQueue(record.Tex.Tex1, "jpg", record.Base.TypeId, true);
            //_texModelsToCopy.Add(new KeyValuePair<string, uint>(CleanStringFromZero(record.Tex.Tex1), record.Base.TypeId));
            if (!string.IsNullOrEmpty(CleanStringFromZero(record.Tex.Tex2)))
                AddTextureToCopyQueue(record.Tex.Tex2, "jpg", record.Base.TypeId, true);
            //_texModelsToCopy.Add(new KeyValuePair<string, uint>(CleanStringFromZero(record.Tex.Tex2), record.Base.TypeId));
            if (!string.IsNullOrEmpty(CleanStringFromZero(record.Tex.Tex3)))
                AddTextureToCopyQueue(record.Tex.Tex3, "jpg", record.Base.TypeId, true);
            //_texModelsToCopy.Add(new KeyValuePair<string, uint>(CleanStringFromZero(record.Tex.Tex3), record.Base.TypeId));

            // Add OrgTex1-3
            if (!string.IsNullOrEmpty(CleanStringFromZero(record.OrgTex.OrgTex1)))
                AddTextureToCopyQueue(record.OrgTex.OrgTex1, "jpg", record.Base.TypeId, true);
            //_texModelsToCopy.Add(new KeyValuePair<string, uint>(CleanStringFromZero(record.OrgTex.OrgTex1), record.Base.TypeId));
            if (!string.IsNullOrEmpty(CleanStringFromZero(record.OrgTex.OrgTex2)))
                AddTextureToCopyQueue(record.OrgTex.OrgTex2, "jpg", record.Base.TypeId, true);
            //_texModelsToCopy.Add(new KeyValuePair<string, uint>(CleanStringFromZero(record.OrgTex.OrgTex2), record.Base.TypeId));
            if (!string.IsNullOrEmpty(CleanStringFromZero(record.OrgTex.OrgTex3)))
                AddTextureToCopyQueue(record.OrgTex.OrgTex3, "jpg", record.Base.TypeId, true);
            //_texModelsToCopy.Add(new KeyValuePair<string, uint>(CleanStringFromZero(record.OrgTex.OrgTex3), record.Base.TypeId));

            tbsModelTextureCopy.Text = "Copy Models/Textures (" + _texModelsToCopy.Count + " waiting)";
        }

        public void AddTextureToCopyQueue(string fileName, string fileExtension, uint typeid, bool addMask)
        {
            string cleanedUpFileName = CleanStringFromZero(fileName);

            string baseFileName = string.Empty;
            string baseExtension = string.Empty;

            if (cleanedUpFileName.Substring((cleanedUpFileName.Length - fileExtension.Length)).ToLower() != fileExtension.ToLower())
            {
                baseFileName = cleanedUpFileName;
                baseExtension = fileExtension;
            }
            else
            {
                baseExtension = Path.GetExtension(cleanedUpFileName).Substring(1);
                baseFileName = Path.GetFileNameWithoutExtension(cleanedUpFileName);
            }

            // At this point we have our filename and the extension, so we can start adding cool stuff

            // So first, let's add the normal entry
            KeyValuePair<string, uint> tmpEntryNormal = new KeyValuePair<string, uint>(baseFileName + "." + baseExtension, typeid);
            _texModelsToCopy.Add(tmpEntryNormal);

            if (addMask)
            {
                KeyValuePair<string, uint> tmpEntryMask = new KeyValuePair<string, uint>(baseFileName + "_mask." + baseExtension, typeid);
                _texModelsToCopy.Add(tmpEntryMask);
            }
        }

        private string CleanStringFromZero(string input)
        {
            return input.Replace("\0", "");
        }

        /// <summary>
        /// Initiates a mass update of the selected parts.
        /// 
        /// Operations:
        /// 0 - Deactivate item
        /// 1 - Activate item
        /// 
        /// 2 - Set price to Pang
        /// 3 - Set price to Cookies
        /// 4 - Set price to hiatus
        /// 
        /// 5 - Enable in shop
        /// 6 - Disable in shop
        /// </summary>
        /// <param name="operation"></param>
        private void MassUpdateItems(int operation, uint value)
        {
            if (lstParts.SelectedItems.Count > 0)
            {
                // Prepare verb
                string verb = string.Empty;

                foreach (ListViewItem selectedItem in lstParts.SelectedItems)
                {
                    IEnumerable<PartsRecord> items = from p in partsList
                                                     where p.Base.TypeId == (uint)selectedItem.Tag
                                                     select p;

                    PartsRecord item = items.First();

                    switch (operation)
                    {
                        case 0:
                            item.Base.Final = 0;
                            verb = "Deactivated";
                            break;
                        case 1:
                            item.Base.Final = 1;
                            verb = "Activated";
                            break;
                        case 2:
                            item.Base.Price = value;
                            item.Base.MoneyType = 0x02;
                            verb = "Set price to " + value + " Pang for";
                            break;
                        case 3:
                            item.Base.Price = value;
                            item.Base.MoneyType = 0x01;
                            verb = "Set price to " + value + " Cookies for";
                            break;
                        case 4:
                            //item.Base.Price = 10000000;
                            item.Base.MoneyType = 0x00;
                            item.Base.IsInStock = false;
                            verb = "Unset price for";
                            break;
                        case 5:
                            item.Base.IsInStock = true;
                            verb = "Shop availability set to 'available' for";
                            break;
                        case 6:
                            item.Base.IsInStock = false;
                            verb = "Shop availability set to 'unavailable' for";
                            break;
                    }
                }

                string msg = string.Format("{0} {1} item(s)!", verb, lstParts.SelectedItems.Count);
                MessageBox.Show(msg, "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MassUpdateSets(int operation, uint value)
        {
            if (lstSets.SelectedItems.Count > 0)
            {
                // Prepare verb
                string verb = string.Empty;

                foreach (ListViewItem selectedItem in lstSets.SelectedItems)
                {
                    IEnumerable<SetItemRecord> items = from s in setList
                                                       where s.Base.TypeId == (uint)selectedItem.Tag
                                                       select s;

                    SetItemRecord item = items.First();

                    switch (operation)
                    {
                        case 0:
                            item.Base.Final = 0;
                            verb = "Deactivated";
                            break;
                        case 1:
                            item.Base.Final = 1;
                            verb = "Activated";
                            break;
                        case 2:
                            item.Base.Price = value;
                            item.Base.MoneyType = 0x02;
                            verb = "Set price to " + value + " Pang for";
                            break;
                        case 3:
                            item.Base.Price = value;
                            item.Base.MoneyType = 0x01;
                            verb = "Set price to " + value + " Cookies for";
                            break;
                        case 4:
                            //item.Base.Price = 10000000;
                            item.Base.MoneyType = 0x00;
                            item.Base.IsInStock = false;
                            verb = "Unset price for";
                            break;
                        case 5:
                            item.Base.IsInStock = true;
                            verb = "Shop availability set to 'available' for";
                            break;
                        case 6:
                            item.Base.IsInStock = false;
                            verb = "Shop availability set to 'unavailable' for";
                            break;
                    }
                }

                string msg = string.Format("{0} {1} item(s)!", verb, lstSets.SelectedItems.Count);
                MessageBox.Show(msg, "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Tries to download an item image from the Pangya! TH Item Encyclopedia.
        /// 
        /// Works threaded, so it looks pretty nice.
        /// </summary>
        /// <param name="imageToSet">Not used</param>
        /// <param name="iconname">Name of the icon to display</param>
        /// <param name="type">What category does this belong to, for example "part"</param>
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

        private void GetItemCommonProperties(IffItemCommon item, eEditType type)
        {
            if (item != null)
            {
                // --- Basic Properties ---
                #region Basic Properties
                txtItemName.Text = item.Name;
                txtItemId.Text = item.TypeId.ToString();

                if (item.Final == 0)
                    chkItemActive.Checked = false;
                else
                    chkItemActive.Checked = true;

                GetTypeIdValues(item);

                string iffType = "";

                if (type == eEditType.PART)
                    iffType = "part";
                else
                    iffType = "setitem";

                CheckEncyclopediaImage(picItemIcon.Image, item.Icon, iffType);

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
                chkItemIsBasic.Checked = item.IsBasic;

                switch (item.MoneyUnit)
                {
                    case (IffItemCommon.eIsCash.Pang):
                        rbItemCostsPang.Checked = true;
                        rbItemCostsCookies.Checked = false;
                        rbItemCostsSpecial.Checked = false;
                        break;
                    case (IffItemCommon.eIsCash.Cookies):
                        rbItemCostsCookies.Checked = true;
                        rbItemCostsPang.Checked = false;
                        rbItemCostsSpecial.Checked = false;
                        break;
                    case (IffItemCommon.eIsCash.Free):
                    case (IffItemCommon.eIsCash.Set):
                        rbItemCostsSpecial.Checked = true;
                        rbItemCostsCookies.Checked = false;
                        rbItemCostsPang.Checked = false;
                        break;
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

                txtItemTime.Text = item.Time.ToString();
                txtItemTimeFlag.Text = item.TimeFlag.ToString();

                textBox3.Text = item.Point.ToString();
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
                    item.MoneyUnit = IffItemCommon.eIsCash.Cookies;
                    item.IsCash = true;
                    item.IsCashSpecial = false;
                }
                if (rbItemCostsPang.Checked)
                {
                    item.MoneyType = 0x02;
                    item.MoneyUnit = IffItemCommon.eIsCash.Pang;
                    item.IsCash = false;
                    item.IsCashSpecial = false;
                }
                if (rbItemCostsSpecial.Checked)
                {
                    item.MoneyType = 0x00;
                    item.MoneyUnit = IffItemCommon.eIsCash.Set;
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

                // Set Time and Time Flag
                item.Time = Convert.ToByte(txtItemTime.Text);
                item.TimeFlag = Convert.ToByte(txtItemTimeFlag.Text);
            }
        }

        private bool UpdateItem(SetItemRecord item)
        {
            if (item != null)
            {
                item.Base.TypeId = Convert.ToUInt32(txtItemId.Text);
                lstSets.SelectedItems[0].Tag = item.Base.TypeId;
                SetItemCommonProperties(item.Base);

                item.Power = Convert.ToUInt16(txtItemPower.Text);
                item.Curve = Convert.ToUInt16(txtItemCurve.Text);
                item.Spin = Convert.ToUInt16(txtItemSpin.Text);
                item.Impact = Convert.ToUInt16(txtItemImpact.Text);
                item.Control = Convert.ToUInt16(txtItemControl.Text);

                item.PowerSlot = Convert.ToUInt16(txtItemPowerSlot.Text);
                item.CurveSlot = Convert.ToUInt16(txtItemCurveSlot.Text);
                item.SpinSlot = Convert.ToUInt16(txtItemSpinSlot.Text);
                item.ImpactSlot = Convert.ToUInt16(txtItemImpactSlot.Text);
                item.ControlSlot = Convert.ToUInt16(txtItemControlSlot.Text);

                // Yeah, this is a crappy way of doing it but it works
                // and is less work than actually using a KeyValuePair...
                item.ElementIds.Clear();
                item.ElementAmount.Clear();

                for (int i = 0; i < lstSetItems.Items.Count; i++)
                {
                    item.ElementIds.Add(Convert.ToUInt32(lstSetItems.Items[i].SubItems[0].Text));
                    item.ElementAmount.Add(Convert.ToUInt16(lstSetItems.Items[i].SubItems[1].Text));
                }

                return true;
            }
            return false;
        }

        private bool UpdateItem(PartsRecord item)
        {
            if (item != null)
            {
                item.Base.TypeId = Convert.ToUInt32(txtItemId.Text);
                lstParts.SelectedItems[0].Tag = item.Base.TypeId;
                SetItemCommonProperties(item.Base);

                item.PosMask = Convert.ToUInt32(txtItemPosMask.Text, 2);
                item.HideMask = Convert.ToUInt32(txtItemHideMask.Text, 2);

                item.Tex.Tex1 = txtItemTex1.Text;
                item.Tex.Tex2 = txtItemTex2.Text;
                item.Tex.Tex3 = txtItemTex3.Text;

                item.OrgTex.OrgTex1 = txtItemOrgTex1.Text;
                item.OrgTex.OrgTex2 = txtItemOrgTex2.Text;
                item.OrgTex.OrgTex3 = txtItemOrgTex3.Text;

                item.SubParts.SubPart1 = UInt32.Parse(txtItemSubpart1.Text);
                item.SubParts.SubPart2 = UInt32.Parse(txtItemSubpart2.Text);

                item.CardCharSlots = UInt16.Parse(txtCharSlots.Text);
                item.CardCaddySlots = UInt16.Parse(txtCaddySlots.Text);

                item.Model = txtItemModel.Text;

                item.EquipmentCategory = TranslateItemMount(cmbItemCategory.SelectedIndex);

                item.Power = UInt16.Parse(txtItemPower.Text);
                item.PowerSlot = UInt16.Parse(txtItemPowerSlot.Text);
                item.Control = UInt16.Parse(txtItemControl.Text);
                item.ControlSlot = UInt16.Parse(txtItemControlSlot.Text);
                item.Impact = UInt16.Parse(txtItemImpact.Text);
                item.ImpactSlot = UInt16.Parse(txtItemImpactSlot.Text);
                item.Spin = UInt16.Parse(txtItemSpin.Text);
                item.SpinSlot = UInt16.Parse(txtItemSpinSlot.Text);
                item.Curve = UInt16.Parse(txtItemCurve.Text);
                item.CurveSlot = UInt16.Parse(txtItemCurveSlot.Text);

                return true;
            }
            return false;
        }

        private void LoadItemDetailFromPartsList(uint index)
        {
            var selectedItem = from u in partsList
                               where u.Base.TypeId == index
                               select u;

            if (selectedItem.Count() > 0)
            {
                PartsRecord recordToDisplay = selectedItem.First();

                if (recordToDisplay != null)
                {
                    itemOnEdit = recordToDisplay;
                    onEdit = eEditType.PART;

                    GetItemCommonProperties(recordToDisplay.Base, eEditType.PART);
                    ShowHideEditTypeSpecificItems();

                    cmbItemCategory.SelectedIndex = TranslateItemMountSelection(recordToDisplay.EquipmentCategory);
                    txtItemEquippableWith.Text = recordToDisplay.EquippableWith;

                    txtItemPosMask.Text = Convert.ToString(recordToDisplay.PosMask, 2).PadLeft(32, '0');
                    txtItemHideMask.Text = Convert.ToString(recordToDisplay.HideMask, 2).PadLeft(32, '0');


                    // --- Generic GUI Elements ---
                    #region Generic GUI Elements
                    btnReturnToParentItem.Visible = false;
                    btnReturnToParentItem.Enabled = false;

                    lblRecordRegion.Text = "Region/MagicNum: " + recordToDisplay.Base.Region;
                    #endregion
                    // --- /Generic GUI Elements ---

                    // --- Stat Modifiers ---
                    #region Stat Modifiers
                    txtCharSlots.Text = recordToDisplay.CardCharSlots.ToString();
                    txtCaddySlots.Text = recordToDisplay.CardCaddySlots.ToString();

                    txtItemPower.Text = recordToDisplay.Power.ToString();
                    txtItemCurve.Text = recordToDisplay.Curve.ToString();
                    txtItemSpin.Text = recordToDisplay.Spin.ToString();
                    txtItemControl.Text = recordToDisplay.Control.ToString();
                    txtItemImpact.Text = recordToDisplay.Impact.ToString();

                    txtItemPowerSlot.Text = recordToDisplay.PowerSlot.ToString();
                    txtItemCurveSlot.Text = recordToDisplay.CurveSlot.ToString();
                    txtItemSpinSlot.Text = recordToDisplay.SpinSlot.ToString();
                    txtItemControlSlot.Text = recordToDisplay.ControlSlot.ToString();
                    txtItemImpactSlot.Text = recordToDisplay.ImpactSlot.ToString();
                    #endregion
                    // --- /Stat Modifiers ---

                    // --- Model and Texture ---
                    #region Model and Texture
                    txtItemIcon.Text = recordToDisplay.Base.Icon;
                    txtItemModel.Text = recordToDisplay.Model;

                    txtItemTex1.Text = recordToDisplay.Tex.Tex1;
                    txtItemTex2.Text = recordToDisplay.Tex.Tex2;
                    txtItemTex3.Text = recordToDisplay.Tex.Tex3;

                    txtItemOrgTex1.Text = recordToDisplay.OrgTex.OrgTex1;
                    txtItemOrgTex2.Text = recordToDisplay.OrgTex.OrgTex2;
                    txtItemOrgTex3.Text = recordToDisplay.OrgTex.OrgTex3;

                    txtItemSubpart1.Text = recordToDisplay.SubParts.SubPart1.ToString();
                    if (recordToDisplay.SubParts.SubPart1 > 0)
                    {
                        var subpart1 = from p in partsList
                                       where p.Base.TypeId == recordToDisplay.SubParts.SubPart1
                                       select p;

                        foreach (PartsRecord p in subpart1)
                        {
                            btnGoToSubpart1.Tag = p.Base.TypeId;
                            btnGoToSubpart1.Enabled = true;
                        }
                    }
                    else
                    {
                        btnGoToSubpart1.Enabled = false;
                    }

                    txtItemSubpart2.Text = recordToDisplay.SubParts.SubPart2.ToString();
                    if (recordToDisplay.SubParts.SubPart2 > 0)
                    {
                        var subpart2 = from p in partsList
                                       where p.Base.TypeId == recordToDisplay.SubParts.SubPart2
                                       select p;

                        foreach (PartsRecord p in subpart2)
                        {
                            btnGoToSubpart2.Tag = p.Base.TypeId;
                            btnGoToSubpart2.Enabled = true;
                        }
                    }
                    else
                    {
                        btnGoToSubpart2.Enabled = false;
                    }
                    #endregion
                    // --- /Model and Texture ---
                }
            }
        }

        private void LoadItemDetailFromSetList(uint index)
        {
            var selectedItem = (cmbFilterByCharacter.SelectedIndex == 0 ? from u in setList
                                                                          where u.Base.TypeId == index
                                                                          select u
                               :
                               from u in setList
                               where u.Base.TypeId == index && u.Base.TypeIdValues.Pos == (UInt16)(cmbFilterByCharacter.SelectedIndex - 1)
                               select u);

            if (selectedItem.Count() > 0)
            {
                SetItemRecord recordToDisplay = selectedItem.First();

                if (recordToDisplay != null)
                {
                    setOnEdit = recordToDisplay;
                    onEdit = eEditType.SET;

                    GetItemCommonProperties(recordToDisplay.Base, eEditType.SET);
                    ShowHideEditTypeSpecificItems();

                    // --- Generic GUI Elements ---
                    #region Generic GUI Elements
                    btnReturnToParentItem.Visible = false;
                    btnReturnToParentItem.Enabled = false;

                    if (_part_Parent != null)
                        chkUseSetItemNamesFromParent.Visible = true;

                    lblRecordRegion.Text = "Region/MagicNum: " + recordToDisplay.Base.Region;

                    txtItemTimeFlag.Text = Convert.ToString(recordToDisplay.Base.TimeFlag, 2).PadLeft(8, '0');
                    txtItemTime.Text = recordToDisplay.Base.Time.ToString();
                    textBox3.Text = recordToDisplay.Base.Point.ToString();
                    #endregion
                    // --- /Generic GUI Elements ---

                    // --- Stat Modifiers ---
                    #region Stat Modifiers
                    txtItemPower.Text = recordToDisplay.Power.ToString();
                    txtItemCurve.Text = recordToDisplay.Curve.ToString();
                    txtItemSpin.Text = recordToDisplay.Spin.ToString();
                    txtItemControl.Text = recordToDisplay.Control.ToString();
                    txtItemImpact.Text = recordToDisplay.Impact.ToString();

                    txtItemPowerSlot.Text = recordToDisplay.PowerSlot.ToString();
                    txtItemCurveSlot.Text = recordToDisplay.CurveSlot.ToString();
                    txtItemSpinSlot.Text = recordToDisplay.SpinSlot.ToString();
                    txtItemControlSlot.Text = recordToDisplay.ControlSlot.ToString();
                    txtItemImpactSlot.Text = recordToDisplay.ImpactSlot.ToString();
                    #endregion
                    // --- /Stat Modifiers ---

                    // --- Model and Texture ---
                    #region Model and Texture
                    txtItemIcon.Text = recordToDisplay.Base.Icon;

                    RefreshSetItemContents(recordToDisplay);

                    txtItemEquippableWith.Text = recordToDisplay.Base.TypeIdValues.Character_Raw.ToString();
                    #endregion
                    // --- /Model and Texture ---
                }
            }
        }

        private void RefreshSetItemContents(SetItemRecord recordToDisplay)
        {
            lstSetItems.BeginUpdate();

            lstSetItems.Items.Clear();
            for (int item = 0; item < recordToDisplay.ElementIds.Count; item++)
            {
                ListViewItem tmpItem = new ListViewItem();

                tmpItem.Text = Convert.ToString(recordToDisplay.ElementIds[item]);
                tmpItem.SubItems.Add(Convert.ToString(recordToDisplay.ElementAmount[item]));
                tmpItem.SubItems.Add("-");
                lstSetItems.Items.Add(tmpItem);
            }
            GetSetItemPartNameFromTypeID();
            lstSetItems.EndUpdate();

            UpdateSetItemCountDisplay();
        }

        private void UpdateSetItemCountDisplay()
        {
            lblSetItemCount.Text = String.Format("{0}/10 Items", lstSetItems.Items.Count);
        }

        private byte TranslateItemMountSelection(ushort itemMount)
        {
            switch (itemMount)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                case 4:
                    return 4;
                case 5:
                    return 5;
                case 8:
                    return 6;
                case 9:
                    return 7;
            }
            return 0;
        }

        private byte TranslateItemMount(int indexInGui)
        {
            switch (indexInGui)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                case 4:
                    return 4;
                case 5:
                    return 5;
                case 6:
                    return 8;
                case 7:
                    return 9;
            }
            return 0;
        }

        private void FilterParts()
        {
            lstParts.Items.Clear();

            var foundItems = from u in partsList select u;

            if (chkOnlyShowActiveItems.Checked)
                foundItems = foundItems.Where(u => u.Base.Final == 1);

            if (chkOnlyShowItemInShop.Checked)
                foundItems = foundItems.Where(u => u.Base.IsInStock);

            // Filter by character if necessary))
            if (cmbFilterByCharacter.SelectedIndex != 0)
                foundItems =
                    foundItems.Where(
                        u =>
                        u.Base.TypeIdValues.Character ==
                        (IffItemCommon.eCharacter)(cmbFilterByCharacter.SelectedIndex - 1));

            if (chkRealItemOnly.Checked)
            {
                foundItems = foundItems.Where(i => i.Base.Icon.Replace("\0", "") != "");

                // For some JP items...
                foundItems = foundItems.Where(i => i.Base.Icon.Replace("\0", "").ToLower() != "not_used");
                foundItems = foundItems.Where(i => i.Base.Icon.Replace("\0", "").ToLower() != "a_dumy");
                foundItems = foundItems.Where(i => i.Base.Icon.Replace("\0", "").ToLower() != "b_dumy");
                foundItems = foundItems.Where(i => i.Base.Icon.Replace("\0", "").ToLower() != "c_dumy");
                foundItems = foundItems.Where(i => i.Base.Icon.Replace("\0", "").ToLower() != "d_dumy");
                foundItems = foundItems.Where(i => i.Base.Icon.Replace("\0", "").ToLower() != "e_dumy");
                foundItems = foundItems.Where(i => i.Base.Icon.Replace("\0", "").ToLower() != "f_dumy");
                foundItems = foundItems.Where(i => i.Base.Icon.Replace("\0", "").ToLower() != "g_dumy");
                foundItems = foundItems.Where(i => i.Base.Icon.Replace("\0", "").ToLower() != "h_dumy");
                foundItems = foundItems.Where(i => i.Base.Icon.Replace("\0", "").ToLower() != "i_dumy");
            }

            // Filter by not present in parent
            if (chkOnlyItemsNotInParent.Checked)
            {
                HashSet<uint> parentIds = new HashSet<uint>(_part_Parent.Select(p => p.Base.TypeId));
                foundItems = foundItems.Where(i => !parentIds.Contains(i.Base.TypeId));
            }

            // Filter by equipment category))
            if (cmbFilterByCategory.SelectedIndex != 0)
                foundItems =
                    foundItems.Where(
                        u => u.EquipmentCategory == (TranslateItemMount(cmbFilterByCategory.SelectedIndex - 1)));

            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                lstParts.BeginUpdate();

                foreach (PartsRecord p in foundItems)
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
                lstParts.EndUpdate();
            }
            else
            {
                lstParts.BeginUpdate();
                foreach (PartsRecord p in foundItems)
                {
                    ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                    tmpLItem.Tag = p.Base.TypeId;
                    lstParts.Items.Add(tmpLItem);
                }
                lstParts.EndUpdate();
            }
        }

        private void FilterSets()
        {
            lstSets.Items.Clear();

            var foundItems = from u in setList select u;

            // Hide inactive items
            if (chkOnlyShowActiveItems.Checked)
                foundItems = foundItems.Where(u => u.Base.Final == 1);

            // Show only items that are active in the shop
            if (chkOnlyShowItemInShop.Checked)
                foundItems = foundItems.Where(u => u.Base.IsInStock);

            // Filter by character if necessary)
            if (cmbFilterByCharacter.SelectedIndex != 0)
                foundItems =
                    foundItems.Where(
                        u =>
                        u.Base.TypeIdValues.Pos == (cmbFilterByCharacter.SelectedIndex - 1));

            // Filter by not present in parent
            if (chkOnlyItemsNotInParent.Checked)
            {
                HashSet<uint> parentIds = new HashSet<uint>(_set_Parent.Select(p => p.Base.TypeId));
                foundItems = foundItems.Where(i => !parentIds.Contains(i.Base.TypeId));
            }

            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                lstSets.BeginUpdate();

                foreach (SetItemRecord p in foundItems)
                {
                    Wildcard wildcard = new Wildcard(txtFilter.Text, RegexOptions.IgnoreCase);
                    if (cmbFilterBy.SelectedIndex == 0)
                    {
                        if (wildcard.IsMatch(p.Base.Name))
                        {
                            ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                            tmpLItem.Tag = p.Base.TypeId;
                            lstSets.Items.Add(tmpLItem);
                        }
                    }
                    else if (cmbFilterBy.SelectedIndex == 1)
                    {
                        if (wildcard.IsMatch(p.Base.TypeId.ToString()))
                        {
                            ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                            tmpLItem.Tag = p.Base.TypeId;
                            lstSets.Items.Add(tmpLItem);
                        }
                    }
                }
                lstSets.EndUpdate();
            }
            else
            {
                lstSets.BeginUpdate();
                foreach (SetItemRecord p in foundItems)
                {
                    ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                    tmpLItem.Tag = p.Base.TypeId;
                    lstSets.Items.Add(tmpLItem);
                }
                lstSets.EndUpdate();
            }
        }

        public void btnFilter_Click(object sender, EventArgs e)
        {
            if (tabLists.SelectedIndex == 0)
                FilterParts();
            else
                FilterSets();
        }

        private void lstParts_ItemActivate(object sender, EventArgs e)
        {
            // Only do cool stuff when not in Select Mode
            if (selectMode == 0)
            {
                if (lstParts.SelectedIndices.Count > 0)
                {
                    lstParts.BeginUpdate();

                    // Reset BG color for all items before proceeding
                    foreach (ListViewItem item in lstParts.Items)
                    {
                        item.BackColor = SystemColors.Window;
                        item.ForeColor = SystemColors.WindowText;
                    }

                    ListViewItem tmpItem = (ListViewItem)lstParts.SelectedItems[0];
                    tmpItem.BackColor = SystemColors.ActiveCaption;
                    tmpItem.ForeColor = SystemColors.ActiveCaptionText;
                    LoadItemDetailFromPartsList((uint)tmpItem.Tag);

                    lstParts.EndUpdate();
                }
            }
            // Select Mode doesn't need fancy highlighting, so remove it...
            else if (selectMode == 1)
            {
                lstParts.BeginUpdate();

                // Reset BG color for all items before proceeding
                foreach (ListViewItem item in lstParts.Items)
                {
                    item.BackColor = SystemColors.Window;
                    item.ForeColor = SystemColors.WindowText;
                }

                lstParts.EndUpdate();
            }
        }

        private void btnSetHighPrice_Click(object sender, EventArgs e)
        {
            txtItemCost.Text = "10000000";
        }

        private void btnDiscardItemChange_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to discard the changes you made to this item?",
                                                  "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                LoadItemDetailFromPartsList(itemOnEdit.Base.TypeId);
        }

        private void btnApplyItemChange_Click(object sender, EventArgs e)
        {
            if (onEdit == eEditType.PART)
            {
                if (UpdateItem(itemOnEdit))
                {
                    // TODO: Try to select the same item again if it still exists
                    // in the filter.
                    try
                    {
                        foreach (ListViewItem item in lstParts.Items)
                        {
                            if ((uint)item.Tag == itemOnEdit.Base.TypeId)
                            {
                                item.Selected = true;
                                break;
                            }
                        }

                        lstParts.SelectedItems[0].Text = itemOnEdit.Base.Name;
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            else
            {
                if (UpdateItem(setOnEdit))
                {
                    // TODO: Try to select the same item again if it still exists
                    // in the filter.
                    try
                    {
                        foreach (ListViewItem item in lstSets.Items)
                        {
                            if ((uint)item.Tag == setOnEdit.Base.TypeId)
                            {
                                item.Selected = true;
                                break;
                            }
                        }

                        lstSets.SelectedItems[0].Text = setOnEdit.Base.Name;
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnFilter.PerformClick();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            string itemName = "";
            if (onEdit == eEditType.PART)
                itemName = itemOnEdit.Base.Name;
            else
                itemName = setOnEdit.Base.Name;

            DialogResult delResult = MessageBox.Show("Are you sure you want to delete the item '" + itemName + "'?",
                            "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);

            if (delResult == DialogResult.Yes)
            {
                if (onEdit == eEditType.PART)
                {
                    lstParts.Items.RemoveAt(lstParts.SelectedIndices[0]);
                    partsList.Remove(itemOnEdit);
                }
                else
                {
                    lstSets.Items.RemoveAt(lstSets.SelectedIndices[0]);
                    setList.Remove(setOnEdit);
                }
            }
        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            if (tabLists.SelectedIndex == 0)
            {
                PartsRecord newItem;

                if (itemOnEdit != null)
                {
                    newItem = (PartsRecord)itemOnEdit.Clone();
                    newItem.Base.Name = "New Item";
                    newItem.Base.TypeId = 10;
                }
                else
                {
                    newItem = new PartsRecord();
                    itemOnEdit = newItem;
                }

                partsList.Add(newItem);

                ListViewItem newItemListView = new ListViewItem(newItem.Base.Name);
                newItemListView.Tag = newItem.Base.TypeId;
                lstParts.Items.Add(newItemListView);
                lstParts.Items[lstParts.Items.Count - 1].Selected = true;
                lstParts.Items[lstParts.Items.Count - 1].Focused = true;
                lstParts.Focus();
                lstParts.Select();
            }
            else
            {
                SetItemRecord newItem;

                if (setOnEdit != null)
                {
                    newItem = (SetItemRecord)setOnEdit.Clone();
                    newItem.Base.Name = "New Set";
                    newItem.Base.TypeId = 10;
                }
                else
                {
                    newItem = new SetItemRecord();
                    setOnEdit = newItem;
                }

                setList.Add(newItem);

                ListViewItem newItemListView = new ListViewItem(newItem.Base.Name);
                newItemListView.Tag = newItem.Base.TypeId;
                lstSets.Items.Add(newItemListView);
                lstSets.Items[lstSets.Items.Count - 1].Selected = true;
                lstSets.Items[lstSets.Items.Count - 1].Focused = true;
                lstSets.Focus();
                lstSets.Select();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lstParts.Items.Clear();
            partsList = new List<PartsRecord>();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pangya IFF File (*.iff)|*.iff";
            ofd.Title = "Open IFF File";
            DialogResult ofdResult = ofd.ShowDialog();

            if (ofdResult == DialogResult.OK)
            {
                DirectoryInfo diParts = Directory.GetParent(ofd.FileName);
                string setIffPath = diParts.FullName + "\\SetItem.iff";

                if (File.Exists(setIffPath))
                {
                    this.Enabled = false;
                    Thread loadPartsThread = new Thread(delegate()
                    {
                        setList = new List<SetItemRecord>();
                        partsList = PartsRecord.LoadPartFile(ofd.FileName);
                        //setList = SetItemRecord.LoadSetItemFile(setIffPath);

                        MethodInvoker addItemsToGui = delegate()
                        {
                            lstParts.BeginUpdate();
                            Text = String.Format("Pangya Part Editor [{0}] ({1} items loaded)", ofd.FileName, partsList.Count);

                            lstParts.Items.Clear();
                            lstSets.Items.Clear();

                            foreach (PartsRecord p in partsList)
                            {
                                ListViewItem tmpLItem = new ListViewItem(p.Base.Name);
                                tmpLItem.Tag = p.Base.TypeId;
                                lstParts.Items.Add(tmpLItem);
                            }

                            /*foreach (SetItemRecord s in setList)
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
                    MessageBox.Show("SetItem.iff not found in the same directory, aborting!", "SetItem.iff not found.",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Pangya Part IFF File";
            sfd.Filter = "Pangya IFF File (*.iff)|*.iff";
            sfd.FileName = "Part.iff";

            DialogResult sfdResult = sfd.ShowDialog();

            if (sfdResult == DialogResult.OK)
            {
                bool success = PartsRecord.SavePartFile(sfd.FileName, partsList, IffFile.IFF_REGION.Default);

                if (success)
                    MessageBox.Show("Part.iff File written!", "Eureka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            sfd.Title = "Save Pangya SetItem IFF File";
            sfd.FileName = "SetItem.iff";

            sfdResult = sfd.ShowDialog();

            if (sfdResult == DialogResult.OK)
            {
                bool success = SetItemRecord.SaveSetItemFile(sfd.FileName, setList, IffFile.IFF_REGION.Default);

                if (success)
                    MessageBox.Show("SetItem.iff File written!", "Eureka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void picHorizBadge_Paint(object sender, PaintEventArgs e)
        {
            string strActionTitle = "Part.iff Editor";

            Rectangle baseRectangle = new Rectangle(0, 0, picHorizBadge.Width, picHorizBadge.Height);
            Brush gradientBrush = new LinearGradientBrush(baseRectangle, SystemColors.ControlDarkDark,
                                                          this.BackColor, LinearGradientMode.Horizontal);

            e.Graphics.FillRectangle(gradientBrush, baseRectangle);

            e.Graphics.DrawString(strActionTitle, new Font(SystemFonts.DialogFont.FontFamily, 16, FontStyle.Bold),
                                  new SolidBrush(SystemColors.ControlText), 6, 6);
            e.Graphics.DrawString(strActionTitle, new Font(SystemFonts.DialogFont.FontFamily, 16, FontStyle.Bold),
                                  new SolidBrush(SystemColors.ControlLightLight), 5, 5);

        }

        private void btnGenerateSql_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Part SQL Query";
            sfd.Filter = "SQL Queries (*.sql)|*.sql";
            sfd.FileName = "Part.sql";
            DialogResult sfdResult = sfd.ShowDialog();

            if (sfdResult == DialogResult.OK)
            {
                PartsRecord.GenerateSqlFile(partsList, sfd.FileName);
                MessageBox.Show("File written!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            sfd.Title = "Save SetItem SQL Query";
            sfd.FileName = "SetItem.sql";
            sfdResult = sfd.ShowDialog();

            if (sfdResult == DialogResult.OK)
            {
                SetItemRecord.GenerateSqlFile(setList, sfd.FileName);
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

        private void MainForm_Resize(object sender, EventArgs e)
        {
            picHorizBadge.Invalidate();
        }

        private void btnCopyFromOtherFile_Click(object sender, EventArgs e)
        {
            if (partsList != null && partsList.Count > 0)
            {
                if (_part_Parent == null || _set_Parent == null)
                {
                    MessageBox.Show(
                        "In the new window please open the Part.iff from which you want to copy the item to your currently opened file.", "How to proceed:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PartEditor cloneFileEditor = new PartEditor(partsList, setList);
                    cloneFileEditor.Owner = this;
                    cloneFileEditor.BackColor = SystemColors.ControlDark;
                    cloneFileEditor.tbsImportItems.Text = "Import selected to Parent";
                    cloneFileEditor.useItemnamesFromThisFileToolStripMenuItem.Enabled = true;
                    cloneFileEditor.useShopContentsFromThisFileToolStripMenuItem.Enabled = true;

                    cloneFileEditor.chkOnlyItemsNotInParent.Enabled = true;
                    cloneFileEditor.chkOnlyItemsNotInParent.Visible = true;
                    cloneFileEditor.chkRealItemOnly.Enabled = true;
                    cloneFileEditor.chkRealItemOnly.Visible = true;
                    cloneFileEditor.chkUseSetItemNamesFromParent.Enabled = true;
                    cloneFileEditor.chkUseSetItemNamesFromParent.Visible = true;

                    cloneFileEditor.Show();
                }
                else
                {
                    // Auto translate name to English or revert to default "Item <TypeId>" name...
                    IffItemCommon onEditBase = new IffItemCommon();

                    switch (onEdit)
                    {
                        case (eEditType.PART):
                            onEditBase = itemOnEdit.Base;
                            break;
                        case (eEditType.SET):
                            onEditBase = setOnEdit.Base;
                            break;
                    }

                    // Pre-set result for error
                    int result = 1;

                    switch (onEdit)
                    {
                        case (eEditType.PART):
                            result = ImportItem(onEditBase.TypeId, false, 0);
                            break;
                        case (eEditType.SET):
                            result = ImportSet(onEditBase.TypeId, false);
                            break;
                    }

                    if (result == 0)
                    {
                        MessageBox.Show("Item \"" + onEditBase.Name.Replace("\0", "") + "\" imported!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Please load a file before continuing.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void btnDataMigrator_Click(object sender, EventArgs e)
        {
            if (selectMode == 0)
            {
                if (_texModelsToCopy.Count > 0)
                {
                    PakDataCopier copier = new PakDataCopier();
                    copier.FileNamesToCopy = _texModelsToCopy;
                    copier.parent = this;
                    copier.Show();
                }
                else
                {
                    if (itemOnEdit != null)
                    {
                        AddModelsTexturesToCopyQueue(itemOnEdit);
                        tbsModelTextureCopy.PerformClick();
                    }
                }
            }
            else
            {
                foreach (ListViewItem selectedItem in lstParts.SelectedItems)
                {
                    IEnumerable<PartsRecord> item = from p in partsList
                                                    where p.Base.TypeId == (uint)selectedItem.Tag
                                                    select p;

                    PartsRecord record = new PartsRecord();

                    if (item.Count() == 1)
                        record = item.First();

                    AddModelsTexturesToCopyQueue(record);
                }
            }
        }

        private void btnGoToSubpart1_Click(object sender, EventArgs e)
        {
            try
            {
                btnReturnToParentItem.Tag = (UInt32)lstParts.SelectedItems[0].Tag;
                LoadItemDetailFromPartsList((UInt32)btnGoToSubpart1.Tag);
                btnReturnToParentItem.Enabled = true;
                btnReturnToParentItem.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading item:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGoToSubpart2_Click(object sender, EventArgs e)
        {
            try
            {
                btnReturnToParentItem.Tag = (UInt32)lstParts.SelectedItems[0].Tag;
                LoadItemDetailFromPartsList((UInt32)btnGoToSubpart2.Tag);
                btnReturnToParentItem.Enabled = true;
                btnReturnToParentItem.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading item:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturnToParentItem_Click(object sender, EventArgs e)
        {
            LoadItemDetailFromPartsList((UInt32)btnReturnToParentItem.Tag);
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            int maxLen = 40;
            Encoding iffEncoding;

            IffItemCommon baseProps = new IffItemCommon();

            if (onEdit == eEditType.PART)
                baseProps = itemOnEdit.Base;
            else
                baseProps = setOnEdit.Base;

            iffEncoding = IffFile.FileEncoding(baseProps.Region);
            maxLen = baseProps.NameMaxLength;

            int textLen = iffEncoding.GetBytes(txtItemName.Text).Length;

            if (textLen > (maxLen - 5))
                lblNameLen.ForeColor = Color.Red;
            else
                lblNameLen.ForeColor = SystemColors.ControlText;

            lblNameLen.Text = string.Format("{0}/{1}", textLen, maxLen);
        }

        private void useItemnamesFromThisFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to use the item names from this file for your parent file?", "Confirm",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Dictionary<uint, string> thisFile = new Dictionary<uint, string>();

                if (onEdit == eEditType.PART)
                {
                    // Get a dictionary of all type IDs in this file
                    foreach (PartsRecord item in partsList)
                    {
                        thisFile.Add(item.Base.TypeId, item.Base.Name);
                    }

                    foreach (PartsRecord item in _part_Parent)
                    {
                        if (thisFile.ContainsKey(item.Base.TypeId))
                            item.Base.Name = thisFile[item.Base.TypeId];
                    }
                }
                else
                {
                    foreach (SetItemRecord item in setList)
                    {
                        thisFile.Add(item.Base.TypeId, item.Base.Name);
                    }

                    foreach (SetItemRecord item in _set_Parent)
                    {
                        if (thisFile.ContainsKey(item.Base.TypeId))
                            item.Base.Name = thisFile[item.Base.TypeId];
                    }
                }

                MessageBox.Show("Done importing item names!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void useShopContentsFromThisFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to use this file as a reference for the shop contents?", "Confirm",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Dictionary<uint, bool> thisFile = new Dictionary<uint, bool>();

                if (onEdit == eEditType.PART)
                {
                    // Get a dictionary of all type IDs in this file
                    foreach (PartsRecord item in partsList)
                    {
                        thisFile.Add(item.Base.TypeId, item.Base.IsInStock);
                    }

                    foreach (PartsRecord item in _part_Parent)
                    {
                        // Reset every item to "not on sale" first...
                        item.Base.IsInStock = false;

                        // ...and check whether we should put it up later.
                        if (thisFile.ContainsKey(item.Base.TypeId))
                            item.Base.IsInStock = thisFile[item.Base.TypeId];
                    }
                }
                // It kind of sucks to have this two times but there doesn't seem to be a way around it...
                else
                {
                    foreach (SetItemRecord item in setList)
                    {
                        thisFile.Add(item.Base.TypeId, item.Base.IsInStock);
                    }

                    foreach (SetItemRecord item in _set_Parent)
                    {
                        item.Base.IsInStock = false;

                        if (thisFile.ContainsKey(item.Base.TypeId))
                            item.Base.IsInStock = thisFile[item.Base.TypeId];
                    }
                }

                MessageBox.Show("Done importing shop contents!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cleanUpItemNamesForWesternFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (onEdit == eEditType.PART)
            {
                foreach (PartsRecord item in partsList)
                {
                    item.Base.Name = ("Item " + item.Base.TypeId.ToString()).PadRight(40, '\0');
                }
            }
            else
            {
                foreach (SetItemRecord item in setList)
                {
                    item.Base.Name = ("Set " + item.Base.TypeId.ToString()).PadRight(40, '\0');
                }
            }

            MessageBox.Show("Cleaned up item names.\r\nIt should be safe to use the western fonts now.", "Done",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sortItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show("Do you want to sort the items by Type ID?",
                                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var sorted = from p in partsList
                             orderby p.Base.TypeId
                             select p;

                List<PartsRecord> newRecordList = new List<PartsRecord>();

                foreach (PartsRecord item in sorted)
                {
                    newRecordList.Add(item);
                }

                partsList = newRecordList;

                MessageBox.Show("Done sorting items.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PartEditor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                tbsImportItems.PerformClick();
        }

        private void lstParts_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                tbsImportItems.PerformClick();
        }

        private void btnModeChange_Click(object sender, EventArgs e)
        {
            switch (selectMode)
            {
                case (0):
                    selectMode = 1;
                    lstParts.MultiSelect = true;
                    lstSets.MultiSelect = true;
                    btnModeChange.Text = "Select Mode";
                    break;
                case (1):
                    selectMode = 0;
                    lstParts.MultiSelect = false;
                    lstSets.MultiSelect = false;
                    btnModeChange.Text = "Edit Mode";
                    break;
            }

            // --- Unselect all items that might still lurk around
            // There's a gotcha to this... normally changing the selected items
            // will fire up the event handler, so we will have to make sure this
            // won't happen by unbinding the handler, performing the unselect and
            // re-binding it again afterwards.
            lstParts.SelectedIndexChanged -= lstParts_ItemActivate;
            foreach (ListViewItem item in lstParts.SelectedItems)
                item.Selected = false;
            lstParts.SelectedIndexChanged += lstParts_ItemActivate;

            lstSets.SelectedIndexChanged -= lstSets_ItemActivate;
            foreach (ListViewItem item in lstSets.SelectedItems)
                item.Selected = false;
            lstSets.SelectedIndexChanged += lstSets_ItemActivate;
            // --- Unselect end
        }

        private void tbsModelTextureCopy_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ClearModelQueue();
                MessageBox.Show("Emptied model/texture queue.", "Notice", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void btnLastSerialForCharacter_Click(object sender, EventArgs e)
        {
            int itemType = 0;

            int.TryParse(txtItemType.Text, out itemType);

            IEnumerable<UInt16> matchingSerial;

            if (onEdit == eEditType.PART)
                matchingSerial = from p in partsList
                                 where p.Base.TypeIdValues.Character == (IffItemCommon.eCharacter)cmbPartCharacter.SelectedIndex
                                       && p.Base.TypeIdValues.Type == itemType
                                       && p.Base.TypeIdValues.Pos == ushort.Parse(txtItemPos.Text)
                                 select p.Base.TypeIdValues.Serial;
            else
                matchingSerial = from p in setList
                                 where p.Base.TypeIdValues.Pos == (UInt16)cmbPartCharacter.SelectedIndex
                                 select p.Base.TypeIdValues.Serial;

            if (matchingSerial.Count() > 0)
            {
                int lastSerial = matchingSerial.Max() + 1;

                txtItemSerial.Text = lastSerial.ToString();
            }
        }

        private void btnRegenerateItemId(object sender, EventArgs e)
        {

            if (onEdit == eEditType.PART)
            {
                if (itemOnEdit != null)
                    txtItemId.Text = IffCommonMethods.GenerateNewTypeId(itemOnEdit.Base, 2, cmbPartCharacter.SelectedIndex, Convert.ToInt32(txtItemPos.Text), Convert.ToInt32(txtItemGroup.Text), Convert.ToInt32(txtItemType.Text), Convert.ToInt32(txtItemSerial.Text)).ToString();
            }
            else
            {
                if (setOnEdit != null)
                    txtItemId.Text = IffCommonMethods.GenerateNewTypeId(setOnEdit.Base, 9, 8, Convert.ToInt32(cmbPartCharacter.SelectedIndex), 0, Convert.ToInt32(txtItemType.Text), Convert.ToInt32(txtItemSerial.Text)).ToString();
            }
        }

        private void btnSetHighDiscountPrice_Click(object sender, EventArgs e)
        {
            txtItemStallPrice.Text = "10000000";
        }

        private void btnSetHighUsedPrice_Click(object sender, EventArgs e)
        {
            txtItemUsedPrice.Text = "10000000";
        }

        // Right-click Context Menu
        #region Right-click Context Menu
        private void activateItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (onEdit == eEditType.PART)
                MassUpdateItems(1, 0);
            else
                MassUpdateSets(1, 0);
        }

        private void deactivateItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (onEdit == eEditType.PART)
                MassUpdateItems(0, 0);
            else
                MassUpdateSets(0, 0);
        }

        private void setPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MassUpdateItems(2, 10000);

            DlgShopPrice shopPrice = new DlgShopPrice();
            DialogResult r = shopPrice.ShowDialog();

            if (r == DialogResult.OK)
            {
                if (onEdit == eEditType.PART)
                {
                    foreach (ListViewItem selectedItem in lstParts.SelectedItems)
                    {
                        IEnumerable<PartsRecord> items = from p in partsList
                                                         where p.Base.TypeId == (uint)selectedItem.Tag
                                                         select p;

                        PartsRecord item = items.First();

                        item.Base.MoneyType = shopPrice.MoneyType;
                        item.Base.Price = shopPrice.Price;
                        item.Base.SalePrice = shopPrice.DiscountPrice;
                        item.Base.UsedPrice = shopPrice.UsedPrice;
                    }
                }
                else
                {
                    foreach (ListViewItem selectedItem in lstSets.SelectedItems)
                    {
                        IEnumerable<SetItemRecord> items = from s in setList
                                                           where s.Base.TypeId == (uint)selectedItem.Tag
                                                           select s;

                        SetItemRecord item = items.First();

                        item.Base.MoneyType = shopPrice.MoneyType;
                        item.Base.Price = shopPrice.Price;
                        item.Base.SalePrice = shopPrice.DiscountPrice;
                        item.Base.UsedPrice = shopPrice.UsedPrice;
                    }
                }

                MessageBox.Show("Set Shop price for selected items.", "Done", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void enableInShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (onEdit == eEditType.PART)
                MassUpdateItems(5, 0);
            else
                MassUpdateSets(5, 0);
        }

        private void disableInShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (onEdit == eEditType.PART)
                MassUpdateItems(6, 0);
            else
                MassUpdateSets(6, 0);
        }
        #endregion

        // Set Entry Controls
        #region Set Entry Controls
        private void btnEditSetItemEntry_Click(object sender, EventArgs e)
        {
            if (lstSetItems.SelectedIndices.Count > 0)
            {
                int index = lstSetItems.SelectedIndices[0];

                lstSetItems.Items[index].SubItems[0].Text = txtSetItemId.Text;
                lstSetItems.Items[index].SubItems[1].Text = numSetItemAmount.Value.ToString();

                IEnumerable<PartsRecord> itemInPartList = from p in partsList
                                                          where p.Base.TypeId == Convert.ToUInt32(lstSetItems.Items[index].Text)
                                                          select p;

                if (itemInPartList.Count() > 0)
                    lstSetItems.Items[index].SubItems[2].Text = itemInPartList.First().Base.Name;
                else
                    lstSetItems.Items[index].SubItems[2].Text = "-";
            }
        }

        private void btnRemoveSetItemEntry_Click(object sender, EventArgs e)
        {
            if (lstSetItems.SelectedIndices.Count > 0)
            {
                lstSetItems.Items.RemoveAt(lstSetItems.SelectedIndices[0]);
                UpdateSetItemCountDisplay();
            }
        }

        private void lstSets_ItemActivate(object sender, EventArgs e)
        {
            // Only do cool stuff when not in Select Mode
            if (selectMode == 0)
            {
                if (lstSets.SelectedIndices.Count > 0)
                {
                    lstSets.BeginUpdate();

                    // Reset BG color for all items before proceeding
                    foreach (ListViewItem item in lstSets.Items)
                    {
                        item.BackColor = SystemColors.Window;
                        item.ForeColor = SystemColors.WindowText;
                    }

                    ListViewItem tmpItem = (ListViewItem)lstSets.SelectedItems[0];
                    tmpItem.BackColor = SystemColors.ActiveCaption;
                    tmpItem.ForeColor = SystemColors.ActiveCaptionText;
                    LoadItemDetailFromSetList((uint)tmpItem.Tag);

                    lstSets.EndUpdate();
                }
            }
            // Select Mode doesn't need fancy highlighting, so remove it...
            else if (selectMode == 1)
            {
                lstSets.BeginUpdate();

                // Reset BG color for all items before proceeding
                foreach (ListViewItem item in lstSets.Items)
                {
                    item.BackColor = SystemColors.Window;
                    item.ForeColor = SystemColors.WindowText;
                }

                lstSets.EndUpdate();
            }
        }

        private void lstSetItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lstSetItems.SelectedIndices.Count > 0)
            {
                try
                {
                    numSetItemAmount.Value = setOnEdit.ElementAmount[lstSetItems.SelectedIndices[0]];
                    txtSetItemId.Text = setOnEdit.ElementIds[lstSetItems.SelectedIndices[0]].ToString();
                }
                catch (Exception)
                {

                }
            }
        }

        private void tabLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabLists.SelectedIndex == 0)
                onEdit = eEditType.PART;
            else
                onEdit = eEditType.SET;
        }
        #endregion

        private void btnAddSetItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSetItemId.Text))
            {
                if (lstSetItems.Items.Count < 10)
                {
                    ListViewItem tmpItemToAddToSet = new ListViewItem();
                    tmpItemToAddToSet.SubItems[0].Text = txtSetItemId.Text;
                    tmpItemToAddToSet.SubItems.Add(Convert.ToString(numSetItemAmount.Value));
                    tmpItemToAddToSet.SubItems.Add("-");
                    lstSetItems.Items.Add(tmpItemToAddToSet);

                    GetSetItemPartNameFromTypeID();
                    UpdateSetItemCountDisplay();
                }
                else
                {
                    MessageBox.Show("You can only have 10 items in a set!", "Sorry", MessageBoxButtons.OK,
                                    MessageBoxIcon.Hand);
                }
            }
        }

        private void GetSetItemPartNameFromTypeID()
        {
            foreach (ListViewItem itemInSet in lstSetItems.Items)
            {
                IEnumerable<PartsRecord> itemInPartList;

                if (!chkUseSetItemNamesFromParent.Checked)
                    itemInPartList = from p in partsList
                                     where p.Base.TypeId == Convert.ToUInt32(itemInSet.SubItems[0].Text)
                                     select p;
                else
                    itemInPartList = from p in _part_Parent
                                     where p.Base.TypeId == Convert.ToUInt32(itemInSet.SubItems[0].Text)
                                     select p;

                if (itemInPartList.Count() > 0)
                    itemInSet.SubItems[2].Text = itemInPartList.First().Base.Name;
                else
                {
                    if (_part_Parent != null)
                    {
                        itemInPartList = from p in partsList
                                         where p.Base.TypeId == Convert.ToUInt32(itemInSet.SubItems[0].Text)
                                         select p;

                        if (itemInPartList.Count() > 0)
                            itemInSet.SubItems[2].Text = itemInPartList.First().Base.Name;
                        else
                            itemInSet.SubItems[2].Text = "-";
                    }
                    else
                        itemInSet.SubItems[2].Text = "-";
                }
            }
        }

        private void btnAddNewItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (onEdit == eEditType.PART)
                {
                    if (partsList != null)
                    {
                        PartsRecord newItem = new PartsRecord();
                        itemOnEdit = newItem;

                        partsList.Add(newItem);

                        ListViewItem newItemListView = new ListViewItem(newItem.Base.Name);
                        newItemListView.Tag = newItem.Base.TypeId;
                        lstParts.Items.Add(newItemListView);
                        lstParts.Items[lstSets.Items.Count - 1].Selected = true;
                        lstParts.Items[lstSets.Items.Count - 1].Focused = true;
                        lstParts.Focus();
                        lstParts.Select();
                    }
                }
                else
                {
                    if (setList != null)
                    {
                        SetItemRecord newItem = new SetItemRecord();
                        setOnEdit = newItem;

                        setList.Add(newItem);

                        ListViewItem newItemListView = new ListViewItem(newItem.Base.Name);
                        newItemListView.Tag = newItem.Base.TypeId;
                        lstSets.Items.Add(newItemListView);
                        lstSets.Items[lstSets.Items.Count - 1].Selected = true;
                        lstSets.Items[lstSets.Items.Count - 1].Focused = true;
                        lstSets.Focus();
                        lstSets.Select();
                    }
                }
            }
        }

        private void chkUseSetItemNamesFromParent_CheckedChanged(object sender, EventArgs e)
        {
            GetSetItemPartNameFromTypeID();
        }
    }
}
