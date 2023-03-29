using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibraryManagementProject
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm?","Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
            this.Close();
        }

        private void btnStudRefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtUSN.Clear();
            txtDept.Clear();
            txtSem.Clear();
            txtContact.Clear();
            txtEmail.Clear();
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtUSN.Text != "" && txtDept.Text != "" && txtSem.Text != "" && txtContact.Text != "" && txtEmail.Text != "")
            {
                String name = txtName.Text;
                String usn = txtUSN.Text;
                String dept = txtDept.Text;
                String sem = txtSem.Text;
                Int64 Contact = Int64.Parse(txtContact.Text);
                String email = txtEmail.Text;

                SqlConnection sqlobj = new SqlConnection();
                sqlobj.ConnectionString = @"Data Source = LAPTOP-IF4F1658; Initial Catalog =TestDb; User ID =Sony; Password = 9611998067";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlobj;

                sqlobj.Open();
                cmd.CommandText = "insert into NewStudent(sname,usn,dept,sem,contact,email) values ('" + name + "','"+ usn + " ', '" + dept + "','" + sem + "'," + Contact + ",'" + email + "' " + ")";
                cmd.ExecuteNonQuery();
                sqlobj.Close();
                MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please Fill the Empty Field", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
