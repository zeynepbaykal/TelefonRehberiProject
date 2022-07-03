using Microsoft.EntityFrameworkCore;
using TelefonRehberiWeb.Models;

namespace TelefonRehberiWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Rehber> Rehbers { get;set; }
        public DbSet<User> Users { get; set; }
    }
}
