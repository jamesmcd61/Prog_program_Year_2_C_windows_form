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
    public partial class Update_Vehical : UserControl
    {
        DB_Connection db = new DB_Connection(); // create class connection for DB statements

        // creating input whitelist
        int i = 0;
        Regex regex = new Regex(@"[^0-9qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM .,]");
        string badchar;

        String VehicleID;
        string Vehicle_Make;
        string Vehicle_Model;
        string Vehicle_Year;
        string VIN;
        string Engine_Size;
        string NP;
        string Capacity;
        string Status;
        string V_status;

        public Update_Vehical()
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

        // This method is to call all the required information for the Vehicles
        public void DisplayInfo()
        {
            db.closeConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(db.LoadVehicals());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                VehicleID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                tb_Make.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                tb_Model.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                tb_Year.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                tb_VIN.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                tb_EngineSize.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                tb_NP.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                tb_Capacity.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();


                Vehicle_Make = tb_Make.Text;
                Vehicle_Model = tb_Model.Text;
                Vehicle_Year = tb_Year.Text;
                VIN = tb_VIN.Text;
                Engine_Size = tb_EngineSize.Text;
                NP = tb_NP.Text;
                Capacity = tb_Capacity.Text;
            }
            catch (Exception)
            {

                tb_Make.Text = "";
                tb_Model.Text = "";
                tb_Year.Text = "";
                tb_VIN.Text = "";
                tb_EngineSize.Text = "";
                tb_NP.Text = "";
                tb_Capacity.Text = "";
            }
        }

        // This is to Update from the database
        private void btn_Update_Click(object sender, EventArgs e)
        {
            //This proccess will first check that there are no blanck textboxs
            if (string.IsNullOrEmpty(tb_Capacity.Text) || string.IsNullOrWhiteSpace(tb_Capacity.Text)|| string.IsNullOrEmpty(tb_EngineSize.Text) || string.IsNullOrWhiteSpace(tb_EngineSize.Text) || string.IsNullOrEmpty(tb_Make.Text) || string.IsNullOrWhiteSpace(tb_Make.Text) || string.IsNullOrEmpty(tb_Model.Text) || string.IsNullOrWhiteSpace(tb_Model.Text) || string.IsNullOrEmpty(tb_NP.Text) || string.IsNullOrWhiteSpace(tb_NP.Text) || string.IsNullOrEmpty(tb_VIN.Text) || string.IsNullOrWhiteSpace(tb_VIN.Text) || string.IsNullOrEmpty(tb_Year.Text) || string.IsNullOrWhiteSpace(tb_Year.Text))
            {
                MessageBox.Show("Please ensure all information is provided.");
            }
            else {
                db.closeConnection();
                // This will then update what the user has entered 
                SqlCommand cmd = db.UpdateVehicals(tb_Make.Text, tb_Model.Text, tb_Year.Text, tb_VIN.Text, tb_EngineSize.Text, tb_NP.Text, tb_Capacity.Text, VehicleID.ToString());

                cmd.Parameters.AddWithValue("@FirstName", tb_Make.Text);
                cmd.Parameters.AddWithValue("@LastName", tb_Model.Text);
                cmd.Parameters.AddWithValue("@DOB", tb_Year.Text);
                cmd.Parameters.AddWithValue("@Address", tb_VIN.Text);
                cmd.Parameters.AddWithValue("@Username", tb_EngineSize.Text);
                cmd.Parameters.AddWithValue("@Password", tb_NP.Text);
                cmd.Parameters.AddWithValue("@PossitionRole", tb_Capacity.Text);

                cmd.ExecuteNonQuery();

                //This resets the text boxes
                tb_Make.ResetText();
                tb_Model.ResetText();
                tb_Year.ResetText();
                tb_VIN.ResetText();
                tb_EngineSize.ResetText();
                tb_NP.ResetText();
                tb_Capacity.ResetText();

                DisplayInfo(); // this is used to refresh the datagrid

                MessageBox.Show("Vehicle updated successfully.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ReadOnly = true; // Insure that the DataGrid is on a read only mode
        }

        //////////////////////// This activated the whitelisting to the combo boxs
        private void Tb_Make_TextChanged(object sender, EventArgs e)
        {
            tb_Make.MaxLength = 255;
            badchar = inputMask(tb_Make.Text);
            if (badchar == "1")
            {
                tb_Make.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Model_TextChanged(object sender, EventArgs e)
        {
            tb_Model.MaxLength = 255;
            badchar = inputMask(tb_Model.Text);
            if (badchar == "1")
            {
                tb_Model.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Year_TextChanged(object sender, EventArgs e)
        {
            tb_Year.MaxLength = 255;
            badchar = inputMask(tb_Year.Text);
            if (badchar == "1")
            {
                tb_Year.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_VIN_TextChanged(object sender, EventArgs e)
        {
            tb_VIN.MaxLength = 255;
            badchar = inputMask(tb_VIN.Text);
            if (badchar == "1")
            {
                tb_VIN.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_EngineSize_TextChanged(object sender, EventArgs e)
        {
            tb_EngineSize.MaxLength = 255;
            badchar = inputMask(tb_EngineSize.Text);
            if (badchar == "1")
            {
                tb_EngineSize.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

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

        private void Tb_Capacity_TextChanged(object sender, EventArgs e)
        {
            tb_Capacity.MaxLength = 255;
            badchar = inputMask(tb_Capacity.Text);
            if (badchar == "1")
            {
                tb_Capacity.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Status_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Update_Vehical_Load(object sender, EventArgs e)
        {

        }
    }
}
