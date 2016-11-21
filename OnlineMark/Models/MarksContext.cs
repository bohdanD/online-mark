using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineMark.Models
{
    public class MarksContext : DbContext
    {
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .Map(t => { t.MapLeftKey("CourseId");
                    t.MapRightKey("StudentId");
                    t.ToTable("CourseStudent"); });
                
        }
    }
}