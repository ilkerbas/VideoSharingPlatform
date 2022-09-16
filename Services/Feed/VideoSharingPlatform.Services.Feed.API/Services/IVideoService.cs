using VideoSharingPlatform.Services.Feed.API.Dtos;
using VideoSharingPlatform.Shared.Dtos;

namespace VideoSharingPlatform.Services.Feed.API.Services
{
    public interface IVideoService
    {
        Task<Response<List<VideoDto>>> GetAllAsync();
        Task<Response<VideoDto>> GetByIdAsync(string id);
        Task<Response<List<VideoDto>>> GetAllByUserIdAsync(string userId);
        Task<Response<VideoDto>> CreateAsync(VideoCreateDto videoCreateDto);
        Task<Response<NoContent>> UpdateAsync(VideoUpdateDto videoUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string id);

    }
}
