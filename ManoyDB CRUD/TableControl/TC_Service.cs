using System;
using System.Windows.Forms;

namespace ManoyDB_CRUD.TableControl
{
    public partial class TC_Service : UserControl
    {
        FormService form;
        public TC_Service()
        {
            InitializeComponent();
            Load += TC_Service_Load;
            form = new FormService(this);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DbService.DisplayAndSearch("SELECT service_id, service_name, starting_fee FROM service_table WHERE service_id LIKE '%" + txtSearch.Text + "%' OR service_name LIKE '%" + txtSearch.Text + "%' OR starting_fee LIKE '%" + txtSearch.Text + "%'", dataGridView);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        public void Display()
        {
            DbService.DisplayAndSearch("SELECT service_id, service_name, starting_fee FROM service_table", dataGridView);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            form.Clear();
            form.ResetForm();
            form.ShowDialog();
        }
        public void TC_Service_Shown(object sender, EventArgs e)
        {
            Display();
        }
        private void TC_Service_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                form.Clear();
                form.service_id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.service_name = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.starting_fee = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                //Edit
                return;
            }
            if (e.ColumnIndex == 1)
            {
                //Delete
                if (MessageBox.Show("Are you sure you want to delete service record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbService.DeleteService(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }

                return;
            }

        }
    }
}
