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
    public partial class Update_Emp_Rates : UserControl
    {

        DB_Connection db = new DB_Connection(); // create class connection for DB statements
        int RateID;

        // creating input whitelist
        int i = 0;
        Regex regex = new Regex(@"[^0-9qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM .,:/]");
        Regex regex2 = new Regex(@"[^0-9 ,]");
        string badchar;

        string role;
        string name;
        string starttime;
        string endtime;
        string RPH;
        string Date;

        public Update_Emp_Rates()
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

        // This method is to call all the required information for the employees rate table
        public void DisplayInfo()
        {
            db.closeConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(db.LoadEmp_Rate());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        // This is to Update from the database
        private void Bt_Update_Click(object sender, EventArgs e)
        {
            //This proccess will first check that there are no blanck textboxs
            if (string.IsNullOrEmpty(Tb_Date.Text) || string.IsNullOrWhiteSpace(Tb_Date.Text) || string.IsNullOrEmpty(Tb_EndTime.Text) || string.IsNullOrWhiteSpace(Tb_EndTime.Text) || string.IsNullOrEmpty(Tb_Name.Text) || string.IsNullOrWhiteSpace(Tb_Name.Text) || string.IsNullOrEmpty(Tb_Role.Text) || string.IsNullOrWhiteSpace(Tb_Role.Text) || string.IsNullOrEmpty(Tb_RPH.Text) || string.IsNullOrWhiteSpace(Tb_RPH.Text) || string.IsNullOrEmpty(Tb_Starttime.Text) || string.IsNullOrWhiteSpace(Tb_Starttime.Text))
            {
                MessageBox.Show("Please ensure all information is provided.");

            }
            else
            {
                db.closeConnection();
                // This will then update what the user has entered
                SqlCommand cmd = db.UpdateEmp_rate(Tb_Role.Text, Tb_Name.Text, Tb_Starttime.Text, Tb_EndTime.Text, Convert.ToDouble(Tb_RPH.Text), Tb_Date.Text, RateID.ToString());

                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@StartTime", starttime);
                cmd.Parameters.AddWithValue("@EndTime", endtime);
                cmd.Parameters.AddWithValue("@RPH", RPH);
                cmd.Parameters.AddWithValue("@Date", Date);

                cmd.ExecuteNonQuery();

                //This resets the text boxes
                Tb_Role.ResetText();
                Tb_Name.ResetText();
                Tb_Starttime.ResetText();
                Tb_EndTime.ResetText();
                Tb_RPH.ResetText();
                Tb_Date.ResetText();

                DisplayInfo(); // this is used to refresh the datagrid

                MessageBox.Show("Employee wages successfully updated.");

                
            }


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                RateID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                Tb_Role.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Tb_Name.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                Tb_Starttime.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                Tb_EndTime.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                Tb_RPH.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                Tb_Date.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();



                role = Tb_Role.Text;
                name = Tb_Name.Text;
                starttime = Tb_Starttime.Text;
                endtime = Tb_EndTime.Text;
                RPH = Tb_RPH.Text;
                Date = Tb_Date.Text;

            }
            catch (Exception)
            {
                Tb_Role.Text = "";
                Tb_Name.Text = "";
                Tb_Starttime.Text = "";
                Tb_EndTime.Text = "";
                Tb_RPH.Text = "";
                Tb_Date.Text = "";


            }
        }

        // This is to remove from the database
        private void Bt_Remove_Click(object sender, EventArgs e)
        {
            //This proccess will first check that there are no blanck textboxs
            if (string.IsNullOrEmpty(Tb_Date.Text) || string.IsNullOrWhiteSpace(Tb_Date.Text) || string.IsNullOrEmpty(Tb_EndTime.Text) || string.IsNullOrWhiteSpace(Tb_EndTime.Text) || string.IsNullOrEmpty(Tb_Name.Text) || string.IsNullOrWhiteSpace(Tb_Name.Text) || string.IsNullOrEmpty(Tb_Role.Text) || string.IsNullOrWhiteSpace(Tb_Role.Text) || string.IsNullOrEmpty(Tb_RPH.Text) || string.IsNullOrWhiteSpace(Tb_RPH.Text) || string.IsNullOrEmpty(Tb_Starttime.Text) || string.IsNullOrWhiteSpace(Tb_Starttime.Text))
            {
                MessageBox.Show("Please select a record.");

            }
            else
            {
                db.closeConnection();
                // This finds a match and then deletes it from the Database
                db.DeleteEmp_Rate(Tb_Name.Text, RateID.ToString());

                //Reset textboxs
                Tb_Role.ResetText();
                Tb_Name.ResetText();
                Tb_Starttime.ResetText();
                Tb_EndTime.ResetText();
                Tb_RPH.ResetText();
                Tb_Date.ResetText();

                DisplayInfo(); // this is used to refresh the datagrid

                MessageBox.Show("Employee wages successfully removed.");
            }

           
        }

        private void Update_Emp_Rates_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ReadOnly = true; // Insure that the DataGrid is on a read only mode
        }


        //////////////////////// This activated the whitelisting to the combo boxs
        
        private void Tb_Role_TextChanged(object sender, EventArgs e)
        {
            Tb_Role.MaxLength = 255;
            badchar = inputMask(Tb_Role.Text);
            if (badchar == "1")
            {
                Tb_Role.ResetText();
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

        private void Tb_Starttime_TextChanged(object sender, EventArgs e)
        {
            Tb_Starttime.MaxLength = 255;
            badchar = inputMask(Tb_Starttime.Text);
            if (badchar == "1")
            {
                Tb_Starttime.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_EndTime_TextChanged(object sender, EventArgs e)
        {
            Tb_EndTime.MaxLength = 255;
            badchar = inputMask(Tb_EndTime.Text);
            if (badchar == "1")
            {
                Tb_EndTime.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_RPH_TextChanged(object sender, EventArgs e)
        {
            Tb_RPH.MaxLength = 255;
            badchar = inputMask2(Tb_RPH.Text);
            if (badchar == "1")
            {
                Tb_RPH.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Date_TextChanged(object sender, EventArgs e)
        {
            Tb_Date.MaxLength = 255;
            badchar = inputMask(Tb_Date.Text);
            if (badchar == "1")
            {
                Tb_Date.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }
    }
}
