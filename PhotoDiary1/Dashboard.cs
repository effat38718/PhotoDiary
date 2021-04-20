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
            InsertDataToDB();
            MessageBox.Show("Your Event is uploaded.", "Done");
        }
        
        private void InsertDataToDB ()
        {
            string query = "INSERT INTO USERS(Description,Date,EventName) VALUES('" + descriptionTextBox.Text + "','" + "@Date" + ",'" + eventNameTextBox.Text + "');";
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
    }
}
