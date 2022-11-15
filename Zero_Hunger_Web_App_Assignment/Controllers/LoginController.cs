using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger_Web_App_Assignment.DB;

namespace Zero_Hunger_Web_App_Assignment.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        //_________________________________Login System For All User_______________________________________

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(NGO nGO,Restaurant restaurant,Employee employee)
        {
            var db = new Zero_Hunger_DBEntities();


            var n = (from ngo in db.NGOs
                     where ngo.Email==nGO.Email
                     select ngo).SingleOrDefault();

            //var r = new Restaurant();
            var r = (from res in db.Restaurants
                              where res.Email == restaurant.Email
                              select res).SingleOrDefault();

            //var e = new Employee();
            var e = (from emp in db.Employees
                            where emp.Email== employee.Email
                            select emp).SingleOrDefault();





             if (n != null)
            {
                if (n.Password == nGO.Password)
                {
                    Session["ngoID"]= n.ID;
                    Session["ngoName"] = n.Name;
                    return RedirectToAction("CollectRequestList", "NGO");
                }
                else
                {
                    TempData["password"] = "Password is incorrect";
                    return RedirectToAction("login");
                }
            }
            else if(r!=null)
            {
                if(r.Password== restaurant.Password)
                {
                    
                    Session["restaurantID"] = r.ID;
                    Session["restaurantName"] = r.Name;
                    return RedirectToAction("CreateCollectRequest","Restaurant");
                }
                else
                {
                    TempData["password"]= "Password is incorrect";
                    return RedirectToAction("login");
                }
            }
            else if(e!=null)
            {
                if(e.Password== employee.Password)
                {
                    Session["employeeID"] = e.ID;
                    Session["employeeName"] = e.Name;
                    return RedirectToAction("CollectRequestsByEmployeeID","Employee");
                }
                else
                {
                    TempData["password"] = "Password is incorrect";
                    return RedirectToAction("login");
                }
            }
            else
            {
                TempData["email"] = "Email is not registered";
                return RedirectToAction("login");
            }
           
        }



        //____________________________Restaurant Login___________________________________

        [HttpGet]
        public ActionResult RestaurantLogin( )
        {
            return View();
        }

        [HttpPost]
        public ActionResult RestaurantLogin(Restaurant restaurant)
        {
            var db = new Zero_Hunger_DBEntities();

            var r = (from res in db.Restaurants
                              where res.Email == restaurant.Email
                              select res).SingleOrDefault();

            if (ModelState.IsValid)
            {
                if (r!=null)
                {
                    if (r.Password == restaurant.Password)
                    {
                        return RedirectToAction("CreateCollectRequest", "Restaurant");
                    }
                    else
                    {
                        TempData["password"] = "Password is incorrect";
                        return RedirectToAction("RestaurantLogin");
                    }
                }
                else
                {
                    TempData["email"] = "Email is not registered";
                    return RedirectToAction("RestaurantLogin");
                }
            }
            else
            {
                return RedirectToAction("RestaurantLogin");
            }
         
        }


        //____________________________Employee Login___________________________________

        [HttpGet]
        public ActionResult EmployeeLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeLogin(Employee employee)
        {
            var db = new Zero_Hunger_DBEntities();

            var e = (from res in db.Employees
                     where res.Email == employee.Email
                     select res).SingleOrDefault();

            if (ModelState.IsValid)
            {
                if (e != null)
                {
                    if (e.Password == employee.Password)
                    {
                        return RedirectToAction("CollectRequestsByEmployeeID", "Employee");
                    }
                    else
                    {
                        TempData["password"] = "Password is incorrect";
                        return RedirectToAction("EmployeeLogin");
                    }
                }
                else
                {
                    TempData["email"] = "Email is not registered";
                    return RedirectToAction("EmployeeLogin");
                }
            }
            else
            {
                return RedirectToAction("EmployeeLogin");
            }

        }

    }
}