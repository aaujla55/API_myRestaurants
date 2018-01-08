using Microsoft.AspNetCore.Mvc;
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
            return GetNoteInternal();
        }

        private async Task<string> GetNoteInternal()
        {
            var notes = await _restaurantRepositry.GetAllNotes();
            return JsonConvert.SerializeObject(notes);
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        public Task<string> Get(string id)
        {
            return GetNoteByIdInternal(id);
        }


        private async Task<string> GetNoteByIdInternal(string id)
        {
            var note = await _restaurantRepositry.GetNote(id) ?? new Restaurant();
            return JsonConvert.SerializeObject(note);
        }

        // POST api/notes
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _restaurantRepositry.AddNote(new Restaurant()
            { Body = value, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
        }

        // PUT api/notes/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]string value)
        {
            _restaurantRepositry.UpdateNote(id, value);
        }

        // DELETE api/notes/5
        public void Delete(string id)
        {
            _restaurantRepositry.RemoveNote(id);
        }
    }
}
