namespace StudentRegistrationFormsApp.EF_Classes
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentRegistrationEntities : DbContext
    {
        public StudentRegistrationEntities()
            : base("name=StudentRegistrationConnection")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("Registration").MapLeftKey(new[] { "CourseId", "DepartmentId" }).MapRightKey("StudentId"));

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.CourseDepartmentId)
                .WillCascadeOnDelete(true);
        }
    }
}
