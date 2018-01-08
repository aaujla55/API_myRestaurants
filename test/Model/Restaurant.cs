﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Model
{
    public class Restaurant
    {

        [BsonId]
        public  ObjectId restuarant_id { get; set; }

        public  ObjectId user_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string cuisine { get; set; }

        public string timings { get; set; }

    }
}
