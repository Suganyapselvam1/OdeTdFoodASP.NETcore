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
        int Commit();
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
