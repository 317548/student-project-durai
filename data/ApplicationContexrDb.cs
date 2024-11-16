

// Data/EnrollmentContext.cs
using enrollment.models;
using Microsoft.EntityFrameworkCore;
using StudentCourseEnrollment.Models;

public class EnrollmentContext : DbContext
{
    public EnrollmentContext(DbContextOptions<EnrollmentContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Courses> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enrollment>()
            .HasKey(e => new { e.StudentId, e.CourseId });

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId);
    }
}

