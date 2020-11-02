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
    public partial class Mechanic : Form
    {
        DB_Connection db = new DB_Connection(); // create class connection for DB statements
        String UserID;
        public Mechanic(String id) // this is to get the ID of the user from the Login
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
        private void Btn_Standard_Click(object sender, EventArgs e)
        {
            // this will display a panel where the user can view all standard serviced bookings
            Mechanioc_Standard ms = new Mechanioc_Standard();
            panel_Mech.Controls.Clear();
            panel_Mech.Controls.Add(ms);
        }

        private void btn_Inc_Click(object sender, EventArgs e)
        {
            // this will display a panel where the user can view all incident serviced bookings
            MacanicIncident mi = new MacanicIncident();
            panel_Mech.Controls.Clear();
            panel_Mech.Controls.Add(mi);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            // Thhis will allow the user to exit to login page
            Login fm = new Login();
            this.Hide();
            fm.Show();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
