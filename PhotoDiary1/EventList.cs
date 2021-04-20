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
    public partial class EventList : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;

        public EventList()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=DESKTOP-HIQ5HKB\\SQLEXPRESS;Initial Catalog=PhotoDiary;Integrated Security=True");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            con.Open();
            DeleteData();
            MessageBox.Show("Event is Deleted");
            con.Close();
        }

        private void DeleteData()
        {
            string query = "DELETE FROM EVENTS WHERE Event_ID = ('" + textBox1.Text + "');";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Event eventlist = new Event();
            eventlist.ShowDialog();
        }
    }
}
