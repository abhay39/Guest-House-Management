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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            user u = new user();
            u.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Abhay Kumar Gupta\Documents\GuestHouseDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void logitbn_Click(object sender, EventArgs e)
        {
            if (unametb.Text == "" || upasstb.Text == "")
            {
                MessageBox.Show("Missing Informations....");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTbl where UName = '"+unametb.Text+"' and UPass = '"+upasstb.Text+"'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if(dt.Rows[0][0].ToString()== "1")
                    {
                        Dashboard d = new Dashboard();
                        d.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username or password..");
                    }
                    Con.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
