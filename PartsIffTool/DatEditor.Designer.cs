namespace PartsIffTool
{
    partial class DatEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatEditor));
            this.lstWords = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.picHorizBadge = new System.Windows.Forms.PictureBox();
            this.btnAddNewWord = new System.Windows.Forms.Button();
            this.btnDeleteWord = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTypeChooser = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNewList = new System.Windows.Forms.ToolStripButton();
            this.tbsOpenList = new System.Windows.Forms.ToolStripButton();
            this.tbsSaveList = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picHorizBadge)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstWords
            // 
            this.lstWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstWords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstWords.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstWords.FullRowSelect = true;
            this.lstWords.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstWords.Location = new System.Drawing.Point(6, 67);
            this.lstWords.MultiSelect = false;
            this.lstWords.Name = "lstWords";
            this.lstWords.Size = new System.Drawing.Size(270, 372);
            this.lstWords.TabIndex = 45;
            this.lstWords.UseCompatibleStateImageBehavior = false;
            this.lstWords.View = System.Windows.Forms.View.Details;
            this.lstWords.SelectedIndexChanged += new System.EventHandler(this.lstWords_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item Name";
            this.columnHeader1.Width = 240;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Boo-boo Word:";
            // 
            // txtWord
            // 
            this.txtWord.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWord.Location = new System.Drawing.Point(370, 76);
            this.txtWord.MaxLength = 29;
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(144, 21);
            this.txtWord.TabIndex = 47;
            this.txtWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWord_KeyDown);
            // 
            // picHorizBadge
            // 
            this.picHorizBadge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picHorizBadge.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picHorizBadge.Location = new System.Drawing.Point(282, 28);
            this.picHorizBadge.Name = "picHorizBadge";
            this.picHorizBadge.Size = new System.Drawing.Size(452, 32);
            this.picHorizBadge.TabIndex = 48;
            this.picHorizBadge.TabStop = false;
            this.picHorizBadge.Paint += new System.Windows.Forms.PaintEventHandler(this.picHorizBadge_Paint);
            // 
            // btnAddNewWord
            // 
            this.btnAddNewWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewWord.Image = global::PartsIffTool.Properties.Resources.add;
            this.btnAddNewWord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewWord.Location = new System.Drawing.Point(632, 415);
            this.btnAddNewWord.Name = "btnAddNewWord";
            this.btnAddNewWord.Size = new System.Drawing.Size(102, 24);
            this.btnAddNewWord.TabIndex = 56;
            this.btnAddNewWord.Text = "&Add Word";
            this.btnAddNewWord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewWord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewWord.UseVisualStyleBackColor = true;
            this.btnAddNewWord.Click += new System.EventHandler(this.btnAddNewWord_Click);
            // 
            // btnDeleteWord
            // 
            this.btnDeleteWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteWord.Image = global::PartsIffTool.Properties.Resources.delete;
            this.btnDeleteWord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteWord.Location = new System.Drawing.Point(524, 415);
            this.btnDeleteWord.Name = "btnDeleteWord";
            this.btnDeleteWord.Size = new System.Drawing.Size(102, 24);
            this.btnDeleteWord.TabIndex = 55;
            this.btnDeleteWord.Text = "&Delete Word";
            this.btnDeleteWord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteWord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteWord.UseVisualStyleBackColor = true;
            this.btnDeleteWord.Click += new System.EventHandler(this.btnDeleteWord_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Note: Saving an empty list will disable the filter.";
            // 
            // cmbTypeChooser
            // 
            this.cmbTypeChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeChooser.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypeChooser.FormattingEnabled = true;
            this.cmbTypeChooser.Items.AddRange(new object[] {
            "chat.bin",
            "nick.bin"});
            this.cmbTypeChooser.Location = new System.Drawing.Point(105, 33);
            this.cmbTypeChooser.Name = "cmbTypeChooser";
            this.cmbTypeChooser.Size = new System.Drawing.Size(171, 23);
            this.cmbTypeChooser.TabIndex = 59;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewList,
            this.tbsOpenList,
            this.tbsSaveList});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(741, 25);
            this.toolStrip1.TabIndex = 60;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNewList
            // 
            this.tsbNewList.Image = global::PartsIffTool.Properties.Resources.database_add;
            this.tsbNewList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewList.Name = "tsbNewList";
            this.tsbNewList.Size = new System.Drawing.Size(72, 22);
            this.tsbNewList.Text = "New List";
            this.tsbNewList.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // tbsOpenList
            // 
            this.tbsOpenList.Image = global::PartsIffTool.Properties.Resources.database_edit;
            this.tbsOpenList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsOpenList.Name = "tbsOpenList";
            this.tbsOpenList.Size = new System.Drawing.Size(77, 22);
            this.tbsOpenList.Text = "Open List";
            this.tbsOpenList.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tbsSaveList
            // 
            this.tbsSaveList.Image = global::PartsIffTool.Properties.Resources.database_save;
            this.tbsSaveList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsSaveList.Name = "tbsSaveList";
            this.tbsSaveList.Size = new System.Drawing.Size(72, 22);
            this.tbsSaveList.Text = "Save List";
            this.tbsSaveList.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 61;
            this.label3.Text = "File Type:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 62;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DatEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 451);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cmbTypeChooser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddNewWord);
            this.Controls.Add(this.btnDeleteWord);
            this.Controls.Add(this.picHorizBadge);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstWords);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DatEditor";
            this.Text = "Pangya $%*§ Editor";
            this.Resize += new System.EventHandler(this.DatEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picHorizBadge)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstWords;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.PictureBox picHorizBadge;
        private System.Windows.Forms.Button btnAddNewWord;
        private System.Windows.Forms.Button btnDeleteWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTypeChooser;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNewList;
        private System.Windows.Forms.ToolStripButton tbsOpenList;
        private System.Windows.Forms.ToolStripButton tbsSaveList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}