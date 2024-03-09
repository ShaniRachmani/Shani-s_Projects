using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using tar2.BL;
using tar1;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{

    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json").Build();
        string cStr = configuration.GetConnectionString("myProjDB");
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }


    //--------------------------------------------------------------------------------------------------
    // This method Inserts a user to the users table 
    //--------------------------------------------------------------------------------------------------
    public int Insert(User user)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateUserInsertCommandWithStoredProcedure("sp_InsertUsersTable", con,user);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    public int deleteUser(string email)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = DeleteUserInsertCommandWithStoredProcedure("sp_DeleteUsers", con, email);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }




    //--------------------------------------------------------------------------------------------------
    // This method reads students from the database 
    //--------------------------------------------------------------------------------------------------
    public List<User> ReadUser()
    {

        SqlConnection con;
        SqlCommand cmd;
        List<User> usersList = new List<User>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithSPWithoutParameters("sp_ReadUsers", con);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                User u = new User();
                u.Email = dataReader["Email"].ToString();
                u.FirstName = dataReader["FirstName"].ToString();
                u.FamilyName = dataReader["FamilyName"].ToString();
                u.Password = dataReader["Password"].ToString();
                u.IsActive = Convert.ToBoolean(dataReader["isActive"]);
                u.IsAdmin = Convert.ToBoolean(dataReader["isAdmin"]);
                usersList.Add(u);
            }
            return usersList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
        
    }

    //--------------------------------------------------------------------------------------------------
    // This method Updates a user to the user table 
    //--------------------------------------------------------------------------------------------------
    public int InsertUpdatedUser(User user, String email)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = UpdateUserInsertCommandWithStoredProcedure("SPUpdateUser", con, user, email);        // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //---------------------------------------------------------------------------------
    // Get User SqlCommand using a stored procedure
    //---------------------------------------------------------------------------------

    public User GetUserByDetails(User user)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithSPWithParameters("spGetUserByDetails", con, user);  // create the command


        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            User u = new User();
            while (dataReader.Read())
            {
                u.Email = dataReader["Email"].ToString();
                u.FirstName = dataReader["FirstName"].ToString();
                u.FamilyName = dataReader["FamilyName"].ToString();
                u.Password = dataReader["Password"].ToString();
               u.IsActive = Convert.ToBoolean(dataReader["isActive"]);

            }
            return u;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }



    //--------------------------------------------------------------------------------------------------
    // This method Inserts a flat to the flat table 
    //--------------------------------------------------------------------------------------------------
    public int InsertFlat(Flat flat)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateFlatInsertCommandWithStoredProcedure("sp_InsertFlatsTable", con, flat);        // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------------------------------------
    // This method reads flats from the database 
    //--------------------------------------------------------------------------------------------------
    public List<Flat> GetFlat()
    {

        SqlConnection con;
        SqlCommand cmd;
        List<Flat> flatsList = new List<Flat>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithSPWithoutParameters("sp_ReadFlat", con);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Flat f = new Flat();
                f.Id1 = Convert.ToInt32(dataReader["Id"]);
                f.City1 = dataReader["City"].ToString();
                f.Address1 = dataReader["Address"].ToString();
                f.NumberOfRoom1 = Convert.ToInt32(dataReader["NumberOfRoom"]);
                f.Price1 = Convert.ToDouble(dataReader["Price"]);


                flatsList.Add(f);
            }
            return flatsList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------------------------------------
    // This method Inserts a vacation to the vacation table 
    //--------------------------------------------------------------------------------------------------
    public int InsertVacation(Vacation vacation)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateVacationInsertCommandWithStoredProcedure("sp_InsertVacationsTable", con, vacation);        // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------------------------------------
    // This method reads vacations from the database 
    //--------------------------------------------------------------------------------------------------
    public List<Vacation> GetVacation()
    {

        SqlConnection con;
        SqlCommand cmd;
        List<Vacation> vacationsList = new List<Vacation>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithSPWithoutParameters("sp_ReadVacation", con);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Vacation v = new Vacation();
                v.Id = Convert.ToInt32(dataReader["id"]);
                v.UserId = (dataReader["user_email"]).ToString();
                v.FlatId = Convert.ToInt32(dataReader["flat_id"]);
                v.StartDate = DateTime.Parse(dataReader["start_date"].ToString());
                v.EndDate = DateTime.Parse(dataReader["end_date"].ToString());
                vacationsList.Add(v);
            }
            return vacationsList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }



    //--------------------------------------------------------------------------------------------------
    // This method reads vacations of specific user from the database (read with parameters)
    //--------------------------------------------------------------------------------------------------
    public List<Vacation> GetVacationByEmail(string email)
    {

        SqlConnection con;
        SqlCommand cmd;
        List<Vacation> vacationsList = new List<Vacation>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithSPWithParametersVaca("spGetVacaByEmail", con, email);  // create the command


        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Vacation v = new Vacation();
                v.Id = Convert.ToInt32(dataReader["id"]);
                v.UserId = (dataReader["user_email"]).ToString();
                v.FlatId = Convert.ToInt32(dataReader["flat_id"]);
                v.StartDate = DateTime.Parse(dataReader["start_date"].ToString());
                v.EndDate = DateTime.Parse(dataReader["end_date"].ToString());
                vacationsList.Add(v);
            }
            return vacationsList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }


    }
    //--------------------------------------------------------------------------------------------------
    // This method read avg price per night for spesicif city and month 
    //--------------------------------------------------------------------------------------------------
    public List<Object> ReadAvgPricePerNight(int month)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        List<Object> AvgPricePerNightList = new List<Object>();

        cmd = BuildReadAvgPricePerNightStoredProcedureCommand(con, "spGetAveragePrice", month);

        SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        while (dataReader.Read())//run untill the table end
        {
            AvgPricePerNightList.Add(new
            {
                city = dataReader["city"].ToString(),
                AveragePricePerNight = Convert.ToDouble(dataReader["AveragePricePerNight"])
            });

        }

        if (con != null)
        {
            // close the db connection
            con.Close();
        }

        return AvgPricePerNightList;

    }




    //---------------------------------------------------------------------------------
    // Create the SqlCommand using a stored procedure 5
    //---------------------------------------------------------------------------------


    private SqlCommand CreateCommandWithSPWithoutParameters(String spName, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        return cmd;
    }
    //6
    private SqlCommand CreateCommandWithSPWithParameters(String spName, SqlConnection con, User user)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@email", user.Email);

        cmd.Parameters.AddWithValue("@password", user.Password);


        return cmd;
    }
    //---------------------------------------------------------------------------------
    // Create Vacation SqlCommand using a stored procedure
    //---------------------------------------------------------------------------------
    private SqlCommand CreateVacationInsertCommandWithStoredProcedure(String spName, SqlConnection con, Vacation vacation)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@start_date", vacation.StartDate);

        cmd.Parameters.AddWithValue("@end_date", vacation.EndDate);

        cmd.Parameters.AddWithValue("@flat_id", vacation.FlatId);

        cmd.Parameters.AddWithValue("@user_email", vacation.UserId);


        return cmd;
    }


    //---------------------------------------------------------------------------------
    // Create Flat SqlCommand using a stored procedure 1
    //---------------------------------------------------------------------------------

    private SqlCommand CreateFlatInsertCommandWithStoredProcedure(String spName, SqlConnection con, Flat flat)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@City", flat.City1);

        cmd.Parameters.AddWithValue("@Address", flat.Address1);

        cmd.Parameters.AddWithValue("@NumberOfRoom", flat.NumberOfRoom1);

        cmd.Parameters.AddWithValue("@Price", flat.Price1);



        return cmd;
    }
    
    //---------------------------------------------------------------------------------
    // Create the SqlCommand update users 4
    //---------------------------------------------------------------------------------
    
    private SqlCommand UpdateUserInsertCommandWithStoredProcedure(String spName, SqlConnection con, User user, String email)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@email", email);

        cmd.Parameters.AddWithValue("@firstName", user.FirstName);

        cmd.Parameters.AddWithValue("@familyName", user.FamilyName);

        cmd.Parameters.AddWithValue("@password", user.Password);

        cmd.Parameters.AddWithValue("@isActive", user.IsActive);

        return cmd;
    }


    //---------------------------------------------------------------------------------
    // Create the SqlCommand Delete users 3
    //---------------------------------------------------------------------------------
    private SqlCommand DeleteUserInsertCommandWithStoredProcedure(String spName, SqlConnection con, string email)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@email", email);


        return cmd;
    }

    //---------------------------------------------------------------------------------
    // Create the SqlCommand using a stored procedure 2
    //---------------------------------------------------------------------------------
    private SqlCommand CreateUserInsertCommandWithStoredProcedure(String spName, SqlConnection con, User user)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@email", user.Email);

        cmd.Parameters.AddWithValue("@firstName", user.FirstName);

        cmd.Parameters.AddWithValue("@familyName", user.FamilyName);

        cmd.Parameters.AddWithValue("@password", user.Password);


        return cmd;
    }
    //comand to spesific user vacations
    private SqlCommand CreateCommandWithSPWithParametersVaca(String spName, SqlConnection con, string email)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@user_email", email);

        return cmd;
    }


    //---------------------------------------------------------------------------------
    // build the  users read SqlCommand using a stored procedure
    //---------------------------------------------------------------------------------


    SqlCommand BuildReadAvgPricePerNightStoredProcedureCommand(SqlConnection con, string spName, int month)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@month", month);

        return cmd;

    }


}
