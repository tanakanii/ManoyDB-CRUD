using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;
using ManoyDB_CRUD.TableControl;
using ManoyDB_CRUD;

namespace ManoyDB_CRUD
{
    public partial class FormService : Form
    {
        private readonly TC_Service _parent;
        public string service_id, service_name, starting_fee;


        public FormService(TC_Service parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        public void UpdateInfo()
        {
            lbltext.Text = "Update Service Details";
            btnSave.Text = "Update";
            txtServiceName.Text = service_name;
            txtStartingFeeName.Text = starting_fee;
        }

        public void Clear()
        {
            txtServiceName.Text = txtStartingFeeName.Text = string.Empty;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtServiceName.Text.Trim().Length < 3)
            {
                MessageBox.Show("First Name is Empty ( > 1 ).");
                return;
            }
            if (txtStartingFeeName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Last Name is Empty ( > 1 ).");
                return;
            }

            if (btnSave.Text == "Save")
            {
                manoydb6 std = new manoydb6(txtServiceName.Text.Trim(), txtStartingFeeName.Text.Trim());
                DbService.AddService(std);
                Clear();
            }
            if (btnSave.Text == "Update")
            {
                manoydb6 std = new manoydb6(txtServiceName.Text.Trim(), txtStartingFeeName.Text.Trim());
                DbService.UpdateService(std, service_id);
            }
            _parent.Display();

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
            LabelText = "Add Service";
            SaveButtonText = "Save";
            Clear();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
