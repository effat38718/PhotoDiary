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
    public partial class Event : Form
    {
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlConnection con;

        public Event()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=DESKTOP-HIQ5HKB\\SQLEXPRESS;Initial Catalog=PhotoDiary;Integrated Security=True");
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.ShowDialog();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            EventList events = new EventList();
            events.ShowDialog();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT * from Events", con);
            da = new SqlDataAdapter();
            con.Open();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds);
            dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                listBox1.Items.Add(dr["Event_Name"].ToString());
            }
            con.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }
    }
}
