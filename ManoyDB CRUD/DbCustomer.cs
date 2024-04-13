using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ManoyDB_CRUD
{
    class DbCustomer
    {

        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=manoydb";
            MySqlConnection conn = new MySqlConnection(sql);
            try
            {
                conn.Open();

            }
            catch (MySqlException ex) {

                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }
        public static void AddCustomer(manoydb std)
        {
            string sql = "INSERT INTO customer_table VALUES (NULL, @customer_first_name, @customer_last_name, @customer_barangay, @customer_municipality, @contact_number, NULL)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@customer_first_name", MySqlDbType.VarChar).Value = std.customer_first_name;
            cmd.Parameters.Add("@customer_last_name", MySqlDbType.VarChar).Value = std.customer_last_name;
            cmd.Parameters.Add("@customer_barangay", MySqlDbType.VarChar).Value = std.customer_barangay;
            cmd.Parameters.Add("@customer_municipality", MySqlDbType.VarChar).Value = std.customer_municipality;
            cmd.Parameters.Add("@contact_number", MySqlDbType.VarChar).Value = std.contact_number;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Customer couldn't be created. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

        }

        public static void UpdateCustomer(manoydb std, string customer_id)
        {
            string sql = "UPDATE customer_table SET customer_first_name = @customer_first_name, customer_last_name = @customer_last_name, customer_barangay = @customer_barangay, customer_municipality = @customer_municipality, contact_number = @contact_number WHERE customer_id = @customer_id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@customer_id", MySqlDbType.VarChar).Value = customer_id;
            cmd.Parameters.Add("@customer_first_name", MySqlDbType.VarChar).Value = std.customer_first_name;
            cmd.Parameters.Add("@customer_last_name", MySqlDbType.VarChar).Value = std.customer_last_name;
            cmd.Parameters.Add("@customer_barangay", MySqlDbType.VarChar).Value = std.customer_barangay;
            cmd.Parameters.Add("@customer_municipality", MySqlDbType.VarChar).Value = std.customer_municipality;
            cmd.Parameters.Add("@contact_number", MySqlDbType.VarChar).Value = std.contact_number;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Customer coudn't be updated. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
        public static void DeleteCustomer(string customer_id)
        {
            string sql = "DELETE FROM customer_table WHERE customer_id = @customer_id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@customer_id", MySqlDbType.VarChar).Value = string.IsNullOrEmpty(customer_id) ? (object)DBNull.Value : customer_id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Customer coudn't be deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            con.Close();
            dgv.DataSource = tbl;
        }
    }
}
