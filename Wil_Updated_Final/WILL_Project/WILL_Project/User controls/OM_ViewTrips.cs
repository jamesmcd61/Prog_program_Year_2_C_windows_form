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
    
    public partial class OM_ViewTrips : UserControl
    {

         DB_Connection db = new DB_Connection(); // db connection 

        public OM_ViewTrips()
        {
            InitializeComponent();
        }

        //display active trip
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            db.closeConnection();

            DataTable dt = new DataTable(); // create datatable
            SqlDataAdapter da = new SqlDataAdapter(db.Active()); // Get trips that are active
            da.Fill(dt); // add trip info into DataTable
            dataGridView1.DataSource = dt; // insert datatabe into datagrid
            dataGridView1.ReadOnly = true; // make datagrid read only
        }

        // desplay pending trip
        private void Button1_Click(object sender, EventArgs e)
        {

            db.closeConnection();
            DataTable dt = new DataTable(); // create datatable
            SqlDataAdapter da = new SqlDataAdapter(db.Pending()); // Get trips that are pending
            da.Fill(dt);// add trip info into DataTable
            dataGridView1.DataSource = dt; // insert datatabe into datagrid
            dataGridView1.ReadOnly = true; // make datagrid read only
        }

        // display complete trip
        private void Btn_Complete_Click(object sender, EventArgs e)
        {

            db.closeConnection();
            DataTable dt = new DataTable(); // create datatable
            SqlDataAdapter da = new SqlDataAdapter(db.Complete()); // Get trips that are complete
            da.Fill(dt); // add trip info into DataTable
            dataGridView1.DataSource = dt; // insert datatabe into datagrid
            dataGridView1.ReadOnly = true; // make datagrid read only
        }

        private void OM_ViewTrips_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
