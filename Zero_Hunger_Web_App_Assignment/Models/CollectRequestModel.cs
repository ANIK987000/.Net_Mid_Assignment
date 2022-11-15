using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Hunger_Web_App_Assignment.Models
{
    public class CollectRequestModel
    {
        public int ID { get; set; }
        public System.DateTime PresentTime { get; set; }
        public System.DateTime MaxPreservedTime { get; set; }
        public string Location { get; set; }
        public int ForHowManyPersons { get; set; }
        public string Status { get; set; }
        public int RID { get; set; }
    }
}