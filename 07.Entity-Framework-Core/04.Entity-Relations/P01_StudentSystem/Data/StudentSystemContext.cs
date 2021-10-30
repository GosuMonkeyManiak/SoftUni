using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public StudentSystemContext()
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                //entity.Property(e => e.StudentId)
                //    .ValueGeneratedOnAdd();

                entity.HasCheckConstraint("CHK_PhoneNumber", "LEN(PhoneNumber) = 10");

            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .ValueGeneratedOnAdd();
                
                entity.Property(e => e.Description)
                    .IsUnicode();
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.ResourceId)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Url)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceType)
                    .HasConversion<string>();

                entity.HasCheckConstraint("CHK_ResourceType", "ResourceType IN ('Video', 'Presentation', 'Document', 'Other')");

                entity
                    .HasOne(e => e.Course)
                    .WithMany(e => e.Resources)
                    .HasForeignKey(e => e.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(e => e.HomeworkId)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CourseId)
                    .IsUnicode(false);

                entity.Property(e => e.ContentType)
                    .HasConversion<string>();

                entity.HasCheckConstraint("CHK_ContentType", "ContentType IN ('Application', 'Pdf', 'Zip')");

                entity
                    .HasOne(e => e.Course)
                    .WithMany(e => e.HomeworkSubmissions)
                    .HasForeignKey(e => e.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(e => e.Student)
                    .WithMany(e => e.HomeworkSubmissions)
                    .HasForeignKey(e => e.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });

                entity
                    .HasOne(e => e.Student)
                    .WithMany(e => e.CourseEnrollments)
                    .HasForeignKey(e => e.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(e => e.Course)
                    .WithMany(e => e.StudentsEnrolled)
                    .HasForeignKey(e => e.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}