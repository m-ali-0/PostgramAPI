using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PostgramAPI.Data;
using PostgramAPI.DTOs;
using PostgramAPI.Models;

namespace PostgramAPI.Services;

public class PostService : IPostService
{
    private readonly PostgramDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<IPostService> _logger;

    public PostService(
        PostgramDbContext context,
        IMapper mapper,
        ILogger<IPostService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PostDto> CreatePost(CreatePostRequest request, int userId)
    {
        _logger.LogInformation("Creating Post at {Time}", DateTime.Now);
        var post = _mapper.Map<Post>(request);
        post.UserId = userId;


        var categories = await _context.Categories
            .Where(c => request.CategoryIds.Contains(c.Id))
            .ToListAsync();

        post.Categories = categories;
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return _mapper.Map<PostDto>(post);
    }

    public async Task<List<PostDto>> GetAllPosts(int? categoryId, int? userId)
    {
        _logger.LogInformation("Getting all posts at {Time}", DateTime.Now);
        var posts = await _context.Posts
            .Include(p => p.User)
            .Include(p => p.Categories)
            .Where(n =>
                (!userId.HasValue || n.UserId == userId)
                &&
                (!categoryId.HasValue ||
                 n.Categories.Any(p =>
                     p.Id == categoryId)))
            .ToListAsync();
        
        return _mapper.Map<List<PostDto>>(posts);
    }

    public async Task<PostDto> GetPostById(int id)
    {
        _logger.LogInformation("Getting post with id {Id} at time {Time}", id, DateTime.Now);
        var post = await _context.Posts
            .Include(p => p.User)
            .Include(p => p.Categories)
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

        return _mapper.Map<PostDto>(post);
    }
}