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
using OfficeOpenXml;

namespace ManoyDB_CRUD.TableControl
{
    public partial class TC_Customer : UserControl
    {
        FormCustomer form;
        public TC_Customer()
        {
            InitializeComponent();
            Load += TC_Customer_Load;
            form = new FormCustomer(this);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DbCustomer.DisplayAndSearch("SELECT customer_id, customer_first_name, customer_last_name, customer_barangay, customer_municipality, contact_number FROM customer_table WHERE customer_first_name LIKE '%"+ txtSearch.Text +"%'", dataGridView);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        public void Display()
        {
            DbCustomer.DisplayAndSearch("SELECT customer_id, customer_first_name, customer_last_name, customer_barangay, customer_municipality, contact_number FROM customer_table", dataGridView);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
            form.Clear();
            form.ResetForm();
            form.ShowDialog();
        }
        public void TC_Customer_Shown(object sender, EventArgs e)
        {
            Display();
        }
        private void TC_Customer_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                form.Clear();
                form.customer_id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.customer_first_name = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.customer_last_name = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.customer_barangay = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.customer_municipality = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.contact_number = dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                //Edit
                return;
            }
            if (e.ColumnIndex == 1)
            {
                //Delete
                if(MessageBox.Show("Are you sure you want to delete cutomer record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbCustomer.DeleteCustomer(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
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
        private void ExportToExcel()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.DefaultExt = "xlsx";
                sfd.FileName = "CustomerData.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("CustomerData");

                        int headerIndex = 1;
                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            if (i != 0 && i != 1)
                            {
                                worksheet.Cells[headerIndex, i - 1].Value = dataGridView.Columns[i].HeaderText;
                            }
                        }

                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView.Columns.Count; j++)
                            {
                                if (j != 0 && j != 1)
                                {
                                    worksheet.Cells[i + 2, j - 1].Value = dataGridView.Rows[i].Cells[j].Value;
                                }
                            }
                        }

                        // Save the file
                        package.SaveAs(new System.IO.FileInfo(sfd.FileName));
                    }

                    MessageBox.Show("Excel file generated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
    }
}
