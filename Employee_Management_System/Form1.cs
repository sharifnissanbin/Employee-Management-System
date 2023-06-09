using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Employee_Management_System
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string query2 = "select * from Employee where Id = @id";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@id",idtb.Text);
            con.Open();
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.HasRows == true)
            {
                MessageBox.Show(idtb.Text + " ID already exists !", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            else
            {


                con.Close();

                string query = "insert into Employee values(@id,@name,@gender,@age,@desig,@salary)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idtb.Text);
                cmd.Parameters.AddWithValue("@name", nametb.Text);
                cmd.Parameters.AddWithValue("@gender", GenderCombo.SelectedItem);
                cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@desig", DCombo.SelectedItem);
                cmd.Parameters.AddWithValue("@salary", salarytb.Text);

                con.Open();

                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Inserted Successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGridView();
                }
                else
                {
                    MessageBox.Show("Insertion Failed !", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
                ResetControls();
            }

        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Employee";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update Employee set Id = @id, name = @name, gender = @gender, age = @age, designation = @desig, salary = @salary where Id = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", idtb.Text);
            cmd.Parameters.AddWithValue("@name", nametb.Text);
            cmd.Parameters.AddWithValue("@gender", GenderCombo.SelectedItem);
            cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@desig", DCombo.SelectedItem);
            cmd.Parameters.AddWithValue("@salary", salarytb.Text);

            con.Open();

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Updated Successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
            else
            {
                MessageBox.Show("Updation Failed !", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
            ResetControls();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            idtb.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            nametb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            GenderCombo.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32 (dataGridView1.SelectedRows[0].Cells[3].Value);
            DCombo.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            salarytb.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from Employee where Id = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", idtb.Text);
            

            con.Open();

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Deleted Successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
            else
            {
                MessageBox.Show("Deletion Failed !", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
            ResetControls();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
        void ResetControls()
        {
            idtb.Clear();
            nametb.Clear();
            GenderCombo.SelectedItem = null;
            numericUpDown1.Value = 0;
            DCombo.SelectedItem = null;
            salarytb.Clear();
            Searchtb.Clear();

            idtb.Focus();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Employee where name like @name + '%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@name",Searchtb.Text.Trim());
            DataTable data = new DataTable();
            sda.Fill(data);
            if(data.Rows.Count > 0)
            {
                dataGridView1.DataSource = data;
            }
           else
            {
                MessageBox.Show("No data found !");
                dataGridView1.DataSource = null;
            }
            
        }

        private void Searchtb_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Employee where name like @name + '%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@name", Searchtb.Text.Trim());
            DataTable data = new DataTable();
            sda.Fill(data);
            if (data.Rows.Count > 0)
            {
                dataGridView1.DataSource = data;
            }
            else
            {
                MessageBox.Show("No data found !");
                dataGridView1.DataSource = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonExits_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close the application?", "Closing window", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)

                Application.Exit();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            login login = new login();
            login.Show();

        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close the application?", "Closing window", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)

               
            this.Close();
            login login = new login();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            login login = new login();
            login.Show();
        }
    }
}
