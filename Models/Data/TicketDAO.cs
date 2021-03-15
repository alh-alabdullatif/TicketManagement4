using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TicketManagement4.Models;

namespace TicketManagement4.Data
{
    internal class TicketDAO
    {

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TicketManagmentSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public List<TicketModel> FetchAll()
        {
            List<TicketModel> returnList = new List<TicketModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM Ticket";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            TicketModel tickets = new TicketModel();

                            tickets.Id = reader.GetInt32(0);
                            tickets.TicketTitle = reader.GetString(1);
                            tickets.TicketDescription = reader.GetString(2);
                            tickets.TicketStatus = reader.GetString(3);
                            tickets.EmployeeId = reader.GetInt32(4);
                            tickets.AdminId = reader.GetInt32(5);

                            returnList.Add(tickets);

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

      
        



    }
}