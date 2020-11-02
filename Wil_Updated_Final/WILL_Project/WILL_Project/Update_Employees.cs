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
    public partial class Update_Employees : UserControl
    {
        DB_Connection db = new DB_Connection(); // create class connection for DB statements

        // creating input whitelist
        int i = 0;
        Regex regex = new Regex(@"[^0-9qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM .,]");
        string badchar;

        String UserID;
        string FirstName;
        string LastName;
        string DOB;
        string Address;
        string Username;
        string Password;
        string Role;

        public Update_Employees()
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
        // This method is to call all the required information for the employees  
        public void DisplayInfo()
        {
            db.closeConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(db.LoadEmployees());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                UserID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                tb_Firstname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                tb_Surename.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                tb_DOB.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                tb_Address.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                tb_Username.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                tb_Password.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                tb_Role.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();


                FirstName = tb_Firstname.Text;
                LastName = tb_Surename.Text;
                DOB = tb_DOB.Text;
                Address = tb_Address.Text;
                Username = tb_Username.Text;
                Password = tb_Password.Text;
                Role = tb_Role.Text;
            }
            catch (Exception)
            {

                tb_Firstname.Text = "";
                tb_Surename.Text = "";
                tb_DOB.Text = "";
                tb_Address.Text = "";
                tb_Username.Text = "";
                tb_Password.Text = "";
                tb_Role.Text = "";
            }
        }

        // This is to Update from the database
        private void btn_Update_Click(object sender, EventArgs e)
        {
            //This proccess will first check that there are no blanck textboxs
            if (string.IsNullOrEmpty(tb_Address.Text) || string.IsNullOrWhiteSpace(tb_Address.Text)|| string.IsNullOrEmpty(tb_DOB.Text) || string.IsNullOrWhiteSpace(tb_DOB.Text) || string.IsNullOrEmpty(tb_Firstname.Text) || string.IsNullOrWhiteSpace(tb_Firstname.Text) || string.IsNullOrEmpty(tb_Password.Text) || string.IsNullOrWhiteSpace(tb_Password.Text) || string.IsNullOrEmpty(tb_Role.Text) || string.IsNullOrWhiteSpace(tb_Role.Text) || string.IsNullOrEmpty(tb_Surename.Text) || string.IsNullOrWhiteSpace(tb_Surename.Text) || string.IsNullOrEmpty(tb_Username.Text) || string.IsNullOrWhiteSpace(tb_Username.Text))
            {
                MessageBox.Show("Please ensure all information is provided.");
            }
            else
            {
                db.closeConnection();

                // This will then update what the user has entered
                SqlCommand cmd = db.UpdateEmployees(tb_Firstname.Text, tb_Surename.Text, tb_DOB.Text, tb_Address.Text, tb_Username.Text, tb_Password.Text, tb_Role.Text, UserID.ToString());

                cmd.Parameters.AddWithValue("@FirstName", tb_Firstname.Text);
                cmd.Parameters.AddWithValue("@LastName", tb_Surename.Text);
                cmd.Parameters.AddWithValue("@DOB", tb_DOB.Text);
                cmd.Parameters.AddWithValue("@Address", tb_Address.Text);
                cmd.Parameters.AddWithValue("@Username", tb_Username.Text);
                cmd.Parameters.AddWithValue("@Password", tb_Password.Text);
                cmd.Parameters.AddWithValue("@PossitionRole", tb_Role.Text);
                cmd.ExecuteNonQuery();

                //This resets the text boxes
                tb_Firstname.ResetText();
                tb_Surename.ResetText();
                tb_DOB.ResetText();
                tb_Address.ResetText();
                tb_Username.ResetText();
                tb_Password.ResetText();
                tb_Role.ResetText();

                DisplayInfo(); // this is used to refresh the datagrid

                MessageBox.Show("Employee record updated successfully.");
            }

            
        }

        // This is to remove from the database
        private void Bt_Remove_Click(object sender, EventArgs e)
        {
            //This proccess will first check that there are no blanck textboxs
            if (string.IsNullOrEmpty(tb_Address.Text) || string.IsNullOrWhiteSpace(tb_Address.Text) || string.IsNullOrEmpty(tb_DOB.Text) || string.IsNullOrWhiteSpace(tb_DOB.Text) || string.IsNullOrEmpty(tb_Firstname.Text) || string.IsNullOrWhiteSpace(tb_Firstname.Text) || string.IsNullOrEmpty(tb_Password.Text) || string.IsNullOrWhiteSpace(tb_Password.Text) || string.IsNullOrEmpty(tb_Role.Text) || string.IsNullOrWhiteSpace(tb_Role.Text) || string.IsNullOrEmpty(tb_Surename.Text) || string.IsNullOrWhiteSpace(tb_Surename.Text) || string.IsNullOrEmpty(tb_Username.Text) || string.IsNullOrWhiteSpace(tb_Username.Text))
            {
                MessageBox.Show("Please select a record.");
            }
            else
            {
                db.closeConnection();
                // This finds a match and then deletes it from the Database
                db.DeleteLogin(tb_Firstname.Text, UserID.ToString());

                //Reset textboxs
                tb_Firstname.ResetText();
                tb_Surename.ResetText();
                tb_DOB.ResetText();
                tb_Address.ResetText();
                tb_Username.ResetText();
                tb_Password.ResetText();
                tb_Role.ResetText();

                DisplayInfo(); // this is used to refresh the datagrid

                MessageBox.Show("Employee recorded successfully deleted.");
            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ReadOnly = true; // Insure that the datagrid in on a read only mode
        }

        //////////////////////// This activated the whitelisting to the combo boxs
        private void Tb_Firstname_TextChanged(object sender, EventArgs e)
        {
            tb_Firstname.MaxLength = 255;
            badchar = inputMask(tb_Firstname.Text);
            if (badchar == "1")
            {
                tb_Firstname.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Surename_TextChanged(object sender, EventArgs e)
        {
            tb_Surename.MaxLength = 255;
            badchar = inputMask(tb_Surename.Text);
            if (badchar == "1")
            {
                tb_Surename.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_DOB_TextChanged(object sender, EventArgs e)
        {
            tb_DOB.MaxLength = 255;
            badchar = inputMask(tb_DOB.Text);
            if (badchar == "1")
            {
                tb_DOB.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Address_TextChanged(object sender, EventArgs e)
        {
            tb_Address.MaxLength = 255;
            badchar = inputMask(tb_Address.Text);
            if (badchar == "1")
            {
                tb_Address.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Username_TextChanged(object sender, EventArgs e)
        {
            tb_Username.MaxLength = 255;
            badchar = inputMask(tb_Username.Text);
            if (badchar == "1")
            {
                tb_Username.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Password_TextChanged(object sender, EventArgs e)
        {
            tb_Password.MaxLength = 255;
            badchar = inputMask(tb_Password.Text);
            if (badchar == "1")
            {
                tb_Password.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }

        private void Tb_Role_TextChanged(object sender, EventArgs e)
        {
            tb_Role.MaxLength = 255;
            badchar = inputMask(tb_Role.Text);
            if (badchar == "1")
            {
                tb_Role.ResetText();
                MessageBox.Show("Sorry but you have entered something incorrectly . We do not comply to symbols ");

            }
        }
    }
}
