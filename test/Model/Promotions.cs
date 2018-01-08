using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Model
{
    public class Promotions
    {
        [BsonId]
        public static ObjectId promotion_id { get; set; }
        public string promotion_couponCode { get; set; }
        public DateTime promotion_startTime { get; set; }
        public DateTime promotion_endTime { get; set; }

        public Boolean promotion_availability { get; set; }




    }
}
