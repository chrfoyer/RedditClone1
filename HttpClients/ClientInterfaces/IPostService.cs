using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task<ICollection<Post>> GetAsync(
    string? userName,
    int? userId,
    string? titleContains,
    string? bodyContains
        );
    Task<Post> GetByIdAsync(int id);
}