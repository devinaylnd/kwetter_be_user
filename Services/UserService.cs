using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using kwetter_user.DbContext;
using kwetter_user.Models.User;

namespace kwetter_user.Services;

public class UserService : IUserService
{
    private ApplicationDbContext _context;  

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserEntity?> CreateUser(UserEntity data)
    {
        try
        {
            var entry = _context.users.Add(data);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
        catch (Exception) { return null; }
    }

    public async Task<UserEntity?> EditUser(UserEntity data)
    {
        try
        {
            EntityEntry<UserEntity> entry = _context.Update(data);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
        catch (Exception) { return null; }
    }

    public async Task<UserEntity?> GetUser(int id)
    {
        try
        {
            var user = await _context.users.Where(q => q.id == id).FirstOrDefaultAsync();
            return user;
        }
        catch (Exception) { return null; }
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await GetUser(id);
        if (user == null) return false; 

        _context.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}