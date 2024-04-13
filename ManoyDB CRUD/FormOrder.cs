using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ManoyDB_CRUD
{
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string orderService = txtOrderService.Text;
            string store = txtStore.Text;
            string productName = txtOrderProductName.Text;
            string price = txtPrice.Text;
            string firstName = txtFN.Text;
            string lastName = txtLN.Text;
            string barangay = txtBrgy.Text;
            string municipal = txtMunicipal.Text;
            string contactNo = txtContact.Text;
            DateTime orderDate = txtDate.Value;
            if (string.IsNullOrEmpty(orderService) || string.IsNullOrEmpty(store) || string.IsNullOrEmpty(productName)
            || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)
            || string.IsNullOrEmpty(barangay) || string.IsNullOrEmpty(municipal) || string.IsNullOrEmpty(contactNo))
                {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string connectionStr = "server=localhost;user id=root;password=;database=manoydb";

            using (MySqlConnection conn = new MySqlConnection(connectionStr))
            {
                conn.Open();

                string query = "INSERT INTO product_table (product_store, product_name, product_price, order_date) " +
                               "VALUES (@Store, @ProductName, @Price, @OrderDate);" +
                               "INSERT INTO customer_table (customer_first_name, customer_last_name, customer_barangay, customer_municipality, contact_number) " +
                               "VALUES (@FirstName, @LastName, @Barangay, @Municipal, @ContactNo);";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Parameters for product_table
                    cmd.Parameters.AddWithValue("@Store", store);
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@OrderDate", orderDate);

                    // Parameters for customer_table
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Barangay", barangay);
                    cmd.Parameters.AddWithValue("@Municipal", municipal);
                    cmd.Parameters.AddWithValue("@ContactNo", contactNo);

                    // Execute the query
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Successfully Saved.");
            }
        }

    }
}