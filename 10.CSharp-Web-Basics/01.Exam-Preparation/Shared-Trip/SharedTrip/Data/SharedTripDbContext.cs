namespace SharedTrip.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SharedTripDbContext : DbContext
    {
        public SharedTripDbContext()
        {   
        }

        public DbSet<User> Users { get; init; }

        public DbSet<Trip> Trips { get; init; }

        public DbSet<UserTrip> UsersTrips { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>(entity =>
            {
                entity
                    .HasKey(k => new { k.UserId, k.TripId });

                entity
                    .HasOne(o => o.User)
                    .WithMany(m => m.UserTrips)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(o => o.Trip)
                    .WithMany(m => m.UserTrips)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
