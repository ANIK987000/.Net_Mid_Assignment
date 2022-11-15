using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger_Web_App_Assignment.DB;
using Zero_Hunger_Web_App_Assignment.Models;

namespace Zero_Hunger_Web_App_Assignment.Repo
{
    public class EmployeeRepo
    {

        //_____________________________Get Employee_______________________________________________

        public static List<EmployeeModel> Get()
        {
            var db = new Zero_Hunger_DBEntities();
            var employees = new List<EmployeeModel>();

            foreach (var item in db.Employees)
            {
                employees.Add(new EmployeeModel()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Location = item.Location,
                    Email=item.Email,
                    Password=item.Password
                });
            }
            return employees;

        }



        //_______________________________________Get Employee Details___________________________________

        public static EmployeeModel EmployeeDetails(int id)
        {
            var db = new Zero_Hunger_DBEntities();
            var employee = new EmployeeModel();

            var dbe = db.Employees.Find(id);


            employee.ID = dbe.ID;
            employee.Name = dbe.Name;
            employee.Location = dbe.Location;
            employee.Email = dbe.Email;
            employee.Password = dbe.Password;

            return employee;


        }


        //________________________________Add Employee_________________________________________

        public static void AddEmployee(EmployeeModel dbe)
        {
            var db = new Zero_Hunger_DBEntities();
            var employee = new Employee();



            //employee.ID = dbe.ID;
            employee.Name = dbe.Name;
            employee.Location = dbe.Location;
            employee.Email = dbe.Email;
            employee.Password = dbe.Password;

            db.Employees.Add(employee);
            db.SaveChanges();
        }


        //_______________________________Delete Employee_______________________________________

        public static void DeleteEmployee(int id)
        {
            var db = new Zero_Hunger_DBEntities();

            var dbe = db.Employees.Find(id);

            db.Employees.Remove(dbe);
            db.SaveChanges();
        }

        //_______________________________Update Employee_________________________________________

        public static void UpdateEmployee(int id,EmployeeModel employee)
        {
            var db = new Zero_Hunger_DBEntities();

            var dbe = db.Employees.Find(id);


            dbe.ID = employee.ID;
            dbe.Name = employee.Name;
            dbe.Location = employee.Location;
            dbe.Email = employee.Email;
            dbe.Password = employee.Password;

            db.SaveChanges();


        }
    }
}