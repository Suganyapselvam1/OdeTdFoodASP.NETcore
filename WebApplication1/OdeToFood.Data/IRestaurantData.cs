using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetResturants();
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
            public IEnumerable<Restaurant> GetResturants()
            {
                return restaurants.OrderBy(x => x.Name);
            }
        }
    }
}
