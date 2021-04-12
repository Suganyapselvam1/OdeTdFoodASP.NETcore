using System;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int MyProperty { get; set; }
        public CuisineType cuisineType { get; set; }
    }
}
