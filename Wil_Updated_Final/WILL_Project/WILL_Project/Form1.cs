using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WILL_Project
{
    public partial class Login : Form
    {
        DB_Connection db = new DB_Connection();
        int i = 0;
        Regex regex = new Regex(@"[^0-9qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM @ .,]");
        string badchar;

        public Login()
        {
            InitializeComponent();
        }
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

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            // compare username and password with one in db
             DataTable dt = db.Login(tb_Username.Text, tb_Password.Text);

            if (string.IsNullOrEmpty(tb_Username.Text) || string.IsNullOrWhiteSpace(tb_Username.Text))
            {
                MessageBox.Show("Sorry you entered no UserName");
            }
            else
            {
                // This is used to check that there are no blank text boxs
                if (string.IsNullOrEmpty(tb_Password.Text) || string.IsNullOrWhiteSpace(tb_Password.Text))
                {
                    MessageBox.Show("Sorry you entered no Password");
                }
                else
                {
                    // This will send user to location
                    if (dt.Rows.Count == 1)
                    {
                        switch (dt.Rows[0]["PossitionRole"] as string)
                        {
                            case "Office Manager": // System will check if the Positional role is equal to this
                                {
                                    this.Hide();
                                    String ID = dt.Rows[0]["empID"].ToString(); // This will get the User Id as they log into the system
                                    OfficeManager ss = new OfficeManager(ID); //parse the Primary key to the next class in the constructor
                                    ss.Show();
                                    break;
                                }

                            case "Vehicle Information Administrator": // System will check if the Positional role is equal to this
                                {
                                    String ID = dt.Rows[0]["empID"].ToString(); // This will get the User Id as they log into the system
                                    this.Hide();
                                    vehicleAdministrator mf = new vehicleAdministrator(ID); //parse the Primary key to the next class in the constructor
                                    mf.Show();
                                    break;
                                }

                            case "Trip Manager": // System will check if the Positional role is equal to this
                                {
                                    String ID = dt.Rows[0]["empID"].ToString(); // This will get the User Id as they log into the system
                                    this.Hide();
                                    tripManager mf = new tripManager(ID); //parse the Primary key to the next class in the constructor
                                    mf.Show();
                                    break;
                                }
                            case "Service Manager": // System will check if the Positional role is equal to this
                                {
                                    String ID = dt.Rows[0]["empID"].ToString(); // This will get the User Id as they log into the system
                                    this.Hide();
                                    serviceManager mf = new serviceManager(ID); //parse the Primary key to the next class in the constructor
                                    mf.Show();
                                    break;
                                }
                            case "Timesheet Manager": // System will check if the Positional role is equal to this
                                {
                                    String ID = dt.Rows[0]["empID"].ToString(); // This will get the User Id as they log into the system
                                    this.Hide();
                                    timesheetManager mf = new timesheetManager(ID); //parse the Primary key to the next class in the constructor
                                    mf.Show();
                                    break;
                                }

                            case "Driver": // System will check if the Positional role is equal to this
                                {

                                    String ID = dt.Rows[0]["empID"].ToString(); // This will get the User Id as they log into the system
                                    this.Hide();
                                    Driver mf = new Driver(ID); //parse the Primary key to the next class in the constructor
                                    mf.Show();
                                    break;
                                }

                            case "Customer": // System will check if the Positional role is equal to this
                                {

                                    String ID = dt.Rows[0]["empID"].ToString(); // This will get the User Id as they log into the system
                                    this.Hide();
                                    Customer_Home mf = new Customer_Home(ID); //parse the Primary key to the next class in the constructor
                                    mf.Show();
                                    break;
                                }

                            case "Mechanic": // System will check if the Positional role is equal to this
                                {

                                    String ID = dt.Rows[0]["empID"].ToString(); // This will get the User Id as they log into the system
                                    this.Hide();
                                    Mechanic mc = new Mechanic(ID); //parse the Primary key to the next class in the constructor
                                    mc.Show();
                                    break;
                                }
                            default:
                                {
                                  
                                    break;
                                }
                        }
                    }
                    else // if username or password is wrong, the system will display a message informing the user that either the username or password is wrong.
                    {
                        MessageBox.Show("Sorry but your username or password is incorrect");

                        tb_Username.ResetText();
                        tb_Password.ResetText();
                    }


                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {


        }

        private void ll_CreateCustAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Create_Customer cc = new Create_Customer(); // this will direct the user to create a customer account
            cc.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Testsdfgh test = new Testsdfgh();
            test.Show();
            this.Hide();
        }

        private void tb_Username_TextChanged(object sender, EventArgs e)
        {
            tb_Username.MaxLength = 255;
            badchar = inputMask(tb_Username.Text);
            if (badchar == "1")
            {
                tb_Username.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // This will exit the application
        }

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tb_Password_TextChanged(object sender, EventArgs e)
        {
            tb_Password.MaxLength = 255;
            badchar = inputMask(tb_Password.Text);
            if (badchar == "1")
            {
                tb_Password.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }
    }
}