using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoSharingPlatform.Services.Feed.API.Dtos;
using VideoSharingPlatform.Services.Feed.API.Services;
using VideoSharingPlatform.Shared.ControllerBases;

namespace VideoSharingPlatform.Services.Feed.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : CustomBaseController
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _videoService.GetAllAsync();

            return CreateActionResultInstance(response);
        }

        // instead of videos?id=4, ensure this videos/4 -> id = 4

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _videoService.GetByIdAsync(id);

            return CreateActionResultInstance(response);
        }

        //api/videos/getallbyuserid/4
        [HttpGet]
        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var response = await _videoService.GetAllByUserIdAsync(userId);

            return CreateActionResultInstance(response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(VideoCreateDto videoCreateDto)
        {
            var response = await _videoService.CreateAsync(videoCreateDto);

            return CreateActionResultInstance(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update(VideoUpdateDto videoUpdateDto)
        {
            var response = await _videoService.UpdateAsync(videoUpdateDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _videoService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}
