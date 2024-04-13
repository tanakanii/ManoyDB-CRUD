using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManoyDB_CRUD
{
    public partial class LoginForm : Form
    {
        private UC_Admin ucAdmin;

        public LoginForm()
        {
            InitializeComponent();
            ucAdmin = new UC_Admin();
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel_container.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btn_admin_Click(object sender, EventArgs e)
        {
            addUserControl(ucAdmin);
        }

        private void btn_customer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome, Customer!");
            FormOrder formOrder = new FormOrder();
            formOrder.FormClosed += (s, args) => this.Close();
            formOrder.Show();

            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}