using PostgramAPI.DTOs;

namespace PostgramAPI.Services;

public interface IPostService
{
    Task<PostDto> CreatePost(CreatePostRequest request, int userId);


    Task<List<PostDto>> GetAllPosts(int? userId, int? categoryId);


    Task<PostDto> GetPostById(int id);
}