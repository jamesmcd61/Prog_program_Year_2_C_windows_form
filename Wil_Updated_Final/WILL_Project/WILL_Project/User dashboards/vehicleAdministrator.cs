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

namespace WILL_Project
{
    public partial class vehicleAdministrator : Form
    {
        DB_Connection db = new DB_Connection();// create class connection for DB statements

        AddVehicle av = new AddVehicle();
        String UserID;
        public vehicleAdministrator(String id) // this is to get the ID of the user from the Login
        {
            this.UserID = id;
            InitializeComponent();
            DisplayName();
        }

        // This Method is used to display the users first name and surename
        void DisplayName()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataReader myReader;
            try
            {
                db.closeConnection();
                // This will get the name that matches the id of the user logged in
                myReader = db.DisplayStaffName(UserID);

                while (myReader.Read())
                {
                    String FirstName = myReader.GetString(0);
                    String LastName = myReader.GetString(1);

                    //This displays the name 
                    label_Names.Text = FirstName + " " + LastName;
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }

        private void Label_Title_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_AddVehicle_Click(object sender, EventArgs e)
        {
            // change panel to where the user can add a vehicle
            panel_VAdmin.Controls.Clear();
            panel_VAdmin.Controls.Add(av);
        }

        private void Btn_Display_Click(object sender, EventArgs e)
        {
            // change panle so user can view status of vehicles
            VA_VehicleStatus VV = new VA_VehicleStatus();
            panel_VAdmin.Controls.Clear();
            panel_VAdmin.Controls.Add(VV);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            // the user can be able to log out the system
            Login fm = new Login();
            this.Hide();
            fm.Show();
        }

        private void vehicleAdministrator_Load(object sender, EventArgs e)
        {

        }

        private void btn_exit2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Minimiza_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
