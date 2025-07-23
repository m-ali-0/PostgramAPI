using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostgramAPI.DTOs;
using PostgramAPI.Services;

namespace PostgramAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreatePost(CreatePostRequest request)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        await _postService.CreatePost(request, userId);
        return Created();
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetPosts(int? categoryId, int? userId)
    {
        var posts = await _postService.GetAllPosts(categoryId, userId);
        return Ok(posts);
    }


    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetPostById(int id)
    {
        var post = await _postService.GetPostById(id);
        return Ok(post);
    }
}