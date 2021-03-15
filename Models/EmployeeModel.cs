using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketManagement4.Models
{
    public class EmployeeModel
    {
        /*SELECT TicketTitle, TicketDescription, TicketStatus
FROM Ticket, Employee
where Ticket.EmployeeId = Employee.Id AND  Employee.Id = 2*/

       
        public string TicketTitle { get; set; }
        public string TicketDescription { get; set; }
        public string TicketStatus { get; set; }
        //public string EmployeeName { get; set; }
       // public string EmployeeUsername { get; set; }
        //public string Password { get; set; }
        public int EmployeeId { get; set; }

        public EmployeeModel()
        {
         
            TicketTitle = "";
            TicketDescription = "";
            TicketStatus = "";
            EmployeeId = -1;
           // EmployeeName = "";
           // EmployeeUsername = "";
           // Password = "";

        }

     

        public EmployeeModel(string ticketTitle, string ticketDescription, string ticketStatus, int employeeId)
        {
            TicketTitle = ticketTitle;
            TicketDescription = ticketDescription;
            TicketStatus = ticketStatus;
            //EmployeeName = employeeName;
            //EmployeeUsername = employeeUsername;
            //Password = password;
            EmployeeId = employeeId;
        }
    }
}