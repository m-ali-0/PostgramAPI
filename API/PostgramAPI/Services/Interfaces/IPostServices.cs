using PostgramAPI.DTOs;
using PostgramAPI.Models;

namespace PostgramAPI.Services;

public interface IPostServices
{
    Task<Post> CreatePost(CreatePostRequest request);


    Task<List<PostDto>> GetAllPosts();


    Task<PostDto> GetPostById(int id);


    Task<List<PostDto>> GetPostsByUserId(int id);


    Task<List<PostDto>> GetPostsByCategoryId(int id);
}