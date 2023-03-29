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
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void txtSearchUSN_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchUSN.Text != "")
            {
                label1.Visible = false;

                Image image = Image.FromFile("C:/Users/91961/Pictures/search.gif");
                pictureBox1.Image = image;

                SqlConnection sqlVsObj = new SqlConnection();
                sqlVsObj.ConnectionString = @"Data Source = LAPTOP-IF4F1658; Initial Catalog =TestDb; User ID =Sony; Password = 9611998067";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlVsObj;
                cmd.CommandText = "Select * from NewStudent where usn LIKE '"+txtSearchUSN.Text+"%'";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                dataGridView1.DataSource = dataSet.Tables[0];
            }
            else
            {
                
                label1.Visible = true;

                Image image = Image.FromFile("C:/Users/91961/Pictures/search.gif");
                pictureBox1.Image = image;
                SqlConnection sqlVsObj = new SqlConnection();
                sqlVsObj.ConnectionString = @"Data Source = LAPTOP-IF4F1658; Initial Catalog =TestDb; User ID =Sony; Password = 9611998067";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlVsObj;
                cmd.CommandText = "Select * from NewStudent";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                dataGridView1.DataSource = dataSet.Tables[0];

            }
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            panel3.Visible= false;
            SqlConnection sqlVsObj = new SqlConnection();
            sqlVsObj.ConnectionString= @"Data Source = LAPTOP-IF4F1658; Initial Catalog =TestDb; User ID =Sony; Password = 9611998067";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlVsObj;
            cmd.CommandText = "Select StudId,sname,usn,dept,contact,email from NewStudent";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet= new DataSet();
            adapter.Fill(dataSet);  

            dataGridView1.DataSource= dataSet.Tables[0];

        }

        int bid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
            panel3.Visible = true;

            SqlConnection sqlVsObj = new SqlConnection();
            sqlVsObj.ConnectionString = @"Data Source = LAPTOP-IF4F1658; Initial Catalog =TestDb; User ID =Sony; Password = 9611998067";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlVsObj;
            cmd.CommandText = "Select * from NewStudent where studId = " + bid + "";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

          
            rowid = Int64.Parse(dataSet.Tables[0].Rows[0][0].ToString());

            txtStudName.Text = dataSet.Tables[0].Rows[0][1].ToString();
            txtUSN.Text = dataSet.Tables[0].Rows[0][2].ToString();
            txtDept.Text = dataSet.Tables[0].Rows[0][3].ToString();
           
            txtContact.Text = dataSet.Tables[0].Rows[0][5].ToString();
            txtEmail.Text = dataSet.Tables[0].Rows[0][6].ToString();




        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String SName = txtStudName.Text;
            String USN = txtUSN.Text;
            String Dept = txtDept.Text; 
           
            Int64 Contact = Int64.Parse(txtContact.Text);
            String email = txtEmail.Text;
            if (MessageBox.Show("Data will be Updated, Confirm ? ", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection sqlVsObj = new SqlConnection();
                sqlVsObj.ConnectionString = @"Data Source = LAPTOP-IF4F1658; Initial Catalog =TestDb; User ID =Sony; Password = 9611998067";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlVsObj;
                cmd.CommandText = "Update NewStudent set sname = '" + SName + "' , usn = '" + USN + "', dept = '" + Dept + "',  contact = " + Contact + ", email = '" + email + "' where studId = " + rowid + " ";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                ViewStudent_Load(this, null);
            }
        }

        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            txtSearchUSN.Clear();
            ViewStudent_Load(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
             if (MessageBox.Show("Data will be Deleted, Confirm ? ", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection sqlVsObj = new SqlConnection();
                sqlVsObj.ConnectionString = @"Data Source = LAPTOP-IF4F1658; Initial Catalog =TestDb; User ID =Sony; Password = 9611998067";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlVsObj;
                cmd.CommandText = "Delete from NewStudent where studId = " + rowid + " ";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                ViewStudent_Load(this, null);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved Data will be Lost  ", "Are You Sure", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
