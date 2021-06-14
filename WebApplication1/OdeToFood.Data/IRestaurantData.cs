using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetResturantByName(string name);
        Restaurant GetRestaurant(int Id);
        Restaurant UpdateRestaurant(Restaurant restaurant);
        Restaurant CreateRestaurant(Restaurant restaurant);
        Restaurant Delete(int id);
        int Commit();
        public class SqlRestaurantData : IRestaurantData
        {
            private readonly OdeToFoodDbContext db;
            public SqlRestaurantData(OdeToFoodDbContext db)
            {
                this.db = db;
            }
            public int Commit()
            {
                return db.SaveChanges();
            }

            public Restaurant CreateRestaurant(Restaurant restaurant)
            {
                db.Add(restaurant);
                return restaurant;
            }

            public Restaurant Delete(int id)
            {
                var restaurant = GetRestaurant(id);
                if (restaurant!=null)
                {
                    db.Resturants.Remove(restaurant);
                }
                return restaurant;
            }

            public Restaurant GetRestaurant(int Id)
            {
                return db.Resturants.Find(Id);
            }

            public IEnumerable<Restaurant> GetResturantByName(string name)
            {
                var query = from r in db.Resturants where r.Name.StartsWith(name) || string.IsNullOrEmpty(name) orderby r.Name select r;
                return query;
            }

            public Restaurant UpdateRestaurant(Restaurant restaurant)
            {
                var entity = db.Resturants.Attach(restaurant);
                entity.State = EntityState.Modified;
                return restaurant;
            }
        }
        public class InMemoryRestaurantData : IRestaurantData
        {
            List<Restaurant> restaurants;
            public InMemoryRestaurantData()
            {
                restaurants = new List<Restaurant>()
                {
                    new Restaurant{ID=1,Name="Scoot's Pizza",Location="Maryland",cuisineType=CuisineType.Indian},
                    new Restaurant{ID=2,Name="Cinnamon club",Location="London",cuisineType=CuisineType.Italian},
                     new Restaurant{ID=3,Name="La casta",Location="Califorinia",cuisineType=CuisineType.Mexican},
                };
            }

            public int Commit()
            {
                return 0;
            }

            public Restaurant CreateRestaurant(Restaurant newRestaurant)
            {
                restaurants.Add(newRestaurant);
                newRestaurant.ID = restaurants.Max(r => r.ID) + 1;
                return newRestaurant;
            }

            public Restaurant Delete(int id)
            {
                var restaurant = restaurants.FirstOrDefault(r=>r.ID==id);
                if (restaurant!=null)
                {
                    restaurants.Remove(restaurant);
                }
                return restaurant;
            }

            public Restaurant GetRestaurant(int Id)
            {
                return restaurants.SingleOrDefault(x=>x.ID==Id);
            }

            public IEnumerable<Restaurant> GetResturantByName(string name=null)
            {
                return restaurants.OrderBy(x => x.ID).Where(x=>string.IsNullOrEmpty(name) || x.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase));
            }

            public Restaurant UpdateRestaurant(Restaurant updateRestaurant)
            {
                var restaurant = restaurants.SingleOrDefault(x => x.ID == updateRestaurant.ID);
                if (restaurant != null)
                {
                    restaurant.Name = updateRestaurant.Name;
                    restaurant.Location = updateRestaurant.Location;
                    restaurant.cuisineType = updateRestaurant.cuisineType;
                }
                return restaurant;
            }
        }
    }
}
