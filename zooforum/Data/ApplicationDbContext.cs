using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using zooforum.Data.DataModel;

namespace zooforum.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
             
        }

        public DbSet<Animal> Animal { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-72OO4P4\\SQLEXPRESS;Database=zooforumDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
    
}