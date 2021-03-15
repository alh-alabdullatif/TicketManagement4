using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketManagement4.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string TicketTitle { get; set; }
        public string TicketDescription { get; set; }
        public string TicketStatus { get; set; }
        public int EmployeeId { get; set; }
        public int AdminId { get; set; }

        public TicketModel()
        {
            Id = -1;
            TicketTitle = "";
            TicketDescription = "";
            TicketStatus = "";
            EmployeeId = -1;
            AdminId = -1;

        }

        public TicketModel(int id, string ticketTitle, string ticketDescription, string ticketStatus, int employeeId, int adminId)
        {
            Id = id;
            TicketTitle = ticketTitle;
            TicketDescription = ticketDescription;
            TicketStatus = ticketStatus;
            EmployeeId = employeeId;
            AdminId = adminId;
        }
    }
}