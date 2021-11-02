using System;
using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

namespace MusicHub.Data
{
    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
            
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public virtual DbSet<Song> Songs { get; set; }

        public virtual DbSet<Writer> Writers { get; set; }

        public virtual DbSet<SongPerformer> SongsPerformers { get; set; }

        public virtual DbSet<Performer> Performers { get; set; }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Producer> Producers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongPerformer>(entity =>
            {
                entity.HasKey(e => new { e.SongId, e.PerformerId });
            });
        }
    }
}
