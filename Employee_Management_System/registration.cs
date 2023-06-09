using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Employee_Management_System
{
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
        }

        private void registration_Load(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            login login = new login();
            login.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=desktop-pi580mo\\sqlexpress;Initial Catalog=WINFORM_DB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[register]
           ([firstname]
           ,[lastname]
           ,[address]
           ,[gender]
           ,[email]
           ,[phone]
           ,[username]
           ,[password])
     VALUES
           ('" + txtFname.Text + "', '" + txtLname.Text + "', '" + txtAdd.Text + "', '" + cmbGender.SelectedItem.ToString() + "','" + txtEmail.Text + "', '" + txtPhone.Text + "', '" + txtUser.Text + "', '" + txtPass.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Register Succesfully");
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}
