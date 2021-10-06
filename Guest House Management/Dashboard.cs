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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            countBooked();
            countCust();
            countBooking();
            getCustomer();
        }

        private void gunaCircleProgressBar1_Click(object sender, EventArgs e)
        {

        }
        private void update()
        {
            string stu = "Booked";
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update RoomTbl set RStatus=@RS where RId = @RKey", Con);
                cmd.Parameters.AddWithValue("@RS", stu);

                cmd.Parameters.AddWithValue("@RKey", RoomNumber);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Room Updated Successfully...");
                Con.Close();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Abhay Kumar Gupta\Documents\GuestHouseDb.mdf;Integrated Security=True;Connect Timeout=30");
        int free, booked;
        int Bper, Freeper;
        private void countBooked()
        {
            string Status = "Booked";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from RoomTbl where RStatus = '" + Status + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            free = 20 - Convert.ToInt32(dt.Rows[0][0].ToString());
            booked = Convert.ToInt32(dt.Rows[0][0].ToString());
            Blbl.Text = dt.Rows[0][0].ToString()+" Booked Rooms";
            Avlbl.Text = free + " Free Rooms";
            Avlbl1.Text = free +"";
            Bper = (booked / 20)*100;
            Freeper = (free / 20)*100;
            BPrgs.Value = Bper;
            AvPgr.Value = Freeper;
            Freeroomprogress.Value = Freeper;
            Con.Close();
        }
        private void countCust()
        {
            string Status = "Booked";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from CustomerTbl ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Custnumlbl.Text =dt.Rows[0][0].ToString()+" Customers";
            Con.Close();
        }
        private void getCustomer()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CusId from CustomerTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CusId", typeof(int));
            dt.Load(rdr);
            CusIdCb.ValueMember = "CusId";
            CusIdCb.DataSource = dt;
            Con.Close();
        }
        private void getCustomerName()
        {
            Con.Open();
            string Query = "select * from CustomerTbl where CusId = " + CusIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CusNametb.Text = dr["CusName"].ToString();
            }
            Con.Close();
        }
        string RType;
        int RC;
        private void Reset()
        {
            RType = "";
            RC = 0;
            RoomNumber = 0;
        }
        private void getRoomType()
        {
            Con.Open();
            string Query = "select * from RoomTbl where RId = "+RoomNumber+"";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                RType = dr["RType"].ToString();
                RC = Convert.ToInt32(dr["RCost"].ToString());
            }
            Con.Close();
        }
        private void CEditbtn_Click(object sender, EventArgs e)
        {
            if(CusNametb.Text==""||RoomNumber == 0)
            {
                MessageBox.Show("Select A Room");
            }
            else
            {

                try
                {
                    getRoomType();
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into BookingTbl(CusId, CusName, RId, RNum, RType, BCost) values(@CI,@CN,@RI,@RN,@RT,@RC)", Con);
                    cmd.Parameters.AddWithValue("@CI", CusIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@CN", CusNametb.Text);
                    cmd.Parameters.AddWithValue("@RI", RoomNumber);
                    cmd.Parameters.AddWithValue("@RN", RoomNumber);
                    cmd.Parameters.AddWithValue("@RT", RType);
                    cmd.Parameters.AddWithValue("@RC", RC);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Booked Successfully...");
                    Reset();
                    Con.Close();
                    update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CusIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getCustomerName();
        }
        int RoomNumber = 0;
        private void R1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label23_Click(object sender, EventArgs e)
        {
           
        }

        private void R4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void R5_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void R6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R7_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void R8_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void R9_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void R10_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void R11_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R12_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void R13_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R14_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R15_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void R16_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R17_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R18_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void R19_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void R20_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R1_Click(object sender, EventArgs e)
        {
            RoomNumber = 1;
        }

        private void R2_Click(object sender, EventArgs e)
        {
            RoomNumber = 2;
        }

        private void R3_Click(object sender, EventArgs e)
        {
            RoomNumber = 3;
        }

        private void R4_Click(object sender, EventArgs e)
        {
            RoomNumber = 4;
        }

        private void R5_Click(object sender, EventArgs e)
        {
            RoomNumber = 5;
        }

        private void R6_Click(object sender, EventArgs e)
        {
            RoomNumber = 6;
        }

        private void R7_Click(object sender, EventArgs e)
        {
            RoomNumber = 7;
        }

        private void R8_Click(object sender, EventArgs e)
        {
            RoomNumber = 8;
        }

        private void R9_Click(object sender, EventArgs e)
        {
            RoomNumber = 9;
        }

        private void R10_Click(object sender, EventArgs e)
        {
            RoomNumber = 10;
        }

        private void R11_Click(object sender, EventArgs e)
        {
            RoomNumber = 11;
        }

        private void R12_Click(object sender, EventArgs e)
        {
            RoomNumber = 12;
        }

        private void R13_Click(object sender, EventArgs e)
        {
            RoomNumber = 13;
        }

        private void R14_Click(object sender, EventArgs e)
        {
            RoomNumber = 14;
        }

        private void R15_Click(object sender, EventArgs e)
        {
            RoomNumber = 15;
        }

        private void R16_Click(object sender, EventArgs e)
        {
            RoomNumber = 16;
        }

        private void R17_Click(object sender, EventArgs e)
        {
            RoomNumber = 17;
        }

        private void R18_Click(object sender, EventArgs e)
        {
            RoomNumber = 18;
        }

        private void R19_Click(object sender, EventArgs e)
        {
            RoomNumber = 19;
        }

        private void R20_Click(object sender, EventArgs e)
        {
            RoomNumber = 20;
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

        private void countBooking()
        {
            string Status = "Booked";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from BookingTbl ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Bookedlbl.Text =dt.Rows[0][0].ToString()+" Customers";
            Con.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
