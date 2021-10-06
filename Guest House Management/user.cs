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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
            showuser();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Abhay Kumar Gupta\Documents\GuestHouseDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void showuser()
        {
            Con.Open();
            string Query = "select * from UserTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            usergdv.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            Unametb.Text = "";
            Uphonetb.Text = "";
            Upasstb.Text = "";
        }
        private void Usavebtn_Click(object sender, EventArgs e)
        {
            if (Unametb.Text == "" || Upasstb.Text == "" || Uphonetb.Text == "" )
            {
                MessageBox.Show("Missing Information...");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTbl(UName, UPhone, UPass) values(@UN,@UP,@UPW)", Con);
                    cmd.Parameters.AddWithValue("@UN", Unametb.Text);
                    cmd.Parameters.AddWithValue("@UP", Uphonetb.Text);
                    cmd.Parameters.AddWithValue("@UPW", Upasstb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Saved Successfully...");
                    Con.Close();
                    showuser();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int Key = 0;
        private void usergdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Unametb.Text = usergdv.SelectedRows[0].Cells[1].Value.ToString();
            Uphonetb.Text = usergdv.SelectedRows[0].Cells[2].Value.ToString();
            Upasstb.Text = usergdv.SelectedRows[0].Cells[3].Value.ToString();
            if (Unametb.Text == "")
            {
                Key= 0;
            }
            else
            {
                Key = Convert.ToInt32(usergdv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UEditbtn_Click(object sender, EventArgs e)
        {
            if (Unametb.Text == "" || Upasstb.Text == "" || Uphonetb.Text == "")
            {
                MessageBox.Show("Missing Information...");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update UserTbl set UName=@UN, UPhone=@UP, UPass=@UPW where UId = @UKey", Con);
                    cmd.Parameters.AddWithValue("@UN", Unametb.Text);
                    cmd.Parameters.AddWithValue("@UP", Uphonetb.Text);
                    cmd.Parameters.AddWithValue("@UPW", Upasstb.Text);
                    cmd.Parameters.AddWithValue("@UKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Updated Successfully...");
                    Con.Close();
                    showuser();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UDeletebtn_Click(object sender, EventArgs e)
        {
            if (Key==0)
            {
                MessageBox.Show("Select User...");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from UserTbl where UId = @UKey", Con);
                    cmd.Parameters.AddWithValue("@UKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted Successfully...");
                    Con.Close();
                    showuser();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            customer c = new customer();
            c.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            booking b = new booking();
            b.Show();
            this.Hide();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
