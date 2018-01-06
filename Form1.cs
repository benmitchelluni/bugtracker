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

namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ben\Documents\DB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("select * from users where username=@username and password =@password", connect);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            SqlDataAdapter login = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            login.Fill(dt);
            connect.Open();
            int i = cmd.ExecuteNonQuery();
            connect.Close();

            if (dt.Rows.Count > 0)
            {
                Form2 settingsForm = new Form2();
                settingsForm.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("The username and password do not match. Please check that they are correct and try again.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
