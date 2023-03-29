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
    public partial class CompleteBookDetails : Form
    {
        public CompleteBookDetails()
        {
            InitializeComponent();
        }

        private void CompleteBookDetails_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = LAPTOP-IF4F1658; Initial Catalog =TestDb; User ID =Sony; Password = 9611998067";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "Select std_usn, std_name, std_dept, std_sem, book_issue_date from IRBooks1 where book_return_date is null";

            SqlDataAdapter adapter= new SqlDataAdapter(cmd);
            DataSet dataSet= new DataSet();
            adapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];

            cmd.CommandText = "Select std_usn, std_name, std_dept, std_sem,  book_return_date from IRBooks1 where book_return_date is not null";
            SqlDataAdapter adapterR = new SqlDataAdapter(cmd);
            DataSet dataSetR = new DataSet();
            adapterR.Fill(dataSetR);

            dataGridView2.DataSource= dataSetR.Tables[0];


        }
    }
}
