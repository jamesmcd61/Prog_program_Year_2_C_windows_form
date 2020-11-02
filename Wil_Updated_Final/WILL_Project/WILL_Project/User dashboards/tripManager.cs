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
    public partial class tripManager : Form
    {
        DB_Connection db = new DB_Connection(); // create class connection for DB statements
        String UserID;

        public tripManager(String id) // this is to get the ID of the user from the Login
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
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {
            //This is used to change the panel to where the user can assign a trip to a driver
            SelectTrip st = new SelectTrip(UserID); 
            panel_TM.Controls.Clear();     
            panel_TM.Controls.Add(st);
        }

        private void Btn_FuelPrice_Click(object sender, EventArgs e)
        {
            //This is used to change the panel to where the user can create a record for the fuel consumption of each trip
            FuelCon fc = new FuelCon();
            panel_TM.Controls.Clear();
            panel_TM.Controls.Add(fc);
        }

        private void Btn_Incidents_Click(object sender, EventArgs e)
        {
            //This is used to change the panel to where the user can create a incident report
            Trip_Incidents ti = new Trip_Incidents();
            panel_TM.Controls.Clear();
            panel_TM.Controls.Add(ti);
        }

        private void tripManager_Load(object sender, EventArgs e)
        {

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            // this is where the user can log out
            Login fm = new Login();
            this.Hide();
            fm.Show();
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
