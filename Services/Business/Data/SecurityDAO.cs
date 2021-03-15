using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TicketManagement4.Models;


namespace TicketManagement4.Services.Business.Data
{
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TicketManagmentSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        bool isAdmin = false;

        internal bool FindByUser(UserModel user)
        {
            //assuming nothing is found 
            bool success = false;
            string queryString = "SELECT * FROM dbo.Admin where AdminUsername = @Username AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;

                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                try{
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        //userID = reader.GetInt32(0);
                        user.Id = reader.GetInt32(0);

                        success = true;
                        isAdmin = true;

                    }
                    else
                    {
                        connection.Close();
                        connection.Open();
                        string queryString2 = "SELECT * FROM dbo.Employee where EmployeeUsername = @Username AND Password = @Password"; 
                        command = new SqlCommand(queryString2, connection);

                        command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;

                        command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;
                        reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {

                            reader.Read();
                           // userID = reader.GetInt32(0);
                            user.Id= reader.GetInt32(0);
                            success = true;
                            isAdmin = false;
                            reader.Close();
                        }
                        else
                        {
                            success = false;
                            isAdmin = false;
                            connection.Close();
                           

                        }
                    }
                    //reader.Close();


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
            return success;
            
        }
        internal bool isAdminFunction() { return isAdmin; }


    }
}