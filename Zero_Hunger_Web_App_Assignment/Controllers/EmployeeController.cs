using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Zero_Hunger_Web_App_Assignment.DB;
using Zero_Hunger_Web_App_Assignment.Repo;

namespace Zero_Hunger_Web_App_Assignment.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        //______________________________________Assigned Collect Requests_________________________________________________

        public ActionResult AssignedCollectRequests()
        {
            return View(AssignEmployeeRepo.AssignedCollectRequests());
        }

        //______________________________________Collect Requests By Employee ID_________________________________________________
        public ActionResult CollectRequestsByEmployeeID()
        {
            var db = new Zero_Hunger_DBEntities();

            var str = Session["employeeID"].ToString();
            var id = new JavaScriptSerializer().Deserialize<int>(str);

            var crbe = (from crb in db.AssignEmployees
                       where crb.EID==id && (crb.Status=="requested" || crb.Status=="accepted")
                       select crb).ToList();

            return View(crbe);
        }


        //______________________________________When clicked collected and becomes deleted from AssignEmployee Table_________________________________________________

        //public ActionResult Collected(int id)
        //{
        //    CollectRequestRepo.UpdateCollectRequestByEmployee(id);
        //    TempData["completed"]= "Collect Request is completed";

        //    var db = new Zero_Hunger_DBEntities();
        //    var crbe = (from crb in db.AssignEmployees
        //                where crb.CRID == id && crb.EID==3
        //                select crb).SingleOrDefault();

        //    AssignEmployeeRepo.DeleteAssignedCollectRequest(crbe.ID);
        //    return RedirectToAction("CollectRequestsByEmployeeID");
        //}


        //______________________________________When clicked collected and becomes status completed_________________________________________________
        public ActionResult Collected(int id)
        {

            CollectRequestRepo.UpdateCollectRequestByEmployee(id);
            TempData["completed"] = "Collect Request is completed";

            //var db = new Zero_Hunger_DBEntities();
            //var crbe = (from crb in db.AssignEmployees
            //            where crb.CRID == id && crb.EID == 3
            //            select crb).SingleOrDefault();

            //AssignEmployeeRepo.DeleteAssignedCollectRequest(crbe.ID);

            var str = Session["employeeID"].ToString();
            var eid = new JavaScriptSerializer().Deserialize<int>(str);

            CollectRequestRepo.UpdateAssignEmployeeStatusByEmployee(id,eid);
            return RedirectToAction("CollectRequestsByEmployeeID");
        }
    }
}