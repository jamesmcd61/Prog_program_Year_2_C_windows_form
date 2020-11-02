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
    public partial class Update_FuelCon : UserControl
    {

        DB_Connection db = new DB_Connection(); // create class connection for DB statements

        string FuelID;
        string NP;
        string BT;
        string AT;
        string Price;

        // creating input whitelist
        int i = 0;
        Regex regex = new Regex(@"[^0-9qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM .,]");
        Regex regex2 = new Regex(@"[^0-9,]");
        string badchar;

        public Update_FuelCon()
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
        public string inputMask2(string txb)
        {
            string inMethod;
            inMethod = txb;
            string isbad = "";

            MatchCollection matches = regex2.Matches(inMethod);

            if (matches.Count > 0)
            {
                ++i;

                Console.WriteLine(i + " invalid caracter " + i);
                isbad = "1";
            }

            return isbad;

        }
        // This method is to call all the required information for all the fuel consumtion for all the trips
        public void DisplayInfo()
        {
            db.closeConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(db.LoadFuelCon());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                FuelID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                tb_NP.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                tb_BeforeTrip.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                tb_AfterTrip.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                tbPrice.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                NP = tb_NP.Text;
                BT = tb_BeforeTrip.Text;
                AT = tb_AfterTrip.Text;
                Price = tbPrice.Text;

            }
            catch (Exception)
            {

                tb_NP.Text = "";
                tb_BeforeTrip.Text = "";
                tb_AfterTrip.Text = "";
                tbPrice.Text = "";

            }
        }

        // This is to Update from the database
        private void btn_Update_Click(object sender, EventArgs e)
        {
            //This proccess will first check that there are no blanck textboxs
            if (string.IsNullOrEmpty(tbPrice.Text) || string.IsNullOrWhiteSpace(tbPrice.Text)||string.IsNullOrEmpty(tb_AfterTrip.Text) || string.IsNullOrWhiteSpace(tb_AfterTrip.Text)|| string.IsNullOrEmpty(tb_BeforeTrip.Text) || string.IsNullOrWhiteSpace(tb_BeforeTrip.Text)|| string.IsNullOrEmpty(tb_NP.Text) || string.IsNullOrWhiteSpace(tb_NP.Text))
            {
                MessageBox.Show("Please ensure all information is provided.");
               
            }
            else
            {
                db.closeConnection();

                // This will then update what the user has entered
                SqlCommand cmd = db.UpdateFuelCon(tb_NP.Text, Convert.ToDouble(tb_BeforeTrip.Text), Convert.ToDouble(tb_AfterTrip.Text), Convert.ToDouble(tbPrice.Text), FuelID.ToString());

                cmd.Parameters.AddWithValue("@Number_Plate", tb_NP.Text);
                cmd.Parameters.AddWithValue("@L_B_T", Convert.ToDouble(tb_BeforeTrip.Text));
                cmd.Parameters.AddWithValue("@L_A_T", Convert.ToDouble(tb_AfterTrip.Text));
                cmd.Parameters.AddWithValue("@PPL", Convert.ToDouble(tbPrice.Text));
                cmd.ExecuteNonQuery();

                //This resets the text boxes
                tb_NP.ResetText();
                tb_BeforeTrip.ResetText();
                tb_AfterTrip.ResetText();
                tbPrice.ResetText();

                DisplayInfo(); // this is used to refresh the datagrid

                MessageBox.Show("Fuel consumption updated successfully.");
            }
        }

        // This is to remove from the database
        private void Bt_Remove_Click(object sender, EventArgs e)
        {
            //This proccess will first check that there are no blanck textboxs
            if (string.IsNullOrEmpty(tbPrice.Text) || string.IsNullOrWhiteSpace(tbPrice.Text) || string.IsNullOrEmpty(tb_AfterTrip.Text) || string.IsNullOrWhiteSpace(tb_AfterTrip.Text) || string.IsNullOrEmpty(tb_BeforeTrip.Text) || string.IsNullOrWhiteSpace(tb_BeforeTrip.Text) || string.IsNullOrEmpty(tb_NP.Text) || string.IsNullOrWhiteSpace(tb_NP.Text))
            {
                MessageBox.Show("Please select a record.");

            }
            else
            {
                db.closeConnection();
                // This finds a match and then deletes it from the Database
                db.DeleteFuelCon(tb_NP.Text, FuelID.ToString());

                //Reset textboxs
                tb_NP.ResetText();
                tb_BeforeTrip.ResetText();
                tb_AfterTrip.ResetText();
                tbPrice.ResetText();

                // this is used to refresh the datagrid
                DisplayInfo();

                MessageBox.Show("Fuel consumption removed successfully.");
            }
        }

        private void Update_FuelCon_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ReadOnly = true; // Insure that the DataGrid is on a read only mode
        }


        //////////////////////// This activated the whitelisting to the combo boxs
        private void Tb_NP_TextChanged(object sender, EventArgs e)
        {
            tb_NP.MaxLength = 255;
            badchar = inputMask(tb_NP.Text);
            if (badchar == "1")
            {
                tb_NP.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_BeforeTrip_TextChanged(object sender, EventArgs e)
        {
            tb_BeforeTrip.MaxLength = 255;
            badchar = inputMask2(tb_BeforeTrip.Text);
            if (badchar == "1")
            {
                tb_BeforeTrip.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_AfterTrip_TextChanged(object sender, EventArgs e)
        {
            tb_AfterTrip.MaxLength = 255;
            badchar = inputMask2(tb_AfterTrip.Text);
            if (badchar == "1")
            {
                tb_AfterTrip.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void TbPrice_TextChanged(object sender, EventArgs e)
        {
            tbPrice.MaxLength = 255;
            badchar = inputMask2(tbPrice.Text);
            if (badchar == "1")
            {
                tbPrice.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }
    }
}
