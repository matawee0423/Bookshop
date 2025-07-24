using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookShop.Models
{
    public class Like
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonElement("userId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } = "";

        [BsonElement("bookId")]
        public string BookId { get; set; } = "";
    }
}
