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
    public partial class Dashboard : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;

        public Dashboard()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=DESKTOP-HIQ5HKB\\SQLEXPRESS;Initial Catalog=PhotoDiary;Integrated Security=True");
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            con.Open();
            InsertDataToDB();
            MessageBox.Show("Your Event is uploaded.", "Done");
            con.Close();
        }
        
        private void InsertDataToDB ()
        {
            string query = "INSERT INTO EVENTS(Event_Description,Event_Date,Event_Name,Event_Photo_Path) VALUES('" + descriptionTextBox.Text + "'," + "@Date" + ",'" + eventNameTextBox.Text + "' ,'" + pathTextBox.Text + "');";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@Date", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
            cmd.ExecuteNonQuery();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Event events = new Event();
            events.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(opnfd.FileName);
                pathTextBox.Text = opnfd.FileName.ToString();
            }
            else
            {
                MessageBox.Show("FILE I/O Error", "!!Error!!");
            }

        }
    }
}
