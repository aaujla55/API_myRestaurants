using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Model
{
    public class User
    {
        [BsonId]
        public  ObjectId user_id { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string user_type { get; set; }

        public string name { get; set; }



    }
}
