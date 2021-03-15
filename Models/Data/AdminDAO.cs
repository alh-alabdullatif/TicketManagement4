using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TicketManagement4.Models.Data
{
    public class AdminDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TicketManagmentSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public List<AdminModel> FetchAll()
        {
            List<AdminModel> returnList = new List<AdminModel>();
            string queryString = "SELECT * FROM Ticket, Employee where Ticket.EmployeeId = Employee.Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            AdminModel admin = new AdminModel();

                            admin.TicketId= reader.GetInt32(0);
                            admin.TicketTitle = reader.GetString(1);
                            admin.TicketDescription = reader.GetString(2);
                            admin.TicketStatus = reader.GetString(3);
                            admin.EmployeeName = reader.GetString(7);
                            //admin.EmployeeId = reader.GetInt32(4);
                            //admin.AdminId = reader.GetInt32(5);

                            returnList.Add(admin);

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

        public AdminModel FetchOne(int Id)
        {
            string queryString = "SELECT TicketTitle, TicketDescription, TicketStatus, EmployeeName, Ticket.Id FROM Ticket, Employee where Ticket.EmployeeId = Employee.Id AND Ticket.Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = Id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                AdminModel admin = new AdminModel();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        //employee.Id = reader.GetInt32(0);
                        admin.TicketTitle = reader.GetString(0);
                        admin.TicketDescription = reader.GetString(1);
                        admin.TicketStatus = reader.GetString(2);
                        admin.TicketId = reader.GetInt32(4);
                        admin.EmployeeName = reader.GetString(3);



                    }

                }

                return admin;
            }
        }
        public int Update(AdminModel adminModel)
        {
            string queryString = "UPDATE Ticket SET TicketStatus = @status WHERE Ticket.Id = @Id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                //int newID;
                
                
                    AdminModel admin = new AdminModel();
           

                    //  command.Parameters.Add("@status", System.Data.SqlDbType.VarChar, 500).Value = admin.TicketStatus;
                command.Parameters.Add("@status", System.Data.SqlDbType.VarChar, 500).Value = admin.TicketStatus;
                    
                    command.Parameters.Add("@Id", System.Data.SqlDbType.Int, 500).Value = admin.TicketId;
                    Debug.WriteLine("Value of title from DAO " + admin.TicketStatus);
                  
                    Debug.WriteLine("Value of ticket  from DAO ");



                    connection.Open();

                  int newID = command.ExecuteNonQuery();
                    Debug.WriteLine("Value of return from update"+ newID);


                return newID;

                
                
            }

        }

        }
}