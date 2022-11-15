using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Hunger_Web_App_Assignment.Models
{
    public class AssignEmployeeModel
    {
        public int ID { get; set; }
        public int EID { get; set; }
        public int RID { get; set; }
        public int CRID { get; set; }
        public string RName { get; set; }
        public string RLocation { get; set; }
        public System.DateTime MaxPreservedTime { get; set; }
        public string Status { get; set; }
    }
}