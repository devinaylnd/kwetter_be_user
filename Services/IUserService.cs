using kwetter_user.Models.User;

namespace kwetter_user.Services;

public interface IUserService
{
    Task<UserEntity?> CreateUser(UserEntity data);
    Task<UserEntity?> EditUser(UserEntity data);
    Task<UserEntity?> GetUser(int id);
    // Task<UserEntity?> GetUsername(String username);
    Task<bool> DeleteUser(int id);
}