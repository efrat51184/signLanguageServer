using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignLanguage.Models
{
    public class Text
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int TextId { get; set; }
        public string TextValue { get; set; }
        public int[] TextAnswer { get; set; }
        public int CategoryId { get; set; }
    }
}
