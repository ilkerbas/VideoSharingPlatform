using VideoSharingPlatform.Services.Feed.API.Dtos;
using VideoSharingPlatform.Shared.Dtos;

namespace VideoSharingPlatform.Services.Feed.API.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
