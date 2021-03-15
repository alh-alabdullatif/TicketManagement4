using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TicketManagement4.Models.Data
{
    public class EmployeeDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TicketManagmentSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public List<EmployeeModel> FetchAll(int Id)
        {
            List<EmployeeModel> returnList = new List<EmployeeModel>();
          
            string queryString = "SELECT TicketTitle, TicketDescription, TicketStatus FROM Ticket, Employee where Ticket.EmployeeId = Employee.Id AND Employee.Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = Id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            EmployeeModel employee = new EmployeeModel();

                            //employee.Id = reader.GetInt32(0);
                            employee.TicketTitle = reader.GetString(0);
                            employee.TicketDescription = reader.GetString(1);
                            employee.TicketStatus = reader.GetString(2);
                           // employee.EmployeeId = userID;
                           // employee.AdminId = reader.GetInt32(5);

                            returnList.Add(employee);

                        }

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
                return returnList;
            }
        }
      
        public int Create(EmployeeModel employeeModel, int Id)
        {
            string queryString = "INSERT INTO dbo.Ticket (TicketTitle, TicketDescription, TicketStatus,EmployeeId) Values (@TicketTitle, @TicketDescription,'pending' ,@EmployeeId)";
            //"INSERT INTO dbo.Ticket(TicketTitle, TicketDescription, EmployeeId) VALUES('test', 'testing', 1)"
            UserModel user = new UserModel();
            int userID = user.Id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@TicketTitle", System.Data.SqlDbType.VarChar,500).Value = employeeModel.TicketTitle;
                command.Parameters.Add("@TicketDescription", System.Data.SqlDbType.VarChar, 500).Value = employeeModel.TicketDescription;
                command.Parameters.Add("@EmployeeId", System.Data.SqlDbType.Int, 500).Value = Id;
                Debug.WriteLine("Value of title from DAO " + employeeModel.EmployeeId);
                Debug.WriteLine("Value of dec from DAO " + employeeModel.EmployeeId);
                Debug.WriteLine("Value of employeeid from DAO " + employeeModel.EmployeeId);



                connection.Open();

                int newID = command.ExecuteNonQuery();

               
                return newID;
            }
        }


    }
}