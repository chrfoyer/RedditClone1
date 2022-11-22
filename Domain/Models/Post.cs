using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Post
{
    [Key]
    public int Id { get; set; }
    public User User { get; private set; }
    public string Title { get; private set; }
    public string Body { get; set; }

    public Post(User user, string title, string body)
    {
        User = user;
        Title = title;
        Body = body;
    }

    private Post()
    {
    }
}