using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.Model;

namespace test.Controllers
{
    [Route("api/[controller]")]

    public class ValuesController : Controller
    {
        private readonly IRestaurantRepositry _restaurantRepositry;

        
        public ValuesController(IRestaurantRepositry restaurantRepositry)
        {
            _restaurantRepositry = restaurantRepositry;
        }

        // GET: notes/notes
        [HttpGet]
        public Task<string> Get()
        {
            return GetRestaurantInternal();
        }

        private async Task<string> GetRestaurantInternal()
        {
            var restaurants = await _restaurantRepositry.GetAllRestaurants();
            return JsonConvert.SerializeObject(restaurants);
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        public Task<string> Get(ObjectId id)
        {
            return GetRestaurantByIdInternal(id);
        }


        private async Task<string> GetRestaurantByIdInternal(ObjectId id)
        {
            var restaurant = await _restaurantRepositry.GetRestaurant(id) ?? new Restaurant();
            return JsonConvert.SerializeObject(restaurant);
        }

        // POST api/notes
        [HttpPost]
        public void Post([FromBody]Restaurant value)
        {
            _restaurantRepositry.AddRestaurant(new Restaurant()
            { name = value.address, address = value.address, cuisine = value.cuisine, timings = value.timings });
        }

        // PUT api/notes/5
        [HttpPut("{id}")]
        public void Put(ObjectId id, [FromBody]Restaurant value)
        {
            _restaurantRepositry.UpdateRestaurant(id, value);
        }

        // DELETE api/notes/5
        public void Delete(ObjectId id)
        {
            _restaurantRepositry.RemoveRestaurant(id);
        }
    }
}
