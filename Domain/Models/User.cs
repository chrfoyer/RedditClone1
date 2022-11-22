using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models;

public class User
{
    [Key] public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    [JsonIgnore] public ICollection<Post> Posts { get; set; }

    public User(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}