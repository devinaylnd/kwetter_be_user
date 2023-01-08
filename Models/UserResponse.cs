namespace kwetter_user.Models.User;

public class UserResponse
{
    public int id { get; }
    public string? email { get; set; }
    public string? username { get; }
    public string? name { get; }
    public string? bio { get; }
    public string? location { get; }
    public string? userPic { get; set; }
    public string? createdAt { get; set; }
    public string? accessToken { get; set; }

    public UserResponse(UserEntity user)
    {
        id = user.id;
        email = user.email;
        username = user.username;
        name = user.name;
        bio = user.bio;
        location = user.location;
        userPic = user.userPic;
        createdAt = user.createdAt;
        accessToken = user.accessToken;
    }
}