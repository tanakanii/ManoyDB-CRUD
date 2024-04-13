using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManoyDB_CRUD;
using MySql.Data.MySqlClient;

namespace ManoyDB_CRUD
{
    class DbService
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
        public static void AddService(manoydb6 std)
        {
            string sql = "INSERT INTO service_table VALUES (NULL, @service_name, @starting_fee, NULL)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@service_name", MySqlDbType.VarChar).Value = std.service_name;
            cmd.Parameters.Add("@starting_fee", MySqlDbType.VarChar).Value = std.starting_fee;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Service couldn't be created. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

        }

        public static void UpdateService(manoydb6 std, string service_id)
        {
            string sql = "UPDATE service_table SET service_name = @service_name, starting_fee = @starting_fee WHERE service_id = @service_id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@service_id", MySqlDbType.VarChar).Value = service_id;
            cmd.Parameters.Add("@service_name", MySqlDbType.VarChar).Value = std.service_name;
            cmd.Parameters.Add("@starting_fee", MySqlDbType.VarChar).Value = std.starting_fee;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Service coudn't be updated. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
        public static void DeleteService(string service_id)
        {
            string sql = "DELETE FROM service_table WHERE service_id = @service_id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@service_id", MySqlDbType.VarChar).Value = string.IsNullOrEmpty(service_id) ? (object)DBNull.Value : service_id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Service coudn't be deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
