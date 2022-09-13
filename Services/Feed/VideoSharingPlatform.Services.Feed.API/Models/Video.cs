using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VideoSharingPlatform.Services.Feed.API.Models
{
    public class Video
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }

        public Feature Feature { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        [BsonIgnore]    // ignore
        public Category Category { get; set; }

    }
}
