namespace VideoSharingPlatform.Services.Feed.API.Settings
{
    public interface IDatabaseSettings
    {
        public string VideoCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
