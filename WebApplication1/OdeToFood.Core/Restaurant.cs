using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int ID { get; set; }
        [Required,StringLength(50)]
        public string Name { get; set; }
        [Required,StringLength(100)]
        public string Location { get; set; }
        public int MyProperty { get; set; }
        public CuisineType cuisineType { get; set; }
    }
}
