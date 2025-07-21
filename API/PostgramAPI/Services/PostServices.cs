using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PostgramAPI.Data;
using PostgramAPI.DTOs;
using PostgramAPI.Models;

namespace PostgramAPI.Services;

public class PostServices : IPostServices
{
    private readonly PostgramDbContext _context;

    public PostServices(PostgramDbContext context)
    {
        _context = context;
    }
    public async Task<Post> CreatePost(CreatePostRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(n=>n.Id==request.UserId);

        var post = new Post()
        {
            Title = request.Title,
            Content = request.Content,
            UserId = user.Id
        };

        var categories = await _context.Categories
            .Where(c => request.Categories.Contains(c.Name))
            .ToListAsync();

        post.PostCategoryRelations = categories
            .Select(c => new PostCategoryRelation()
            {
                CategoryId = c.Id
            }).ToList();
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<List<PostDto>> GetAllPosts()
    {
        var posts = await _context.Posts
            .Include(p => p.User)
            .Include(p => p.PostCategoryRelations)
            .ThenInclude(pc => pc.Category)
            .Select(n => new PostDto()
            {
                Title = n.Title,
                Content = n.Content,
                DisplayName = n.User.DisplayName,
                Categories = n.PostCategoryRelations
                    .Select(p=>new CategoryDto2()
                    {
                        CategoryName = p.Category.Name
                    }).ToList()
                
            }).ToListAsync();
                
            
        return posts;
    }

    public async Task<PostDto> GetPostById(int id)
    {
        var post = await _context.Posts
            .Include(p => p.User)
            .Include(p => p.PostCategoryRelations)
            .ThenInclude(pc => pc.Category)
            .Where(p => p.Id == id)
            .Select(n => new PostDto()
            {
                Title = n.Title,
                Content = n.Content,
                DisplayName = n.User.DisplayName,
                Categories = n.PostCategoryRelations
                    .Select(pc => new CategoryDto2()
                    {
                        CategoryName = pc.Category.Name
                    }).ToList()
            }).FirstOrDefaultAsync();
        return post;
    }

    public async Task<List<PostDto>> GetPostsByUserId(int id)
    {
        var posts = await _context.Posts
            .Include(p => p.User)
            .Include(p => p.PostCategoryRelations)
            .ThenInclude(pc => pc.Category)
            .Where(p => p.UserId == id)
            .Select(n => new PostDto()
            {
                Title = n.Title,
                Content = n.Content,
                DisplayName = n.User.DisplayName,
                Categories = n.PostCategoryRelations
                    .Select(n => new CategoryDto2()
                    {
                        CategoryName = n.Category.Name
                    }).ToList()
            }).ToListAsync();
        return posts;
    }

    public async Task<List<PostDto>> GetPostsByCategoryId(int id)
    {
        var posts = await _context.Posts
            .Include(p => p.User)
            .Include(p => p.PostCategoryRelations)
            .ThenInclude(pc => pc.Category)
            .Where(p=>p.PostCategoryRelations.Any(pc => pc.CategoryId == id))
            .Select(n => new PostDto()
            {
                Title = n.Title,
                Content = n.Content,
                DisplayName = n.User.DisplayName,
                Categories = n.PostCategoryRelations
                    .Select(p=> new CategoryDto2()
                    {
                        CategoryName = p.Category.Name
                    }).ToList()
            }).ToListAsync();
        return posts;
    }
}