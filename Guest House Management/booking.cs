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

namespace Guest_House_Management
{
    public partial class booking : Form
    {
        public booking()
        {
            InitializeComponent();
            showBookings();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Abhay Kumar Gupta\Documents\GuestHouseDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void showBookings()
        {
            Con.Open();
            string Query = "select * from BookingTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            bokinggdv.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FilterBookings()
        {
            Con.Open();
            string Query = "select * from BookingTbl where RType = '"+RTypecb.SelectedItem.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            bokinggdv.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void serchbtn_Click(object sender, EventArgs e)
        {
            showBookings();
        }

        private void RTypecb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterBookings();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            user u = new user();
            u.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            customer c = new customer();
            c.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }
    }
}
