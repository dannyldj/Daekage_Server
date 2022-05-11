using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Daekage_Server.Models
{
    public class Notice
    {
        #nullable enable
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        #nullable disable
        public string Writer { get; set; }

        public string Date { get; set; }

        public List<string> Files { get; set; }

        public string Text { get; set; }
    }
}