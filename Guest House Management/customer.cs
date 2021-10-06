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
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
            showCustomer();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Abhay Kumar Gupta\Documents\GuestHouseDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void showCustomer()
        {
            Con.Open();
            string Query = "select * from CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            customergdv.DataSource = ds.Tables[0];
            Con.Close();
        }
        int Key;
        private void Reset()
        {
            Cnametb.Text = "";
            Cphone.Text = "";
            CGendercb.SelectedIndex = -1;
            Key = 0;
        }

        private void Csavebtn_Click(object sender, EventArgs e)
        {
            if (Cnametb.Text == "" || Cphone.Text == "" || CGendercb.SelectedIndex==-1)
            {
                MessageBox.Show("Missing Information...");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CustomerTbl(CusName, CusPhone, CusGender, CusDob) values(@CN,@CP,@CG,@CD)", Con);
                    cmd.Parameters.AddWithValue("@CN", Cnametb.Text);
                    cmd.Parameters.AddWithValue("@CP", Cphone.Text);
                    cmd.Parameters.AddWithValue("@CG", CGendercb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CD", Cbookingdate.Value.Date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Saved Successfully...");
                    Con.Close();
                    showCustomer();
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

        private void customergdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Cnametb.Text = customergdv.SelectedRows[0].Cells[1].Value.ToString();
            Cphone.Text = customergdv.SelectedRows[0].Cells[2].Value.ToString();
            CGendercb.Text = customergdv.SelectedRows[0].Cells[3].Value.ToString();
            Cbookingdate.Text = customergdv.SelectedRows[0].Cells[4].Value.ToString();
            if (Cnametb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(customergdv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void CEditbtn_Click(object sender, EventArgs e)
        {
            if (Cnametb.Text == "" || Cphone.Text == "" || CGendercb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information...");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update CustomerTbl set CusName=@CN, CusPhone=@CP, CusGender=@CG where CusId = @CKey", Con);
                    cmd.Parameters.AddWithValue("@CN", Cnametb.Text);
                    cmd.Parameters.AddWithValue("@CP", Cphone.Text);
                    cmd.Parameters.AddWithValue("@CG", CGendercb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Updated Successfully...");
                    Con.Close();
                    showCustomer();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CDeletebtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select Customer...");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from CustomerTbl where CusId = @CKey", Con);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted Successfully...");
                    Con.Close();
                    showCustomer();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            user u = new user();
            u.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
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
    }
}
