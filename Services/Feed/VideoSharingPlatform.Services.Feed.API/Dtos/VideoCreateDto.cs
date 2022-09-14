namespace VideoSharingPlatform.Services.Feed.API.Dtos
{
    public class VideoCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }

        public FeatureDto Feature { get; set; }
        public string CategoryId { get; set; }
    }
}
