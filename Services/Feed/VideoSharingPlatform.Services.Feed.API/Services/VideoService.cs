using AutoMapper;
using MongoDB.Driver;
using VideoSharingPlatform.Services.Feed.API.Dtos;
using VideoSharingPlatform.Services.Feed.API.Models;
using VideoSharingPlatform.Services.Feed.API.Settings;
using VideoSharingPlatform.Shared.Dtos;

namespace VideoSharingPlatform.Services.Feed.API.Services
{
    public class VideoService:IVideoService
    {
        private readonly IMongoCollection<Video> _videoCollection;

        private readonly IMongoCollection<Category> _categoryCollection;

        private readonly IMapper _mapper;

        public VideoService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _videoCollection = database.GetCollection<Video>(databaseSettings.VideoCollectionName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }


        public async Task<Response<List<VideoDto>>> GetAllAsync()
        {
            var Videos = await _videoCollection.Find(Video => true).ToListAsync();

            if (Videos.Any())
            {
                foreach (var Video in Videos)
                {
                    Video.Category = await _categoryCollection.Find<Category>(c => c.Id == Video.CategoryId).FirstAsync();

                }
            }
            else
            {
                Videos = new List<Video>();
            }

            return Response<List<VideoDto>>.Success(_mapper.Map<List<VideoDto>>(Videos), 200);


        }

        public async Task<Response<VideoDto>> GetByIdAsync(string id)
        {
            var Video = await _videoCollection.Find<Video>(c => c.Id == id).FirstOrDefaultAsync();
            if (Video == null)
            {
                return Response<VideoDto>.Fail("Video not found", 404);
            }

            Video.Category = await _categoryCollection.Find<Category>(x => x.Id == Video.CategoryId).FirstAsync();

            return Response<VideoDto>.Success(_mapper.Map<VideoDto>(Video), 200);
        }


        public async Task<Response<List<VideoDto>>> GetAllByUserIdAsync(string userId)
        {

            var Videos = await _videoCollection.Find<Video>(x => x.UserId == userId).ToListAsync();

            if (Videos.Any())
            {
                foreach (var Video in Videos)
                {
                    Video.Category = await _categoryCollection.Find<Category>(c => c.Id == Video.CategoryId).FirstAsync();

                }
            }
            else
            {
                Videos = new List<Video>();
            }

            return Response<List<VideoDto>>.Success(_mapper.Map<List<VideoDto>>(Videos), 200);

        }

        public async Task<Response<VideoDto>> CreateAsync(VideoCreateDto VideoCreateDto)
        {
            var newVideo = _mapper.Map<Video>(VideoCreateDto);   // db knows Video not dto

            newVideo.CreatedTime = DateTime.Now;

            await _videoCollection.InsertOneAsync(newVideo);

            return Response<VideoDto>.Success(_mapper.Map<VideoDto>(newVideo), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(VideoUpdateDto VideoUpdateDto)
        {
            var updateVideo = _mapper.Map<Video>(VideoUpdateDto);

            var result = await _videoCollection.FindOneAndReplaceAsync(x => x.Id == VideoUpdateDto.Id, updateVideo);

            if (result == null)
            {
                return Response<NoContent>.Fail("Video not found", 404);
            }

            return Response<NoContent>.Success(204);   // success with no body 204
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _videoCollection.DeleteOneAsync(x => x.Id == id);

            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Video not found", 404);
            }
        }
    }
}
