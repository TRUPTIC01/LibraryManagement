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
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = LAPTOP-IF4F1658; Initial Catalog =TestDb; User ID =Sony; Password = 9611998067";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= conn;
            
            conn.Open();

            cmd = new SqlCommand("Select bName from NewBook", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                for(int i =0;i<reader.FieldCount;i++)
                {
                    comboBookName.Items.Add(reader.GetString(i));
                }
                
              

            }
            reader.Close();
            conn.Close();
        }

        int count;
        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            if (txtSearchUSN.Text != "")
            {
                String uid = txtSearchUSN.Text;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source = LAPTOP-IF4F1658; Initial Catalog =TestDb; User ID =Sony; Password = 9611998067";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select * from NewStudent where usn = '" + uid + "'";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);





                // code to count number of books issued
                cmd.CommandText = "Select count(std_usn) from IRBooks1 where std_usn = '" + uid + "' and book_return_date is null ";
                SqlDataAdapter sda1 = new SqlDataAdapter();
                DataSet ds1 = new DataSet();
                sda.Fill(ds1);

                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());



                if (ds.Tables[0].Rows.Count != 0) {

                    txtStudentName.Text= ds.Tables[0].Rows[0][1].ToString();
                    txtDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtSemester.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();


                }
                else
                {
                    txtStudentName.Clear();
                    txtDepartment.Clear();
                    txtSemester.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();

                    MessageBox.Show("Invalid USN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text != "")
            {

                if (comboBookName.SelectedIndex != -1 && count <= 2)
                {
                    String usn = txtSearchUSN.Text;
                    String sname = txtStudentName.Text;
                    String dept = txtDepartment.Text;
                    String sem = txtSemester.Text;
                    Int64 contact = Int64.Parse(txtContact.Text);
                    String email = txtEmail.Text;
                    String BookName = comboBookName.Text;
                    String BookIssueDate = dateTimePicker1.Text;


                    String uid = txtSearchUSN.Text;
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = @"Data Source = LAPTOP-IF4F1658; Initial Catalog =TestDb; User ID =Sony; Password = 9611998067";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "insert into IRBooks1(std_name,std_usn,std_dept,std_sem,std_contact,std_email,book_name,book_issue_date) values('" + sname + "','"+usn+"','" + dept + "','" + sem + "', " + contact + ",'" + email + "','" + BookName + "','" + BookIssueDate + "')"; 
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Book Issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Select Book OR Max Books has been Issued", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {

                MessageBox.Show("Enter Valid USN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtSearchUSN_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchUSN.Text != "")
            {
                txtStudentName.Clear();
                txtDepartment.Clear();
                txtSemester.Clear();
                txtEmail.Clear();
                txtContact.Clear();

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchUSN.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
