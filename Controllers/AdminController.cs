using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManagement4.Models;
using TicketManagement4.Models.Data;

namespace TicketManagement4.Controllers
{
    public class AdminController : Controller
    {
        string id;
        int Int_id;
        // GET: Admin
        public ActionResult Index()
        {
            List<AdminModel> admin = new List<AdminModel>();

            AdminDAO adminDAO = new AdminDAO();
            admin = adminDAO.FetchAll();
            AdminModel adminModel = new AdminModel();
            return View("Index", admin);
            //return RedirectToAction("Index", new { adminModel.TicketId });

        }
        public ActionResult Detalis(int id) {


            AdminDAO adminDAO = new AdminDAO();
            

            AdminModel admin = adminDAO.FetchOne(id);
            return View("Details",admin);
        }




        //[HttpPost]
        public ActionResult Update(int id, string status)
        {
            status = "approve";

            AdminDAO adminDAO = new AdminDAO();

            AdminModel admin = adminDAO.FetchOne(id);
            Debug.WriteLine("Value of int in index " + id);

            Debug.WriteLine("Value of status 1" + admin.TicketStatus);

            return View("UpdateForm", admin);
            Debug.WriteLine("Value of status 2" + admin.TicketStatus);

        }
        [HttpPost]

        public ActionResult ProccessUpdate(AdminModel adminModel)
        {
            //status = "approve";
            AdminDAO adminDAO = new AdminDAO();
            //  string id = (string)RouteData.Values["id"];
            // int Int_id = int.Parse(id);

            id = (string)RouteData.Values["id"];

            Int_id = int.Parse(id);
            employeeModel.EmployeeId = Int_id;
            Session["id"] = Int_id;
            Debug.WriteLine("Value of id in session" + id);

            //int newId = adminDAO.Update(adminModel, (int)id);

            int newId = adminDAO.Update(adminModel);

     //       return RedirectToAction("Index", "Employee", new { id });
           // int newId = adminDAO.Update(adminModel,status);


            return RedirectToAction("Index", "Admin");

        }
        public ActionResult FetchId()
        {
            string id_string = (string)RouteData.Values["TicketId"];
            int id = Int32.Parse(id_string);
            Debug.WriteLine("Value of int in index " + id);

            return View("Updated");
        
        }
        public ActionResult Reject()
        {
            string id_string = (string)RouteData.Values["TicketId"];
           // int id = Int32.Parse(id_string);
            //Debug.WriteLine("Value of int in index " + id);

            return View("Updated");

        }

     

      

    }
}