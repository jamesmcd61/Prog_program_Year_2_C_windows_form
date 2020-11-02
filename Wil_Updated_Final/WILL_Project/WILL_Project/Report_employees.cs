using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WILL_Project
{
    public partial class Report_employees : UserControl
    {

        DB_Connection db = new DB_Connection(); // create class connection for DB statements
        DataTable Emp_Report; // create DataTable

        public Report_employees()
        {
            InitializeComponent();
        }

        // Create Method for button
        public void Emp_Rate() 
        {
            db.closeConnection(); // close database connection before using it again

            // Create DataTable with headers 
            DataTable dt = new DataTable();
            
            dt.Columns.Add("Role", typeof(String));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Hourly Rate", typeof(String));
            dt.Columns.Add("Start Time", typeof(String));
            dt.Columns.Add("End Time", typeof(String));
            dt.Columns.Add("Date", typeof(String));
            dt.Columns.Add("Total Wage", typeof(String));

            Emp_Report = db.EmployeeReport(); // this method will call the required information from the employee rate

            //This will loop the above method and generate all employees that are done
            for (int i = 0; i < Emp_Report.Rows.Count; i++)
            {
                
                    string Role = Emp_Report.Rows[i][0].ToString();
                    string Name = Emp_Report.Rows[i][1].ToString();
                    string HourlyRate = Emp_Report.Rows[i][2].ToString();
                    string StartTime = Emp_Report.Rows[i][3].ToString();
                    string EndTime = Emp_Report.Rows[i][4].ToString();
                string Date = Emp_Report.Rows[i][5].ToString();
                string TotalWage = Emp_Report.Rows[i][6].ToString();

                // This will then display to the datagrid 

                dt.Rows.Add(Role, Name, HourlyRate, StartTime, EndTime, Date, TotalWage);

                    dg_emp_report.DataSource = dt;
                }
            }
        

        private void btn_View_emp_rates_Click(object sender, EventArgs e)
        {
            Emp_Rate(); // This is how to call a method created on this page
            dg_emp_report.ReadOnly = true; // Set Datagrid to read only
        }

        private void Report_employees_Load(object sender, EventArgs e)
        {

        }
    }
}
