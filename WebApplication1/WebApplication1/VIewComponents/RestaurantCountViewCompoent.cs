using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.VIewComponents
{
    public class RestaurantCountViewCompoent: ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewCompoent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetRestauranstCount();
            return View(count);
        }
    }
}
