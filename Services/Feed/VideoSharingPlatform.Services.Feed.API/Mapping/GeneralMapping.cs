using AutoMapper;
using VideoSharingPlatform.Services.Feed.API.Dtos;
using VideoSharingPlatform.Services.Feed.API.Models;

namespace VideoSharingPlatform.Services.Feed.API.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Video, VideoDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Video, VideoCreateDto>().ReverseMap();
            CreateMap<Video, VideoUpdateDto>().ReverseMap();
        }
    }
}
