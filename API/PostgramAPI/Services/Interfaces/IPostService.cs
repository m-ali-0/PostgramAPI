using PostgramAPI.DTOs;
using PostgramAPI.Models;

namespace PostgramAPI.Services;

public interface IPostService
{
    Task<Post> CreatePost(CreatePostRequest request, int userId);


    Task<List<PostDto>> GetAllPosts(int? userId, int? categoryId);


    Task<PostDto> GetPostById(int id);


}