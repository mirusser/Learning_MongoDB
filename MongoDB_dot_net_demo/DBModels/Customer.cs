using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_dot_net_demo.DBModels
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        //To save it with different name in the document
        [BsonElement("PhoneNumber")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}
