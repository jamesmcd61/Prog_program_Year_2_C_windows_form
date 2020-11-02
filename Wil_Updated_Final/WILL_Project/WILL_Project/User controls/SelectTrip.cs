using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;



namespace WILL_Project
{
    
    public partial class SelectTrip : UserControl
    {
        DB_Connection db = new DB_Connection(); // create class connection for DB statements

        List<string> truckIDComboBox = new List<string>(); // List for all vehicles that can be used for a trip
        List<string> DriverChoice = new List<string>(); // List for all drivers that can take a trip
        String UserID;
        String TripID;
        String VehicalID;
        String DriverID;
        public SelectTrip(String id) // This will help track drivers ID for the trip
        {
            this.UserID = id;
           
            InitializeComponent();
            Fillcombo();
            DisplayVType();
            ChooseDriver();
        }

        // this method is used to desplay the name of a trip that the office manager has approved
        void Fillcombo() {
          
            cb_SelectTrip.Items.Clear();  // clear drop down before page loads

            SqlDataReader myReader;
            try
            {

                db.closeConnection();
                //This will select the name of the trip 
                myReader = db.SelectTrip();
                
                while (myReader.Read())
                {
                    String sname = myReader.GetString(7); // index number
                   // will display the trip name in the combo box
                    cb_SelectTrip.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            }

        // desplay vehicle that can be used for trip
        void DisplayVType()
        {
           
            SqlDataReader myReader;
            try
            {
                
                db.closeConnection();
               // this will search for vehicles that are able to take a trip
                myReader = db.DisplayVType();
               
                truckIDComboBox.Clear();
                while (myReader.Read())
                {
                    String sname = myReader.GetString(7); // index number
                    // This is all the vehicle size to a combo box
                    cb_SelectV.Items.Add(sname);

                    String test = myReader.GetInt32(0).ToString();
                    truckIDComboBox.Add(test);
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // select driver for the trip
        void ChooseDriver()
        {
            SqlDataReader myReader;
            try
            {

                db.closeConnection();
                //This will display a list of drivers
                myReader = db.ChooseDriver();

                DriverChoice.Clear();
                while (myReader.Read())
                {
                    String sname = myReader.GetString(1); // index number

                    //display drivers in a combo box
                    cb_Driver.Items.Add(sname);
                    String test = myReader.GetInt32(0).ToString();
                    DriverChoice.Add(test);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // insert the trip info to db
        void fillDB()
        {

            db.closeConnection();
            // Create the connection of trip, triver and vehicle
            db.fillDB(DriverID, VehicalID, TripID, dateTimePicker1.Text);

        }

       // change status for active
        void ChangeStatus()
        {
           
            db.closeConnection();
            // This will change status so trip can be taken by driver
            db.ChangeStatus(TripID);
            
            Fillcombo(); //reloads
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // dispay trip info 
        private void Cb_SelectTrip_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            SqlCommand cmd = new SqlCommand();   

            SqlDataReader myReader;
            try
            {
                //  con.Open();
                db.closeConnection();
               //get trip info depending on what is chosen in the drop down
                myReader = db.SelectTripIndex(cb_SelectTrip.Text);

                while (myReader.Read())
                {
                    string rollno = myReader.GetInt32(0).ToString();
                    string name = myReader.GetString(7);
                    string address = myReader.GetString(8);
                    string city = myReader.GetString(9);
                    string postcode = myReader.GetString(10);
                    string province = myReader.GetString(11);
                    string R_Phone = myReader.GetString(12);
                    string R_Description = myReader.GetString(13);

                    //Display trip info to user
                    tb_CName.Text = name;
                    tb_Address.Text = address;
                    tb_City.Text = city;
                    tb_PC.Text = postcode;
                    tb_Prov.Text = province;
                    tb_Phone.Text = R_Phone;
                    TripID = rollno;
                    rtb_TripInfo.Text = R_Description;

                }

            }
            catch(Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
            
        }

        private void Label_ST_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_SelectV.SelectedIndex != -1)
            {
                VehicalID = truckIDComboBox[cb_SelectV.SelectedIndex];
            }
            
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            //checks if textbox id null/blank
            if (string.IsNullOrEmpty(cb_SelectTrip.Text) || string.IsNullOrWhiteSpace(cb_SelectTrip.Text)||string.IsNullOrEmpty(cb_Driver.Text) || string.IsNullOrWhiteSpace(cb_Driver.Text)|| string.IsNullOrEmpty(cb_SelectV.Text) || string.IsNullOrWhiteSpace(cb_SelectV.Text)|| string.IsNullOrEmpty(dateTimePicker1.Text) || string.IsNullOrWhiteSpace(dateTimePicker1.Text))
            {
                MessageBox.Show("Please ensure all information is provided");
            }
            else
            {

                fillDB();
                ChangeStatus();

                cb_SelectTrip.ResetText();
                tb_CName.ResetText();
                tb_City.ResetText();
                tb_Address.ResetText();
                tb_PC.ResetText();
                tb_Prov.ResetText();
                tb_Phone.ResetText();
                rtb_TripInfo.ResetText();
                dateTimePicker1.ResetText();
                cb_SelectV.ResetText();

                MessageBox.Show("Trip successfully started");
            }
        }

        private void cb_Driver_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cb_Driver.SelectedIndex != -1)
            {
                DriverID = DriverChoice[cb_Driver.SelectedIndex];
            }
        }
    }
}
