using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Model
{
    public class Reviews
    {

        [BsonId]
       
        public ObjectId review_id { get; set; }
        public ObjectId menu_id { get; set; }
        public  ObjectId user_id { get; set; }

        public int stars { get; set; }

        public string review { get; set; }
    }
}
