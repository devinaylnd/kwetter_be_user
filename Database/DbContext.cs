using Microsoft.EntityFrameworkCore;
using kwetter_user.Models.User;

namespace kwetter_user.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    public DbSet<UserEntity> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var userEntity = modelBuilder.Entity<UserEntity>();
    }
}