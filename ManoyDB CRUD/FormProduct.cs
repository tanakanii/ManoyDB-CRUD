using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManoyDB_CRUD.TableControl;

namespace ManoyDB_CRUD
{
    public partial class FormProduct : Form
    {
        private readonly TC_Product _parent;
        public string product_id, product_store, product_name, product_price, order_date;


        public FormProduct(TC_Product parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        public void UpdateInfo()
        {
            lbltext.Text = "Update Product Details";
            btnSave.Text = "Update";
            txtProductStore.Text = product_store;
            txtProductName.Text = product_name;
            txtProductPrice.Text = product_price;
            txtOderDate.Text = order_date;
        }

        public void Clear()
        {
            txtProductStore.Text = txtProductName.Text = txtProductPrice.Text = string.Empty;
        }



        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtProductStore.Text.Trim().Length < 3)
            {
                MessageBox.Show("Product Store is Empty.");
                return;
            }
            if (txtProductName.Text.Trim().Length < 0)
            {
                MessageBox.Show("Product Name is Empty.");
                return;
            }
            if (txtProductPrice.Text.Trim().Length < 0)
            {
                MessageBox.Show("Product Price is Empty.");
                return;
            }
            if (txtOderDate.Text.Trim().Length < 3)
            {
                MessageBox.Show("Order Date is Empty ( > 1 ).");
                return;
            }


            if (btnSave.Text == "Save")
            {
                manoydb3 std = new manoydb3(txtProductStore.Text.Trim(), txtProductName.Text.Trim(), txtProductPrice.Text.Trim(), txtOderDate.Value.ToString("yyyy-MM-dd"));
                DbProduct.AddProduct(std);
                Clear();
            }
            if (btnSave.Text == "Update")
            {
                manoydb3 std = new manoydb3(txtProductStore.Text.Trim(), txtProductName.Text.Trim(), txtProductPrice.Text.Trim(), txtOderDate.Value.ToString("yyyy-MM-dd"));
                DbProduct.UpdateProduct(std, product_id);
            }
            _parent.Display();
        }

        public string LabelText
        {
            get { return lbltext.Text; }
            set { lbltext.Text = value; }
        }

        public string SaveButtonText
        {
            get { return btnSave.Text; }
            set { btnSave.Text = value; }
        }
        public void ResetForm()
        {
            LabelText = "Add Product";
            SaveButtonText = "Save";
            Clear();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
