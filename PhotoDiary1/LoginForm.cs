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

namespace PhotoDiary1
{
    public partial class LoginForm : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader dr;

        public LoginForm()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=DESKTOP-HIQ5HKB\\SQLEXPRESS;Initial Catalog=PhotoDiary;Integrated Security=True");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT password From Users Where email='" + EmailTextBox.Text + "';";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            string Password = dr.GetValue(0).ToString();
            if(PasswordTextBox.Text == Password)
            {
                this.Hide();
                Event eventlist = new Event();
                eventlist.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Email & Password Combination", "!!Error!!");
            }
            

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegistrationForm rForm = new RegistrationForm();
            rForm.ShowDialog();
        }
    }
}
