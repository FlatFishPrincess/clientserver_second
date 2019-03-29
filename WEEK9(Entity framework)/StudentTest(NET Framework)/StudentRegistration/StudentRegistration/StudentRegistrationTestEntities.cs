namespace StudentRegistration
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentRegistrationTestEntities : DbContext
    {
        public StudentRegistrationTestEntities()
            : base("name=StudentRegistrationTestEntities")
        {
        }

        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("Registration").MapLeftKey(new[] { "CourseId", "DepartmentId" }).MapRightKey("StudentId"));

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.CourseDepartmentId)
                .WillCascadeOnDelete(false);
        }
    }
}
