using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketManagement4.Models
{
    public class AdminModel
    {
        /*      SELECT TicketTitle, TicketDescription, TicketStatus, Employee.EmployeeName
      FROM Ticket , Employee
      where Ticket.EmployeeId = Employee.Id
      */
        public int TicketId { get; set; }
        public string TicketTitle { get; set; }
        public string TicketDescription { get; set; }

        public string TicketStatus { get; set; }
        public string EmployeeName { get; set; }

        public AdminModel()
        {
            TicketTitle = "";
            TicketDescription = "";
            TicketStatus = "";
            EmployeeName = "";
            TicketId = -1;
        }

        public AdminModel(int ticketId,string ticketTitle, string ticketDescription, string ticketStatus, string employeeName)
        {
            TicketId = ticketId;
            TicketTitle = ticketTitle;
            TicketDescription = ticketDescription;
            TicketStatus = ticketStatus;
            EmployeeName = employeeName;

        }
    }
}