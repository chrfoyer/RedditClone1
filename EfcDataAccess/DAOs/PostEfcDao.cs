using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly PostContext context;

    public PostEfcDao(PostContext context)
    {
        this.context = context;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();

        return added.Entity;
    }
    
    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParams)
    {
        IQueryable<Post> query = context.Posts.Include(post => post.User).AsQueryable();

        if (!string.IsNullOrEmpty(searchParams.UserName))
        {
            // we know username is unique, so just fetch the first
            query = query.Where(post =>
                post.User.UserName.Equals(searchParams.UserName, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParams.UserId != null)
        {
            query = query.Where(post => post.User.Id == searchParams.UserId);
        }

        if (!string.IsNullOrEmpty(searchParams.TitleContains))
        {
            query = query.Where(post =>
                post.Title.Contains(searchParams.TitleContains, StringComparison.OrdinalIgnoreCase));
        }
        
        if (!string.IsNullOrEmpty(searchParams.BodyContains))
        {
            query = query.Where(post =>
                post.Title.Contains(searchParams.BodyContains, StringComparison.OrdinalIgnoreCase));
        }

        List<Post> result = await query.ToListAsync();
        return result;
    }

    public async Task<Post?> GetByIdAsync(int postId)
    {
        Post? existing = await context.Posts
            .Include(p => p.User)
            .SingleOrDefaultAsync(p => p.Id == postId);

        return existing;
    }
}