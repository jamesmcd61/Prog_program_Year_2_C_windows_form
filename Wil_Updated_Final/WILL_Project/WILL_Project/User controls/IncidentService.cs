﻿using System;
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
    public partial class IncidentService : UserControl
    {
        DB_Connection db = new DB_Connection(); // create class connection for DB statements

        String ServiceID;
        int Vehicle_ID;

        public IncidentService()
        {
            InitializeComponent();
            Fillcombo();
        }

        void Fillcombo()
        {
            
            cb_SelectV.Items.Clear();  // clear drop down before page loads

            SqlDataReader myReader;
            try
            {

                db.closeConnection();
                // get vehicle info of vehicle that trip manager issued
                myReader = db.incedentDD();

                while (myReader.Read())
                {
                    String sname = myReader.GetString(5); // index number
                    // display number plate in drop down
                    cb_SelectV.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            // insure there is no blank inputs when submit button in entered
            if (string.IsNullOrEmpty(cb_SelectV.Text) || string.IsNullOrWhiteSpace(cb_SelectV.Text)||string.IsNullOrEmpty(DTP.Text) || string.IsNullOrWhiteSpace(DTP.Text))
            {
                MessageBox.Show("Please ensure all information is provided");
            }
            else
            {


                db.closeConnection();
                // insert incident into database to mechanicx can fix
                SqlCommand cmd = db.createIncService();

                cmd.Parameters.Add("@Vehicle_Make", tb_Make.Text);
                cmd.Parameters.Add("@Vehicle_Model", tb_Model.Text);
                cmd.Parameters.Add("@Number_Plate", tb_NP.Text);
                cmd.Parameters.Add("@Problem", RTB_Problem.Text);
                cmd.Parameters.Add("@Date", DTP.Value.Date);
                cmd.Parameters.Add("@Vehicle_ID", Vehicle_ID);

                cmd.ExecuteNonQuery();

                // reset textbox
                tb_Make.ResetText();
                tb_Model.ResetText();
                tb_NP.ResetText();
                RTB_Problem.ResetText();
                DTP.ResetText();

                // change status of vehicle so mechanic can fix
                db.closeConnection();
                db.ChangeV_Incident(ServiceID);

                db.closeConnection();
                db.ChangeIncStatus(Vehicle_ID.ToString());

                MessageBox.Show("Service incident/repair reported successfully");
            }
        }

        private void Cb_SelectV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // display info of vehicle that needs a service
            SqlCommand cmd = new SqlCommand();

            SqlDataReader myReader;
            try
            {
                db.closeConnection();

                // get incident info that matchs the number plate chosen
                myReader = db.SelectIncident(cb_SelectV.Text);

                while (myReader.Read())
                {
                    string rollno = myReader.GetInt32(0).ToString();
                    string Location = myReader.GetString(1);
                    string CauseOf = myReader.GetString(2);
                    string Driver = myReader.GetString(3);
                    string VehicleMake = myReader.GetString(4);
                    string NumberPlate = myReader.GetString(5);
                    string OtherParties = myReader.GetString(6);
                    string VehicleModel = myReader.GetString(7);
                    int Vehicle_ID1 = myReader.GetInt32(9);

                    // display info to user
                    tb_Make.Text = VehicleMake;
                    tb_Model.Text = VehicleModel;
                    tb_NP.Text = NumberPlate;
                    RTB_Problem.Text = CauseOf;

                    ServiceID = rollno;
                    Vehicle_ID = Vehicle_ID1;;
                }

            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }    

    }
}
