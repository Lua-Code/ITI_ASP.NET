using ITI_ASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_ASP.NET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainee>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Trainees)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Course)
                .WithMany(c => c.Instructors)
                .HasForeignKey(i => i.CourseId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId);

            modelBuilder.Entity<CourseResult>()
                .HasOne(cr => cr.Course)
                .WithMany(c => c.CourseResults)
                .HasForeignKey(cr => cr.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CourseResult>()
                .HasOne(cr => cr.Trainee)
                .WithMany(t => t.CourseResults)
                .HasForeignKey(cr => cr.TraineeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Course>()
                .Property(c => c.Degree)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Course>()
                .Property(c => c.MinDegree)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CourseResult>()
                .Property(cr => cr.Degree)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Instructor>()
                .Property(i => i.Salary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Trainee>()
                .Property(t => t.Grade)
                .HasPrecision(18, 2);
        }
    }
}