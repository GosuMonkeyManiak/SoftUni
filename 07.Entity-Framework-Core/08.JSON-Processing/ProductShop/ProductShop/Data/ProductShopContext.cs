namespace ProductShop.Data
{
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
        }

        public ProductShopContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=ProductShop;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(x => new { x.CategoryId, x.ProductId});

                entity
                    .HasOne(cp => cp.Product)
                    .WithMany(p => p.CategoryProducts)
                    .HasForeignKey(fk => fk.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(cp => cp.Category)
                    .WithMany(c => c.CategoryProducts)
                    .HasForeignKey(fk => fk.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(x => x.ProductsBought)
                      .WithOne(x => x.Buyer)
                      .HasForeignKey(x => x.BuyerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(x => x.ProductsSold)
                      .WithOne(x => x.Seller)
                      .HasForeignKey(x => x.SellerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity
                    .HasMany(p => p.CategoryProducts)
                    .WithOne(cp => cp.Product)
                    .HasForeignKey(fk => fk.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity
                    .HasMany(c => c.CategoryProducts)
                    .WithOne(cp => cp.Category)
                    .HasForeignKey(fk => fk.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}