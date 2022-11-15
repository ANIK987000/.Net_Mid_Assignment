using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger_Web_App_Assignment.DB;
using Zero_Hunger_Web_App_Assignment.Models;

namespace Zero_Hunger_Web_App_Assignment.Repo
{
    public class AssignEmployeeRepo
    {
        //________________________________Assign Employee_________________________________________

        public static void AssignEmployee(AssignEmployeeModel aem)
        {
            var db = new Zero_Hunger_DBEntities();
            var assignEmployee = new AssignEmployee();



            //assignEmployee.ID = aem.ID;
            assignEmployee.EID = aem.EID;
            assignEmployee.RID = aem.RID;
            assignEmployee.CRID = aem.CRID;
            assignEmployee.RName = aem.RName;
            assignEmployee.RLocation = aem.RLocation;
            assignEmployee.MaxPreservedTime = aem.MaxPreservedTime;
            assignEmployee.Status = aem.Status;

            db.AssignEmployees.Add(assignEmployee);
            db.SaveChanges();
        }

        //________________________________Assigned Collect Requests_________________________________________
        public static List<AssignEmployeeModel> AssignedCollectRequests()
        {
            var db = new Zero_Hunger_DBEntities();
            var assignEmployees = new List<AssignEmployeeModel>();

            foreach (var item in db.AssignEmployees)
            {
                assignEmployees.Add(new AssignEmployeeModel()
                {
                    ID = item.ID,
                    EID = item.EID,
                    RID = item.RID,
                    CRID= item.CRID,
                    RName = item.RName,
                RLocation = item.RLocation,
                MaxPreservedTime = item.MaxPreservedTime,
                Status=item.Status
            });
            }
            return assignEmployees;
        }



        //________________________________Assigned Collect Requests By An Employee_________________________________________
        //public static List<AssignEmployeeModel> AssignedCollectRequestsByAnEmployee()
        //{
        //    var db = new Zero_Hunger_DBEntities();
        //    var assignEmployees = new List<AssignEmployeeModel>();

        //    foreach (var item in db.AssignEmployees)
        //    {
        //        assignEmployees.Add(new AssignEmployeeModel()
        //        {
        //            (from assignEmployee in db.AssignEmployees
        //                         where assignEmployee.EID == 1
        //                         select assignEmployee)
        //        });
        //    }
        //    return assignEmployees;


        //}


        //___________________________________Delete Assigned Collect Request____________________________________________________

        public static void DeleteAssignedCollectRequest(int id)
        {
            var db = new Zero_Hunger_DBEntities();
            //var restaurant = new RestaurantModel();

            var dbr = db.AssignEmployees.Find(id);

            db.AssignEmployees.Remove(dbr);
            db.SaveChanges();
        }
    }
}