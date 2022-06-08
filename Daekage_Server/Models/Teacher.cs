using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Daekage_Server.Models
{
    public class Teacher
    {
        #nullable enable
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        #nullable disable
        public string Email { get; set; }

        public string Name { get; set; }
    }
}
