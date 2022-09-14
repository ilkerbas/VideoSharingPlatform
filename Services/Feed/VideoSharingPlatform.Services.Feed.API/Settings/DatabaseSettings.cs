namespace VideoSharingPlatform.Services.Feed.API.Settings
{
    public class DatabaseSettings:IDatabaseSettings
    {
        public string VideoCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
