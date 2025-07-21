using Microsoft.AspNetCore.Mvc;
using PostgramAPI.DTOs;
using PostgramAPI.Services;

namespace PostgramAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostServices _postServices;

    public PostController(IPostServices postServices)
    {
        _postServices = postServices;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePostRequest request)
    {
        var post = await _postServices.CreatePost(request);
        return Created(post.Id.ToString(), post);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPosts(int? categoryId, int? userId)
    {
        var posts = await _postServices.GetAllPosts();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var post = await _postServices.GetPostById(id);
        return Ok(post);
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetByUserId(int id)
    {
        var posts = await _postServices.GetPostsByUserId(id);
        return Ok(posts);
    }

    [HttpGet("category/{id}")]
    public async Task<IActionResult> GetByCategoryId(int id)
    {
        var posts = await _postServices.GetPostsByCategoryId(id);
        return Ok(posts);
    }
}