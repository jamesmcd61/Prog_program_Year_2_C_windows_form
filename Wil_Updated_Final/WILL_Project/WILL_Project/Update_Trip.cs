using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WILL_Project
{
    public partial class Update_Trip : UserControl
    {
        DB_Connection db = new DB_Connection(); // create class connection for DB statements

        // creating input whitelist
        int i = 0;
        Regex regex = new Regex(@"[^0-9qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM .,]");
        string badchar;


        string TripID;
        string name;
        string streetaddress;
        string city;
        string postcode;
        string province;
        string phone;
        string name2;
        string streetaddress2;
        string city2;
        string postcode2;
        string province2;
        string phone2;
        string description2;
        string status;
        
        public Update_Trip()
        {
            InitializeComponent();
           DisplayInfo();
        }

        // input method mask that filters
        public string inputMask(string txb)
        {
            string inMethod;
            inMethod = txb;
            string isbad = "";

            MatchCollection matches = regex.Matches(inMethod);

            if (matches.Count > 0)
            {
                ++i;

                Console.WriteLine(i + " invalid caracter " + i);
                isbad = "1";
            }

            return isbad;

        }

        // This method is to call all the required information for all trips
        public void DisplayInfo()
        {
            db.closeConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(db.LoadTrip());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                TripID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Tb_Name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Tb_Streetname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                Tb_City.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                Tb_PostCode.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                Tb_Province.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                Tb_Phone.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                Tb_Name2.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                Tb_StreetAddress2.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                Tb_City2.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                Tb_Postcode2.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                Tb_Province2.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                Tb_Phone2.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                Tb_Description.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();


                name = Tb_Name.Text;
                streetaddress = Tb_Streetname.Text;
                city = Tb_City.Text;
                postcode = Tb_PostCode.Text;
                province = Tb_Province.Text;
                phone = Tb_Phone.Text;
                name2 = Tb_Name2.Text;
                streetaddress2 = Tb_StreetAddress2.Text;
                city2 = Tb_City2.Text;
                postcode2 = Tb_Postcode2.Text;
                province2 = Tb_Province2.Text;
                phone2 = Tb_Phone2.Text;
                description2 = Tb_Description.Text;



            }
            catch (Exception)
            {

                Tb_Name.Text = " ";
                Tb_Streetname.Text = "";
                Tb_City.Text = "";
                Tb_PostCode.Text = "";
                Tb_Province.Text = "";
                Tb_Phone.Text = "";
                Tb_Name2.Text = "";
                Tb_StreetAddress2.Text = "";
                Tb_City2.Text = "";
                Tb_Postcode2.Text = "";
                Tb_Province2.Text = "";
                Tb_Phone2.Text = "";
                Tb_Description.Text = "";

            }
        }

        // This is to Update from the database
        private void Bt_Update_Click(object sender, EventArgs e)
        {
            //This proccess will first check that there are no blanck textboxs
            if (string.IsNullOrEmpty(Tb_City.Text) || string.IsNullOrWhiteSpace(Tb_City.Text) ||string.IsNullOrEmpty(Tb_City2.Text) || string.IsNullOrWhiteSpace(Tb_City2.Text) || string.IsNullOrEmpty(Tb_Description.Text) || string.IsNullOrWhiteSpace(Tb_Description.Text) || string.IsNullOrEmpty(Tb_Name.Text) || string.IsNullOrWhiteSpace(Tb_Name.Text) || string.IsNullOrEmpty(Tb_Name2.Text) || string.IsNullOrWhiteSpace(Tb_Name2.Text) || string.IsNullOrEmpty(Tb_Phone.Text) || string.IsNullOrWhiteSpace(Tb_Phone.Text) || string.IsNullOrEmpty(Tb_Phone2.Text) || string.IsNullOrWhiteSpace(Tb_Phone2.Text) || string.IsNullOrEmpty(Tb_PostCode.Text) || string.IsNullOrWhiteSpace(Tb_PostCode.Text) || string.IsNullOrEmpty(Tb_Postcode2.Text) || string.IsNullOrWhiteSpace(Tb_Postcode2.Text) || string.IsNullOrEmpty(Tb_Province.Text) || string.IsNullOrWhiteSpace(Tb_Province.Text) || string.IsNullOrEmpty(Tb_Province2.Text) || string.IsNullOrWhiteSpace(Tb_Province2.Text) || string.IsNullOrEmpty(Tb_StreetAddress2.Text) || string.IsNullOrWhiteSpace(Tb_StreetAddress2.Text )|| string.IsNullOrEmpty(Tb_Streetname.Text) || string.IsNullOrWhiteSpace(Tb_Streetname.Text))
            {
                MessageBox.Show("Please ensure all information is provided.");
            }
            else
            {
                db.closeConnection();

                // This will then update what the user has entered
                SqlCommand cmd = db.UpdateTrip(Tb_Name.Text, Tb_Streetname.Text, Tb_City.Text, Tb_PostCode.Text, Tb_Province.Text, Tb_Phone.Text, Tb_Name2.Text, Tb_StreetAddress2.Text, Tb_City2.Text, Tb_Postcode2.Text, Tb_Province2.Text, Tb_Phone2.Text, Tb_Description.Text, TripID.ToString());

                cmd.Parameters.AddWithValue("@S_Name", Tb_Name.Text);
                cmd.Parameters.AddWithValue("@S_StreetAddress", Tb_Streetname.Text);
                cmd.Parameters.AddWithValue("@S_City", Tb_City.Text);
                cmd.Parameters.AddWithValue("@S_Postcode", Tb_PostCode.Text);
                cmd.Parameters.AddWithValue("@S_Province", Tb_Province.Text);
                cmd.Parameters.AddWithValue("@S_Phone", Tb_Phone.Text);
                cmd.Parameters.AddWithValue("@R_Name", Tb_Name2.Text);
                cmd.Parameters.AddWithValue("@R_StreetAddress", Tb_StreetAddress2.Text);
                cmd.Parameters.AddWithValue("@R_City", Tb_City2.Text);
                cmd.Parameters.AddWithValue("@R_Postcode", Tb_Postcode2.Text);
                cmd.Parameters.AddWithValue("@R_Province", Tb_Province2.Text);
                cmd.Parameters.AddWithValue("@R_Phone", Tb_Phone2.Text);
                cmd.Parameters.AddWithValue("@R_Description", Tb_Description.Text);

                cmd.ExecuteNonQuery();

                //This resets the text boxes

                Tb_Name.ResetText();
                Tb_Streetname.ResetText();
                Tb_City.ResetText();
                Tb_PostCode.ResetText();
                Tb_Province.ResetText();
                Tb_Phone.ResetText();
                Tb_Name2.ResetText();
                Tb_StreetAddress2.ResetText();
                Tb_City2.ResetText();
                Tb_Postcode2.ResetText();
                Tb_Province2.ResetText();
                Tb_Phone2.ResetText();
                Tb_Description.ResetText();

                DisplayInfo(); // this is used to refresh the datagrid

                MessageBox.Show("Trip updated successfully.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ReadOnly = true; // Insure that the DataGrid is on a read only mode
        }


        //////////////////////// This activated the whitelisting to the combo boxs
        private void Tb_Streetname_TextChanged(object sender, EventArgs e)
        {
            Tb_Streetname.MaxLength = 255;
            badchar = inputMask(Tb_Streetname.Text);
            if (badchar == "1")
            {
                Tb_Streetname.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_PostCode_TextChanged(object sender, EventArgs e)
        {
            Tb_PostCode.MaxLength = 255;
            badchar = inputMask(Tb_PostCode.Text);
            if (badchar == "1")
            {
                Tb_PostCode.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Phone_TextChanged(object sender, EventArgs e)
        {
            Tb_Phone.MaxLength = 255;
            badchar = inputMask(Tb_Phone.Text);
            if (badchar == "1")
            {
                Tb_Phone.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Name_TextChanged(object sender, EventArgs e)
        {
            Tb_Name.MaxLength = 255;
            badchar = inputMask(Tb_Name.Text);
            if (badchar == "1")
            {
                Tb_Name.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_City_TextChanged(object sender, EventArgs e)
        {
            Tb_City.MaxLength = 255;
            badchar = inputMask(Tb_City.Text);
            if (badchar == "1")
            {
                Tb_City.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Province_TextChanged(object sender, EventArgs e)
        {
            Tb_Province.MaxLength = 255;
            badchar = inputMask(Tb_Province.Text);
            if (badchar == "1")
            {
                Tb_Province.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Name2_TextChanged(object sender, EventArgs e)
        {
            Tb_Name2.MaxLength = 255;
            badchar = inputMask(Tb_Name2.Text);
            if (badchar == "1")
            {
                Tb_Name2.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_StreetAddress2_TextChanged(object sender, EventArgs e)
        {
            Tb_StreetAddress2.MaxLength = 255;
            badchar = inputMask(Tb_StreetAddress2.Text);
            if (badchar == "1")
            {
                Tb_StreetAddress2.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_City2_TextChanged(object sender, EventArgs e)
        {
            Tb_City2.MaxLength = 255;
            badchar = inputMask(Tb_City2.Text);
            if (badchar == "1")
            {
                Tb_City2.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Province2_TextChanged(object sender, EventArgs e)
        {
            Tb_Province2.MaxLength = 255;
            badchar = inputMask(Tb_Province2.Text);
            if (badchar == "1")
            {
                Tb_Province2.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Postcode2_TextChanged(object sender, EventArgs e)
        {
            Tb_Postcode2.MaxLength = 255;
            badchar = inputMask(Tb_Postcode2.Text);
            if (badchar == "1")
            {
                Tb_Postcode2.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Phone2_TextChanged(object sender, EventArgs e)
        {
            Tb_Phone2.MaxLength = 255;
            badchar = inputMask(Tb_Phone2.Text);
            if (badchar == "1")
            {
                Tb_Phone2.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Description_TextChanged(object sender, EventArgs e)
        {
            Tb_Description.MaxLength = 255;
            badchar = inputMask(Tb_Description.Text);
            if (badchar == "1")
            {
                Tb_Description.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Statue_TextChanged(object sender, EventArgs e)
        {

            
        }
    }
}
