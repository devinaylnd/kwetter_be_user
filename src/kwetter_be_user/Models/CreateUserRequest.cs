namespace kwetter_user.Models.User;

public class CreateUserRequest
{
    public string? email { get; set; }
    public string? username { get; set; }
    public string? name { get; set; }
    public string? bio { get; set; }
    public string? location { get; set; }
    public string? userPic { get; set; }
    public string? createdAt { get; set; }
    public string? accessToken { get; set; }
}