using MechaSync.Domain;
using Microsoft.EntityFrameworkCore;

namespace MechaSync.Infrastructure.Context
{
    public class MechaSyncDbContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServiceCategoryRelation> ServiceCategoryRelations { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<InventoryCategory> InventoryCategories { get; set; }
        public DbSet<InventoryItemRelation> InventoryItemRelations { get; set; }
        public DbSet<RepairTracking> RepairTrackings { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<User> Users { get; set; }

        public MechaSyncDbContext(DbContextOptions<MechaSyncDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Chave composta para ServiceCategoryRelation
            modelBuilder.Entity<ServiceCategoryRelation>()
                .HasKey(sc => new { sc.ServiceId, sc.CategoryId });

            modelBuilder.Entity<ServiceCategoryRelation>()
                .HasOne(sc => sc.Service)
                .WithMany(s => s.ServiceCategoryRelations)
                .HasForeignKey(sc => sc.ServiceId);

            modelBuilder.Entity<ServiceCategoryRelation>()
                .HasOne(sc => sc.ServiceCategory)
                .WithMany(sc => sc.ServiceCategoryRelations)
                .HasForeignKey(sc => sc.CategoryId);

            // Chave composta para InventoryItemRelation
            modelBuilder.Entity<InventoryItemRelation>()
                .HasKey(ir => new { ir.InventoryItemId, ir.InventoryCategoryId });

            modelBuilder.Entity<InventoryItemRelation>()
                .HasOne(ir => ir.InventoryItem)
                .WithMany(ii => ii.InventoryItemRelations)
                .HasForeignKey(ir => ir.InventoryItemId);

            modelBuilder.Entity<InventoryItemRelation>()
                .HasOne(ir => ir.InventoryCategory)
                .WithMany(ic => ic.InventoryItemRelations)
                .HasForeignKey(ir => ir.InventoryCategoryId);
        }

    }
}