using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Employee_Management_System
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=desktop-pi580mo\\sqlexpress;Initial Catalog=WINFORM_DB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from login where username = '" + txtuser.Text + "' and password = '" + txtpass.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string cmbItemValue = comboBox1.SelectedItem.ToString();
            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["usertype"].ToString()==cmbItemValue)
                    {
                        MessageBox.Show("you are login as " + dt.Rows[i][2]);
                        if(comboBox1.SelectedIndex==0)
                        {
                            Form1 f = new Form1();
                            f.Show();
                            this.Hide();
                        }
                        else
                        {
                            user ff = new user();
                            ff.Show();
                            this.Hide();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtuser.Clear();
            txtpass.Clear();
            txtuser.Focus();

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close the application?","Closing window", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question)==DialogResult.Yes)
                
            Application.Exit(); 

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            registration reg = new registration();
            reg.Show();
            Visible = false;
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
