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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPublication.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "") {
                String bName = txtBookName.Text;
                String bAuthor = txtAuthor.Text;
                String publ = txtPublication.Text;
                String pDate = dateTimePicker1.Text;
                Int64 bprice = Int64.Parse(txtPrice.Text);
                Int64 bQuan = Int64.Parse(txtQuantity.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source = LAPTOP-IF4F1658; Initial Catalog =TestDb; User ID =Sony; Password = 9611998067";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewBook(bName,bAuthor,bPubl,bPDate,bPrice,bQuan) values ('" + bName + "','" + bAuthor + "','" + publ + "','" + pDate + "'," + bprice + "," + bQuan + ")";
                cmd.ExecuteNonQuery();
                con.Close();

                

                MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookName.Clear();
                txtAuthor.Clear();
                txtPrice.Clear();
                txtPublication.Clear();
                txtQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Empty Field not allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will delete your unsaved Data","Are you Sure", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void AddBook_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            int price = int.Parse(txtPrice.Text);
            int quan = int.Parse(txtQuantity.Text);
            int result = price * quan;
            MessageBox.Show("Total Price = " + result.ToString() + "", "Price", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
