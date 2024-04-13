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
    class DbProduct
    {

        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=manoydb";
            MySqlConnection conn = new MySqlConnection(sql);
            try
            {
                conn.Open();

            }
            catch (MySqlException ex)
            {

                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }
        public static void AddProduct(manoydb3 std)
        {
            string sql = "INSERT INTO product_table VALUES (NULL, @product_store, @product_name, @product_price, @order_date, NULL)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@product_store", MySqlDbType.VarChar).Value = std.product_store;
            cmd.Parameters.Add("@product_name", MySqlDbType.VarChar).Value = std.product_name;
            cmd.Parameters.Add("@product_price", MySqlDbType.VarChar).Value = std.product_price;
            cmd.Parameters.Add("@order_date", MySqlDbType.Date).Value = std.order_date;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Product couldn't be created. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

        }

        public static void UpdateProduct(manoydb3 std, string product_id)
        {
            string sql = "UPDATE product_table SET product_store = @product_store, product_name = @product_name, product_price = @product_price, order_date = @order_date WHERE product_id = @product_id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@product_id", MySqlDbType.VarChar).Value = product_id;
            cmd.Parameters.Add("@product_store", MySqlDbType.VarChar).Value = std.product_store;
            cmd.Parameters.Add("@product_name", MySqlDbType.VarChar).Value = std.product_name;
            cmd.Parameters.Add("@product_price", MySqlDbType.VarChar).Value = std.product_price;
            cmd.Parameters.Add("@order_date", MySqlDbType.VarChar).Value = std.order_date;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Order coudn't be updated. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
        public static void DeleteProduct(string product_id)
        {
            string sql = "DELETE FROM product_table WHERE product_id = @product_id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@product_id", MySqlDbType.VarChar).Value = string.IsNullOrEmpty(product_id) ? (object)DBNull.Value : product_id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Product coudn't be deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
