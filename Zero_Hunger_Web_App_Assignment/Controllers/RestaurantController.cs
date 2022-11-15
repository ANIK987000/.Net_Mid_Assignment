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
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }



        //__________________________________________________________Collect Request Related Operation_____________________________________




        //______________________________Create Collect Request________________________

        [HttpGet]
        public ActionResult CreateCollectRequest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCollectRequest(CollectRequestModel collectRequest)
        {
            if (ModelState.IsValid)
            {
                var str = Session["restaurantID"].ToString();
                var id = new JavaScriptSerializer().Deserialize<int>(str);

                CollectRequestRepo.CreateCollectRequest(collectRequest,id);  // AddRestaurant is create function of RestaurantRepo made by me
                TempData["created"] = "Collect Request Created";
                return RedirectToAction("CollectRequestRequestedByRestauarant");
            }

            return View(collectRequest);
        }


        //_____________________________Collect Request Requested By Restauarant__________________________

        public ActionResult CollectRequestRequestedByRestauarant()
        {

            var str = Session["restaurantID"].ToString();
            var id = new JavaScriptSerializer().Deserialize<int>(str);

            var db = new Zero_Hunger_DBEntities();
            var crrbr = (from cr in db.CollectRequests
                        where cr.RID == id
                        select cr).ToList();

            return View(crrbr);
        }
        //______________________________Delete Collect Request________________________



        //______________________________Update Collect Request________________________
    }
}