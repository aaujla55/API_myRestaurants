using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Model
{
    public interface IRestaurantRepositry
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurants();
        Task<Restaurant> GetRestaurant(ObjectId id);
        Task AddRestaurant(Restaurant item);
        Task<bool> RemoveRestaurant(ObjectId id);
        Task<bool> UpdateRestaurant(ObjectId id, Restaurant value);
        Task<bool> UpdateRestaurantDocument(ObjectId id, Restaurant value);
        Task<bool> RemoveAllRestaurants();
    }
    
}
