using Microsoft.AspNetCore.Mvc;
using PostgramAPI.Data;
using PostgramAPI.DTOs;
using PostgramAPI.Services;

namespace PostgramAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly PostServices _postServices;

    public PostController(PostServices postServices)
    {
        _postServices = postServices;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePostRequest request)
    {
        var post = await _postServices.CreatePost(request);
        return Ok(post);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
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
        var posts = await _postServices.GetPostByUserId(id);
        return Ok(posts);
    }

    [HttpGet("category/{id}")]
    public async Task<IActionResult> GetByCategoryId(int id)
    {
        var posts = await _postServices.GetPostByCategoryId(id);
        return Ok(posts);
    }
}