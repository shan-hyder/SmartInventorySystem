using Microsoft.EntityFrameworkCore;
using SmartInventorySystem.Entities;
namespace SmartInventorySystem.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options):base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //for category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(c => c.Name).
                IsRequired().HasMaxLength(100);
                entity.HasQueryFilter(c => c.IsActive);

            });

            //for Product

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(p => p.Name).IsRequired()
                .HasMaxLength(200);
                entity.Property(p => p.Price).IsRequired().
                HasColumnType("decimal(18,2)");

                entity.HasOne(p => p.Category).WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);

                entity.HasQueryFilter(p => p.IsActive);

            });


        }
    }
   
}
