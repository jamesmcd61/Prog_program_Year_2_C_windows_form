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
    public partial class Mechanioc_Standard : UserControl
    {
        DB_Connection db = new DB_Connection(); // connecting to bd class
        String ServiceID;
        int Vehicle_ID;

        // creating input whitelist
        int i = 0;
        Regex regex = new Regex(@"[^0-9qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM .,]");
        Regex regex2 = new Regex(@"[^0-9.,]");
        string badchar;

        public Mechanioc_Standard()
        {
            
            InitializeComponent();
            Fillcombo();
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

        // input method mask that filters
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

        // display vehcle inf that needs standard service
        private void Cb_ServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataReader myReader;
            try
            {
                db.closeConnection();

                // This will get the vehicle information on which was chosen in the combo box
                myReader = db.SelectedStaService(cb_ServiceType.Text);

                while (myReader.Read())
                {
         
                   string ServiceID1 = myReader.GetInt32(0).ToString();
                    string Vehicle_Make = myReader.GetString(1);
                    string Vehicle_Model = myReader.GetString(2);
                    string Number_Plate = myReader.GetString(3);
                    string Date = myReader.GetString(4).ToString();
                    int Total_Milage = myReader.GetInt32(5);
                    int V_ID = myReader.GetInt32(6);
                   
                    // create relationship
                    ServiceID = ServiceID1;
                    Vehicle_ID = V_ID;

                    //reset textbox
                    tb_VMake.Text = Vehicle_Make;
                    tb_VM.Text = Vehicle_Model;
                    tb_NP.Text = Number_Plate;
                    tb_TMilage.Text = Total_Milage.ToString();
                    tb_Date.Text = Date;



                }

            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }

        // desplay vehicl name for standard service
        void Fillcombo()
        {

           cb_ServiceType.Items.Clear(); 

            SqlDataReader myReader;
            try
            {

                db.closeConnection();
                // Get name of vehicle that needs a standard service
                myReader = db.StandardService();

                while (myReader.Read())
                {
                    String sname = myReader.GetString(1); // index number
                    //Display name in Combobox
                    cb_ServiceType.Items.Add(sname);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {  
            //This proccess will first check that there are no blanck textboxs
            if (cb_ServiceType.ToString() == "" || rtb_Requirement.Text == "" || tb_TP.Text == "")
            {
                MessageBox.Show("Please ensure all information is provided");
            }
            else
            {


                db.closeConnection();

                // Add service to database
                SqlCommand cmd = db.CompleteService();

                cmd.Parameters.Add("@ServiceID", ServiceID);
                cmd.Parameters.Add("@Description", rtb_Requirement.Text);
                cmd.Parameters.Add("@Price", tb_TP.Text);
                cmd.ExecuteNonQuery();

                // Reset Textboxs
                rtb_Requirement.ResetText();
                tb_TP.ResetText();
                tb_VMake.ResetText();
                tb_VM.ResetText();
                tb_NP.ResetText();
                tb_TMilage.ResetText();
                tb_Date.ResetText();

                ChangeStatus();
                // Set service to complete
                db.closeConnection();

                // change status of vehicle so Trip Manager can user it
                db.ChangeV_Fixed(Vehicle_ID.ToString());

                MessageBox.Show("Standard service submitted successfully");
            }
        }

        void ChangeStatus()
        {

            db.closeConnection();
            db.ChangeService(ServiceID);


        }

        ////////////////////// This activated the whitelisting to the combo boxs
        private void rtb_Requirement_TextChanged(object sender, EventArgs e)
        {
            rtb_Requirement.MaxLength = 255;
            badchar = inputMask(rtb_Requirement.Text);
            if (badchar == "1")
            {
                rtb_Requirement.ResetText();
                MessageBox.Show("Sorry but you have entered Vehicle Requirements incorrectly . We do not comply to symbols ");

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
