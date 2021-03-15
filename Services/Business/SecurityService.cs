using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketManagement4.Models;
using TicketManagement4.Services.Business.Data;

namespace TicketManagement4.Services.Business
{
    public class SecurityService
    {
        SecurityDAO daoService = new SecurityDAO();

        public bool isAdmin()
        {
            return daoService.isAdminFunction();
        }
        public bool Authenticate(UserModel user) {

            return daoService.FindByUser(user);
        }
       
    }
   
}