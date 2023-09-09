using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}