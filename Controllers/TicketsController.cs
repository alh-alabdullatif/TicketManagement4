using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManagement4.Data;
using TicketManagement4.Models;

namespace TicketManagement4.Controllers
{
    public class TicketsController : Controller
    {
        // GET: Tickets
        public ActionResult Index()
        {
            List<TicketModel> tickets = new List<TicketModel>();

            TicketDAO ticketDAO = new TicketDAO();
            tickets = ticketDAO.FetchAll();

            return View("Index",tickets);
        }
    }
}