using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Model;

namespace test.Controllers
{
    [Route("api/[controller]")]
    public class SystemController: Controller
    {

        private readonly IRestaurantRepositry _restaurantRepository;

        public SystemController(IRestaurantRepositry restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        // Call an initialization - api/system/init
        [HttpGet("{setting}")]
        public string Get(string setting)
        {
            if (setting == "init")
            {
                _restaurantRepository.RemoveAllRestaurants();
                _restaurantRepository.AddRestaurant(new Restaurant()
                {
                   name= "Tim",
                   address = "941 Progress Avenue",
                   cuisine ="Fast food",
                   timings = "9 to 5"
                   
                });
                

                return "Done";
            }

            return "Unknown";
        }
    }
}
