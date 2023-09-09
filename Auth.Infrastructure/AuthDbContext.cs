using Auth.Base.Models.Entities;
using Auth.UserAuth.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<AccessToken> AccessTokens { get; set; }
    }
}