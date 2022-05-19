namespace SMS.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SMSDbContext : DbContext
    {
        public SMSDbContext()
        {
            
        }

        public DbSet<User> Users { get; init; }

        public DbSet<Product> Products { get; init; }

        public DbSet<Cart> Carts { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<User>(u => u.CartId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Product>()
                .HasOne(p => p.Cart)
                .WithMany(c => c.Products)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}