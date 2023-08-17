using MechaSync.Domain;
using Microsoft.EntityFrameworkCore;

namespace MechaSync.Infrastructure.Context
{
    public class MechaSyncDbContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<User> User { get; set; }
        
        public MechaSyncDbContext(DbContextOptions<MechaSyncDbContext> options) : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=BOTELHO\\SQLEXPRESS;Database=MechaSync;Trusted_Connection=true;TrustServerCertificate=true");
        }
    }
}
