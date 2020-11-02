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
    public partial class Update_Service : UserControl
    {
        DB_Connection db = new DB_Connection(); // create class connection for DB statements

        // creating input whitelist
        int i = 0;
        Regex regex = new Regex(@"[^0-9qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM .,/:]");
        string badchar;


        string ServiceID;
        string VMake;
        string VModel;
        string NP;
        string Milage;
        string Date;
        string Prob;
        string Status;

        public Update_Service()
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

        // This method is to call all the required information for the Service history
        public void DisplayInfo()
        {
            db.closeConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(db.LoadService());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ServiceID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                tb_VMak.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                tb_VModel.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                tb_NP.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                tb_Milage.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                tb_Date.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                tb_Problem.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();


                VMake = tb_VMak.Text;
                VModel = tb_VModel.Text;
                NP = tb_NP.Text;
                Milage = tb_Milage.Text;
                Date = tb_Date.Text;
                Prob = tb_Problem.Text;

            }
            catch (Exception)
            {

                tb_VMak.Text = "";
                tb_VModel.Text = "";
                tb_NP.Text = "";
                tb_Milage.Text = "";
                tb_Date.Text = "";
                tb_Problem.Text = "";

            }
        }
        // This is to Update from the database
        private void btn_Update_Click(object sender, EventArgs e)
        {
            //This proccess will first check that there are no blanck textboxs
            if (string.IsNullOrEmpty(tb_Date.Text) || string.IsNullOrWhiteSpace(tb_Date.Text) || string.IsNullOrEmpty(tb_Milage.Text) || string.IsNullOrWhiteSpace(tb_Milage.Text) || string.IsNullOrEmpty(tb_NP.Text) || string.IsNullOrWhiteSpace(tb_NP.Text) || string.IsNullOrEmpty(tb_Problem.Text) || string.IsNullOrWhiteSpace(tb_Problem.Text) || string.IsNullOrEmpty(tb_VMak.Text) || string.IsNullOrWhiteSpace(tb_VMak.Text) || string.IsNullOrEmpty(tb_VModel.Text) || string.IsNullOrWhiteSpace(tb_VModel.Text))
                {
                MessageBox.Show("Please ensure all information is provided.");
                }
            else { 
                db.closeConnection();
                // This will then update what the user has entered
                SqlCommand cmd = db.UpdateService(tb_VMak.Text, tb_VModel.Text, tb_NP.Text, tb_Milage.Text, tb_Date.Text, tb_Problem.Text, ServiceID.ToString());

                cmd.Parameters.AddWithValue("@Vehicle_Make", tb_VMak.Text);
                cmd.Parameters.AddWithValue("@Vehicle_Model", tb_VModel.Text);
                cmd.Parameters.AddWithValue("@Number_Plate", tb_NP.Text);
                cmd.Parameters.AddWithValue("@Total_Milage", tb_Milage.Text);
                cmd.Parameters.AddWithValue("@Date", tb_Date.Text);
                cmd.Parameters.AddWithValue("@Problem", tb_Problem.Text);

                cmd.ExecuteNonQuery();

                //This resets the text boxes
                tb_VMak.ResetText();
                tb_VModel.ResetText();
                tb_NP.ResetText();
                tb_Milage.ResetText();
                tb_Date.ResetText();
                tb_Problem.ResetText();

                DisplayInfo(); // this is used to refresh the datagrid

                MessageBox.Show("Service information updated successfully.");
            }
        }

        // This is to remove from the database
        private void Bt_Remove_Click(object sender, EventArgs e)
        {
            //This proccess will first check that there are no blanck textboxs
            if (string.IsNullOrEmpty(tb_Date.Text) || string.IsNullOrWhiteSpace(tb_Date.Text) || string.IsNullOrEmpty(tb_Milage.Text) || string.IsNullOrWhiteSpace(tb_Milage.Text) || string.IsNullOrEmpty(tb_NP.Text) || string.IsNullOrWhiteSpace(tb_NP.Text) || string.IsNullOrEmpty(tb_Problem.Text) || string.IsNullOrWhiteSpace(tb_Problem.Text) || string.IsNullOrEmpty(tb_VMak.Text) || string.IsNullOrWhiteSpace(tb_VMak.Text) || string.IsNullOrEmpty(tb_VModel.Text) || string.IsNullOrWhiteSpace(tb_VModel.Text))
            {
                MessageBox.Show("Please select a record.");
            }
            else
            {
                db.closeConnection();
                // This finds a match and then deletes it from the Database
                db.DeleteService(tb_VMak.Text, ServiceID.ToString());

                //Reset textboxs
                tb_VMak.ResetText();
                tb_VModel.ResetText();
                tb_NP.ResetText();
                tb_Milage.ResetText();
                tb_Date.ResetText();
                tb_Problem.ResetText();

                // this is used to refresh the datagrid
                DisplayInfo();

                MessageBox.Show("Service record removed successfully.");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ReadOnly = true; // Insure that the DataGrid is on a read only mode
        }


        //////////////////////// This activated the whitelisting to the combo boxs
        private void Tb_VMak_TextChanged(object sender, EventArgs e)
        {
            tb_VMak.MaxLength = 255;
            badchar = inputMask(tb_VMak.Text);
            if (badchar == "1")
            {
                tb_VMak.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_VModel_TextChanged(object sender, EventArgs e)
        {
            tb_VModel.MaxLength = 255;
            badchar = inputMask(tb_VModel.Text);
            if (badchar == "1")
            {
                tb_VModel.ResetText();
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

        private void Tb_Milage_TextChanged(object sender, EventArgs e)
        {
            tb_Milage.MaxLength = 255;
            badchar = inputMask(tb_Milage.Text);
            if (badchar == "1")
            {
                tb_Milage.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Date_TextChanged(object sender, EventArgs e)
        {
            tb_Date.MaxLength = 255;
            badchar = inputMask(tb_Date.Text);
            if (badchar == "1")
            {
                tb_Date.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Problem_TextChanged(object sender, EventArgs e)
        {
            tb_Problem.MaxLength = 255;
            badchar = inputMask(tb_Problem.Text);
            if (badchar == "1")
            {
                tb_Problem.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Status_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
