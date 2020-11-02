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

namespace WILL_Project
{
    public partial class ViewDriverTrip : UserControl
    {
        String UserID;
        DB_Connection db = new DB_Connection(); // create class connection for DB statements
        String TID;
        String V_ID;

        public ViewDriverTrip(String id)
        {
            this.UserID = id;
            InitializeComponent();
            Fillcombo();
          
        }

        // desplay drivers trip details when selected on the combobox
        private void Cb_ViewTrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataReader myReader;
            try
            {
                db.closeConnection();

                //This searches the database to find the trip info
                myReader = db.DisplayDriverTrip(cb_ViewTrip.Text);

                while (myReader.Read())
                {

                    String Name = myReader.GetString(1);
                    String city = myReader.GetString(2);
                    String address = myReader.GetString(3);
                    String postcode = myReader.GetString(4);
                    String Province = myReader.GetString(5);
                    String number = myReader.GetString(6);
                    String Desc = myReader.GetString(7);
                    String Date = myReader.GetString(8);
                    String Vehcle = myReader.GetString(9);
                    String TriID = myReader.GetInt32(10).ToString();
                    String VehicleID = myReader.GetInt32(11).ToString();

                    //This is how the trip info is displayed in textboxs
                    tb_CName.Text = Name;
                    tb_City.Text = city;
                    tb_Address.Text = address;
                    tb_PC.Text = postcode;
                    tb_Prov.Text = Province;
                    tb_Phone.Text = number;
                    rtb_TripInfo.Text = Desc;
                    tb_DOT.Text = Date;
                    tb_Vehicle.Text = Vehcle;

                    TID = TriID;
                    V_ID = VehicleID;
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }

        // fill allocated trip into combo box
        void Fillcombo()
        {

            cb_ViewTrip.Items.Clear();  // clear drop down before page loads

            SqlDataReader myReader;
            try
            {
                
                db.closeConnection();
                //Get Trip that is allocated to the driver
                myReader = db.SelectAssinedTrip(UserID);

                while (myReader.Read())
                {
                    String sname = myReader.GetString(0); // index number

                    //Display Trip name in combobox for driver
                    cb_ViewTrip.Items.Add(sname);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
       

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            //checks if textbox id null/blank
            if (string.IsNullOrEmpty(cb_ViewTrip.Text) || string.IsNullOrWhiteSpace(cb_ViewTrip.Text))
            {
                MessageBox.Show("Please ensure all information is provided");
            }
            else
            {


                db.closeConnection();
                // This will change the trip to Active so that the Office manager can see that is is being delivered
                db.ChangeTStatus(TID);

                db.closeConnection();
                //This will change the status of the vehicle so that it can not be assined to another trip
                db.ChangeV_Status(V_ID);

                //This will clear all textboxs
                cb_ViewTrip.ResetText();
                tb_CName.ResetText();
                tb_City.ResetText();
                tb_Address.ResetText();
                tb_PC.ResetText();
                tb_Prov.ResetText();
                tb_Phone.ResetText();
                rtb_TripInfo.ResetText();
                tb_DOT.ResetText();
                tb_Vehicle.ResetText();

                MessageBox.Show("Trip successfully started. Drive safely.");
            }
        }

        private void panel_DriverTrip_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
