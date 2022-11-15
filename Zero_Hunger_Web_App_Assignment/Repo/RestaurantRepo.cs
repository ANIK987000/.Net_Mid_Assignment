using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger_Web_App_Assignment.DB;
using Zero_Hunger_Web_App_Assignment.Models;

namespace Zero_Hunger_Web_App_Assignment.Repo
{
    public class RestaurantRepo
    {
        //_____________________________Get Restaurant_______________________________________________

        public static List<RestaurantModel> Get()
        {
            var db = new Zero_Hunger_DBEntities();
            var restaurants = new List<RestaurantModel>();

            foreach (var item in db.Restaurants)
            {
                restaurants.Add(new RestaurantModel()
                {
                    ID = item.ID,
                    Name=item.Name,
                    Location=item.Location,
                    Email=item.Email,
                    Password=item.Password
                }) ;
            }
            return restaurants;

        }


        //_______________________________________Get Restaurant Details___________________________________

        public static RestaurantModel RestaurantDetails(int id)
        {
            var db = new Zero_Hunger_DBEntities();
            var restaurant = new RestaurantModel();

            var dbr = db.Restaurants.Find(id);


            restaurant.ID = dbr.ID;
            restaurant.Name = dbr.Name;
            restaurant.Location = dbr.Location;
            restaurant.Email = dbr.Email;
            restaurant.Password = dbr.Password;

            return restaurant;


        }


        //________________________________Add Restaurant_________________________________________

        public static void AddRestaurant(RestaurantModel dbr)
        {
            var db = new Zero_Hunger_DBEntities();
            var restaurant = new Restaurant();



            restaurant.ID = dbr.ID;
            restaurant.Name = dbr.Name;
            restaurant.Location = dbr.Location;
            restaurant.Email = dbr.Email;
            restaurant.Password = dbr.Password;

            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }


        //_______________________________Delete Restautant_______________________________________

        public static void DeleteRestaurant(int id)
        {
            var db = new Zero_Hunger_DBEntities();
            //var restaurant = new RestaurantModel();

            var dbr = db.Restaurants.Find(id);

            db.Restaurants.Remove(dbr);
            db.SaveChanges();
        }

        //_______________________________Update Restaurant_________________________________________

        public static void UpdateRestaurant(int id,RestaurantModel restaurant)
        {
            var db = new Zero_Hunger_DBEntities();

            var dbr = db.Restaurants.Find(id);


            dbr.ID = restaurant.ID;
            dbr.Name = restaurant.Name;
            dbr.Location = restaurant.Location;
            dbr.Email = restaurant.Email;
            dbr.Password = restaurant.Password;

            db.SaveChanges();


        }
    }
}