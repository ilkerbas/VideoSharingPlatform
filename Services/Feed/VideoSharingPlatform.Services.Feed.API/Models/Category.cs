using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VideoSharingPlatform.Services.Feed.API.Models
{
    public class Category
    {
        [BsonId]    // to specify mongo db bson id
        [BsonRepresentation(BsonType.ObjectId)]    // gets object id from database and converts it to string and vice versa.
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
