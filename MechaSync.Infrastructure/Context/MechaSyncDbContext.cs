using MechaSync.Domain;
using Microsoft.EntityFrameworkCore;

namespace MechaSync.Infrastructure.Context
{
    public class MechaSyncDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServiceCategoryRelation> ServiceCategoryRelations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public MechaSyncDbContext(DbContextOptions<MechaSyncDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Chave composta para ServiceCategoryRelation
            modelBuilder.Entity<ServiceCategoryRelation>()
                .HasKey(sc => new { sc.ServiceId, sc.CategoryId });

            // Definição de relacionamentos
            modelBuilder.Entity<ServiceCategoryRelation>()
                .HasOne(sc => sc.Service)
                .WithMany(s => s.ServiceCategoryRelations)
                .HasForeignKey(sc => sc.ServiceId);

            modelBuilder.Entity<ServiceCategoryRelation>()
                .HasOne(sc => sc.ServiceCategory)
                .WithMany(sc => sc.ServiceCategoryRelations)
                .HasForeignKey(sc => sc.CategoryId);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=BDC;Database=MechaSync;Trusted_Connection=true;TrustServerCertificate=true");
        //}
    }
}