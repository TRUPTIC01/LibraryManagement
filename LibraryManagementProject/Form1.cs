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

namespace LibraryManagementProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsrName_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void txtUsrName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsrName.Text == "UserName")
            {
                txtUsrName.Clear();
            }

        }

        private void txtPswrd_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPswrd.Text == "Password")
            {
                txtPswrd.Clear();
                txtPswrd.PasswordChar = '*';

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = LAPTOP-IF4F1658; Initial Catalog =TestDb; User ID =Sony; Password = 9611998067";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from loginTable where UserName ='"+txtUsrName.Text+"' and pass = '"+txtPswrd.Text+"' ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count!= 0) {
                this.Hide();
                Dashboard dsb = new Dashboard();
                dsb.Show();
            } else
            {
                MessageBox.Show("User doesn't Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 signup = new Form2();
            signup.Show();
        }

        private void txtUsrName_Enter(object sender, EventArgs e)
        {
            txtUsrName.Clear();
        }

       

        private void txtPswrd_Enter(object sender, EventArgs e)
        {
            txtPswrd.Clear();
            txtPswrd.PasswordChar = '*';
        }
    }
    }
