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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            TableControl.TC_Customer tc = new TableControl.TC_Customer();
            addTableControl(tc);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void addTableControl(UserControl tableControl)
        {
            tableControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(tableControl);
            tableControl.BringToFront();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TableControl.TC_Customer tc = new TableControl.TC_Customer();
            addTableControl(tc);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            TableControl.TC_Product tc = new TableControl.TC_Product();
            addTableControl(tc);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //TableControl.TC_Rider tc = new TableControl.TC_Rider();
            //addTableControl(tc);
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            TableControl.TC_Service tc = new TableControl.TC_Service();
            addTableControl(tc);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }
    }
}
