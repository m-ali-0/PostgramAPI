using Microsoft.AspNetCore.Http.HttpResults;
using PostgramAPI.DTOs;
using PostgramAPI.Models;

namespace PostgramAPI.Services;

public class PostServices
{
    public async Task<Post> CreatePost(CreatePostRequest request)
    {
    }

    public async Task<PostDto> GetAllPosts()
    {
    }

    public async Task<PostDto> GetPostById(int id)
    {
    }

    public async Task<PostDto> GetPostByUserId(int id)
    {
    }

    public async Task<PostDto> GetPostByCategoryId(int id)
    {
    }
}