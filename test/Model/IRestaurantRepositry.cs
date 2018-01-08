using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Model
{
    public interface IRestaurantRepositry
    {
       Task<IEnumerable<Restaurant>> GetAllNotes();
        Task<Restaurant> GetNote(string id);
        Task AddNote(Restaurant item);
        Task<bool> RemoveNote(string id);
        Task<bool> UpdateNote(string id, string body);
        Task<bool> UpdateNoteDocument(string id, string body);
        Task<bool> RemoveAllNotes();
    }
    
}
