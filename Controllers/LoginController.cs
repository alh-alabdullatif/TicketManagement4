using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManagement4.Models;
using TicketManagement4.Models.Data;
using TicketManagement4.Services.Business;

namespace TicketManagement4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }
        
        public ActionResult Login(UserModel userModel) {
            //return "Results: Username:"+ userModel.Username + "pass is "+ userModel.Password;
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(userModel);
            Boolean isAdmin = securityService.isAdmin();
            Session["id"] = userModel.Id;
            var session_id = (int)Session["id"];


            if (success && isAdmin)
            {
                //return View("LoginSuccess", userModel);

                return RedirectToAction("Index", "Admin",new { userModel.Id });
             

            }
            else
            {
                if (success)
                {
                    //go to employee page
                    return RedirectToAction("Index", "Employee", new { userModel.Id });


                }
                else
                {
                    return View("LoginFailure");
                }
            }

        }


    }
}