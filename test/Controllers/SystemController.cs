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
                _restaurantRepository.RemoveAllNotes();
                _restaurantRepository.AddNote(new Restaurant()
                {
                    Id = "1",
                    Body = "Test note 1",
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    UserId = 1
                });
                _restaurantRepository.AddNote(new Restaurant()
                {
                    Id = "2",
                    Body = "Test note 2",
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    UserId = 1
                });
                _restaurantRepository.AddNote(new Restaurant()
                {
                    Id = "3",
                    Body = "Test note 3",
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    UserId = 2
                });
                _restaurantRepository.AddNote(new Restaurant()
                {
                    Id = "4",
                    Body = "Test note 4",
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    UserId = 2
                });

                return "Done";
            }

            return "Unknown";
        }
    }
}
