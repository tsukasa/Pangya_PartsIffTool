using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PartsIffTool
{
    public partial class DlgShopPrice : Form
    {
        public UInt32 Price
        {
            get
            {
                return Convert.ToUInt32(txtItemCost.Text);
            }
        }

        public UInt32 DiscountPrice
        {
            get
            {
                return Convert.ToUInt32(txtItemStallPrice.Text);
            }
        }

        public UInt32 UsedPrice
        {
            get
            {
                return Convert.ToUInt32(txtItemUsedPrice.Text);
            }
        }

        public Byte MoneyType
        {
            get
            {
                if (rbItemCostsCookies.Checked)
                    return 0x01;
                if (rbItemCostsPang.Checked)
                    return 0x02;
                if (rbItemCostsSpecial.Checked)
                    return 0x00;

                // If none of the conditions match
                return 0x00;
            }
        }

        public DlgShopPrice()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSetHighPrice_Click(object sender, EventArgs e)
        {
            txtItemCost.Text = "10000000";
        }

        private void btnSetHighDiscountPrice_Click(object sender, EventArgs e)
        {
            txtItemStallPrice.Text = "10000000";
        }

        private void btnSetHighUsedPrice_Click(object sender, EventArgs e)
        {
            txtItemUsedPrice.Text = "10000000";
        }
    }
}
