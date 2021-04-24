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
        private object da;
        public SqlDataAdapter oda;
        public DataSet ds;
        public DataTable dt;
        private int myindex;
        private object myid;
        private object fn;

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

        private void Show_Button_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM EVENTS;";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Events");
            dataGridView1.DataSource = ds.Tables["Events"].DefaultView;
        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            
        }
        
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            

            string eventID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string ColumnName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            string change = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            string query = "UPDATE Events set " + ColumnName + " = '" + change + "'  WHERE Event_ID = " + eventID + "       ;";
            MessageBox.Show(query, "Column Name");
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }
    }
}
