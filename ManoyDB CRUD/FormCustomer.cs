using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManoyDB_CRUD.TableControl;
using MySql.Data.MySqlClient;

namespace ManoyDB_CRUD
{
    public partial class FormCustomer : Form
    {
        private readonly TC_Customer _parent;
        public string customer_id, customer_first_name,customer_last_name, customer_barangay, customer_municipality, contact_number;


        public FormCustomer(TC_Customer parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        public void UpdateInfo()
        {
            lbltext.Text = "Update Customer Details";
            btnSave.Text = "Update";
            txtFirstName.Text = customer_first_name;
            txtLastName.Text = customer_last_name;
            txtBarangay.Text = customer_barangay;
            txtMunicipality.Text = customer_municipality;
            txtContactNo.Text = contact_number;
        }
       
        public void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtBarangay.Text = txtMunicipality.Text = txtContactNo.Text = string.Empty;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Trim().Length < 3)
            {
                MessageBox.Show("First Name is Empty ( > 1 ).");
                return;
            }
            if (txtLastName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Last Name is Empty ( > 1 ).");
                return;
            }
            if (txtContactNo.Text.Trim().Length != 11 || !IsNumeric(txtContactNo.Text.Trim()))
            {
                MessageBox.Show("Contact No. should be 11 digits and contain only numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtBarangay.Text.Trim().Length < 3)
            {
                MessageBox.Show("Barangay is Empty ( > 1 ).");
                return;
            }
            if (txtMunicipality.Text.Trim().Length < 3)
            {
                MessageBox.Show("Municipality is Empty ( > 1 ).");
                return;
            }

            if (btnSave.Text == "Save")
            {
                manoydb std = new manoydb(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtBarangay.Text.Trim(), txtMunicipality.Text.Trim(), txtContactNo.Text.Trim());
                DbCustomer.AddCustomer(std);
                Clear();
            }
            if (btnSave.Text == "Update")
            {
                manoydb std = new manoydb(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtBarangay.Text.Trim(), txtMunicipality.Text.Trim(), txtContactNo.Text.Trim());
                DbCustomer.UpdateCustomer(std, customer_id);
            }
            _parent.Display();
        }

        private bool IsNumeric(string input)
        {
            return long.TryParse(input, out _);
        }
        public string LabelText
        {
            get { return lbltext.Text; }
            set { lbltext.Text = value; }
        }

        public string SaveButtonText
        {
            get { return btnSave.Text; }
            set { btnSave.Text = value; }
        }
        public void ResetForm()
        {
            LabelText = "Add Customer";
            SaveButtonText = "Save";
            Clear();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
