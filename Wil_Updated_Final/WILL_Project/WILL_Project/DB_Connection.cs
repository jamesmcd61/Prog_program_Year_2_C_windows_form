using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WILL_Project
{
    class DB_Connection
    {
        public static SqlConnection con = null;

        public DB_Connection()
        {
           
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string newpath = path.Remove(path.Length - 9, 9) + "DataBase.mdf";
            string fullPath = newpath.Remove(0, 6);

            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + fullPath + ";Integrated Security=True");
        }
        
        // Display trip that is ready to be assined
        public SqlDataReader SelectTrip() 
        {
            String sql = "select * from Trip where Status = 'Stationary'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
            
        }

        // display trip name to the driver 
        public SqlDataReader SelectAssinedTrip(String Driver) // may need to delete
        {
            String sql = "select T.R_City from Trip T, History H, Login L where T.Status = 'waiting' and T.TripID = H.TripID and L.EmpID = H.DriverID and L.EmpID = '" + Driver+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;

        }

        // display trip info that customer created and office manager must approve or not
        public SqlDataReader RequestTrip()
        {

            String sql = "select * from Trip where Status = 'Request'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // This will approve the customers trip request
        public void ChangeRequest(String TripID) 
        {
           
            String sql = "update Trip set Status = 'Stationary' where Status='Request' and TripID = '" + TripID + "'";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // This will decline the customers trip request
        public void DeclineTripRequest(String TripID)
        {
            String sql = "update Trip set Status = 'Decline' where Status='Request' and TripID = '" + TripID + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // this is used to get the Vehicle info trip manager to manage a trip
        public SqlDataReader DisplayVType()
        {  
            String sql = "select * from Vehical where Status = 'Stationary'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // Display drivers to the trip manager to manage trip
        public SqlDataReader ChooseDriver()
        {
            String sql = "select * from Login where PossitionRole = 'Driver'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // create connection of driverID, VehicleID and trripID together in table
        public void fillDB(string UserID, string VehicalID, string TripID, String date)
        {
            string help = "INSERT INTO History ([DriverID], [VehicalID], [TripID],[Start_Date], [Status]) VALUES('" + UserID + "', ' " + VehicalID + "', '" + TripID + "', '" + date + "', '" + " Active " + "'); ";
            SqlCommand cmd = new SqlCommand(help, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        
        // display trip info to allocated driver
        public SqlDataReader DisplayDriverInfo(String DriverID)
        {
            String sql = "select * from History where DriverID = '"+DriverID+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // display standard service vehicle make to user
        public SqlDataReader StandardService()
        {
            String sql = "select * from Service where Problem = 'N/A' and Status = 'Pending'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;

        }

        // display service name for mechanioc with incident vehicle
        public SqlDataReader IncedintService() 
        {
            String sql = "select * from Service where Status = 'Pending'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;

        }

        public void ChangeStatus(String TripID)
        {
             
            String sql = "update Trip set Status = 'waiting' where Status='Stationary' and TripID = '" + TripID + "'";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // Add End Date to the driver trip
        public SqlCommand UpdateTripEndDate(string EndTrip, string TripID)
        {
            String query = "update History set End_Date = '" + EndTrip + "' where TripID = '" + TripID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            return cmd;
        }

        // update trip to active 
        public void ChangeTStatus(String TripID)
        {
            String sql = "update Trip set Status = 'Active' where Status='waiting' and TripID = '" + TripID + "'";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader SelectTripIndex(String Trip)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename = D:\VARSITY\WILLPROG\WILL_PROJECT\WILL_PROJECT\DATABASE.MDF");
            String sql = "select * from Trip where R_Name = '" + Trip + "' ";
            //String sql1 = "UPDATE Trip set Status = @Status", _con;
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;

        }

        public SqlDataReader SelectedService(String Trip)
        {
           
            String sql = "select * from Service where Vehicle_Make = '" + Trip + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;

        }

        // Display service info to user that match the chosen number plate
        public SqlDataReader SelectedIncService(String Trip)
        {
            String sql = "select ServiceID, Vehicle_Make, Vehicle_Model, Number_Plate, Date, Problem, Vehicle_ID from Service where Number_Plate = '" + Trip + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;

        }

        // display all standard service vehicle info that match the vehicle make 
        public SqlDataReader SelectedStaService(String Trip)
        {
            String sql = "select ServiceID, Vehicle_Make, Vehicle_Model, Number_Plate, Date, Total_Milage, Vehicle_ID from Service where Vehicle_Make = '" + Trip + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;

        }

        // this is to close the connection
        public void closeConnection()
        {
            con.Close();
        }

        //-COMPLETE  TRIP----------------------------------------------------------------------

            // Display trip that is take by driver and ready to be complete
        public SqlDataReader Fillcombo(String UserID)
        {
            //      1               //                                 2                                //                                              3                                                       ///             4
            String sql = "select Tr.[R_City] from [Vehical] as ve, [Login] as Lo, [Trip] as Tr, [History] as His where Ve.[VehicalID] = His.[VehicalID] and Lo.[EmpID] = His.[DriverID] and Tr.[TripID] = His.[TripID] AND Tr.Status = 'Active' AND DriverID = '" + UserID + "' ";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // Update trip to complete
        public void ChangeTripStatus(String tripID)
        {
            string complete = "Complete";

            String sql = "update Trip set Status = 'Complete' where Status = 'Active' and TripID = '" + tripID + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        //---------VIEW THE TRIPS IN OM_VIEWTRIP--------------------------------------------------------------------------------------------

        // Display active trips for the office manager to view in datagrid
        public SqlCommand Active()
        {
           String query = "select Tr.[R_Name] as 'Customer Name', Tr.[R_StreetAddress] as 'Customer Street', Tr.[R_City] as 'Customer City', Lo.[FirstName] as 'Driver Name', Lo.[LastName] as 'Driver Surname', Ve.[Vehical_Make] as 'Vehical Make', Ve.[Vehical_Model] as 'Vehical Model', Ve.[VIN_Number] as 'VIN Number', Tr.[Status] from [Vehical] as ve, [Login] as Lo, [Trip] as Tr, [History] as His where Ve.[VehicalID] = His.[VehicalID] and Lo.[EmpID] = His.[DriverID] and Tr.[TripID] = His.[TripID] AND Tr.Status = 'Active'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        // display complete trips for the office manager in a in datagrid
        public SqlCommand Complete()
        {
            String query = "select Tr.[R_Name] as 'Customer Name', Tr.[R_StreetAddress] as 'Customer Street', Tr.[R_City] as 'Customer City', Lo.[FirstName] as 'Driver Name', Lo.[LastName] as 'Driver Surename', Ve.[Vehical_Make] as 'Vehical Make', Ve.[Vehical_Model] as 'Vehical Model', Ve.[VIN_Number] as 'VIN Number', Tr.[Status] from [Vehical] as ve, [Login] as Lo, [Trip] as Tr, [History] as His where Ve.[VehicalID] = His.[VehicalID] and Lo.[EmpID] = His.[DriverID] and Tr.[TripID] = His.[TripID] AND Tr.Status = 'Complete'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        public SqlCommand test()
        {
            String query = "Select * from Login";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        // display pending trips to office manager in datagrid
        public SqlCommand Pending()
        {
            String query = "select [R_Name] as 'Customer Name', [R_StreetAddress] as 'Customer Street', [R_City] as 'Customer City', [R_Postcode] as 'Customer Postcode', [Status] from Trip WHERE Status='waiting'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }
       
        // create new employee account
        public SqlCommand create()
        {
            String query = "INSERT INTO Login (FirstName, LastName, DOB, Address, Username, Password, PossitionRole) VALUES (@FirstName, @LastName, @DOB, @Address, @Username, @Password, @PossitionRole) ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }
        public SqlCommand createCustomer()
        {
            String query = "INSERT INTO Login (FirstName, LastName, DOB, Address, Username, Password) VALUES (@FirstName, @LastName, @DOB, @Address, @Username, @Password) ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        // create a trip
        public SqlCommand createTrip()
        {
            String query = "INSERT INTO Trip (S_Name, S_StreetAddress, S_City, S_Postcode, S_Province, S_Phone, R_Name, R_StreetAddress, R_City, R_Postcode, R_Province, R_Phone, R_Description)" +
            " VALUES (@S_Name, @S_StreetAddress, @S_City, @S_Postcode, @S_Province, @S_Phone, @R_Name, @R_StreetAddress, @R_City, @R_Postcode, @R_Province, @R_Phone, @R_Description)";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        // Create a new vehicle to the system / database
        public SqlCommand createVehicle()
        {
            String query = "INSERT INTO Vehical (Vehical_Make, Vehical_Model, Vehical_Year, VIN_Number, Engine_Size, Number_Plate, Capacity)" +
            " VALUES (@Vehical_Make, @Vehical_Model, @Vehical_Year, @VIN_Number, @Engine_Size, @Number_Plate, @Capacity)";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            return cmd;
        }

        // This method is used for the login to check if the username and password are a match
        public DataTable Login(String Username, String Password)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select PossitionRole, empID from Login Where UserName='" + Username + "' and Password='" + Password + "'   ", con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            return dt;

            //SqlDataAdapter sda = new SqlDataAdapter("Select PossitionRole, empID from Login Where UserName='" + tb_Username.Text + "' and Password='" + tb_Password.Text + "'   ", con);
        }

        // display positional roles for when making EmployeeHours
        public SqlDataReader FillEmpRole()
        {
            String sql = "SELECT distinct L.PossitionRole from Login L";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // Display employee name that has the same positional role chosen
        public SqlDataReader FillEmpName(String Role)
        {
           
            String sql = "SELECT L.FirstName from Login L where L.PossitionRole = '"+Role+"'";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // creat an employee Rate reccord
        public SqlCommand empRate()
        {
            String query = "INSERT INTO Emp_Rate (Role, Name, StartTime, EndTime, RPH, Date, Wage) VALUES (@Role, @Name, @StartTime, @EndTime, @RPH, @Date, @Wage) ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        // create a fuel consumption record
        public SqlCommand FuelCon()
        {
            String query = "INSERT INTO Fuel_Consumption (Number_Plate, L_B_T, L_A_T, PPL) VALUES (@Number_Plate, @L_B_T, @L_A_T, @PPL) ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        // display Number Plate for Fuel Consumption
        public SqlDataReader FillNP()
        {
             String sql = "SELECT Number_Plate from Vehical";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // create a incident recort 
        public SqlCommand IncidentRec()
        {
            String query = "INSERT INTO Trip_Incidents (Location, CauseOf, Driver, VehicleMake, VehicleModel, NumberPlate, OtherParties, Vehicle_ID) VALUES (@Location, @CauseOf, @Driver, @VehicleMake, @VehicleModel, @NumberPlate, @OtherParties, @Vehicle_ID) ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        // Display all vehicles into a datagrid
        public SqlCommand StatVehicleSta()
        {
            String query = "select V.Vehical_Make as 'Vehicle Make', V.Vehical_Model as 'Vehicle Model', V.Vehical_Year as 'Year', V.VIN_Number as 'VIN Number', V.Engine_Size as 'Engine Size', V.Number_Plate as 'Number Plate', V.Capacity as 'Capacity' from Vehical V where V.Status like '%stationary%'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        //Display all vehicles into a datagrid that are on a trip
        public SqlCommand StatVehicleAct()
        {
            String query = "select V.Vehical_Make as 'Vehicle Make', V.Vehical_Model as 'Vehicle Model', V.Vehical_Year as 'Year', V.VIN_Number as 'VIN Number', V.Engine_Size as 'Engine Size', V.Number_Plate as 'Number Plate', V.Capacity as 'Capacity' from Vehical V where V.Status like '%Active%';";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        //Display all vehicles into a datagrid that are in a service
        public SqlCommand StatVehicleSer()
        {
            String query = "select V.Vehical_Make as 'Vehicle Make', V.Vehical_Model as 'Vehicle Model', V.Vehical_Year as 'Year', V.VIN_Number as 'VIN Number', V.Engine_Size as 'Engine Size', V.Number_Plate as 'Number Plate', V.Capacity as 'Capacity' from Vehical V where V.Status like 'In_Service';";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        // display number plate of vehicle on a trip for incident report
        public SqlDataReader Select_NP()
        {
            String sql = "SELECT v.Number_Plate, h.VehicalID, h.TripID from Vehical v, History h, Trip t where h.VehicalID = v.VehicalID and h.TripID = t.TripID and t.Status = 'Active'";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // get vehicle ID
        public SqlDataReader VID(String NP)
        {
            String sql = "SELECT VehicalID from Vehical where  Number_Plate = '"+NP+"'";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // display history info of trip where number plate is equal to
        public SqlDataReader TripInc(String NP)
        {
            String sql = "select l.FirstName, v.Vehical_Make, Vehical_Model from Login l, Vehical v, History h where l.EmpID = h.DriverID and v.VehicalID = h.VehicalID and v.Number_Plate = '" + NP + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // create service
        public SqlCommand createService()
        {
            String query = "INSERT INTO Service (Vehicle_Make, Vehicle_Model, Number_Plate, Total_Milage, Date, Vehicle_ID) VALUES (@Vehicle_Make, @Vehicle_Model, @Number_Plate, @Total_Milage, @Date, @Vehicle_ID) ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        // create service record of vehicle that was in a incedint
        public SqlCommand createIncService()
        {
            String query = "INSERT INTO Service (Vehicle_Make, Vehicle_Model, Number_Plate, Date, Problem, Vehicle_ID) VALUES (@Vehicle_Make, @Vehicle_Model, @Number_Plate, @Date, @Problem, @Vehicle_ID) ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        // Get trip incident info from table that vehicle has just broke
        public SqlDataReader incedentDD()
        {
            String sql = "SELECT * from Trip_Incidents where Status = 'Broken'";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // change status of trip incident
        public void ChangeIncStatus(String Vehicle_ID)
        {
            String sql = "update Trip_Incidents set Status = 'In-Service' where Status = 'Broken' and Vehicle_ID = '" + Vehicle_ID + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // display incident to user that match the chosen number plate
        public SqlDataReader SelectIncident(String NP)
        {
            String sql = "select * from Trip_Incidents where NumberPlate = '" + NP + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        //Display driver info for completion that matches trip city 
        public SqlDataReader DisplayDriverTrip(String name)
        {
            String sql = "select T.TripID, T.R_Name, T.R_StreetAddress, T.R_City, T.R_Postcode, T.R_Province, T.R_Phone, T.R_Description, V.Vehical_Make, H.Start_Date, T.TripID, V.VehicalID from Trip T, History H, Vehical V, Login L where H.TripID = T.TripID and H.DriverID = L.EmpID and T.R_City = '" + name + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // add complete service into new table
        public SqlCommand CompleteService()
        {
            String query = "INSERT INTO Complet_Service (ServiceID, Description, Price) VALUES (@ServiceID, @Description, @Price) ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        // set service to complete
        public void ChangeService(String TripID)
        {
            String sql = "update Service set Status = 'Complete' where Status='Pending' and ServiceID = '" + TripID + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // update vehicle to indicate it is on a trip
        public void ChangeV_Status(String V_ID)
        {
            String sql = "update Vehical set Status = 'Active' where Status='Stationary' and VehicalID = '" + V_ID+"' ";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // Make vehicle active for another trip
        public void ChangeV_AfterTrip(String V_ID)
        {
            String sql = "update Vehical set Status = 'Stationary' where VehicalID = '" + V_ID + "' ";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // change vehicle status for a service
        public void ChangeV_Incident(String V_ID)
        {
            String sql = "update Vehical set Status = 'In_Service' where VehicalID = '" + V_ID + "' ";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // make vehicle ready to be used again
        public void ChangeV_Fixed(String V_ID)
        {
            String sql = "update Vehical set Status = 'Stationary' where VehicalID = '" + V_ID + "' ";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // display vehicle make for service
        public SqlDataReader DisplayStandard()
        {
            String sql = "select DISTINCT Vehical_Make from Vehical";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // Display number plate that matches the vehicle make chosen by user
        public SqlDataReader DisplayStandardNP(String V_Make)
        {
            String sql = "select Number_Plate from Vehical where Vehical_Make = '"+V_Make+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // select vehicle maodel that matchs the make and number plate
        public SqlDataReader StandardServiceInfo(String Make, String NP)
        {
            String sql = "select Vehical_Model from  Vehical where Vehical_Make = '"+Make+"' and Number_Plate = '"+NP+"' ";
             SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;

        }

        // Update the Employees /  customers information
        public SqlCommand updateLogin(string FirstName, string LastName, string DOB, string Address, string Username, string Password, string Role, string UserID)
        { 
            string query = "UPDATE LOGIN SET FirstName = '" + FirstName + "', LastName = '" + LastName + "', DOB = '" + DOB + "', Address = '" + Address + "', Username = '" + Username + "', Password = '" + Password + "', PossitionRole = '" + Role + "' where EmpID = '"+UserID+"' ";
        SqlCommand cmd = new SqlCommand(query, con);
        con.Open();
            return cmd;
        }


        //---------------------------------------------------------------------------------------------------- CRUD--------------------------------------------------------------
        
        public SqlCommand LoadEmployees()
        {
            String query = "Select * from Login";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        public SqlCommand UpdateEmployees(string FirstName, string LastName, string DOB, string Address, string Username, string Password, string Role, string UserID)
        {
            string query = "UPDATE LOGIN SET FirstName = '" + FirstName + "', LastName = '" + LastName + "', DOB = '" + DOB + "', Address = '" + Address + "', Username = '" + Username + "', Password = '" + Password + "', PossitionRole = '" + Role + "' where EmpID = '" + UserID + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        public SqlCommand LoadVehicals()
        {
            String query = "Select * from Vehical";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        public SqlCommand UpdateVehicals(string V_Make, string V_Model, string V_Year, string V_VIN, string V_Size, string NP, string Cap, string V_ID)
        {
            string query = "UPDATE Vehical SET Vehical_Make = '" + V_Make + "', Vehical_Model = '" + V_Model + "', Vehical_Year = '" + V_Year + "', VIN_Number = '" + V_VIN + "', Engine_Size = '" + V_Size + "', Number_Plate = '" + NP + "', Capacity = '" + Cap + "' where VehicalID = '" + V_ID + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        public SqlCommand LoadService()
        {
            String query = "Select * from Service";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        public SqlCommand UpdateService(string make, string model, string NP, string Milage, string Date, string Problem, string ServiceID)
        {
            string query = "UPDATE Service SET Vehicle_Make = '" + make + "', Vehicle_Model = '" + model + "', Number_Plate = '" + NP + "', Total_Milage = '" + Milage + "', Date = '" + Date + "', Problem = '" + Problem + "' where ServiceID = '" + ServiceID + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        public SqlCommand LoadFuelCon()
        {
            String query = "Select * from Fuel_Consumption";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }
        public SqlCommand UpdateFuelCon(string NP, double LBT, double LAT, double Price, string FuelID)
        {
            string query = "UPDATE Fuel_Consumption SET Number_Plate = '" + NP + "' ,L_B_T = '" + LBT + "' ,  L_A_T = '" + LAT + "', PPL = '" + Price + "'  where FuelID = '" + FuelID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        public SqlCommand LoadEmp_Rate()
        {
            String query = "Select * from Emp_Rate";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }
        public SqlCommand UpdateEmp_rate(string role, string name, string starttime, string endtime, double RPH, string Date, string RateID)
        {
            string query = "UPDATE Emp_rate SET Role= '" + role + "', Name = '" + name + "', StartTime = '" + starttime + "', EndTime = '" + endtime + "' , RPH = '" + RPH + "', Date = '" + Date + "' where RateID = '" + RateID + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        public void DeleteEmp_Rate(string name, string RateID)
        {
            string query = "DELETE FROM Emp_Rate WHERE Name = '" + name + "' AND RateID = '" + RateID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        public void DeleteLogin(string FirstName, string UserID)
        {
            string query = "DELETE FROM Login WHERE FirstName = '" + FirstName + "' AND EmpID = '" + UserID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        public void DeleteFuelCon(string Number_Plate, string FuelID)
        {
            string query = "DELETE FROM Fuel_Consumption WHERE Number_Plate = '" + Number_Plate + "' AND FuelID = '" + FuelID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        public void DeleteService(string po, string la)
        {
            string query = "DELETE FROM Service WHERE Vehicle_Make = '" + po + "' AND ServiceID = '" + la + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        public SqlCommand LoadTrip()
        {
            String query = "Select * from Trip";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        public SqlCommand UpdateTrip(string Name1, string Address1, string City1, string PC1, string Prov1, string Phone1, string Name2, string Address2, string City2, string PC2, string Prov2, string Phone2, string Desc2, string TID)
        {
            // 
            string query = "UPDATE Trip SET S_Name ='"+Name1+"', S_StreetAddress= '"+Address1+"', S_City = '"+City1+"', S_Postcode = '"+PC1+"', S_Province = '"+Prov1+"', S_Phone = '"+Phone1+"', R_Name ='"+Name2+"', R_StreetAddress= '"+ Address2 + "', R_City = '"+ City2 + "', R_Postcode = '"+ PC2 + "', R_Province = '"+ Prov2 + "', R_Phone = '"+ Phone2 + "', R_Description = '"+Desc2+"' where TripID = '"+TID+"' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }
        //----------------------------------------------------------------------------------------------END OF CRUD UPDATING--------------------------------------------------------------------------------------------------------------
        
            // display users name after login where userID has a match
        public SqlDataReader DisplayStaffName(String UserID)
        {
            String sql = "SELECT FirstName, LastName from Login where EmpID = '" + UserID + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();
            return myReader;
        }

        // check that username is not taken for new login account
        public DataTable LoginUsername(String username)
        {
            String sql = "select Username from Login where Username = '" + username + "';";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sql, con);
            DataTable UserAnswer = new DataTable("Username");
            sqlDA.Fill(UserAnswer);

            return UserAnswer;
        }

        // this will be able to re assign a trip if a driver cannot complete
        public void ChangeIncTrip(String TripID)
        {
            String sql = "update Trip set Status = 'Stationary' where Status='Active' and TripID = '" + TripID + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // create employee report into a datagridview
        public DataTable EmployeeReport()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select Role, Name, RPH, StartTime, EndTime, Date, Wage from Emp_Rate", con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            return dt;

        }

        // display all vehicles for vehicle report
        public DataTable ViewAllVehicles()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Vehical", con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            return dt;

        }

        public DataTable ViewServiceAppointment()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Service where status = 'Pending'", con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            return dt;

        }

        // create complete service for vehicle report
        public DataTable ViewCompleteService()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select s.Vehicle_Make, s.Vehicle_Model, s.Number_Plate, cs.Description, cs.Price from Service s, Complet_Service cs where cs.ServiceID = s.ServiceID and Status = 'Complete'", con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            return dt;

        }

        // delete history relation when driver cannot complete a trip
        public void cancelTrip(string DriverID, string TripID)
        {
            string query = "DELETE FROM History WHERE DriverID = '" + DriverID + "' AND TripID = '" + TripID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // create service pending for vehicle report
        public SqlCommand ServiceBooking()
        {
            String query = "select Vehicle_Make as 'Vehicle Make', Vehicle_Model as 'Vehicle Model', Number_Plate as 'Number Plate', Total_Milage as 'Total Milage', Date as 'Date Of', Problem as 'Problem Description' from Service where status = 'Pending'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        public DataTable CheckVINNum(String VINNum)
        {
            String sql = "select VIN_Number from Vehical where VIN_Number = '" + VINNum + "';";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sql, con);
            DataTable UserAnswer = new DataTable("Username");
            sqlDA.Fill(UserAnswer);

            return UserAnswer;
        }
        

    }
}
