using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Model
{
    public class Menu
    {

        [BsonId]
        public  ObjectId menu_id { get; set; }
        public  ObjectId user_id { get; set; }

        public  ObjectId review_id { get; set; }

        public string menu_type { get; set; }

        public string menu_name { get; set; }
        public string menu_description{ get; set; }

        public string menu_calories { get; set; }

        public string menu_price { get; set; }

        public Boolean menu_availability { get; set; }

        public DateTime menu_UpdatedOn { get; set; } = DateTime.Now;

        public Boolean menu_active { get; set; }

        public Boolean menu_isRecommended { get; set; }


    }
}
