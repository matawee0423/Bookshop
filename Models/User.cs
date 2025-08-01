using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookShop.Models
{
    public class User
    {

        [BsonId]  
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; } = "";

        
         [BsonElement("email")]
         public string Email { get; set; } = "";

        [BsonElement("username")]
        public string Username { get; set; } = "";

        [BsonElement("password")]
        public string Password { get; set; } = "";

        [BsonElement("fullname")]
        public string Fullname { get; set; } = "";

         [BsonElement("phone_number")]
        public string Phone_number { get; set; } = "";
    }
}