using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManoyDB_CRUD;

namespace ManoyDB_CRUD
{
    public partial class UC_Admin : UserControl
    {
        public UC_Admin()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                string user, pass;
                user = username_txt.Text.Trim();
                pass = password_txt.Text.Trim();

                if (user == "admin" && pass == "admin123")
                {
                    MessageBox.Show("Welcome, Admin!");
                    // Hide the current form (UC_Admin)
                    this.ParentForm.Hide();

                    // Open the MenuForm
                    MenuForm menuForm = new MenuForm();
                    menuForm.FormClosed += (s, args) => this.ParentForm.Close(); // Close UC_Admin when MenuForm is closed
                    menuForm.Show();
                }
                else if (user == "" || pass == "")
                {
                    MessageBox.Show("Please Type Your Username Or Password");
                }
                else if (user == "admin" && pass != "admin123")
                {
                    MessageBox.Show("Incorrect Password, Please Try Again.");
                }
                else if (user != "admin" && pass == "admin123")
                {
                    MessageBox.Show("Incorrect Username, Please Try Again.");
                }
                else
                {
                    MessageBox.Show("Incorrect Username And Password!");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or log it, if needed
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            // Remove the current UserControl (UC_Admin) from its parent container
            this.Parent.Controls.Remove(this);

        }

    }
}
