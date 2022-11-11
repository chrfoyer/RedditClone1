using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto postToCreate)
    {
        ValidateData(postToCreate);
        Post toCreate = new Post((await userDao.GetByUsernameAsync(postToCreate.Username))!, postToCreate.Title, postToCreate.Body);

        Post created = await postDao.CreateAsync(toCreate);

        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        return postDao.GetAsync(searchParameters);
    }

    public Task<Post?> GetByIdAsync(int postId)
    {
        return postDao.GetByIdAsync(postId);
    }

    private static void ValidateData(PostCreationDto postToCreate)
    {
        // TODO post rules
    }
}