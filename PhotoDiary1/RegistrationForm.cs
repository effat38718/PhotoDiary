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
    public partial class RegistrationForm : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;

        public RegistrationForm()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=DESKTOP-HIQ5HKB\\SQLEXPRESS;Initial Catalog=PhotoDiary;Integrated Security=True");
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if(PasswordTextBox.Text == ConfirmPassTextBox.Text)
            {
                if (checkBox1.Checked)
                {
                    InsertDatatoDB();
                }
                else
                {
                    MessageBox.Show("Check the Terms and Condition", "Please Accept Before Creating an Account");
                }
            }
            else
            {
                MessageBox.Show("Password Doesn't Match", "Please Rerite the password");
            }
            con.Close();
        }

        private void InsertDatatoDB()
        {
            string Gender = "";
            if(MaleRB.Checked)
            {
                Gender = "Male";
            }
            else
            {
                Gender = "Female";
            }
            string query = "INSERT INTO USERS(Name,UserName,Password,Email,DateOfBirth,Gender) VALUES('" + NameTextBox.Text + "','" + UserNameTextBox.Text + "','" + PasswordTextBox.Text + "','" + EmailTextBox.Text + "'," + "@DateOfBirth"+",'"+Gender+"');";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your Account is created . Please login now.", "Done");
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
