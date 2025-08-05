using System.Drawing;

namespace PartsIffTool
{
    partial class PartEditor
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartEditor));
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lstParts = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.cmsItemList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setItemStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activateItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.setPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setShopAvailabilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableInShopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableInShopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.tabProperties = new System.Windows.Forms.TabControl();
            this.tabBasicProperties = new System.Windows.Forms.TabPage();
            this.txtItemType = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnLastSerialForCharacter = new System.Windows.Forms.Button();
            this.cmbPartCharacter = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.txtItemSerial = new System.Windows.Forms.TextBox();
            this.txtItemPos = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.lblRecordRegion = new System.Windows.Forms.Label();
            this.lblNameLen = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.picItemIcon = new System.Windows.Forms.PictureBox();
            this.lblEquippableWithLabel = new System.Windows.Forms.Label();
            this.txtItemEquippableWith = new System.Windows.Forms.TextBox();
            this.lblHideMaskLabel = new System.Windows.Forms.Label();
            this.txtItemHideMask = new System.Windows.Forms.TextBox();
            this.lblPosMaskLabel = new System.Windows.Forms.Label();
            this.txtItemPosMask = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbMaxLevel = new System.Windows.Forms.RadioButton();
            this.rbMinLevel = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbItemMinLevel = new System.Windows.Forms.ComboBox();
            this.lblItemCategoryLabel = new System.Windows.Forms.Label();
            this.cmbItemCategory = new System.Windows.Forms.ComboBox();
            this.txtItemIcon = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkItemActive = new System.Windows.Forms.CheckBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabShopProperties = new System.Windows.Forms.TabPage();
            this.label29 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtItemTime = new System.Windows.Forms.TextBox();
            this.txtItemTimeFlag = new System.Windows.Forms.TextBox();
            this.chkSaleEnd = new System.Windows.Forms.CheckBox();
            this.chkSaleStart = new System.Windows.Forms.CheckBox();
            this.dateSaleEnd = new System.Windows.Forms.DateTimePicker();
            this.dateSaleStart = new System.Windows.Forms.DateTimePicker();
            this.txtItemUsedPrice = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtItemStallPrice = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.chkItemIsReserve = new System.Windows.Forms.CheckBox();
            this.chkItemIsHot = new System.Windows.Forms.CheckBox();
            this.chkItemIsNew = new System.Windows.Forms.CheckBox();
            this.chkItemIsInStock = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rbItemCostsSpecial = new System.Windows.Forms.RadioButton();
            this.rbItemCostsCookies = new System.Windows.Forms.RadioButton();
            this.rbItemCostsPang = new System.Windows.Forms.RadioButton();
            this.txtItemCost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetHighUsedPrice = new System.Windows.Forms.Button();
            this.btnSetHighDiscountPrice = new System.Windows.Forms.Button();
            this.btnSetHighPrice = new System.Windows.Forms.Button();
            this.tabStatModifiers = new System.Windows.Forms.TabPage();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtItemCurveSlot = new System.Windows.Forms.TextBox();
            this.txtItemSpinSlot = new System.Windows.Forms.TextBox();
            this.txtItemImpactSlot = new System.Windows.Forms.TextBox();
            this.txtItemControlSlot = new System.Windows.Forms.TextBox();
            this.txtItemPowerSlot = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtItemCurve = new System.Windows.Forms.TextBox();
            this.txtItemSpin = new System.Windows.Forms.TextBox();
            this.txtItemImpact = new System.Windows.Forms.TextBox();
            this.txtItemControl = new System.Windows.Forms.TextBox();
            this.txtItemPower = new System.Windows.Forms.TextBox();
            this.txtCaddySlots = new System.Windows.Forms.TextBox();
            this.txtCharSlots = new System.Windows.Forms.TextBox();
            this.lblCaddyCardSlotsLabel = new System.Windows.Forms.Label();
            this.lblCharCardSlotsLabel = new System.Windows.Forms.Label();
            this.tabModelProperties = new System.Windows.Forms.TabPage();
            this.label35 = new System.Windows.Forms.Label();
            this.txtItemGroup = new System.Windows.Forms.TextBox();
            this.txtItemSubpart2 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtItemSubpart1 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtItemOrgTex3 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtItemOrgTex2 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtItemTex3 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtItemTex2 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtItemModel = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtItemOrgTex1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtItemTex1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGoToSubpart2 = new System.Windows.Forms.Button();
            this.btnGoToSubpart1 = new System.Windows.Forms.Button();
            this.tabSetItems = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.chkUseSetItemNamesFromParent = new System.Windows.Forms.CheckBox();
            this.lblSetItemCount = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.numSetItemAmount = new System.Windows.Forms.NumericUpDown();
            this.txtSetItemId = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.btnEditSetItemEntry = new System.Windows.Forms.Button();
            this.btnRemoveSetItemEntry = new System.Windows.Forms.Button();
            this.btnAddSetItem = new System.Windows.Forms.Button();
            this.lstSetItems = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbsNewPartIff = new System.Windows.Forms.ToolStripButton();
            this.tbsOpenPartIff = new System.Windows.Forms.ToolStripButton();
            this.tbsSavePartIff = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbsImportItems = new System.Windows.Forms.ToolStripButton();
            this.tbsModelTextureCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cleanUpItemNamesForWesternFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.useItemnamesFromThisFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useShopContentsFromThisFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbsGenerateSql = new System.Windows.Forms.ToolStripButton();
            this.tbsGiveItem = new System.Windows.Forms.ToolStripButton();
            this.cmbOutputRegion = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.cmbFilterByCharacter = new System.Windows.Forms.ComboBox();
            this.cmbFilterByCategory = new System.Windows.Forms.ComboBox();
            this.chkOnlyItemsNotInParent = new System.Windows.Forms.CheckBox();
            this.chkRealItemOnly = new System.Windows.Forms.CheckBox();
            this.tabLists = new System.Windows.Forms.TabControl();
            this.tabParts = new System.Windows.Forms.TabPage();
            this.tabSets = new System.Windows.Forms.TabPage();
            this.lstSets = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.chkOnlyShowItemInShop = new System.Windows.Forms.CheckBox();
            this.chkOnlyShowActiveItems = new System.Windows.Forms.CheckBox();
            this.btnModeChange = new System.Windows.Forms.Button();
            this.btnReturnToParentItem = new System.Windows.Forms.Button();
            this.btnAddNewItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnDiscardItemChange = new System.Windows.Forms.Button();
            this.btnApplyItemChange = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.picHorizBadge = new System.Windows.Forms.PictureBox();
            this.chkItemIsBasic = new System.Windows.Forms.CheckBox();
            this.cmsItemList.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.tabBasicProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItemIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabShopProperties.SuspendLayout();
            this.tabStatModifiers.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabModelProperties.SuspendLayout();
            this.tabSetItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSetItemAmount)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabLists.SuspendLayout();
            this.tabParts.SuspendLayout();
            this.tabSets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHorizBadge)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilter.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(7, 485);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(141, 21);
            this.txtFilter.TabIndex = 6;
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // lstParts
            // 
            this.lstParts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstParts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstParts.ContextMenuStrip = this.cmsItemList;
            this.lstParts.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstParts.FullRowSelect = true;
            this.lstParts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstParts.Location = new System.Drawing.Point(1, 3);
            this.lstParts.MultiSelect = false;
            this.lstParts.Name = "lstParts";
            this.lstParts.Size = new System.Drawing.Size(262, 355);
            this.lstParts.TabIndex = 5;
            this.lstParts.UseCompatibleStateImageBehavior = false;
            this.lstParts.View = System.Windows.Forms.View.Details;
            this.lstParts.ItemActivate += new System.EventHandler(this.lstParts_ItemActivate);
            this.lstParts.SelectedIndexChanged += new System.EventHandler(this.lstParts_ItemActivate);
            this.lstParts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstParts_KeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item Name";
            this.columnHeader1.Width = 240;
            // 
            // cmsItemList
            // 
            this.cmsItemList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setItemStatusToolStripMenuItem,
            this.toolStripMenuItem3,
            this.setPriceToolStripMenuItem,
            this.setShopAvailabilityToolStripMenuItem});
            this.cmsItemList.Name = "cmsItemList";
            this.cmsItemList.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsItemList.Size = new System.Drawing.Size(182, 76);
            // 
            // setItemStatusToolStripMenuItem
            // 
            this.setItemStatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activateItemToolStripMenuItem,
            this.deactivateItemToolStripMenuItem});
            this.setItemStatusToolStripMenuItem.Name = "setItemStatusToolStripMenuItem";
            this.setItemStatusToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.setItemStatusToolStripMenuItem.Text = "Set Item Status";
            // 
            // activateItemToolStripMenuItem
            // 
            this.activateItemToolStripMenuItem.Name = "activateItemToolStripMenuItem";
            this.activateItemToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.activateItemToolStripMenuItem.Text = "Activate Item";
            this.activateItemToolStripMenuItem.Click += new System.EventHandler(this.activateItemToolStripMenuItem_Click);
            // 
            // deactivateItemToolStripMenuItem
            // 
            this.deactivateItemToolStripMenuItem.Name = "deactivateItemToolStripMenuItem";
            this.deactivateItemToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.deactivateItemToolStripMenuItem.Text = "Deactivate Item";
            this.deactivateItemToolStripMenuItem.Click += new System.EventHandler(this.deactivateItemToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(178, 6);
            // 
            // setPriceToolStripMenuItem
            // 
            this.setPriceToolStripMenuItem.Name = "setPriceToolStripMenuItem";
            this.setPriceToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.setPriceToolStripMenuItem.Text = "Set Price";
            this.setPriceToolStripMenuItem.Click += new System.EventHandler(this.setPriceToolStripMenuItem_Click);
            // 
            // setShopAvailabilityToolStripMenuItem
            // 
            this.setShopAvailabilityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableInShopToolStripMenuItem,
            this.disableInShopToolStripMenuItem});
            this.setShopAvailabilityToolStripMenuItem.Name = "setShopAvailabilityToolStripMenuItem";
            this.setShopAvailabilityToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.setShopAvailabilityToolStripMenuItem.Text = "Set Shop Availability";
            // 
            // enableInShopToolStripMenuItem
            // 
            this.enableInShopToolStripMenuItem.Name = "enableInShopToolStripMenuItem";
            this.enableInShopToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.enableInShopToolStripMenuItem.Text = "Enable in Shop";
            this.enableInShopToolStripMenuItem.Click += new System.EventHandler(this.enableInShopToolStripMenuItem_Click);
            // 
            // disableInShopToolStripMenuItem
            // 
            this.disableInShopToolStripMenuItem.Name = "disableInShopToolStripMenuItem";
            this.disableInShopToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.disableInShopToolStripMenuItem.Text = "Disable in Shop";
            this.disableInShopToolStripMenuItem.Click += new System.EventHandler(this.disableInShopToolStripMenuItem_Click);
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "Name",
            "ID"});
            this.cmbFilterBy.Location = new System.Drawing.Point(156, 485);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(57, 21);
            this.cmbFilterBy.TabIndex = 7;
            // 
            // tabProperties
            // 
            this.tabProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabProperties.Controls.Add(this.tabBasicProperties);
            this.tabProperties.Controls.Add(this.tabShopProperties);
            this.tabProperties.Controls.Add(this.tabStatModifiers);
            this.tabProperties.Controls.Add(this.tabModelProperties);
            this.tabProperties.Controls.Add(this.tabSetItems);
            this.tabProperties.Location = new System.Drawing.Point(286, 66);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.SelectedIndex = 0;
            this.tabProperties.Size = new System.Drawing.Size(632, 464);
            this.tabProperties.TabIndex = 56;
            // 
            // tabBasicProperties
            // 
            this.tabBasicProperties.Controls.Add(this.txtItemType);
            this.tabBasicProperties.Controls.Add(this.button3);
            this.tabBasicProperties.Controls.Add(this.btnLastSerialForCharacter);
            this.tabBasicProperties.Controls.Add(this.cmbPartCharacter);
            this.tabBasicProperties.Controls.Add(this.label38);
            this.tabBasicProperties.Controls.Add(this.label37);
            this.tabBasicProperties.Controls.Add(this.txtItemSerial);
            this.tabBasicProperties.Controls.Add(this.txtItemPos);
            this.tabBasicProperties.Controls.Add(this.label34);
            this.tabBasicProperties.Controls.Add(this.lblRecordRegion);
            this.tabBasicProperties.Controls.Add(this.lblNameLen);
            this.tabBasicProperties.Controls.Add(this.label36);
            this.tabBasicProperties.Controls.Add(this.label31);
            this.tabBasicProperties.Controls.Add(this.picItemIcon);
            this.tabBasicProperties.Controls.Add(this.lblEquippableWithLabel);
            this.tabBasicProperties.Controls.Add(this.txtItemEquippableWith);
            this.tabBasicProperties.Controls.Add(this.lblHideMaskLabel);
            this.tabBasicProperties.Controls.Add(this.txtItemHideMask);
            this.tabBasicProperties.Controls.Add(this.lblPosMaskLabel);
            this.tabBasicProperties.Controls.Add(this.txtItemPosMask);
            this.tabBasicProperties.Controls.Add(this.panel1);
            this.tabBasicProperties.Controls.Add(this.label16);
            this.tabBasicProperties.Controls.Add(this.cmbItemMinLevel);
            this.tabBasicProperties.Controls.Add(this.lblItemCategoryLabel);
            this.tabBasicProperties.Controls.Add(this.cmbItemCategory);
            this.tabBasicProperties.Controls.Add(this.txtItemIcon);
            this.tabBasicProperties.Controls.Add(this.label13);
            this.tabBasicProperties.Controls.Add(this.txtItemId);
            this.tabBasicProperties.Controls.Add(this.label2);
            this.tabBasicProperties.Controls.Add(this.chkItemActive);
            this.tabBasicProperties.Controls.Add(this.txtItemName);
            this.tabBasicProperties.Controls.Add(this.label1);
            this.tabBasicProperties.Location = new System.Drawing.Point(4, 22);
            this.tabBasicProperties.Name = "tabBasicProperties";
            this.tabBasicProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasicProperties.Size = new System.Drawing.Size(624, 438);
            this.tabBasicProperties.TabIndex = 0;
            this.tabBasicProperties.Text = "Basic Properties";
            this.tabBasicProperties.UseVisualStyleBackColor = true;
            // 
            // txtItemType
            // 
            this.txtItemType.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemType.Location = new System.Drawing.Point(369, 148);
            this.txtItemType.Name = "txtItemType";
            this.txtItemType.Size = new System.Drawing.Size(143, 21);
            this.txtItemType.TabIndex = 132;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(369, 227);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 23);
            this.button3.TabIndex = 131;
            this.button3.Text = "Re-generate Item ID";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnRegenerateItemId);
            // 
            // btnLastSerialForCharacter
            // 
            this.btnLastSerialForCharacter.Image = global::PartsIffTool.Properties.Resources.bullet_arrow_up;
            this.btnLastSerialForCharacter.Location = new System.Drawing.Point(518, 199);
            this.btnLastSerialForCharacter.Name = "btnLastSerialForCharacter";
            this.btnLastSerialForCharacter.Size = new System.Drawing.Size(23, 23);
            this.btnLastSerialForCharacter.TabIndex = 129;
            this.btnLastSerialForCharacter.UseVisualStyleBackColor = true;
            this.btnLastSerialForCharacter.Click += new System.EventHandler(this.btnLastSerialForCharacter_Click);
            // 
            // cmbPartCharacter
            // 
            this.cmbPartCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPartCharacter.FormattingEnabled = true;
            this.cmbPartCharacter.Location = new System.Drawing.Point(106, 53);
            this.cmbPartCharacter.Name = "cmbPartCharacter";
            this.cmbPartCharacter.Size = new System.Drawing.Size(141, 21);
            this.cmbPartCharacter.TabIndex = 128;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(282, 198);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(81, 23);
            this.label38.TabIndex = 127;
            this.label38.Text = "Item Serial:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(283, 172);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(81, 23);
            this.label37.TabIndex = 126;
            this.label37.Text = "Item Pos:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemSerial
            // 
            this.txtItemSerial.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSerial.Location = new System.Drawing.Point(369, 200);
            this.txtItemSerial.Name = "txtItemSerial";
            this.txtItemSerial.Size = new System.Drawing.Size(143, 21);
            this.txtItemSerial.TabIndex = 125;
            // 
            // txtItemPos
            // 
            this.txtItemPos.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemPos.Location = new System.Drawing.Point(369, 174);
            this.txtItemPos.Name = "txtItemPos";
            this.txtItemPos.Size = new System.Drawing.Size(143, 21);
            this.txtItemPos.TabIndex = 124;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(19, 51);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(81, 23);
            this.label34.TabIndex = 123;
            this.label34.Text = "Character:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRecordRegion
            // 
            this.lblRecordRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecordRegion.Location = new System.Drawing.Point(421, 412);
            this.lblRecordRegion.Name = "lblRecordRegion";
            this.lblRecordRegion.Size = new System.Drawing.Size(200, 23);
            this.lblRecordRegion.TabIndex = 121;
            this.lblRecordRegion.Text = "Region/MagicNum: -";
            this.lblRecordRegion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNameLen
            // 
            this.lblNameLen.AutoSize = true;
            this.lblNameLen.Location = new System.Drawing.Point(337, 28);
            this.lblNameLen.Name = "lblNameLen";
            this.lblNameLen.Size = new System.Drawing.Size(30, 13);
            this.lblNameLen.TabIndex = 120;
            this.lblNameLen.Text = "0/40";
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(282, 145);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(81, 23);
            this.label36.TabIndex = 119;
            this.label36.Text = "Item Type:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(268, 51);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(95, 23);
            this.label31.TabIndex = 102;
            this.label31.Text = "Item Preview:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picItemIcon
            // 
            this.picItemIcon.BackgroundImage = global::PartsIffTool.Properties.Resources.item_preview_bg;
            this.picItemIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picItemIcon.Image = global::PartsIffTool.Properties.Resources.item_no_preview;
            this.picItemIcon.Location = new System.Drawing.Point(369, 51);
            this.picItemIcon.Name = "picItemIcon";
            this.picItemIcon.Size = new System.Drawing.Size(90, 90);
            this.picItemIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picItemIcon.TabIndex = 101;
            this.picItemIcon.TabStop = false;
            // 
            // lblEquippableWithLabel
            // 
            this.lblEquippableWithLabel.Location = new System.Drawing.Point(268, 254);
            this.lblEquippableWithLabel.Name = "lblEquippableWithLabel";
            this.lblEquippableWithLabel.Size = new System.Drawing.Size(95, 23);
            this.lblEquippableWithLabel.TabIndex = 100;
            this.lblEquippableWithLabel.Text = "Equippable with:";
            this.lblEquippableWithLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemEquippableWith
            // 
            this.txtItemEquippableWith.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemEquippableWith.Location = new System.Drawing.Point(369, 256);
            this.txtItemEquippableWith.Name = "txtItemEquippableWith";
            this.txtItemEquippableWith.Size = new System.Drawing.Size(142, 21);
            this.txtItemEquippableWith.TabIndex = 99;
            // 
            // lblHideMaskLabel
            // 
            this.lblHideMaskLabel.Location = new System.Drawing.Point(5, 364);
            this.lblHideMaskLabel.Name = "lblHideMaskLabel";
            this.lblHideMaskLabel.Size = new System.Drawing.Size(95, 23);
            this.lblHideMaskLabel.TabIndex = 98;
            this.lblHideMaskLabel.Text = "HideMask:";
            this.lblHideMaskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemHideMask
            // 
            this.txtItemHideMask.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemHideMask.Location = new System.Drawing.Point(106, 366);
            this.txtItemHideMask.Name = "txtItemHideMask";
            this.txtItemHideMask.Size = new System.Drawing.Size(261, 21);
            this.txtItemHideMask.TabIndex = 97;
            // 
            // lblPosMaskLabel
            // 
            this.lblPosMaskLabel.Location = new System.Drawing.Point(5, 337);
            this.lblPosMaskLabel.Name = "lblPosMaskLabel";
            this.lblPosMaskLabel.Size = new System.Drawing.Size(95, 23);
            this.lblPosMaskLabel.TabIndex = 96;
            this.lblPosMaskLabel.Text = "PosMask:";
            this.lblPosMaskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemPosMask
            // 
            this.txtItemPosMask.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemPosMask.Location = new System.Drawing.Point(106, 339);
            this.txtItemPosMask.Name = "txtItemPosMask";
            this.txtItemPosMask.Size = new System.Drawing.Size(261, 21);
            this.txtItemPosMask.TabIndex = 95;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbMaxLevel);
            this.panel1.Controls.Add(this.rbMinLevel);
            this.panel1.Location = new System.Drawing.Point(42, 229);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 49);
            this.panel1.TabIndex = 94;
            // 
            // rbMaxLevel
            // 
            this.rbMaxLevel.AutoSize = true;
            this.rbMaxLevel.Location = new System.Drawing.Point(64, 26);
            this.rbMaxLevel.Name = "rbMaxLevel";
            this.rbMaxLevel.Size = new System.Drawing.Size(98, 17);
            this.rbMaxLevel.TabIndex = 53;
            this.rbMaxLevel.Text = "Maximum Level";
            this.rbMaxLevel.UseVisualStyleBackColor = true;
            // 
            // rbMinLevel
            // 
            this.rbMinLevel.AutoSize = true;
            this.rbMinLevel.Checked = true;
            this.rbMinLevel.Location = new System.Drawing.Point(64, 3);
            this.rbMinLevel.Name = "rbMinLevel";
            this.rbMinLevel.Size = new System.Drawing.Size(95, 17);
            this.rbMinLevel.TabIndex = 52;
            this.rbMinLevel.TabStop = true;
            this.rbMinLevel.Text = "Minimum Level";
            this.rbMinLevel.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(5, 200);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 23);
            this.label16.TabIndex = 92;
            this.label16.Text = "Level:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbItemMinLevel
            // 
            this.cmbItemMinLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemMinLevel.FormattingEnabled = true;
            this.cmbItemMinLevel.Items.AddRange(new object[] {
            "Rookie F",
            "Rookie E",
            "Rookie D",
            "Rookie C",
            "Rookie B",
            "Rookie A",
            "Beginner E",
            "Beginner D",
            "Beginner C",
            "Beginner B",
            "Beginner A",
            "Junior E",
            "Junior D",
            "Junior C",
            "Junior B",
            "Junior A",
            "Senior E",
            "Senior D",
            "Senior C",
            "Senior B",
            "Senior A",
            "Amateur E",
            "Amateur D",
            "Amateur C",
            "Amateur B",
            "Amateur A",
            "Semi-Pro E",
            "Semi-Pro D",
            "Semi-Pro C",
            "Semi-Pro B",
            "Semi-Pro A",
            "Pro E",
            "Pro D",
            "Pro C",
            "Pro B",
            "Pro A",
            "National Pro E",
            "National Pro D",
            "National Pro C",
            "National Pro B",
            "National Pro A",
            "World Pro E",
            "World Pro D",
            "World Pro C",
            "World Pro B",
            "World Pro A",
            "Master E",
            "Master D",
            "Master C",
            "Master B",
            "Master A",
            "Top Master E",
            "Top Master D",
            "Top Master C",
            "Top Master B",
            "Top Master A",
            "World Master E",
            "World Master D",
            "World Master C",
            "World Master B",
            "World Master A",
            "Legend E",
            "Legend D",
            "Legend C",
            "Legend B",
            "Legend A"});
            this.cmbItemMinLevel.Location = new System.Drawing.Point(106, 202);
            this.cmbItemMinLevel.Name = "cmbItemMinLevel";
            this.cmbItemMinLevel.Size = new System.Drawing.Size(142, 21);
            this.cmbItemMinLevel.TabIndex = 74;
            // 
            // lblItemCategoryLabel
            // 
            this.lblItemCategoryLabel.Location = new System.Drawing.Point(5, 284);
            this.lblItemCategoryLabel.Name = "lblItemCategoryLabel";
            this.lblItemCategoryLabel.Size = new System.Drawing.Size(95, 23);
            this.lblItemCategoryLabel.TabIndex = 91;
            this.lblItemCategoryLabel.Text = "Item Category:";
            this.lblItemCategoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbItemCategory
            // 
            this.cmbItemCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemCategory.FormattingEnabled = true;
            this.cmbItemCategory.Items.AddRange(new object[] {
            "Upper Body",
            "Lower Body",
            "Hat",
            "Gloves",
            "Shoes",
            "Accessory",
            "UCC Blank Cloth",
            "UCC Copy Cloth"});
            this.cmbItemCategory.Location = new System.Drawing.Point(106, 286);
            this.cmbItemCategory.Name = "cmbItemCategory";
            this.cmbItemCategory.Size = new System.Drawing.Size(142, 21);
            this.cmbItemCategory.TabIndex = 73;
            // 
            // txtItemIcon
            // 
            this.txtItemIcon.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemIcon.Location = new System.Drawing.Point(105, 175);
            this.txtItemIcon.Name = "txtItemIcon";
            this.txtItemIcon.Size = new System.Drawing.Size(143, 21);
            this.txtItemIcon.TabIndex = 80;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(18, 174);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 23);
            this.label13.TabIndex = 88;
            this.label13.Text = "Icon:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemId
            // 
            this.txtItemId.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemId.Location = new System.Drawing.Point(105, 148);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(143, 21);
            this.txtItemId.TabIndex = 65;
            this.txtItemId.Text = "0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 62;
            this.label2.Text = "Item ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkItemActive
            // 
            this.chkItemActive.Location = new System.Drawing.Point(105, 80);
            this.chkItemActive.Name = "chkItemActive";
            this.chkItemActive.Size = new System.Drawing.Size(100, 24);
            this.chkItemActive.TabIndex = 64;
            this.chkItemActive.Text = "Item Active";
            this.chkItemActive.UseVisualStyleBackColor = true;
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(106, 24);
            this.txtItemName.MaxLength = 40;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(225, 21);
            this.txtItemName.TabIndex = 63;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 61;
            this.label1.Text = "Item Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabShopProperties
            // 
            this.tabShopProperties.Controls.Add(this.chkItemIsBasic);
            this.tabShopProperties.Controls.Add(this.label29);
            this.tabShopProperties.Controls.Add(this.label23);
            this.tabShopProperties.Controls.Add(this.txtItemTime);
            this.tabShopProperties.Controls.Add(this.txtItemTimeFlag);
            this.tabShopProperties.Controls.Add(this.chkSaleEnd);
            this.tabShopProperties.Controls.Add(this.chkSaleStart);
            this.tabShopProperties.Controls.Add(this.dateSaleEnd);
            this.tabShopProperties.Controls.Add(this.dateSaleStart);
            this.tabShopProperties.Controls.Add(this.txtItemUsedPrice);
            this.tabShopProperties.Controls.Add(this.label19);
            this.tabShopProperties.Controls.Add(this.txtItemStallPrice);
            this.tabShopProperties.Controls.Add(this.label18);
            this.tabShopProperties.Controls.Add(this.chkItemIsReserve);
            this.tabShopProperties.Controls.Add(this.chkItemIsHot);
            this.tabShopProperties.Controls.Add(this.chkItemIsNew);
            this.tabShopProperties.Controls.Add(this.chkItemIsInStock);
            this.tabShopProperties.Controls.Add(this.label14);
            this.tabShopProperties.Controls.Add(this.rbItemCostsSpecial);
            this.tabShopProperties.Controls.Add(this.rbItemCostsCookies);
            this.tabShopProperties.Controls.Add(this.rbItemCostsPang);
            this.tabShopProperties.Controls.Add(this.txtItemCost);
            this.tabShopProperties.Controls.Add(this.label3);
            this.tabShopProperties.Controls.Add(this.btnSetHighUsedPrice);
            this.tabShopProperties.Controls.Add(this.btnSetHighDiscountPrice);
            this.tabShopProperties.Controls.Add(this.btnSetHighPrice);
            this.tabShopProperties.Location = new System.Drawing.Point(4, 22);
            this.tabShopProperties.Name = "tabShopProperties";
            this.tabShopProperties.Size = new System.Drawing.Size(624, 438);
            this.tabShopProperties.TabIndex = 3;
            this.tabShopProperties.Text = "Shop";
            this.tabShopProperties.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(314, 305);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(56, 13);
            this.label29.TabIndex = 130;
            this.label29.Text = "Time Flag:";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(275, 273);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(95, 23);
            this.label23.TabIndex = 129;
            this.label23.Text = "Time:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemTime
            // 
            this.txtItemTime.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemTime.Location = new System.Drawing.Point(386, 274);
            this.txtItemTime.Name = "txtItemTime";
            this.txtItemTime.Size = new System.Drawing.Size(43, 21);
            this.txtItemTime.TabIndex = 128;
            this.txtItemTime.Text = "0";
            // 
            // txtItemTimeFlag
            // 
            this.txtItemTimeFlag.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemTimeFlag.Location = new System.Drawing.Point(386, 301);
            this.txtItemTimeFlag.Name = "txtItemTimeFlag";
            this.txtItemTimeFlag.Size = new System.Drawing.Size(97, 22);
            this.txtItemTimeFlag.TabIndex = 127;
            // 
            // chkSaleEnd
            // 
            this.chkSaleEnd.AutoSize = true;
            this.chkSaleEnd.Location = new System.Drawing.Point(328, 206);
            this.chkSaleEnd.Name = "chkSaleEnd";
            this.chkSaleEnd.Size = new System.Drawing.Size(82, 17);
            this.chkSaleEnd.TabIndex = 126;
            this.chkSaleEnd.Text = "Sale ends...";
            this.chkSaleEnd.UseVisualStyleBackColor = true;
            // 
            // chkSaleStart
            // 
            this.chkSaleStart.AutoSize = true;
            this.chkSaleStart.Location = new System.Drawing.Point(328, 160);
            this.chkSaleStart.Name = "chkSaleStart";
            this.chkSaleStart.Size = new System.Drawing.Size(84, 17);
            this.chkSaleStart.TabIndex = 125;
            this.chkSaleStart.Text = "Sale starts...";
            this.chkSaleStart.UseVisualStyleBackColor = true;
            // 
            // dateSaleEnd
            // 
            this.dateSaleEnd.Location = new System.Drawing.Point(328, 226);
            this.dateSaleEnd.Name = "dateSaleEnd";
            this.dateSaleEnd.Size = new System.Drawing.Size(200, 20);
            this.dateSaleEnd.TabIndex = 124;
            // 
            // dateSaleStart
            // 
            this.dateSaleStart.Location = new System.Drawing.Point(328, 180);
            this.dateSaleStart.Name = "dateSaleStart";
            this.dateSaleStart.Size = new System.Drawing.Size(200, 20);
            this.dateSaleStart.TabIndex = 123;
            // 
            // txtItemUsedPrice
            // 
            this.txtItemUsedPrice.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemUsedPrice.Location = new System.Drawing.Point(386, 46);
            this.txtItemUsedPrice.Name = "txtItemUsedPrice";
            this.txtItemUsedPrice.Size = new System.Drawing.Size(113, 21);
            this.txtItemUsedPrice.TabIndex = 120;
            this.txtItemUsedPrice.Text = "0";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(285, 45);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(95, 23);
            this.label19.TabIndex = 122;
            this.label19.Text = "Used Price:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemStallPrice
            // 
            this.txtItemStallPrice.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemStallPrice.Location = new System.Drawing.Point(386, 19);
            this.txtItemStallPrice.Name = "txtItemStallPrice";
            this.txtItemStallPrice.Size = new System.Drawing.Size(113, 21);
            this.txtItemStallPrice.TabIndex = 117;
            this.txtItemStallPrice.Text = "0";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(285, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 23);
            this.label18.TabIndex = 119;
            this.label18.Text = "Discount Price:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkItemIsReserve
            // 
            this.chkItemIsReserve.AutoSize = true;
            this.chkItemIsReserve.Location = new System.Drawing.Point(117, 183);
            this.chkItemIsReserve.Name = "chkItemIsReserve";
            this.chkItemIsReserve.Size = new System.Drawing.Size(80, 17);
            this.chkItemIsReserve.TabIndex = 115;
            this.chkItemIsReserve.Text = "Not giftable";
            this.chkItemIsReserve.UseVisualStyleBackColor = true;
            // 
            // chkItemIsHot
            // 
            this.chkItemIsHot.AutoSize = true;
            this.chkItemIsHot.Location = new System.Drawing.Point(117, 229);
            this.chkItemIsHot.Name = "chkItemIsHot";
            this.chkItemIsHot.Size = new System.Drawing.Size(102, 17);
            this.chkItemIsHot.TabIndex = 114;
            this.chkItemIsHot.Text = "Tag Item as Hot";
            this.chkItemIsHot.UseVisualStyleBackColor = true;
            // 
            // chkItemIsNew
            // 
            this.chkItemIsNew.AutoSize = true;
            this.chkItemIsNew.Location = new System.Drawing.Point(117, 206);
            this.chkItemIsNew.Name = "chkItemIsNew";
            this.chkItemIsNew.Size = new System.Drawing.Size(107, 17);
            this.chkItemIsNew.TabIndex = 113;
            this.chkItemIsNew.Text = "Tag Item as New";
            this.chkItemIsNew.UseVisualStyleBackColor = true;
            // 
            // chkItemIsInStock
            // 
            this.chkItemIsInStock.AutoSize = true;
            this.chkItemIsInStock.Location = new System.Drawing.Point(117, 160);
            this.chkItemIsInStock.Name = "chkItemIsInStock";
            this.chkItemIsInStock.Size = new System.Drawing.Size(98, 17);
            this.chkItemIsInStock.TabIndex = 112;
            this.chkItemIsInStock.Text = "Item is in Stock";
            this.chkItemIsInStock.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(16, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 23);
            this.label14.TabIndex = 110;
            this.label14.Text = "Shop Tag:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbItemCostsSpecial
            // 
            this.rbItemCostsSpecial.AutoSize = true;
            this.rbItemCostsSpecial.Location = new System.Drawing.Point(117, 114);
            this.rbItemCostsSpecial.Name = "rbItemCostsSpecial";
            this.rbItemCostsSpecial.Size = new System.Drawing.Size(84, 17);
            this.rbItemCostsSpecial.TabIndex = 107;
            this.rbItemCostsSpecial.Text = "Price not set";
            this.rbItemCostsSpecial.UseVisualStyleBackColor = true;
            // 
            // rbItemCostsCookies
            // 
            this.rbItemCostsCookies.AutoSize = true;
            this.rbItemCostsCookies.Location = new System.Drawing.Point(117, 91);
            this.rbItemCostsCookies.Name = "rbItemCostsCookies";
            this.rbItemCostsCookies.Size = new System.Drawing.Size(101, 17);
            this.rbItemCostsCookies.TabIndex = 106;
            this.rbItemCostsCookies.Text = "Price in Cookies";
            this.rbItemCostsCookies.UseVisualStyleBackColor = true;
            // 
            // rbItemCostsPang
            // 
            this.rbItemCostsPang.AutoSize = true;
            this.rbItemCostsPang.Checked = true;
            this.rbItemCostsPang.Location = new System.Drawing.Point(117, 68);
            this.rbItemCostsPang.Name = "rbItemCostsPang";
            this.rbItemCostsPang.Size = new System.Drawing.Size(88, 17);
            this.rbItemCostsPang.TabIndex = 105;
            this.rbItemCostsPang.TabStop = true;
            this.rbItemCostsPang.Text = "Price in Pang";
            this.rbItemCostsPang.UseVisualStyleBackColor = true;
            // 
            // txtItemCost
            // 
            this.txtItemCost.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCost.Location = new System.Drawing.Point(117, 18);
            this.txtItemCost.Name = "txtItemCost";
            this.txtItemCost.Size = new System.Drawing.Size(113, 21);
            this.txtItemCost.TabIndex = 103;
            this.txtItemCost.Text = "0";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 109;
            this.label3.Text = "Shop Price:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSetHighUsedPrice
            // 
            this.btnSetHighUsedPrice.Image = global::PartsIffTool.Properties.Resources.bullet_arrow_up;
            this.btnSetHighUsedPrice.Location = new System.Drawing.Point(505, 45);
            this.btnSetHighUsedPrice.Name = "btnSetHighUsedPrice";
            this.btnSetHighUsedPrice.Size = new System.Drawing.Size(23, 23);
            this.btnSetHighUsedPrice.TabIndex = 121;
            this.btnSetHighUsedPrice.UseVisualStyleBackColor = true;
            this.btnSetHighUsedPrice.Click += new System.EventHandler(this.btnSetHighUsedPrice_Click);
            // 
            // btnSetHighDiscountPrice
            // 
            this.btnSetHighDiscountPrice.Image = global::PartsIffTool.Properties.Resources.bullet_arrow_up;
            this.btnSetHighDiscountPrice.Location = new System.Drawing.Point(505, 18);
            this.btnSetHighDiscountPrice.Name = "btnSetHighDiscountPrice";
            this.btnSetHighDiscountPrice.Size = new System.Drawing.Size(23, 23);
            this.btnSetHighDiscountPrice.TabIndex = 118;
            this.btnSetHighDiscountPrice.UseVisualStyleBackColor = true;
            this.btnSetHighDiscountPrice.Click += new System.EventHandler(this.btnSetHighDiscountPrice_Click);
            // 
            // btnSetHighPrice
            // 
            this.btnSetHighPrice.Image = global::PartsIffTool.Properties.Resources.bullet_arrow_up;
            this.btnSetHighPrice.Location = new System.Drawing.Point(236, 17);
            this.btnSetHighPrice.Name = "btnSetHighPrice";
            this.btnSetHighPrice.Size = new System.Drawing.Size(23, 23);
            this.btnSetHighPrice.TabIndex = 104;
            this.btnSetHighPrice.UseVisualStyleBackColor = true;
            this.btnSetHighPrice.Click += new System.EventHandler(this.btnSetHighPrice_Click);
            // 
            // tabStatModifiers
            // 
            this.tabStatModifiers.Controls.Add(this.label28);
            this.tabStatModifiers.Controls.Add(this.textBox3);
            this.tabStatModifiers.Controls.Add(this.groupBox2);
            this.tabStatModifiers.Controls.Add(this.label8);
            this.tabStatModifiers.Controls.Add(this.label7);
            this.tabStatModifiers.Controls.Add(this.label6);
            this.tabStatModifiers.Controls.Add(this.label5);
            this.tabStatModifiers.Controls.Add(this.label4);
            this.tabStatModifiers.Controls.Add(this.groupBox1);
            this.tabStatModifiers.Controls.Add(this.txtCaddySlots);
            this.tabStatModifiers.Controls.Add(this.txtCharSlots);
            this.tabStatModifiers.Controls.Add(this.lblCaddyCardSlotsLabel);
            this.tabStatModifiers.Controls.Add(this.lblCharCardSlotsLabel);
            this.tabStatModifiers.Location = new System.Drawing.Point(4, 22);
            this.tabStatModifiers.Name = "tabStatModifiers";
            this.tabStatModifiers.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatModifiers.Size = new System.Drawing.Size(624, 438);
            this.tabStatModifiers.TabIndex = 1;
            this.tabStatModifiers.Text = "Stat Modifiers";
            this.tabStatModifiers.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(327, 188);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(39, 13);
            this.label28.TabIndex = 119;
            this.label28.Text = "Points:";
            this.label28.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(382, 184);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(97, 22);
            this.textBox3.TabIndex = 114;
            this.textBox3.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtItemCurveSlot);
            this.groupBox2.Controls.Add(this.txtItemSpinSlot);
            this.groupBox2.Controls.Add(this.txtItemImpactSlot);
            this.groupBox2.Controls.Add(this.txtItemControlSlot);
            this.groupBox2.Controls.Add(this.txtItemPowerSlot);
            this.groupBox2.Location = new System.Drawing.Point(187, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(63, 158);
            this.groupBox2.TabIndex = 103;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Slots:";
            // 
            // txtItemCurveSlot
            // 
            this.txtItemCurveSlot.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCurveSlot.Location = new System.Drawing.Point(10, 129);
            this.txtItemCurveSlot.MaxLength = 3;
            this.txtItemCurveSlot.Name = "txtItemCurveSlot";
            this.txtItemCurveSlot.Size = new System.Drawing.Size(43, 21);
            this.txtItemCurveSlot.TabIndex = 9;
            this.txtItemCurveSlot.Text = "0";
            // 
            // txtItemSpinSlot
            // 
            this.txtItemSpinSlot.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSpinSlot.Location = new System.Drawing.Point(10, 101);
            this.txtItemSpinSlot.MaxLength = 3;
            this.txtItemSpinSlot.Name = "txtItemSpinSlot";
            this.txtItemSpinSlot.Size = new System.Drawing.Size(43, 21);
            this.txtItemSpinSlot.TabIndex = 7;
            this.txtItemSpinSlot.Text = "0";
            // 
            // txtItemImpactSlot
            // 
            this.txtItemImpactSlot.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemImpactSlot.Location = new System.Drawing.Point(10, 73);
            this.txtItemImpactSlot.MaxLength = 3;
            this.txtItemImpactSlot.Name = "txtItemImpactSlot";
            this.txtItemImpactSlot.Size = new System.Drawing.Size(43, 21);
            this.txtItemImpactSlot.TabIndex = 5;
            this.txtItemImpactSlot.Text = "0";
            // 
            // txtItemControlSlot
            // 
            this.txtItemControlSlot.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemControlSlot.Location = new System.Drawing.Point(10, 46);
            this.txtItemControlSlot.MaxLength = 3;
            this.txtItemControlSlot.Name = "txtItemControlSlot";
            this.txtItemControlSlot.Size = new System.Drawing.Size(43, 21);
            this.txtItemControlSlot.TabIndex = 3;
            this.txtItemControlSlot.Text = "0";
            // 
            // txtItemPowerSlot
            // 
            this.txtItemPowerSlot.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemPowerSlot.Location = new System.Drawing.Point(10, 19);
            this.txtItemPowerSlot.MaxLength = 3;
            this.txtItemPowerSlot.Name = "txtItemPowerSlot";
            this.txtItemPowerSlot.Size = new System.Drawing.Size(43, 21);
            this.txtItemPowerSlot.TabIndex = 1;
            this.txtItemPowerSlot.Text = "0";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(24, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 23);
            this.label8.TabIndex = 108;
            this.label8.Text = "Curve:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(24, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 23);
            this.label7.TabIndex = 107;
            this.label7.Text = "Spin:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 23);
            this.label6.TabIndex = 106;
            this.label6.Text = "Impact:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 23);
            this.label5.TabIndex = 105;
            this.label5.Text = "Control:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 23);
            this.label4.TabIndex = 104;
            this.label4.Text = "Power:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtItemCurve);
            this.groupBox1.Controls.Add(this.txtItemSpin);
            this.groupBox1.Controls.Add(this.txtItemImpact);
            this.groupBox1.Controls.Add(this.txtItemControl);
            this.groupBox1.Controls.Add(this.txtItemPower);
            this.groupBox1.Location = new System.Drawing.Point(107, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(63, 158);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stats:";
            // 
            // txtItemCurve
            // 
            this.txtItemCurve.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCurve.Location = new System.Drawing.Point(10, 129);
            this.txtItemCurve.MaxLength = 3;
            this.txtItemCurve.Name = "txtItemCurve";
            this.txtItemCurve.Size = new System.Drawing.Size(43, 21);
            this.txtItemCurve.TabIndex = 9;
            this.txtItemCurve.Text = "0";
            // 
            // txtItemSpin
            // 
            this.txtItemSpin.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSpin.Location = new System.Drawing.Point(10, 101);
            this.txtItemSpin.MaxLength = 3;
            this.txtItemSpin.Name = "txtItemSpin";
            this.txtItemSpin.Size = new System.Drawing.Size(43, 21);
            this.txtItemSpin.TabIndex = 7;
            this.txtItemSpin.Text = "0";
            // 
            // txtItemImpact
            // 
            this.txtItemImpact.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemImpact.Location = new System.Drawing.Point(10, 73);
            this.txtItemImpact.MaxLength = 3;
            this.txtItemImpact.Name = "txtItemImpact";
            this.txtItemImpact.Size = new System.Drawing.Size(43, 21);
            this.txtItemImpact.TabIndex = 5;
            this.txtItemImpact.Text = "0";
            // 
            // txtItemControl
            // 
            this.txtItemControl.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemControl.Location = new System.Drawing.Point(10, 46);
            this.txtItemControl.MaxLength = 3;
            this.txtItemControl.Name = "txtItemControl";
            this.txtItemControl.Size = new System.Drawing.Size(43, 21);
            this.txtItemControl.TabIndex = 3;
            this.txtItemControl.Text = "0";
            // 
            // txtItemPower
            // 
            this.txtItemPower.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemPower.Location = new System.Drawing.Point(10, 19);
            this.txtItemPower.MaxLength = 3;
            this.txtItemPower.Name = "txtItemPower";
            this.txtItemPower.Size = new System.Drawing.Size(43, 21);
            this.txtItemPower.TabIndex = 1;
            this.txtItemPower.Text = "0";
            // 
            // txtCaddySlots
            // 
            this.txtCaddySlots.Font = new System.Drawing.Font("Courier New", 9F);
            this.txtCaddySlots.Location = new System.Drawing.Point(382, 68);
            this.txtCaddySlots.Name = "txtCaddySlots";
            this.txtCaddySlots.Size = new System.Drawing.Size(43, 21);
            this.txtCaddySlots.TabIndex = 101;
            this.txtCaddySlots.Text = "0";
            // 
            // txtCharSlots
            // 
            this.txtCharSlots.Font = new System.Drawing.Font("Courier New", 9F);
            this.txtCharSlots.Location = new System.Drawing.Point(382, 41);
            this.txtCharSlots.Name = "txtCharSlots";
            this.txtCharSlots.Size = new System.Drawing.Size(43, 21);
            this.txtCharSlots.TabIndex = 100;
            this.txtCharSlots.Text = "0";
            // 
            // lblCaddyCardSlotsLabel
            // 
            this.lblCaddyCardSlotsLabel.Location = new System.Drawing.Point(271, 66);
            this.lblCaddyCardSlotsLabel.Name = "lblCaddyCardSlotsLabel";
            this.lblCaddyCardSlotsLabel.Size = new System.Drawing.Size(95, 23);
            this.lblCaddyCardSlotsLabel.TabIndex = 99;
            this.lblCaddyCardSlotsLabel.Text = "Caddy Card Slots:";
            this.lblCaddyCardSlotsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCharCardSlotsLabel
            // 
            this.lblCharCardSlotsLabel.Location = new System.Drawing.Point(271, 39);
            this.lblCharCardSlotsLabel.Name = "lblCharCardSlotsLabel";
            this.lblCharCardSlotsLabel.Size = new System.Drawing.Size(95, 23);
            this.lblCharCardSlotsLabel.TabIndex = 98;
            this.lblCharCardSlotsLabel.Text = "Char Card Slots:";
            this.lblCharCardSlotsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabModelProperties
            // 
            this.tabModelProperties.Controls.Add(this.label35);
            this.tabModelProperties.Controls.Add(this.txtItemGroup);
            this.tabModelProperties.Controls.Add(this.txtItemSubpart2);
            this.tabModelProperties.Controls.Add(this.label33);
            this.tabModelProperties.Controls.Add(this.txtItemSubpart1);
            this.tabModelProperties.Controls.Add(this.label32);
            this.tabModelProperties.Controls.Add(this.txtItemOrgTex3);
            this.tabModelProperties.Controls.Add(this.label24);
            this.tabModelProperties.Controls.Add(this.txtItemOrgTex2);
            this.tabModelProperties.Controls.Add(this.label22);
            this.tabModelProperties.Controls.Add(this.txtItemTex3);
            this.tabModelProperties.Controls.Add(this.label21);
            this.tabModelProperties.Controls.Add(this.txtItemTex2);
            this.tabModelProperties.Controls.Add(this.label20);
            this.tabModelProperties.Controls.Add(this.txtItemModel);
            this.tabModelProperties.Controls.Add(this.label12);
            this.tabModelProperties.Controls.Add(this.txtItemOrgTex1);
            this.tabModelProperties.Controls.Add(this.label11);
            this.tabModelProperties.Controls.Add(this.txtItemTex1);
            this.tabModelProperties.Controls.Add(this.label9);
            this.tabModelProperties.Controls.Add(this.btnGoToSubpart2);
            this.tabModelProperties.Controls.Add(this.btnGoToSubpart1);
            this.tabModelProperties.Location = new System.Drawing.Point(4, 22);
            this.tabModelProperties.Name = "tabModelProperties";
            this.tabModelProperties.Size = new System.Drawing.Size(624, 438);
            this.tabModelProperties.TabIndex = 2;
            this.tabModelProperties.Text = "Model";
            this.tabModelProperties.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(290, 192);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(81, 23);
            this.label35.TabIndex = 116;
            this.label35.Text = "Item Group:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemGroup
            // 
            this.txtItemGroup.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemGroup.Location = new System.Drawing.Point(377, 194);
            this.txtItemGroup.Name = "txtItemGroup";
            this.txtItemGroup.Size = new System.Drawing.Size(143, 21);
            this.txtItemGroup.TabIndex = 111;
            // 
            // txtItemSubpart2
            // 
            this.txtItemSubpart2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSubpart2.Location = new System.Drawing.Point(101, 192);
            this.txtItemSubpart2.Name = "txtItemSubpart2";
            this.txtItemSubpart2.Size = new System.Drawing.Size(114, 21);
            this.txtItemSubpart2.TabIndex = 106;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(14, 191);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(81, 23);
            this.label33.TabIndex = 107;
            this.label33.Text = "Subpart 2:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemSubpart1
            // 
            this.txtItemSubpart1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSubpart1.Location = new System.Drawing.Point(101, 165);
            this.txtItemSubpart1.Name = "txtItemSubpart1";
            this.txtItemSubpart1.Size = new System.Drawing.Size(114, 21);
            this.txtItemSubpart1.TabIndex = 104;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(14, 164);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(81, 23);
            this.label32.TabIndex = 105;
            this.label32.Text = "Subpart 1:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemOrgTex3
            // 
            this.txtItemOrgTex3.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemOrgTex3.Location = new System.Drawing.Point(377, 119);
            this.txtItemOrgTex3.Name = "txtItemOrgTex3";
            this.txtItemOrgTex3.Size = new System.Drawing.Size(143, 21);
            this.txtItemOrgTex3.TabIndex = 102;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(290, 118);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(81, 23);
            this.label24.TabIndex = 103;
            this.label24.Text = "Org Tex 3:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemOrgTex2
            // 
            this.txtItemOrgTex2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemOrgTex2.Location = new System.Drawing.Point(377, 92);
            this.txtItemOrgTex2.Name = "txtItemOrgTex2";
            this.txtItemOrgTex2.Size = new System.Drawing.Size(143, 21);
            this.txtItemOrgTex2.TabIndex = 100;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(290, 91);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(81, 23);
            this.label22.TabIndex = 101;
            this.label22.Text = "Org Tex 2:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemTex3
            // 
            this.txtItemTex3.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemTex3.Location = new System.Drawing.Point(101, 118);
            this.txtItemTex3.Name = "txtItemTex3";
            this.txtItemTex3.Size = new System.Drawing.Size(143, 21);
            this.txtItemTex3.TabIndex = 98;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(14, 117);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(81, 23);
            this.label21.TabIndex = 99;
            this.label21.Text = "Tex 3:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemTex2
            // 
            this.txtItemTex2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemTex2.Location = new System.Drawing.Point(101, 91);
            this.txtItemTex2.Name = "txtItemTex2";
            this.txtItemTex2.Size = new System.Drawing.Size(143, 21);
            this.txtItemTex2.TabIndex = 96;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(14, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(81, 23);
            this.label20.TabIndex = 97;
            this.label20.Text = "Tex 2:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemModel
            // 
            this.txtItemModel.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemModel.Location = new System.Drawing.Point(101, 21);
            this.txtItemModel.Name = "txtItemModel";
            this.txtItemModel.Size = new System.Drawing.Size(143, 21);
            this.txtItemModel.TabIndex = 93;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(14, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 23);
            this.label12.TabIndex = 95;
            this.label12.Text = "Model:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemOrgTex1
            // 
            this.txtItemOrgTex1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemOrgTex1.Location = new System.Drawing.Point(377, 65);
            this.txtItemOrgTex1.Name = "txtItemOrgTex1";
            this.txtItemOrgTex1.Size = new System.Drawing.Size(143, 21);
            this.txtItemOrgTex1.TabIndex = 91;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(290, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 23);
            this.label11.TabIndex = 94;
            this.label11.Text = "Org Tex 1:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemTex1
            // 
            this.txtItemTex1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemTex1.Location = new System.Drawing.Point(101, 64);
            this.txtItemTex1.Name = "txtItemTex1";
            this.txtItemTex1.Size = new System.Drawing.Size(143, 21);
            this.txtItemTex1.TabIndex = 90;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(14, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 23);
            this.label9.TabIndex = 92;
            this.label9.Text = "Tex 1:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGoToSubpart2
            // 
            this.btnGoToSubpart2.Image = global::PartsIffTool.Properties.Resources.bullet_go;
            this.btnGoToSubpart2.Location = new System.Drawing.Point(221, 190);
            this.btnGoToSubpart2.Name = "btnGoToSubpart2";
            this.btnGoToSubpart2.Size = new System.Drawing.Size(23, 23);
            this.btnGoToSubpart2.TabIndex = 109;
            this.btnGoToSubpart2.UseVisualStyleBackColor = true;
            this.btnGoToSubpart2.Click += new System.EventHandler(this.btnGoToSubpart2_Click);
            // 
            // btnGoToSubpart1
            // 
            this.btnGoToSubpart1.Image = global::PartsIffTool.Properties.Resources.bullet_go;
            this.btnGoToSubpart1.Location = new System.Drawing.Point(221, 165);
            this.btnGoToSubpart1.Name = "btnGoToSubpart1";
            this.btnGoToSubpart1.Size = new System.Drawing.Size(23, 23);
            this.btnGoToSubpart1.TabIndex = 108;
            this.btnGoToSubpart1.UseVisualStyleBackColor = true;
            this.btnGoToSubpart1.Click += new System.EventHandler(this.btnGoToSubpart1_Click);
            // 
            // tabSetItems
            // 
            this.tabSetItems.Controls.Add(this.label10);
            this.tabSetItems.Controls.Add(this.chkUseSetItemNamesFromParent);
            this.tabSetItems.Controls.Add(this.lblSetItemCount);
            this.tabSetItems.Controls.Add(this.label41);
            this.tabSetItems.Controls.Add(this.label40);
            this.tabSetItems.Controls.Add(this.numSetItemAmount);
            this.tabSetItems.Controls.Add(this.txtSetItemId);
            this.tabSetItems.Controls.Add(this.label39);
            this.tabSetItems.Controls.Add(this.btnEditSetItemEntry);
            this.tabSetItems.Controls.Add(this.btnRemoveSetItemEntry);
            this.tabSetItems.Controls.Add(this.btnAddSetItem);
            this.tabSetItems.Controls.Add(this.lstSetItems);
            this.tabSetItems.Location = new System.Drawing.Point(4, 22);
            this.tabSetItems.Name = "tabSetItems";
            this.tabSetItems.Size = new System.Drawing.Size(624, 438);
            this.tabSetItems.TabIndex = 4;
            this.tabSetItems.Text = "Set Items";
            this.tabSetItems.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(12, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 23);
            this.label10.TabIndex = 128;
            this.label10.Text = "Set Contents:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkUseSetItemNamesFromParent
            // 
            this.chkUseSetItemNamesFromParent.AutoSize = true;
            this.chkUseSetItemNamesFromParent.Location = new System.Drawing.Point(473, 11);
            this.chkUseSetItemNamesFromParent.Name = "chkUseSetItemNamesFromParent";
            this.chkUseSetItemNamesFromParent.Size = new System.Drawing.Size(138, 17);
            this.chkUseSetItemNamesFromParent.TabIndex = 127;
            this.chkUseSetItemNamesFromParent.Text = "Use Names from Parent";
            this.chkUseSetItemNamesFromParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUseSetItemNamesFromParent.UseVisualStyleBackColor = true;
            this.chkUseSetItemNamesFromParent.Visible = false;
            this.chkUseSetItemNamesFromParent.CheckedChanged += new System.EventHandler(this.chkUseSetItemNamesFromParent_CheckedChanged);
            // 
            // lblSetItemCount
            // 
            this.lblSetItemCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSetItemCount.Location = new System.Drawing.Point(12, 203);
            this.lblSetItemCount.Name = "lblSetItemCount";
            this.lblSetItemCount.Size = new System.Drawing.Size(92, 24);
            this.lblSetItemCount.TabIndex = 121;
            this.lblSetItemCount.Text = "0/10 Items";
            this.lblSetItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(107, 307);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(191, 26);
            this.label41.TabIndex = 70;
            this.label41.Text = "For equipment (clothes, clubs, caddies)\r\nyou can leave the amount at 0.";
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(9, 278);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(95, 23);
            this.label40.TabIndex = 69;
            this.label40.Text = "Amount:";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numSetItemAmount
            // 
            this.numSetItemAmount.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSetItemAmount.Location = new System.Drawing.Point(110, 280);
            this.numSetItemAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSetItemAmount.Name = "numSetItemAmount";
            this.numSetItemAmount.Size = new System.Drawing.Size(143, 21);
            this.numSetItemAmount.TabIndex = 68;
            // 
            // txtSetItemId
            // 
            this.txtSetItemId.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetItemId.Location = new System.Drawing.Point(110, 252);
            this.txtSetItemId.Name = "txtSetItemId";
            this.txtSetItemId.Size = new System.Drawing.Size(143, 21);
            this.txtSetItemId.TabIndex = 67;
            this.txtSetItemId.Text = "0";
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(9, 251);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(95, 23);
            this.label39.TabIndex = 66;
            this.label39.Text = "Item ID:";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnEditSetItemEntry
            // 
            this.btnEditSetItemEntry.Image = global::PartsIffTool.Properties.Resources.textfield_key;
            this.btnEditSetItemEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditSetItemEntry.Location = new System.Drawing.Point(293, 203);
            this.btnEditSetItemEntry.Name = "btnEditSetItemEntry";
            this.btnEditSetItemEntry.Size = new System.Drawing.Size(102, 24);
            this.btnEditSetItemEntry.TabIndex = 124;
            this.btnEditSetItemEntry.Text = "&Update Entry";
            this.btnEditSetItemEntry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditSetItemEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditSetItemEntry.UseVisualStyleBackColor = true;
            this.btnEditSetItemEntry.Click += new System.EventHandler(this.btnEditSetItemEntry_Click);
            // 
            // btnRemoveSetItemEntry
            // 
            this.btnRemoveSetItemEntry.Image = global::PartsIffTool.Properties.Resources.delete;
            this.btnRemoveSetItemEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveSetItemEntry.Location = new System.Drawing.Point(509, 203);
            this.btnRemoveSetItemEntry.Name = "btnRemoveSetItemEntry";
            this.btnRemoveSetItemEntry.Size = new System.Drawing.Size(102, 24);
            this.btnRemoveSetItemEntry.TabIndex = 123;
            this.btnRemoveSetItemEntry.Text = "&Remove";
            this.btnRemoveSetItemEntry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveSetItemEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoveSetItemEntry.UseVisualStyleBackColor = true;
            this.btnRemoveSetItemEntry.Click += new System.EventHandler(this.btnRemoveSetItemEntry_Click);
            // 
            // btnAddSetItem
            // 
            this.btnAddSetItem.Image = global::PartsIffTool.Properties.Resources.add;
            this.btnAddSetItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddSetItem.Location = new System.Drawing.Point(401, 203);
            this.btnAddSetItem.Name = "btnAddSetItem";
            this.btnAddSetItem.Size = new System.Drawing.Size(102, 24);
            this.btnAddSetItem.TabIndex = 122;
            this.btnAddSetItem.Text = "Add to Set";
            this.btnAddSetItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddSetItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddSetItem.UseVisualStyleBackColor = true;
            this.btnAddSetItem.Click += new System.EventHandler(this.btnAddSetItem_Click);
            // 
            // lstSetItems
            // 
            this.lstSetItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSetItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstSetItems.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSetItems.FullRowSelect = true;
            this.lstSetItems.Location = new System.Drawing.Point(12, 34);
            this.lstSetItems.MultiSelect = false;
            this.lstSetItems.Name = "lstSetItems";
            this.lstSetItems.Size = new System.Drawing.Size(599, 163);
            this.lstSetItems.TabIndex = 0;
            this.lstSetItems.UseCompatibleStateImageBehavior = false;
            this.lstSetItems.View = System.Windows.Forms.View.Details;
            this.lstSetItems.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstSetItems_ItemSelectionChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Item ID";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Amount";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Part Name";
            this.columnHeader5.Width = 320;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbsNewPartIff,
            this.tbsOpenPartIff,
            this.tbsSavePartIff,
            this.toolStripSeparator1,
            this.tbsImportItems,
            this.tbsModelTextureCopy,
            this.toolStripSeparator2,
            this.toolStripDropDownButton1,
            this.tbsGenerateSql,
            this.tbsGiveItem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(926, 25);
            this.toolStrip1.TabIndex = 57;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbsNewPartIff
            // 
            this.tbsNewPartIff.Image = global::PartsIffTool.Properties.Resources.database_add;
            this.tbsNewPartIff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsNewPartIff.Name = "tbsNewPartIff";
            this.tbsNewPartIff.Size = new System.Drawing.Size(89, 22);
            this.tbsNewPartIff.Text = "New Part.iff";
            this.tbsNewPartIff.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // tbsOpenPartIff
            // 
            this.tbsOpenPartIff.Image = global::PartsIffTool.Properties.Resources.database_edit;
            this.tbsOpenPartIff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsOpenPartIff.Name = "tbsOpenPartIff";
            this.tbsOpenPartIff.Size = new System.Drawing.Size(94, 22);
            this.tbsOpenPartIff.Text = "Open Part.iff";
            this.tbsOpenPartIff.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tbsSavePartIff
            // 
            this.tbsSavePartIff.Image = global::PartsIffTool.Properties.Resources.database_save;
            this.tbsSavePartIff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsSavePartIff.Name = "tbsSavePartIff";
            this.tbsSavePartIff.Size = new System.Drawing.Size(89, 22);
            this.tbsSavePartIff.Text = "Save Part.iff";
            this.tbsSavePartIff.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbsImportItems
            // 
            this.tbsImportItems.Image = global::PartsIffTool.Properties.Resources.arrow_join;
            this.tbsImportItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsImportItems.Name = "tbsImportItems";
            this.tbsImportItems.Size = new System.Drawing.Size(90, 22);
            this.tbsImportItems.Text = "Import Item";
            this.tbsImportItems.Click += new System.EventHandler(this.btnCopyFromOtherFile_Click);
            // 
            // tbsModelTextureCopy
            // 
            this.tbsModelTextureCopy.Image = global::PartsIffTool.Properties.Resources.bricks;
            this.tbsModelTextureCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsModelTextureCopy.Name = "tbsModelTextureCopy";
            this.tbsModelTextureCopy.Size = new System.Drawing.Size(146, 22);
            this.tbsModelTextureCopy.Text = "Copy Models/Textures";
            this.tbsModelTextureCopy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbsModelTextureCopy_MouseUp);
            this.tbsModelTextureCopy.Click += new System.EventHandler(this.btnDataMigrator_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cleanUpItemNamesForWesternFontToolStripMenuItem,
            this.sortItemsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.useItemnamesFromThisFileToolStripMenuItem,
            this.useShopContentsFromThisFileToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(124, 22);
            this.toolStripDropDownButton1.Text = "Mass Operations";
            // 
            // cleanUpItemNamesForWesternFontToolStripMenuItem
            // 
            this.cleanUpItemNamesForWesternFontToolStripMenuItem.Name = "cleanUpItemNamesForWesternFontToolStripMenuItem";
            this.cleanUpItemNamesForWesternFontToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.cleanUpItemNamesForWesternFontToolStripMenuItem.Text = "Clean up item names for western font";
            this.cleanUpItemNamesForWesternFontToolStripMenuItem.Click += new System.EventHandler(this.cleanUpItemNamesForWesternFontToolStripMenuItem_Click);
            // 
            // sortItemsToolStripMenuItem
            // 
            this.sortItemsToolStripMenuItem.Name = "sortItemsToolStripMenuItem";
            this.sortItemsToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.sortItemsToolStripMenuItem.Text = "Sort Items by Type ID";
            this.sortItemsToolStripMenuItem.Click += new System.EventHandler(this.sortItemsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(270, 6);
            // 
            // useItemnamesFromThisFileToolStripMenuItem
            // 
            this.useItemnamesFromThisFileToolStripMenuItem.Enabled = false;
            this.useItemnamesFromThisFileToolStripMenuItem.Name = "useItemnamesFromThisFileToolStripMenuItem";
            this.useItemnamesFromThisFileToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.useItemnamesFromThisFileToolStripMenuItem.Text = "Use Item names from this File";
            this.useItemnamesFromThisFileToolStripMenuItem.Click += new System.EventHandler(this.useItemnamesFromThisFileToolStripMenuItem_Click);
            // 
            // useShopContentsFromThisFileToolStripMenuItem
            // 
            this.useShopContentsFromThisFileToolStripMenuItem.Enabled = false;
            this.useShopContentsFromThisFileToolStripMenuItem.Name = "useShopContentsFromThisFileToolStripMenuItem";
            this.useShopContentsFromThisFileToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.useShopContentsFromThisFileToolStripMenuItem.Text = "Use Shop contents from this File";
            this.useShopContentsFromThisFileToolStripMenuItem.Click += new System.EventHandler(this.useShopContentsFromThisFileToolStripMenuItem_Click);
            // 
            // tbsGenerateSql
            // 
            this.tbsGenerateSql.Image = global::PartsIffTool.Properties.Resources.database_go;
            this.tbsGenerateSql.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsGenerateSql.Name = "tbsGenerateSql";
            this.tbsGenerateSql.Size = new System.Drawing.Size(98, 22);
            this.tbsGenerateSql.Text = "Generate SQL";
            this.tbsGenerateSql.Click += new System.EventHandler(this.btnGenerateSql_Click);
            // 
            // tbsGiveItem
            // 
            this.tbsGiveItem.Image = global::PartsIffTool.Properties.Resources.cart_add;
            this.tbsGiveItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsGiveItem.Name = "tbsGiveItem";
            this.tbsGiveItem.Size = new System.Drawing.Size(77, 22);
            this.tbsGiveItem.Text = "Give Item";
            this.tbsGiveItem.Click += new System.EventHandler(this.btnGiveItem_Click);
            // 
            // cmbOutputRegion
            // 
            this.cmbOutputRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutputRegion.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutputRegion.FormattingEnabled = true;
            this.cmbOutputRegion.Location = new System.Drawing.Point(112, 33);
            this.cmbOutputRegion.Name = "cmbOutputRegion";
            this.cmbOutputRegion.Size = new System.Drawing.Size(167, 23);
            this.cmbOutputRegion.TabIndex = 58;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(6, 32);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(100, 23);
            this.label30.TabIndex = 59;
            this.label30.Text = "Output Region:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFilterByCharacter
            // 
            this.cmbFilterByCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbFilterByCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterByCharacter.FormattingEnabled = true;
            this.cmbFilterByCharacter.Items.AddRange(new object[] {
            "(All Characters)"});
            this.cmbFilterByCharacter.Location = new System.Drawing.Point(7, 458);
            this.cmbFilterByCharacter.Name = "cmbFilterByCharacter";
            this.cmbFilterByCharacter.Size = new System.Drawing.Size(141, 21);
            this.cmbFilterByCharacter.TabIndex = 60;
            // 
            // cmbFilterByCategory
            // 
            this.cmbFilterByCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbFilterByCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterByCategory.FormattingEnabled = true;
            this.cmbFilterByCategory.Items.AddRange(new object[] {
            "(All Categories)",
            "Upper Body",
            "Lower Body",
            "Hat",
            "Gloves",
            "Shoes",
            "Accessory",
            "UCC Blank Cloth",
            "UCC Copy Cloth"});
            this.cmbFilterByCategory.Location = new System.Drawing.Point(156, 458);
            this.cmbFilterByCategory.Name = "cmbFilterByCategory";
            this.cmbFilterByCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbFilterByCategory.TabIndex = 74;
            // 
            // chkOnlyItemsNotInParent
            // 
            this.chkOnlyItemsNotInParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkOnlyItemsNotInParent.AutoSize = true;
            this.chkOnlyItemsNotInParent.Enabled = false;
            this.chkOnlyItemsNotInParent.Location = new System.Drawing.Point(156, 536);
            this.chkOnlyItemsNotInParent.Name = "chkOnlyItemsNotInParent";
            this.chkOnlyItemsNotInParent.Size = new System.Drawing.Size(126, 17);
            this.chkOnlyItemsNotInParent.TabIndex = 75;
            this.chkOnlyItemsNotInParent.Text = "Not present in Parent";
            this.chkOnlyItemsNotInParent.UseVisualStyleBackColor = true;
            this.chkOnlyItemsNotInParent.Visible = false;
            // 
            // chkRealItemOnly
            // 
            this.chkRealItemOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRealItemOnly.AutoSize = true;
            this.chkRealItemOnly.Location = new System.Drawing.Point(6, 513);
            this.chkRealItemOnly.Name = "chkRealItemOnly";
            this.chkRealItemOnly.Size = new System.Drawing.Size(93, 17);
            this.chkRealItemOnly.TabIndex = 76;
            this.chkRealItemOnly.Text = "Hide Subparts";
            this.chkRealItemOnly.UseVisualStyleBackColor = true;
            // 
            // tabLists
            // 
            this.tabLists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tabLists.Controls.Add(this.tabParts);
            this.tabLists.Controls.Add(this.tabSets);
            this.tabLists.Location = new System.Drawing.Point(6, 66);
            this.tabLists.Name = "tabLists";
            this.tabLists.SelectedIndex = 0;
            this.tabLists.Size = new System.Drawing.Size(274, 386);
            this.tabLists.TabIndex = 78;
            this.tabLists.SelectedIndexChanged += new System.EventHandler(this.tabLists_SelectedIndexChanged);
            // 
            // tabParts
            // 
            this.tabParts.Controls.Add(this.lstParts);
            this.tabParts.Location = new System.Drawing.Point(4, 22);
            this.tabParts.Name = "tabParts";
            this.tabParts.Padding = new System.Windows.Forms.Padding(3);
            this.tabParts.Size = new System.Drawing.Size(266, 360);
            this.tabParts.TabIndex = 0;
            this.tabParts.Text = "Parts";
            this.tabParts.UseVisualStyleBackColor = true;
            // 
            // tabSets
            // 
            this.tabSets.Controls.Add(this.lstSets);
            this.tabSets.Location = new System.Drawing.Point(4, 22);
            this.tabSets.Name = "tabSets";
            this.tabSets.Padding = new System.Windows.Forms.Padding(3);
            this.tabSets.Size = new System.Drawing.Size(266, 360);
            this.tabSets.TabIndex = 1;
            this.tabSets.Text = "Sets";
            this.tabSets.UseVisualStyleBackColor = true;
            // 
            // lstSets
            // 
            this.lstSets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstSets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lstSets.ContextMenuStrip = this.cmsItemList;
            this.lstSets.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSets.FullRowSelect = true;
            this.lstSets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstSets.Location = new System.Drawing.Point(1, 3);
            this.lstSets.MultiSelect = false;
            this.lstSets.Name = "lstSets";
            this.lstSets.Size = new System.Drawing.Size(262, 355);
            this.lstSets.TabIndex = 6;
            this.lstSets.UseCompatibleStateImageBehavior = false;
            this.lstSets.View = System.Windows.Forms.View.Details;
            this.lstSets.ItemActivate += new System.EventHandler(this.lstSets_ItemActivate);
            this.lstSets.SelectedIndexChanged += new System.EventHandler(this.lstSets_ItemActivate);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Item Name";
            this.columnHeader2.Width = 240;
            // 
            // chkOnlyShowItemInShop
            // 
            this.chkOnlyShowItemInShop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkOnlyShowItemInShop.AutoSize = true;
            this.chkOnlyShowItemInShop.Location = new System.Drawing.Point(6, 536);
            this.chkOnlyShowItemInShop.Name = "chkOnlyShowItemInShop";
            this.chkOnlyShowItemInShop.Size = new System.Drawing.Size(108, 17);
            this.chkOnlyShowItemInShop.TabIndex = 79;
            this.chkOnlyShowItemInShop.Text = "Available in Shop";
            this.chkOnlyShowItemInShop.UseVisualStyleBackColor = true;
            // 
            // chkOnlyShowActiveItems
            // 
            this.chkOnlyShowActiveItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkOnlyShowActiveItems.AutoSize = true;
            this.chkOnlyShowActiveItems.Location = new System.Drawing.Point(156, 513);
            this.chkOnlyShowActiveItems.Name = "chkOnlyShowActiveItems";
            this.chkOnlyShowActiveItems.Size = new System.Drawing.Size(89, 17);
            this.chkOnlyShowActiveItems.TabIndex = 80;
            this.chkOnlyShowActiveItems.Text = "Hide Inactive";
            this.chkOnlyShowActiveItems.UseVisualStyleBackColor = true;
            // 
            // btnModeChange
            // 
            this.btnModeChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModeChange.Image = global::PartsIffTool.Properties.Resources.wand;
            this.btnModeChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModeChange.Location = new System.Drawing.Point(383, 534);
            this.btnModeChange.Name = "btnModeChange";
            this.btnModeChange.Size = new System.Drawing.Size(102, 24);
            this.btnModeChange.TabIndex = 77;
            this.btnModeChange.Text = "Mode Change";
            this.btnModeChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModeChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModeChange.UseVisualStyleBackColor = true;
            this.btnModeChange.Click += new System.EventHandler(this.btnModeChange_Click);
            // 
            // btnReturnToParentItem
            // 
            this.btnReturnToParentItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturnToParentItem.Image = global::PartsIffTool.Properties.Resources.book_previous;
            this.btnReturnToParentItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnToParentItem.Location = new System.Drawing.Point(817, 61);
            this.btnReturnToParentItem.Name = "btnReturnToParentItem";
            this.btnReturnToParentItem.Size = new System.Drawing.Size(102, 24);
            this.btnReturnToParentItem.TabIndex = 61;
            this.btnReturnToParentItem.Text = "Back to &Parent";
            this.btnReturnToParentItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnToParentItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReturnToParentItem.UseVisualStyleBackColor = true;
            this.btnReturnToParentItem.Visible = false;
            this.btnReturnToParentItem.Click += new System.EventHandler(this.btnReturnToParentItem_Click);
            // 
            // btnAddNewItem
            // 
            this.btnAddNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewItem.Image = global::PartsIffTool.Properties.Resources.add;
            this.btnAddNewItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewItem.Location = new System.Drawing.Point(491, 534);
            this.btnAddNewItem.Name = "btnAddNewItem";
            this.btnAddNewItem.Size = new System.Drawing.Size(102, 24);
            this.btnAddNewItem.TabIndex = 30;
            this.btnAddNewItem.Text = "Add &new Item";
            this.btnAddNewItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewItem.UseVisualStyleBackColor = true;
            this.btnAddNewItem.Click += new System.EventHandler(this.btnAddNewItem_Click);
            this.btnAddNewItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAddNewItem_MouseUp);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteItem.Image = global::PartsIffTool.Properties.Resources.delete;
            this.btnDeleteItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteItem.Location = new System.Drawing.Point(600, 534);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(102, 24);
            this.btnDeleteItem.TabIndex = 29;
            this.btnDeleteItem.Text = "&Delete Item";
            this.btnDeleteItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnDiscardItemChange
            // 
            this.btnDiscardItemChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscardItemChange.Image = global::PartsIffTool.Properties.Resources.arrow_undo;
            this.btnDiscardItemChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscardItemChange.Location = new System.Drawing.Point(708, 534);
            this.btnDiscardItemChange.Name = "btnDiscardItemChange";
            this.btnDiscardItemChange.Size = new System.Drawing.Size(102, 24);
            this.btnDiscardItemChange.TabIndex = 28;
            this.btnDiscardItemChange.Text = "&Undo Changes";
            this.btnDiscardItemChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscardItemChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDiscardItemChange.UseVisualStyleBackColor = true;
            this.btnDiscardItemChange.Click += new System.EventHandler(this.btnDiscardItemChange_Click);
            // 
            // btnApplyItemChange
            // 
            this.btnApplyItemChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyItemChange.Image = global::PartsIffTool.Properties.Resources.tick;
            this.btnApplyItemChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApplyItemChange.Location = new System.Drawing.Point(816, 534);
            this.btnApplyItemChange.Name = "btnApplyItemChange";
            this.btnApplyItemChange.Size = new System.Drawing.Size(102, 24);
            this.btnApplyItemChange.TabIndex = 27;
            this.btnApplyItemChange.Text = "Apply &Changes";
            this.btnApplyItemChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApplyItemChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApplyItemChange.UseVisualStyleBackColor = true;
            this.btnApplyItemChange.Click += new System.EventHandler(this.btnApplyItemChange_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilter.Image = global::PartsIffTool.Properties.Resources.zoom;
            this.btnFilter.Location = new System.Drawing.Point(219, 484);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(58, 24);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "&Filter";
            this.btnFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // picHorizBadge
            // 
            this.picHorizBadge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picHorizBadge.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picHorizBadge.Location = new System.Drawing.Point(286, 28);
            this.picHorizBadge.Name = "picHorizBadge";
            this.picHorizBadge.Size = new System.Drawing.Size(632, 32);
            this.picHorizBadge.TabIndex = 2;
            this.picHorizBadge.TabStop = false;
            this.picHorizBadge.Paint += new System.Windows.Forms.PaintEventHandler(this.picHorizBadge_Paint);
            // 
            // chkItemIsBasic
            // 
            this.chkItemIsBasic.AutoSize = true;
            this.chkItemIsBasic.Location = new System.Drawing.Point(117, 45);
            this.chkItemIsBasic.Name = "chkItemIsBasic";
            this.chkItemIsBasic.Size = new System.Drawing.Size(129, 17);
            this.chkItemIsBasic.TabIndex = 131;
            this.chkItemIsBasic.Text = "Has \"Basic\" Discount";
            this.chkItemIsBasic.UseVisualStyleBackColor = true;
            // 
            // PartEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 563);
            this.Controls.Add(this.chkOnlyShowActiveItems);
            this.Controls.Add(this.chkOnlyShowItemInShop);
            this.Controls.Add(this.tabLists);
            this.Controls.Add(this.btnModeChange);
            this.Controls.Add(this.chkRealItemOnly);
            this.Controls.Add(this.cmbFilterByCategory);
            this.Controls.Add(this.chkOnlyItemsNotInParent);
            this.Controls.Add(this.btnReturnToParentItem);
            this.Controls.Add(this.cmbFilterByCharacter);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.cmbOutputRegion);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabProperties);
            this.Controls.Add(this.cmbFilterBy);
            this.Controls.Add(this.btnAddNewItem);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnDiscardItemChange);
            this.Controls.Add(this.btnApplyItemChange);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.picHorizBadge);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PartEditor";
            this.Text = "Pangya Part Editor";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PartEditor_KeyUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.cmsItemList.ResumeLayout(false);
            this.tabProperties.ResumeLayout(false);
            this.tabBasicProperties.ResumeLayout(false);
            this.tabBasicProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItemIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabShopProperties.ResumeLayout(false);
            this.tabShopProperties.PerformLayout();
            this.tabStatModifiers.ResumeLayout(false);
            this.tabStatModifiers.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabModelProperties.ResumeLayout(false);
            this.tabModelProperties.PerformLayout();
            this.tabSetItems.ResumeLayout(false);
            this.tabSetItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSetItemAmount)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabLists.ResumeLayout(false);
            this.tabParts.ResumeLayout(false);
            this.tabSets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHorizBadge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picHorizBadge;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnApplyItemChange;
        private System.Windows.Forms.Button btnDiscardItemChange;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnAddNewItem;
        private System.Windows.Forms.ListView lstParts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.TabControl tabProperties;
        private System.Windows.Forms.TabPage tabStatModifiers;
        private System.Windows.Forms.TextBox txtCaddySlots;
        private System.Windows.Forms.TextBox txtCharSlots;
        private System.Windows.Forms.Label lblCaddyCardSlotsLabel;
        private System.Windows.Forms.Label lblCharCardSlotsLabel;
        private System.Windows.Forms.TabPage tabBasicProperties;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbMaxLevel;
        private System.Windows.Forms.RadioButton rbMinLevel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbItemMinLevel;
        private System.Windows.Forms.Label lblItemCategoryLabel;
        private System.Windows.Forms.ComboBox cmbItemCategory;
        private System.Windows.Forms.TextBox txtItemIcon;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkItemActive;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabModelProperties;
        private System.Windows.Forms.TextBox txtItemModel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtItemOrgTex1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtItemTex1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabShopProperties;
        private System.Windows.Forms.CheckBox chkItemIsReserve;
        private System.Windows.Forms.CheckBox chkItemIsInStock;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSetHighPrice;
        private System.Windows.Forms.RadioButton rbItemCostsSpecial;
        private System.Windows.Forms.RadioButton rbItemCostsCookies;
        private System.Windows.Forms.RadioButton rbItemCostsPang;
        private System.Windows.Forms.TextBox txtItemCost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbsNewPartIff;
        private System.Windows.Forms.ToolStripButton tbsOpenPartIff;
        private System.Windows.Forms.ToolStripButton tbsSavePartIff;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbsImportItems;
        private System.Windows.Forms.ToolStripButton tbsModelTextureCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbsGenerateSql;
        private System.Windows.Forms.ToolStripButton tbsGiveItem;
        private System.Windows.Forms.TextBox txtItemStallPrice;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnSetHighDiscountPrice;
        private System.Windows.Forms.TextBox txtItemUsedPrice;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSetHighUsedPrice;
        private System.Windows.Forms.CheckBox chkSaleEnd;
        private System.Windows.Forms.CheckBox chkSaleStart;
        private System.Windows.Forms.DateTimePicker dateSaleEnd;
        private System.Windows.Forms.DateTimePicker dateSaleStart;
        private System.Windows.Forms.CheckBox chkItemIsHot;
        private System.Windows.Forms.CheckBox chkItemIsNew;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtItemCurveSlot;
        private System.Windows.Forms.TextBox txtItemSpinSlot;
        private System.Windows.Forms.TextBox txtItemImpactSlot;
        private System.Windows.Forms.TextBox txtItemControlSlot;
        private System.Windows.Forms.TextBox txtItemPowerSlot;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtItemCurve;
        private System.Windows.Forms.TextBox txtItemSpin;
        private System.Windows.Forms.TextBox txtItemImpact;
        private System.Windows.Forms.TextBox txtItemControl;
        private System.Windows.Forms.TextBox txtItemPower;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtItemOrgTex3;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtItemOrgTex2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtItemTex3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtItemTex2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblHideMaskLabel;
        private System.Windows.Forms.TextBox txtItemHideMask;
        private System.Windows.Forms.Label lblPosMaskLabel;
        private System.Windows.Forms.TextBox txtItemPosMask;
        private System.Windows.Forms.Label lblEquippableWithLabel;
        private System.Windows.Forms.TextBox txtItemEquippableWith;
        public System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cmbOutputRegion;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.PictureBox picItemIcon;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cmbFilterByCharacter;
        private System.Windows.Forms.TextBox txtItemSubpart2;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtItemSubpart1;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnGoToSubpart2;
        private System.Windows.Forms.Button btnGoToSubpart1;
        private System.Windows.Forms.Button btnReturnToParentItem;
        private System.Windows.Forms.TextBox txtItemGroup;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ComboBox cmbFilterByCategory;
        private System.Windows.Forms.Label lblNameLen;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem useItemnamesFromThisFileToolStripMenuItem;
        private System.Windows.Forms.Label lblRecordRegion;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.CheckBox chkOnlyItemsNotInParent;
        private System.Windows.Forms.CheckBox chkRealItemOnly;
        private System.Windows.Forms.ToolStripMenuItem cleanUpItemNamesForWesternFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sortItemsToolStripMenuItem;
        private System.Windows.Forms.Button btnModeChange;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtItemSerial;
        private System.Windows.Forms.TextBox txtItemPos;
        private System.Windows.Forms.ComboBox cmbPartCharacter;
        private System.Windows.Forms.Button btnLastSerialForCharacter;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtItemType;
        private System.Windows.Forms.ContextMenuStrip cmsItemList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem setItemStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activateItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deactivateItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setShopAvailabilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableInShopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableInShopToolStripMenuItem;
        private System.Windows.Forms.TabControl tabLists;
        private System.Windows.Forms.TabPage tabParts;
        private System.Windows.Forms.TabPage tabSets;
        private System.Windows.Forms.ListView lstSets;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabSetItems;
        private System.Windows.Forms.ListView lstSetItems;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.NumericUpDown numSetItemAmount;
        private System.Windows.Forms.TextBox txtSetItemId;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label lblSetItemCount;
        private System.Windows.Forms.Button btnEditSetItemEntry;
        private System.Windows.Forms.Button btnRemoveSetItemEntry;
        private System.Windows.Forms.Button btnAddSetItem;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.CheckBox chkUseSetItemNamesFromParent;
        private System.Windows.Forms.ToolStripMenuItem useShopContentsFromThisFileToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkOnlyShowItemInShop;
        private System.Windows.Forms.CheckBox chkOnlyShowActiveItems;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtItemTime;
        private System.Windows.Forms.TextBox txtItemTimeFlag;
        private System.Windows.Forms.CheckBox chkItemIsBasic;
    }
}

