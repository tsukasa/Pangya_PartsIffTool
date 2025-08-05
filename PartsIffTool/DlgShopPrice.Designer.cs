namespace PartsIffTool
{
    partial class DlgShopPrice
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
            this.txtItemUsedPrice = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtItemStallPrice = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.rbItemCostsSpecial = new System.Windows.Forms.RadioButton();
            this.rbItemCostsCookies = new System.Windows.Forms.RadioButton();
            this.rbItemCostsPang = new System.Windows.Forms.RadioButton();
            this.txtItemCost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetHighUsedPrice = new System.Windows.Forms.Button();
            this.btnSetHighDiscountPrice = new System.Windows.Forms.Button();
            this.btnSetHighPrice = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtItemUsedPrice
            // 
            this.txtItemUsedPrice.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemUsedPrice.Location = new System.Drawing.Point(382, 38);
            this.txtItemUsedPrice.Name = "txtItemUsedPrice";
            this.txtItemUsedPrice.Size = new System.Drawing.Size(113, 21);
            this.txtItemUsedPrice.TabIndex = 5;
            this.txtItemUsedPrice.Text = "0";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(281, 37);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(95, 23);
            this.label19.TabIndex = 134;
            this.label19.Text = "Used Price:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemStallPrice
            // 
            this.txtItemStallPrice.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemStallPrice.Location = new System.Drawing.Point(382, 11);
            this.txtItemStallPrice.Name = "txtItemStallPrice";
            this.txtItemStallPrice.Size = new System.Drawing.Size(113, 21);
            this.txtItemStallPrice.TabIndex = 3;
            this.txtItemStallPrice.Text = "0";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(281, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 23);
            this.label18.TabIndex = 131;
            this.label18.Text = "Discount Price:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbItemCostsSpecial
            // 
            this.rbItemCostsSpecial.AutoSize = true;
            this.rbItemCostsSpecial.Location = new System.Drawing.Point(113, 83);
            this.rbItemCostsSpecial.Name = "rbItemCostsSpecial";
            this.rbItemCostsSpecial.Size = new System.Drawing.Size(84, 17);
            this.rbItemCostsSpecial.TabIndex = 9;
            this.rbItemCostsSpecial.Text = "Price not set";
            this.rbItemCostsSpecial.UseVisualStyleBackColor = true;
            // 
            // rbItemCostsCookies
            // 
            this.rbItemCostsCookies.AutoSize = true;
            this.rbItemCostsCookies.Location = new System.Drawing.Point(113, 60);
            this.rbItemCostsCookies.Name = "rbItemCostsCookies";
            this.rbItemCostsCookies.Size = new System.Drawing.Size(101, 17);
            this.rbItemCostsCookies.TabIndex = 8;
            this.rbItemCostsCookies.Text = "Price in Cookies";
            this.rbItemCostsCookies.UseVisualStyleBackColor = true;
            // 
            // rbItemCostsPang
            // 
            this.rbItemCostsPang.AutoSize = true;
            this.rbItemCostsPang.Checked = true;
            this.rbItemCostsPang.Location = new System.Drawing.Point(113, 37);
            this.rbItemCostsPang.Name = "rbItemCostsPang";
            this.rbItemCostsPang.Size = new System.Drawing.Size(88, 17);
            this.rbItemCostsPang.TabIndex = 7;
            this.rbItemCostsPang.TabStop = true;
            this.rbItemCostsPang.Text = "Price in Pang";
            this.rbItemCostsPang.UseVisualStyleBackColor = true;
            // 
            // txtItemCost
            // 
            this.txtItemCost.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCost.Location = new System.Drawing.Point(113, 10);
            this.txtItemCost.Name = "txtItemCost";
            this.txtItemCost.Size = new System.Drawing.Size(113, 21);
            this.txtItemCost.TabIndex = 1;
            this.txtItemCost.Text = "0";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 128;
            this.label3.Text = "Shop Price:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSetHighUsedPrice
            // 
            this.btnSetHighUsedPrice.Image = global::PartsIffTool.Properties.Resources.bullet_arrow_up;
            this.btnSetHighUsedPrice.Location = new System.Drawing.Point(501, 37);
            this.btnSetHighUsedPrice.Name = "btnSetHighUsedPrice";
            this.btnSetHighUsedPrice.Size = new System.Drawing.Size(23, 23);
            this.btnSetHighUsedPrice.TabIndex = 6;
            this.btnSetHighUsedPrice.UseVisualStyleBackColor = true;
            this.btnSetHighUsedPrice.Click += new System.EventHandler(this.btnSetHighUsedPrice_Click);
            // 
            // btnSetHighDiscountPrice
            // 
            this.btnSetHighDiscountPrice.Image = global::PartsIffTool.Properties.Resources.bullet_arrow_up;
            this.btnSetHighDiscountPrice.Location = new System.Drawing.Point(501, 10);
            this.btnSetHighDiscountPrice.Name = "btnSetHighDiscountPrice";
            this.btnSetHighDiscountPrice.Size = new System.Drawing.Size(23, 23);
            this.btnSetHighDiscountPrice.TabIndex = 4;
            this.btnSetHighDiscountPrice.UseVisualStyleBackColor = true;
            this.btnSetHighDiscountPrice.Click += new System.EventHandler(this.btnSetHighDiscountPrice_Click);
            // 
            // btnSetHighPrice
            // 
            this.btnSetHighPrice.Image = global::PartsIffTool.Properties.Resources.bullet_arrow_up;
            this.btnSetHighPrice.Location = new System.Drawing.Point(232, 9);
            this.btnSetHighPrice.Name = "btnSetHighPrice";
            this.btnSetHighPrice.Size = new System.Drawing.Size(23, 23);
            this.btnSetHighPrice.TabIndex = 2;
            this.btnSetHighPrice.UseVisualStyleBackColor = true;
            this.btnSetHighPrice.Click += new System.EventHandler(this.btnSetHighPrice_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(449, 112);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(368, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DlgShopPrice
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(545, 147);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtItemUsedPrice);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtItemStallPrice);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.rbItemCostsSpecial);
            this.Controls.Add(this.rbItemCostsCookies);
            this.Controls.Add(this.rbItemCostsPang);
            this.Controls.Add(this.txtItemCost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSetHighUsedPrice);
            this.Controls.Add(this.btnSetHighDiscountPrice);
            this.Controls.Add(this.btnSetHighPrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgShopPrice";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Price";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemUsedPrice;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtItemStallPrice;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton rbItemCostsSpecial;
        private System.Windows.Forms.RadioButton rbItemCostsCookies;
        private System.Windows.Forms.RadioButton rbItemCostsPang;
        private System.Windows.Forms.TextBox txtItemCost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSetHighUsedPrice;
        private System.Windows.Forms.Button btnSetHighDiscountPrice;
        private System.Windows.Forms.Button btnSetHighPrice;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}