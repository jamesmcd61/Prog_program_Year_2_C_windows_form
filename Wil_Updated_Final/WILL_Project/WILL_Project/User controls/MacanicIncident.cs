using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WILL_Project
{
    public partial class MacanicIncident : UserControl
    {
        DB_Connection db = new DB_Connection(); // connecting to db class
        String ServiceID;
        int Vehicle_ID;

        // creating input whitelist
        int i = 0;
        Regex regex = new Regex(@"[^0-9qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM ,.]");
        Regex regex2 = new Regex(@"[^0-9,.]");
        string badchar;

        public MacanicIncident()
        {
            InitializeComponent();
            Fillcombo();
        }

        // display vehicle name that needs to be serviced for incedent
        void Fillcombo()
        {

            cb_DisplayService.Items.Clear(); // this will clear / refresh the combo box

            SqlDataReader myReader;
            try
            {

                db.closeConnection();
                // This will get all vehicle names that are booked for a incident service
                myReader = db.IncedintService();

                while (myReader.Read())
                {
                    String sname = myReader.GetString(3); // index number
                    //This will display the vehicle name in the combobox
                    cb_DisplayService.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        ////////////////////// This activated the whitelisting to the combo boxs
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
        // This activated the whitelisting to the combo boxs
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

        private void cb_DisplayService_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataReader myReader;
            try
            {
                db.closeConnection();
                // This will select the vehicle info
                myReader = db.SelectedIncService(cb_DisplayService.Text);

                while (myReader.Read())
                {

                    string ServiceID1 = myReader.GetInt32(0).ToString();
                    string Vehicle_Make = myReader.GetString(1);
                    string Vehicle_Model = myReader.GetString(2);
                    string Number_Plate = myReader.GetString(3);
                    string Date = myReader.GetString(4);
                    string Problem = myReader.GetString(5);
                    int VehicleID = myReader.GetInt32(6);

                    ServiceID = ServiceID1;
                    Vehicle_ID = VehicleID;

                    // Display The vehicle info 
                    tb_VMake.Text = Vehicle_Make;
                    tb_VM.Text = Vehicle_Model;
                    tb_NP.Text = Number_Plate;
                    tb_Date.Text = Date;
                    rtb_Problem.Text = Problem;


                }

            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }


       

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            //This proccess will first check that there are no blanck textboxs
            if (cb_DisplayService.ToString() == "" || rtb_Requirement.Text == "" || tb_TP.Text == "")
            {
                MessageBox.Show("Please ensure all information is provided");
            }
            else
            {


                db.closeConnection();
                // add service to databasde
                SqlCommand cmd = db.CompleteService();

                cmd.Parameters.Add("@ServiceID", ServiceID);
                cmd.Parameters.Add("@Description", rtb_Requirement.Text);
                cmd.Parameters.Add("@Price", tb_TP.Text);
                cmd.ExecuteNonQuery();

                //  reset Textbox
                rtb_Requirement.ResetText();
                tb_TP.ResetText();
                tb_VMake.ResetText();
                tb_VM.ResetText();
                tb_NP.ResetText();
                tb_Date.ResetText();
                rtb_Problem.ResetText();

                ChangeStatus(); // Change status of vehicle to Trip Manager can use it



                db.closeConnection();
                db.ChangeV_Fixed(Vehicle_ID.ToString());

                MessageBox.Show("Service requirements added successfully");
            }

        }

        void ChangeStatus()
        {
            db.closeConnection();
           db.ChangeService(ServiceID);


          
        }


        //////////////////////// This activated the whitelisting to the combo boxs
        private void rtb_Requirement_TextChanged(object sender, EventArgs e)
        {
            rtb_Requirement.MaxLength = 255;
            badchar = inputMask(rtb_Requirement.Text);
            if (badchar == "1")
            {
                rtb_Requirement.ResetText();
                MessageBox.Show("Sorry but you have entered the Vehicle Requirements incorrectly . We do not comply to symbols ");

            }
        }

        private void tb_TP_TextChanged(object sender, EventArgs e)
        {
            tb_TP.MaxLength = 255;
            badchar = inputMask2(tb_TP.Text);
            if (badchar == "1")
            {
                tb_TP.ResetText();
                MessageBox.Show("Sorry but you have entered Total Price incorrectly . We do not comply to symbols ");
            }
        }
    }
}
