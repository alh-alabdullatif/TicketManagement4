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
    public class EmployeeController : Controller
    {
        // GET: Employee
        int Int_id;
        string id;
        public ActionResult Index()
        {
            List<EmployeeModel> employee = new List<EmployeeModel>();
            UserModel user = new UserModel();
            EmployeeModel employeeModel = new EmployeeModel();
            EmployeeDAO employeeDAO = new EmployeeDAO();

             id = (string)RouteData.Values["id"];

             Int_id =int.Parse(id);
            employeeModel.EmployeeId = Int_id;
            Session["id"] = Int_id;
            //EmployeeModel employeeModel = new EmployeeModel();
            // employeeModel.EmployeeId = Int_id;
            Debug.WriteLine("Value of int in index " + Int_id);

            employee = employeeDAO.FetchAll(Int_id);
           

            return View("Index", employee);
        }
        /*
        public ActionResult Details(int id)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
           EmployeeModel employee = employeeDAO.FetchOne(id);

            return View("Details", employee);
        }*/

        public ActionResult Create()
        {
            Debug.WriteLine("Value of int in create" + Int_id);

            // return View("TicketForm");
            //id = (string)RouteData.Values["id"];

           // Int_id = int.Parse(id);
            return View("TicketForm");

        }
        public ActionResult ProccessCreate(EmployeeModel employeeModel)
        {

            EmployeeDAO employeeDAO = new EmployeeDAO();
            //  string id = (string)RouteData.Values["id"];
            // int Int_id = int.Parse(id);
            Debug.WriteLine("Value of int in proccess create"+Int_id);
            var id= Session["id"];
            Debug.WriteLine("Value of id in session" + id);
           

            int newId = employeeDAO.Create(employeeModel, (int)id);

            return RedirectToAction("Index", "Employee", new { id });
            
        }
    }
}