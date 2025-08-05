namespace PartsIffTool
{
    partial class DescEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DescEditor));
            this.lstParts = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.txtObjId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.txtObjDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnTranslateFile = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnAddNewObj = new System.Windows.Forms.Button();
            this.btnDeleteObj = new System.Windows.Forms.Button();
            this.btnDiscardObjChange = new System.Windows.Forms.Button();
            this.btnApplyObjChange = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.picHorizBadge = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnInsertColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picHorizBadge)).BeginInit();
            this.SuspendLayout();
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
            this.lstParts.Size = new System.Drawing.Size(270, 233);
            this.lstParts.TabIndex = 44;
            this.lstParts.UseCompatibleStateImageBehavior = false;
            this.lstParts.View = System.Windows.Forms.View.Details;
            this.lstParts.SelectedIndexChanged += new System.EventHandler(this.lstParts_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item Name";
            this.columnHeader1.Width = 240;
            // 
            // txtObjId
            // 
            this.txtObjId.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjId.Location = new System.Drawing.Point(291, 101);
            this.txtObjId.Name = "txtObjId";
            this.txtObjId.Size = new System.Drawing.Size(104, 21);
            this.txtObjId.TabIndex = 48;
            this.txtObjId.Text = "0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(288, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 47;
            this.label2.Text = "Object ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilter.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(12, 279);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(189, 21);
            this.txtFilter.TabIndex = 45;
            // 
            // txtObjDescription
            // 
            this.txtObjDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObjDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjDescription.Location = new System.Drawing.Point(291, 154);
            this.txtObjDescription.MaxLength = 511;
            this.txtObjDescription.Multiline = true;
            this.txtObjDescription.Name = "txtObjDescription";
            this.txtObjDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObjDescription.Size = new System.Drawing.Size(427, 117);
            this.txtObjDescription.TabIndex = 55;
            this.txtObjDescription.TextChanged += new System.EventHandler(this.txtObjDescription_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(288, 128);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(430, 23);
            this.lblDescription.TabIndex = 56;
            this.lblDescription.Text = "Description:";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTranslateFile
            // 
            this.btnTranslateFile.Image = global::PartsIffTool.Properties.Resources.arrow_merge;
            this.btnTranslateFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTranslateFile.Location = new System.Drawing.Point(330, 12);
            this.btnTranslateFile.Name = "btnTranslateFile";
            this.btnTranslateFile.Size = new System.Drawing.Size(100, 24);
            this.btnTranslateFile.TabIndex = 57;
            this.btnTranslateFile.Text = "Translate File";
            this.btnTranslateFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTranslateFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTranslateFile.UseVisualStyleBackColor = true;
            this.btnTranslateFile.Click += new System.EventHandler(this.btnTranslateFile_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::PartsIffTool.Properties.Resources.database_save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(224, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 24);
            this.btnSave.TabIndex = 43;
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
            this.btnNew.TabIndex = 40;
            this.btnNew.Text = "New IFF File";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnAddNewObj
            // 
            this.btnAddNewObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewObj.Image = global::PartsIffTool.Properties.Resources.add;
            this.btnAddNewObj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewObj.Location = new System.Drawing.Point(291, 277);
            this.btnAddNewObj.Name = "btnAddNewObj";
            this.btnAddNewObj.Size = new System.Drawing.Size(102, 24);
            this.btnAddNewObj.TabIndex = 53;
            this.btnAddNewObj.Text = "Add &new Obj";
            this.btnAddNewObj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewObj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewObj.UseVisualStyleBackColor = true;
            this.btnAddNewObj.Click += new System.EventHandler(this.btnAddNewObj_Click);
            // 
            // btnDeleteObj
            // 
            this.btnDeleteObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteObj.Image = global::PartsIffTool.Properties.Resources.delete;
            this.btnDeleteObj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteObj.Location = new System.Drawing.Point(400, 277);
            this.btnDeleteObj.Name = "btnDeleteObj";
            this.btnDeleteObj.Size = new System.Drawing.Size(102, 24);
            this.btnDeleteObj.TabIndex = 52;
            this.btnDeleteObj.Text = "&Delete Obj";
            this.btnDeleteObj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteObj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteObj.UseVisualStyleBackColor = true;
            this.btnDeleteObj.Click += new System.EventHandler(this.btnDeleteObj_Click);
            // 
            // btnDiscardObjChange
            // 
            this.btnDiscardObjChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscardObjChange.Image = global::PartsIffTool.Properties.Resources.arrow_undo;
            this.btnDiscardObjChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscardObjChange.Location = new System.Drawing.Point(508, 277);
            this.btnDiscardObjChange.Name = "btnDiscardObjChange";
            this.btnDiscardObjChange.Size = new System.Drawing.Size(102, 24);
            this.btnDiscardObjChange.TabIndex = 51;
            this.btnDiscardObjChange.Text = "&Undo Changes";
            this.btnDiscardObjChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscardObjChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDiscardObjChange.UseVisualStyleBackColor = true;
            this.btnDiscardObjChange.Click += new System.EventHandler(this.btnDiscardObjChange_Click);
            // 
            // btnApplyObjChange
            // 
            this.btnApplyObjChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyObjChange.Image = global::PartsIffTool.Properties.Resources.tick;
            this.btnApplyObjChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApplyObjChange.Location = new System.Drawing.Point(616, 277);
            this.btnApplyObjChange.Name = "btnApplyObjChange";
            this.btnApplyObjChange.Size = new System.Drawing.Size(102, 24);
            this.btnApplyObjChange.TabIndex = 50;
            this.btnApplyObjChange.Text = "Apply &Changes";
            this.btnApplyObjChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApplyObjChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApplyObjChange.UseVisualStyleBackColor = true;
            this.btnApplyObjChange.Click += new System.EventHandler(this.btnApplyObjChange_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilter.Image = global::PartsIffTool.Properties.Resources.zoom;
            this.btnFilter.Location = new System.Drawing.Point(207, 278);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 24);
            this.btnFilter.TabIndex = 46;
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
            this.picHorizBadge.Size = new System.Drawing.Size(430, 32);
            this.picHorizBadge.TabIndex = 41;
            this.picHorizBadge.TabStop = false;
            this.picHorizBadge.Paint += new System.Windows.Forms.PaintEventHandler(this.picHorizBadge_Paint);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = global::PartsIffTool.Properties.Resources.database_edit;
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.Location = new System.Drawing.Point(118, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 24);
            this.btnOpen.TabIndex = 42;
            this.btnOpen.Text = "Open IFF File";
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnInsertColor
            // 
            this.btnInsertColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertColor.Location = new System.Drawing.Point(662, 128);
            this.btnInsertColor.Name = "btnInsertColor";
            this.btnInsertColor.Size = new System.Drawing.Size(56, 23);
            this.btnInsertColor.TabIndex = 58;
            this.btnInsertColor.Text = "Color";
            this.btnInsertColor.UseVisualStyleBackColor = true;
            this.btnInsertColor.Click += new System.EventHandler(this.btnInsertColor_Click);
            // 
            // DescEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 314);
            this.Controls.Add(this.btnInsertColor);
            this.Controls.Add(this.btnTranslateFile);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtObjDescription);
            this.Controls.Add(this.lstParts);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnAddNewObj);
            this.Controls.Add(this.btnDeleteObj);
            this.Controls.Add(this.btnDiscardObjChange);
            this.Controls.Add(this.btnApplyObjChange);
            this.Controls.Add(this.txtObjId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.picHorizBadge);
            this.Controls.Add(this.btnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DescEditor";
            this.Text = "Pangya Desc Editor";
            this.Resize += new System.EventHandler(this.DescEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picHorizBadge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstParts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnAddNewObj;
        private System.Windows.Forms.Button btnDeleteObj;
        private System.Windows.Forms.Button btnDiscardObjChange;
        private System.Windows.Forms.Button btnApplyObjChange;
        private System.Windows.Forms.TextBox txtObjId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.PictureBox picHorizBadge;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtObjDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnTranslateFile;
        private System.Windows.Forms.Button btnInsertColor;
    }
}