using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ManoyDB_CRUD.TableControl
{
    public partial class TC_Product : UserControl
    {
        FormProduct form;
        public TC_Product()
        {
            InitializeComponent();
            Load += TC_Product_Load;
            form = new FormProduct(this);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DbCustomer.DisplayAndSearch("SELECT product_id, product_store, product_name, product_price, order_date FROM product_table WHERE product_store LIKE '%" + txtSearch.Text + "%' OR product_name LIKE '%" + txtSearch.Text + "%' OR product_price LIKE '%" + txtSearch.Text + "%'", dataGridView);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        public void Display()
        {
            DbCustomer.DisplayAndSearch("SELECT product_id, product_store, product_name, product_price, order_date FROM product_table", dataGridView);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            form.Clear();
            form.ResetForm();
            form.ShowDialog();
        }
        public void TC_Product_Shown(object sender, EventArgs e)
        {
            Display();
        }
        private void TC_Product_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                form.Clear();
                form.product_id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.product_store = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.product_name = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.product_price = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.order_date = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                //Edit
                return;
            }
            if (e.ColumnIndex == 1)
            {
                //Delete
                if (MessageBox.Show("Are you sure you want to delete product record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbProduct.DeleteProduct(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }

                return;
            }

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
