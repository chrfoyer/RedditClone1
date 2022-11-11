namespace Domain.DTOs;

public class SearchPostParametersDto
{
    public string? UserName { get; }
    public int? UserId { get; }
    public string? TitleContains { get; }
    public string? BodyContains { get; }

    public SearchPostParametersDto(string? userName, int? userId, string? titleContains, string? bodyContains)
    {
        UserName = userName;
        UserId = userId;
        TitleContains = titleContains;
        BodyContains = bodyContains;
    }
}