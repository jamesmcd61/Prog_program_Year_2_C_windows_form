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

namespace WILL_Project
{
    public partial class Report_vehicle : UserControl
    {
        DB_Connection db = new DB_Connection(); // create class connection for DB statements

        DataTable AllVehicles; // create DataTable

        public Report_vehicle()
        {
            InitializeComponent();
            
        }
        void All_Vehicles() // This Method is used to display all the vehicles that the company has
        {
            db.closeConnection();// close database connection before using it again

            // Create DataTable with headers 
            DataTable dt = new DataTable();

            dt.Columns.Add("Vehicle Make", typeof(String));
            dt.Columns.Add("Vehicle Model", typeof(String));
            dt.Columns.Add("Vehicle Year", typeof(String));
            dt.Columns.Add("VIN Number", typeof(String));
            dt.Columns.Add("Engine Size", typeof(String));
            dt.Columns.Add("Number Plate", typeof(String));
            dt.Columns.Add("Capacity", typeof(String));

            AllVehicles = db.ViewAllVehicles(); // this method will call the required information from all the vehicles

            //This will loop the above method and generate all employees that are done
            for (int i = 0; i < AllVehicles.Rows.Count; i++)
            {

                string V_Make = AllVehicles.Rows[i][1].ToString();
                string V_Model = AllVehicles.Rows[i][2].ToString();
                string V_Year = AllVehicles.Rows[i][3].ToString();
                string VIN_Num = AllVehicles.Rows[i][4].ToString();
                string Engine_Size = AllVehicles.Rows[i][5].ToString();
                string NP = AllVehicles.Rows[i][6].ToString();
                string Capacity = AllVehicles.Rows[i][7].ToString();

                // This will then display to the datagrid 
                dt.Rows.Add(V_Make, V_Model, V_Year, VIN_Num, Engine_Size, NP, Capacity);

                dg_vehicle_report.DataSource = dt;
            }
        }

        void Pending_Service() // this method is to display all vehicles that are booked for a service
        {
           
            db.closeConnection(); // close database connection before using it again
            DataTable dt = new DataTable(); // This creates a DataTable to store values in
            SqlDataAdapter da = new SqlDataAdapter(db.ServiceBooking()); // This will call the vehicles that are booked for a service
            da.Fill(dt); // This stores the vehicles that are booked for a service in the DataTable
            dg_vehicle_report.DataSource = dt; // This will then display the DataTable in the DataGrid


        }
        void Complete_Service() // This method is to display all thye service history
        {

            db.closeConnection(); // close database connection before using it again

            // Create DataTable with headers 
            DataTable dt = new DataTable();
           
            dt.Columns.Add("Vehicle Make", typeof(String));
            dt.Columns.Add("Vehicle Model", typeof(String));
            dt.Columns.Add("Number Plate", typeof(String));
            dt.Columns.Add("Replacement Required", typeof(String));
            dt.Columns.Add("Total price", typeof(String));
            
            AllVehicles = db.ViewCompleteService(); // this method will call the required information from all the vehicles that has has a service

            for (int i = 0; i < AllVehicles.Rows.Count; i++)
            {

                string V_Make = AllVehicles.Rows[i][0].ToString();
                string V_Model = AllVehicles.Rows[i][1].ToString();
                string NP = AllVehicles.Rows[i][2].ToString();
                string Description = AllVehicles.Rows[i][3].ToString();
                string Total_Price = AllVehicles.Rows[i][4].ToString();

                dt.Rows.Add(V_Make, V_Model, NP, Description, Total_Price); // This will put the vehicle information into the DataTable

                dg_vehicle_report.DataSource = dt; //This will then display the information in the DataTable into the DataGrid
            }
        }


        // This is how to call methods and create a read only DataGrid
        private void Btn_View_all_vehicles_Click(object sender, EventArgs e)
        {
            All_Vehicles();
            dg_vehicle_report.ReadOnly = true;
        }

        private void Btn_vehicles_booked_service_Click(object sender, EventArgs e)
        {
            
            Pending_Service();
            dg_vehicle_report.ReadOnly = true;
        }

        private void Btn_vehicles_service_complete_Click(object sender, EventArgs e)
        {
            Complete_Service();
            dg_vehicle_report.ReadOnly = true;
        }

        private void Report_vehicle_Load(object sender, EventArgs e)
        {

        }
    }
}
