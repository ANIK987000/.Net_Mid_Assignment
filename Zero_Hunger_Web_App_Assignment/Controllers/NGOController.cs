using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Zero_Hunger_Web_App_Assignment.DB;
using Zero_Hunger_Web_App_Assignment.Models;
using Zero_Hunger_Web_App_Assignment.Repo;

namespace Zero_Hunger_Web_App_Assignment.Controllers
{
    public class NGOController : Controller
    {
        // GET: NGO
        public ActionResult Index()
        {
            return View();
        }






        //________________________________________________________Restaurant Related Operation____________________________________

        //______________________________Restaurant List_______________________

        public ActionResult RestaurantList()
        {
            return View(RestaurantRepo.Get()); // Get() is the  function of RestaurantRepo for getting all restaurants made by me
        }


        //______________________________Add Restaurant________________________

        [HttpGet]
        public ActionResult AddRestaurant()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRestaurant(RestaurantModel restaurant)
        {
            if(ModelState.IsValid)
            {
                RestaurantRepo.AddRestaurant(restaurant);  // AddRestaurant is create function of RestaurantRepo made by me
                TempData["added"] = "A new restaurant is added";
                return RedirectToAction("RestaurantList");
            }
            return View(restaurant);
        }

        //_____________________________Delete Restaurant________________________

        public ActionResult DeleteRestaurant(int id)
        {
            RestaurantRepo.DeleteRestaurant(id);
            return RedirectToAction("RestaurantList");
        }

        //_____________________________Update Restaurant________________________

        [HttpGet]
        public ActionResult UpdateRestaurant(int id)
        {
            //RestaurantRepo.UpdateRestaurant(id);

            return View(RestaurantRepo.RestaurantDetails(id));
        }


        [HttpPost]
        public ActionResult UpdateRestaurant(int id,RestaurantModel restaurant)
        {
            RestaurantRepo.UpdateRestaurant(id, restaurant);
            TempData["updated"] = "Information is updated";
            return RedirectToAction("RestaurantList");
        }


        //______________________________Restaurant Details_____________________


        public ActionResult RestaurantDetails(int id)
        {
            
            return View(RestaurantRepo.RestaurantDetails(id));
        }










        //________________________________________________________________Employee Related Operation____________________________________________


        //_________________________Employee List_______________________

        public ActionResult EmployeeList()
        {
            return View(EmployeeRepo.Get());
        }

        //_________________________Add Employee________________________

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepo.AddEmployee(employee);  // AddRestaurant is create function of RestaurantRepo made by me
                TempData["added"] = "A new employee is added";
                return RedirectToAction("EmployeeList");
            }
            return View(employee);
        }




        //_____________________________Delete Employee________________________

        public ActionResult DeleteEmployee(int id)
        {
            EmployeeRepo.DeleteEmployee(id);
            return RedirectToAction("EmployeeList");
        }

        //_____________________________Update Employee________________________

        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            //RestaurantRepo.UpdateRestaurant(id);

            return View(EmployeeRepo.EmployeeDetails(id));
        }


        [HttpPost]
        public ActionResult UpdateEmployee(int id, EmployeeModel employee )
        {
            EmployeeRepo.UpdateEmployee(id, employee);
            TempData["updated"] = "Information is updated";
            return RedirectToAction("EmployeeList");
        }


        //________________________________Employee Details_____________________


        public ActionResult EmployeeDetails(int id)
        {

            return View(EmployeeRepo.EmployeeDetails(id));
        }












        //________________________________________________________________Collect Request Related Operation____________________________________________

        //_________________________Collect Request List_______________________

        public ActionResult CollectRequestList()
        {
            //var db = new Zero_Hunger_DBEntities();

            //var collectRequest = (from cr in db.CollectRequests
            //                      where cr.Status=="requested"
            //                      select cr).ToList();
            //return View(collectRequest);


        

            return View(CollectRequestRepo.Get());
        }

        //_________________________Accept Collect Request List_______________________
        

        public ActionResult AcceptCollectRequest(int id)
        {
            

            CollectRequestRepo.UpdateCollectRequest(id);
            TempData["accepted"] = "Collect Request is accepted";
            return RedirectToAction("CollectRequestList");
        }


        
        //_________________________Delete Collect Request_______________________


        public ActionResult DeleteCollectRequest(int id)
        {
            CollectRequestRepo.DeleteCollectRequest(id);
            return RedirectToAction("CollectRequestList");
        }


        //_________________________Delete Assigned Collect Request_______________________


        public ActionResult DeleteAssignedCollectRequest(int id)
        {
            AssignEmployeeRepo.DeleteAssignedCollectRequest(id);
            TempData["deleted"]= "Deleted successfully";
            return RedirectToAction("AssignedCollectRequests","Employee");
        }


        //_________________________Collect Request Details_______________________


        public ActionResult CollectRequestDetails(int id)
        {
            var db = new Zero_Hunger_DBEntities();
            var rid = CollectRequestRepo.CollectRequestDetails(id).RID;
            var d = (from res in db.Restaurants
                     where res.ID == rid
                     select res).SingleOrDefault();
            ViewBag.restaurant = d.Name;

            ViewBag.employList = EmployeeRepo.Get();
            return View(CollectRequestRepo.CollectRequestDetails(id));
        }


        //_________________________________________________________________________Assign Employee Related Operation_____________________________________



        //__________________________Assign Employee________________________
       

        [HttpGet]
        public ActionResult AssignEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AssignEmployee(AssignEmployeeModel assignEmployee)
        {
            //if (ModelState.IsValid)
            //{
            //    AssignEmployeeRepo.AssignEmployee(assignEmployee);  // AddRestaurant is create function of RestaurantRepo made by me
            //    TempData["assign"] = "Employee Is Assigned for Collect Request ID "+assignEmployee.CRID;
            //    return RedirectToAction("CollectRequestList");
            //}
            //return View(assignEmployee);
            var db = new Zero_Hunger_DBEntities();
            if (ModelState.IsValid)
            {
                //var ext = (from e in db.AssignEmployees
                //           where e.EID==assignEmployee.EID && e.CRID==assignEmployee.CRID
                //           select e).SingleOrDefault();
                AssignEmployeeRepo.AssignEmployee(assignEmployee);  // AddRestaurant is create function of RestaurantRepo made by me
                TempData["assign"] = "Employee Is Assigned for Collect Request ID " + assignEmployee.CRID;
                return RedirectToAction("CollectRequestList");
            }
            return View(assignEmployee);


        }

    }
}