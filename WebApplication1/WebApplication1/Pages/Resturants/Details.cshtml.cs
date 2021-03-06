using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Resturants
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public DetailsModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        [TempData]
        public string Message { get; set; }
        public Restaurant Restaurant { get; set; }
        public IActionResult OnGet(int id)
        {
            Restaurant = restaurantData.GetRestaurant(id);
            if (Restaurant==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
