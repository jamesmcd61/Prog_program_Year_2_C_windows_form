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
    public partial class VA_VehicleStatus : UserControl
    {
        DB_Connection db = new DB_Connection(); // connecting to database class
        public VA_VehicleStatus()
        {
            InitializeComponent();
        }

        private void Btn_SV_Click(object sender, EventArgs e)
        {
            // desplay vehicles that are not being used
            db.closeConnection();
            DataTable dt = new DataTable(); // create datatable
            SqlDataAdapter da = new SqlDataAdapter(db.StatVehicleSta()); // Get vehicles that are not in use
            da.Fill(dt); // add vehicle info into DataTable
            DGV_TripStatus.DataSource = dt;  // insert datatabe into datagrid
            DGV_TripStatus.ReadOnly = true; // make datagrid read only

           

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // desplay vehicles that are in use
            db.closeConnection();
            DataTable dt = new DataTable(); // create datatable
            SqlDataAdapter da = new SqlDataAdapter(db.StatVehicleAct()); // Get vehicles that are in use
            da.Fill(dt); // add vehicle info into DataTable
            DGV_TripStatus.DataSource = dt; // insert datatabe into datagrid
            DGV_TripStatus.ReadOnly = true; // make datagrid read only
        }

        private void btn_InService_Click(object sender, EventArgs e)
        {
            // desplay vehicles that are in a service
            db.closeConnection();
            DataTable dt = new DataTable(); // create datatable
            SqlDataAdapter da = new SqlDataAdapter(db.StatVehicleSer()); // Get vehicles that are in a service
            da.Fill(dt); // add vehicle info into DataTable
            DGV_TripStatus.DataSource = dt; // insert datatabe into datagrid
            DGV_TripStatus.ReadOnly = true; // make datagrid read only

        }

        private void DGV_TripStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DGV_TripStatus.Columns[0].ReadOnly = true; // make datagrid read only

        }
    }
}
