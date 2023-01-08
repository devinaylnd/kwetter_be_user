using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kwetter_user.Models.User;

public class UserEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string? email { get; set; }
    public string? username { get; set; }
    public string? name { get; set; }
    public string? bio { get; set; }
    public string? location { get; set; }
    // public int totalFollowing { get; set; }
    // public int totalFollowers { get; set; }
    public string? userPic { get; set; }
    public string? createdAt { get; set; }
    public string? accessToken { get; set; }
}
