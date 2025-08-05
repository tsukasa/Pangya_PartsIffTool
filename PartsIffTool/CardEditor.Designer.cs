namespace PartsIffTool
{
    partial class CardEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtItemIcon = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
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
            this.lstParts = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkItemActive = new System.Windows.Forms.CheckBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEffect = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEffectDuration = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCardImage = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCardSubIcon = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCardSlotImage = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCardBuffImage = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtEffectValue = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCardVolume = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.btnCopyFromOtherFile = new System.Windows.Forms.Button();
            this.btnGiveItem = new System.Windows.Forms.Button();
            this.btnGenerateSql = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnAddNewItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnDiscardItemChange = new System.Windows.Forms.Button();
            this.btnApplyItemChange = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.picHorizBadge = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cmbRareType = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHorizBadge)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "Name",
            "ID"});
            this.cmbFilterBy.Location = new System.Drawing.Point(161, 526);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(57, 21);
            this.cmbFilterBy.TabIndex = 112;
            // 
            // txtItemIcon
            // 
            this.txtItemIcon.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemIcon.Location = new System.Drawing.Point(394, 278);
            this.txtItemIcon.Name = "txtItemIcon";
            this.txtItemIcon.Size = new System.Drawing.Size(143, 21);
            this.txtItemIcon.TabIndex = 128;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(307, 277);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 23);
            this.label13.TabIndex = 138;
            this.label13.Text = "Icon:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtItemCurveSlot);
            this.groupBox2.Controls.Add(this.txtItemSpinSlot);
            this.groupBox2.Controls.Add(this.txtItemImpactSlot);
            this.groupBox2.Controls.Add(this.txtItemControlSlot);
            this.groupBox2.Controls.Add(this.txtItemPowerSlot);
            this.groupBox2.Location = new System.Drawing.Point(713, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(63, 158);
            this.groupBox2.TabIndex = 127;
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
            this.label8.Location = new System.Drawing.Point(630, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 23);
            this.label8.TabIndex = 136;
            this.label8.Text = "Curve:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(630, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 23);
            this.label7.TabIndex = 134;
            this.label7.Text = "Spin:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(630, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 23);
            this.label6.TabIndex = 133;
            this.label6.Text = "Impact:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(630, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 23);
            this.label5.TabIndex = 131;
            this.label5.Text = "Control:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(630, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 23);
            this.label4.TabIndex = 129;
            this.label4.Text = "Power:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstParts
            // 
            this.lstParts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstParts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstParts.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstParts.FullRowSelect = true;
            this.lstParts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstParts.Location = new System.Drawing.Point(12, 40);
            this.lstParts.MultiSelect = false;
            this.lstParts.Name = "lstParts";
            this.lstParts.Size = new System.Drawing.Size(270, 480);
            this.lstParts.TabIndex = 110;
            this.lstParts.UseCompatibleStateImageBehavior = false;
            this.lstParts.View = System.Windows.Forms.View.Details;
            this.lstParts.SelectedIndexChanged += new System.EventHandler(this.lstParts_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item Name";
            this.columnHeader1.Width = 240;
            // 
            // txtItemId
            // 
            this.txtItemId.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemId.Location = new System.Drawing.Point(394, 124);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(179, 21);
            this.txtItemId.TabIndex = 117;
            this.txtItemId.Text = "0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(293, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 113;
            this.label2.Text = "Item ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkItemActive
            // 
            this.chkItemActive.Location = new System.Drawing.Point(676, 95);
            this.chkItemActive.Name = "chkItemActive";
            this.chkItemActive.Size = new System.Drawing.Size(100, 24);
            this.chkItemActive.TabIndex = 116;
            this.chkItemActive.Text = "Item Active";
            this.chkItemActive.UseVisualStyleBackColor = true;
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(394, 96);
            this.txtItemName.MaxLength = 40;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(274, 21);
            this.txtItemName.TabIndex = 115;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(293, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 109;
            this.label1.Text = "Item Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilter.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(12, 526);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(141, 21);
            this.txtFilter.TabIndex = 111;
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(293, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 143;
            this.label3.Text = "Effect:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbEffect
            // 
            this.cmbEffect.FormattingEnabled = true;
            this.cmbEffect.Location = new System.Drawing.Point(394, 171);
            this.cmbEffect.Name = "cmbEffect";
            this.cmbEffect.Size = new System.Drawing.Size(179, 21);
            this.cmbEffect.TabIndex = 144;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(293, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 23);
            this.label9.TabIndex = 145;
            this.label9.Text = "Effect Duration:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEffectDuration
            // 
            this.txtEffectDuration.Location = new System.Drawing.Point(394, 199);
            this.txtEffectDuration.Name = "txtEffectDuration";
            this.txtEffectDuration.Size = new System.Drawing.Size(70, 20);
            this.txtEffectDuration.TabIndex = 146;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(468, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 147;
            this.label10.Text = "Minutes";
            // 
            // txtCardImage
            // 
            this.txtCardImage.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardImage.Location = new System.Drawing.Point(394, 305);
            this.txtCardImage.Name = "txtCardImage";
            this.txtCardImage.Size = new System.Drawing.Size(143, 21);
            this.txtCardImage.TabIndex = 148;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(307, 304);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 23);
            this.label11.TabIndex = 149;
            this.label11.Text = "Image:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCardSubIcon
            // 
            this.txtCardSubIcon.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardSubIcon.Location = new System.Drawing.Point(394, 332);
            this.txtCardSubIcon.Name = "txtCardSubIcon";
            this.txtCardSubIcon.Size = new System.Drawing.Size(143, 21);
            this.txtCardSubIcon.TabIndex = 150;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(307, 331);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 23);
            this.label12.TabIndex = 151;
            this.label12.Text = "Sub Icon:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCardSlotImage
            // 
            this.txtCardSlotImage.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardSlotImage.Location = new System.Drawing.Point(394, 359);
            this.txtCardSlotImage.Name = "txtCardSlotImage";
            this.txtCardSlotImage.Size = new System.Drawing.Size(143, 21);
            this.txtCardSlotImage.TabIndex = 152;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(307, 358);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 23);
            this.label14.TabIndex = 153;
            this.label14.Text = "Slot Image:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCardBuffImage
            // 
            this.txtCardBuffImage.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardBuffImage.Location = new System.Drawing.Point(394, 386);
            this.txtCardBuffImage.Name = "txtCardBuffImage";
            this.txtCardBuffImage.Size = new System.Drawing.Size(143, 21);
            this.txtCardBuffImage.TabIndex = 154;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(307, 385);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 23);
            this.label15.TabIndex = 155;
            this.label15.Text = "Buff Image:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEffectValue
            // 
            this.txtEffectValue.Location = new System.Drawing.Point(394, 225);
            this.txtEffectValue.Name = "txtEffectValue";
            this.txtEffectValue.Size = new System.Drawing.Size(70, 20);
            this.txtEffectValue.TabIndex = 157;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(293, 222);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 23);
            this.label16.TabIndex = 156;
            this.label16.Text = "Effect Value:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCardVolume
            // 
            this.txtCardVolume.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardVolume.Location = new System.Drawing.Point(723, 312);
            this.txtCardVolume.MaxLength = 3;
            this.txtCardVolume.Name = "txtCardVolume";
            this.txtCardVolume.Size = new System.Drawing.Size(43, 21);
            this.txtCardVolume.TabIndex = 158;
            this.txtCardVolume.Text = "0";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(630, 311);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 23);
            this.label17.TabIndex = 159;
            this.label17.Text = "Card Volume:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(630, 340);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 23);
            this.label18.TabIndex = 161;
            this.label18.Text = "Card No:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCardNo
            // 
            this.txtCardNo.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNo.Location = new System.Drawing.Point(723, 341);
            this.txtCardNo.MaxLength = 3;
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(43, 21);
            this.txtCardNo.TabIndex = 160;
            this.txtCardNo.Text = "0";
            // 
            // btnCopyFromOtherFile
            // 
            this.btnCopyFromOtherFile.Image = global::PartsIffTool.Properties.Resources.box;
            this.btnCopyFromOtherFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyFromOtherFile.Location = new System.Drawing.Point(542, 12);
            this.btnCopyFromOtherFile.Name = "btnCopyFromOtherFile";
            this.btnCopyFromOtherFile.Size = new System.Drawing.Size(100, 24);
            this.btnCopyFromOtherFile.TabIndex = 142;
            this.btnCopyFromOtherFile.Text = "Clone";
            this.btnCopyFromOtherFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyFromOtherFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopyFromOtherFile.UseVisualStyleBackColor = true;
            // 
            // btnGiveItem
            // 
            this.btnGiveItem.Image = global::PartsIffTool.Properties.Resources.cart_add;
            this.btnGiveItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiveItem.Location = new System.Drawing.Point(436, 12);
            this.btnGiveItem.Name = "btnGiveItem";
            this.btnGiveItem.Size = new System.Drawing.Size(100, 24);
            this.btnGiveItem.TabIndex = 141;
            this.btnGiveItem.Text = "Give this Item";
            this.btnGiveItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiveItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGiveItem.UseVisualStyleBackColor = true;
            // 
            // btnGenerateSql
            // 
            this.btnGenerateSql.Image = global::PartsIffTool.Properties.Resources.database_go;
            this.btnGenerateSql.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateSql.Location = new System.Drawing.Point(330, 12);
            this.btnGenerateSql.Name = "btnGenerateSql";
            this.btnGenerateSql.Size = new System.Drawing.Size(100, 24);
            this.btnGenerateSql.TabIndex = 108;
            this.btnGenerateSql.Text = "Generate SQL";
            this.btnGenerateSql.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateSql.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerateSql.UseVisualStyleBackColor = true;
            this.btnGenerateSql.Click += new System.EventHandler(this.btnGenerateSql_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::PartsIffTool.Properties.Resources.database_save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(224, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 24);
            this.btnSave.TabIndex = 107;
            this.btnSave.Text = "Save IFF File";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::PartsIffTool.Properties.Resources.database_add;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(12, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 24);
            this.btnNew.TabIndex = 104;
            this.btnNew.Text = "New IFF File";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnAddNewItem
            // 
            this.btnAddNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewItem.Image = global::PartsIffTool.Properties.Resources.add;
            this.btnAddNewItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewItem.Location = new System.Drawing.Point(526, 525);
            this.btnAddNewItem.Name = "btnAddNewItem";
            this.btnAddNewItem.Size = new System.Drawing.Size(102, 24);
            this.btnAddNewItem.TabIndex = 137;
            this.btnAddNewItem.Text = "Add &new Item";
            this.btnAddNewItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewItem.UseVisualStyleBackColor = true;
            this.btnAddNewItem.Click += new System.EventHandler(this.btnAddNewItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteItem.Image = global::PartsIffTool.Properties.Resources.delete;
            this.btnDeleteItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteItem.Location = new System.Drawing.Point(635, 525);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(102, 24);
            this.btnDeleteItem.TabIndex = 135;
            this.btnDeleteItem.Text = "&Delete Item";
            this.btnDeleteItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            // 
            // btnDiscardItemChange
            // 
            this.btnDiscardItemChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscardItemChange.Image = global::PartsIffTool.Properties.Resources.arrow_undo;
            this.btnDiscardItemChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscardItemChange.Location = new System.Drawing.Point(743, 525);
            this.btnDiscardItemChange.Name = "btnDiscardItemChange";
            this.btnDiscardItemChange.Size = new System.Drawing.Size(102, 24);
            this.btnDiscardItemChange.TabIndex = 132;
            this.btnDiscardItemChange.Text = "&Undo Changes";
            this.btnDiscardItemChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscardItemChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDiscardItemChange.UseVisualStyleBackColor = true;
            // 
            // btnApplyItemChange
            // 
            this.btnApplyItemChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyItemChange.Image = global::PartsIffTool.Properties.Resources.tick;
            this.btnApplyItemChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApplyItemChange.Location = new System.Drawing.Point(851, 525);
            this.btnApplyItemChange.Name = "btnApplyItemChange";
            this.btnApplyItemChange.Size = new System.Drawing.Size(102, 24);
            this.btnApplyItemChange.TabIndex = 130;
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
            this.btnFilter.Location = new System.Drawing.Point(224, 525);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(58, 24);
            this.btnFilter.TabIndex = 114;
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
            this.picHorizBadge.Location = new System.Drawing.Point(288, 40);
            this.picHorizBadge.Name = "picHorizBadge";
            this.picHorizBadge.Size = new System.Drawing.Size(665, 32);
            this.picHorizBadge.TabIndex = 106;
            this.picHorizBadge.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Image = global::PartsIffTool.Properties.Resources.database_edit;
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.Location = new System.Drawing.Point(118, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 24);
            this.btnOpen.TabIndex = 105;
            this.btnOpen.Text = "Open IFF File";
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cmbRareType
            // 
            this.cmbRareType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRareType.FormattingEnabled = true;
            this.cmbRareType.Location = new System.Drawing.Point(394, 437);
            this.cmbRareType.Name = "cmbRareType";
            this.cmbRareType.Size = new System.Drawing.Size(179, 21);
            this.cmbRareType.TabIndex = 163;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(293, 435);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(95, 23);
            this.label19.TabIndex = 162;
            this.label19.Text = "Rare Type:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CardEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 561);
            this.Controls.Add(this.cmbRareType);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtCardNo);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtCardVolume);
            this.Controls.Add(this.txtEffectValue);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtCardBuffImage);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtCardSlotImage);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCardSubIcon);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCardImage);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEffectDuration);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbEffect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCopyFromOtherFile);
            this.Controls.Add(this.cmbFilterBy);
            this.Controls.Add(this.btnGiveItem);
            this.Controls.Add(this.btnGenerateSql);
            this.Controls.Add(this.txtItemIcon);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstParts);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnAddNewItem);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnDiscardItemChange);
            this.Controls.Add(this.btnApplyItemChange);
            this.Controls.Add(this.txtItemId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkItemActive);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.picHorizBadge);
            this.Controls.Add(this.btnOpen);
            this.Name = "CardEditor";
            this.Text = "CardEditor";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHorizBadge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCopyFromOtherFile;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.Button btnGiveItem;
        private System.Windows.Forms.Button btnGenerateSql;
        private System.Windows.Forms.TextBox txtItemIcon;
        private System.Windows.Forms.Label label13;
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
        private System.Windows.Forms.ListView lstParts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnAddNewItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnDiscardItemChange;
        private System.Windows.Forms.Button btnApplyItemChange;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkItemActive;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.PictureBox picHorizBadge;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEffect;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEffectDuration;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCardImage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCardSubIcon;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCardSlotImage;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCardBuffImage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtEffectValue;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCardVolume;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.ComboBox cmbRareType;
        private System.Windows.Forms.Label label19;
    }
}