namespace PartsIffTool
{
    partial class GenericDumper
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
            this.btnGenerateSql = new System.Windows.Forms.Button();
            this.lstParts = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnGiveItem = new System.Windows.Forms.Button();
            this.picHorizBadge = new System.Windows.Forms.PictureBox();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHorizBadge)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateSql
            // 
            this.btnGenerateSql.Image = global::PartsIffTool.Properties.Resources.database_go;
            this.btnGenerateSql.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateSql.Location = new System.Drawing.Point(118, 12);
            this.btnGenerateSql.Name = "btnGenerateSql";
            this.btnGenerateSql.Size = new System.Drawing.Size(100, 24);
            this.btnGenerateSql.TabIndex = 13;
            this.btnGenerateSql.Text = "Generate SQL";
            this.btnGenerateSql.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateSql.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerateSql.UseVisualStyleBackColor = true;
            this.btnGenerateSql.Click += new System.EventHandler(this.btnGenerateSql_Click);
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
            this.lstParts.Location = new System.Drawing.Point(12, 42);
            this.lstParts.MultiSelect = false;
            this.lstParts.Name = "lstParts";
            this.lstParts.Size = new System.Drawing.Size(270, 279);
            this.lstParts.TabIndex = 15;
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
            this.txtItemId.Location = new System.Drawing.Point(386, 116);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(142, 21);
            this.txtItemId.TabIndex = 18;
            this.txtItemId.Text = "0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(285, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "Item ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(386, 88);
            this.txtItemName.MaxLength = 40;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(274, 21);
            this.txtItemName.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(285, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Item Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOpen
            // 
            this.btnOpen.Image = global::PartsIffTool.Properties.Resources.database_edit;
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.Location = new System.Drawing.Point(12, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 24);
            this.btnOpen.TabIndex = 12;
            this.btnOpen.Text = "Open IFF File";
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnGiveItem
            // 
            this.btnGiveItem.Image = global::PartsIffTool.Properties.Resources.cart_add;
            this.btnGiveItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiveItem.Location = new System.Drawing.Point(224, 12);
            this.btnGiveItem.Name = "btnGiveItem";
            this.btnGiveItem.Size = new System.Drawing.Size(100, 24);
            this.btnGiveItem.TabIndex = 49;
            this.btnGiveItem.Text = "Give this Item";
            this.btnGiveItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiveItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGiveItem.UseVisualStyleBackColor = true;
            this.btnGiveItem.Click += new System.EventHandler(this.btnGiveItem_Click);
            // 
            // picHorizBadge
            // 
            this.picHorizBadge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picHorizBadge.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picHorizBadge.Location = new System.Drawing.Point(288, 42);
            this.picHorizBadge.Name = "picHorizBadge";
            this.picHorizBadge.Size = new System.Drawing.Size(385, 32);
            this.picHorizBadge.TabIndex = 57;
            this.picHorizBadge.TabStop = false;
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "Name",
            "ID"});
            this.cmbFilterBy.Location = new System.Drawing.Point(161, 328);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(57, 21);
            this.cmbFilterBy.TabIndex = 59;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilter.Image = global::PartsIffTool.Properties.Resources.zoom;
            this.btnFilter.Location = new System.Drawing.Point(224, 327);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(58, 24);
            this.btnFilter.TabIndex = 60;
            this.btnFilter.Text = "&Filter";
            this.btnFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilter.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(12, 328);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(141, 21);
            this.txtFilter.TabIndex = 58;
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // GenericDumper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 361);
            this.Controls.Add(this.cmbFilterBy);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.picHorizBadge);
            this.Controls.Add(this.btnGiveItem);
            this.Controls.Add(this.btnGenerateSql);
            this.Controls.Add(this.lstParts);
            this.Controls.Add(this.txtItemId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpen);
            this.Name = "GenericDumper";
            this.Text = "Generic IFF Contents Dumper";
            ((System.ComponentModel.ISupportInitialize)(this.picHorizBadge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateSql;
        private System.Windows.Forms.ListView lstParts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnGiveItem;
        private System.Windows.Forms.PictureBox picHorizBadge;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtFilter;
    }
}