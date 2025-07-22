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
    public async Task<IActionResult> Post(CreatePostRequest request)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        var post = await _postService.CreatePost(request, userId);
        return Created(post.Id.ToString(), post);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllPosts(int? categoryId, int? userId)
    {
        var posts = await _postService.GetAllPosts(categoryId, userId);
        return Ok(posts);
    }

    
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        var post = await _postService.GetPostById(id);
        return Ok(post);
    }

    

    
}