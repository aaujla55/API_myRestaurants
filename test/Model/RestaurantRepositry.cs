using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Model
{
    public class RestaurantRepositry: IRestaurantRepositry
    {

        private readonly DbContext _context = null;

        public RestaurantRepositry(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            try
            {
                return await _context.Restaurants
                        .Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<Restaurant> GetRestaurant(ObjectId id)
        {
            var filter = Builders<Restaurant>.Filter.Eq("restuarant_id", id);

            try
            {
                return await _context.Restaurants
                                .Find(filter)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddRestaurant(Restaurant item)
        {
            try
            {
                await _context.Restaurants.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveRestaurant(ObjectId id)
        {
            try
            {
                DeleteResult actionResult = await _context.Restaurants.DeleteOneAsync(
                        Builders<Restaurant>.Filter.Eq("restuarant_id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateRestaurant(ObjectId id, Restaurant body)
        {
            var filter = Builders<Restaurant>.Filter.Eq(s => body.user_id, id);
            //Set<Restaurant> ss = new S
            var update = Builders<Restaurant>.Update
                            .Set(s => s.address, body.address);
                         
                            

            try
            {
                UpdateResult actionResult
                     = await _context.Restaurants.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateNote(ObjectId id, Restaurant item)
        {
            try
            {
                ReplaceOneResult actionResult
                    = await _context.Restaurants
                                    .ReplaceOneAsync(n => n.restuarant_id.Equals(id)
                                            , item
                                            , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveAllRestaurants()
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Restaurants.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Task<bool> UpdateRestaurantDocument(ObjectId id, string body)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRestaurantDocument(ObjectId id, Restaurant value)
        {
            throw new NotImplementedException();
        }
    }
}
