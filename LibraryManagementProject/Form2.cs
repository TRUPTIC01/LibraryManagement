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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if(txtPasswrdConfirm.Text!="" || txtPswrd.Text != "" || txtUsrName.Text != ""){
                if (txtPswrd.Text == txtPasswrdConfirm.Text)
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = @"Data Source = LAPTOP-IF4F1658; Initial Catalog =TestDb; User ID =Sony; Password = 9611998067";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from loginTable where UserName ='"+txtUsrName.Text+"' and pass = '"+txtPswrd.Text+"'", conn );
                    SqlDataReader reader = cmd.ExecuteReader(); 
                    
                    if(reader.Read())
                    {
                        reader.Close();
                        MessageBox.Show("User Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        reader.Close();
                        cmd = new SqlCommand("insert into loginTable(Username,pass) values('" + txtUsrName.Text + "', '" + txtPswrd.Text + "')", conn);

                        cmd.Parameters.AddWithValue("Username", txtUsrName.Text);
                        cmd.Parameters.AddWithValue("pass", txtPswrd.Text);
                        
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created","Done", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        conn.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Please Enter both passwords same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields not allowed","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsrName_MouseClick(object sender, MouseEventArgs e)
        {
            txtUsrName.Clear();
        }

        private void txtPswrd_MouseClick(object sender, MouseEventArgs e)
        {
            txtPswrd.Clear();
            txtPswrd.PasswordChar = '*';
        }

        private void txtPasswrdConfirm_MouseClick(object sender, MouseEventArgs e)
        {
            txtPasswrdConfirm.Clear();
            txtPasswrdConfirm.PasswordChar = '*';

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

        private void txtPasswrdConfirm_Enter(object sender, EventArgs e)
        {
            txtPasswrdConfirm.Clear();
            txtPasswrdConfirm.PasswordChar = '*';

        }

        private void txtUsrName_Click(object sender, EventArgs e)
        {
            txtUsrName.Clear();
        }

        private void txtPswrd_Click(object sender, EventArgs e)
        {
            txtPswrd.Clear();
            txtPswrd.PasswordChar = '*';
        }

       

        
        private void txtPasswrdConfirm_Click(object sender, EventArgs e)
        {
            txtPasswrdConfirm.Clear();
            txtPasswrdConfirm.PasswordChar = '*';
        }

  
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();

        }
    }
}
