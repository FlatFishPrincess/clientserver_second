namespace StudentRegistrationCodeFirstApp.EF_Classes
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentRegistrationEntities : DbContext
    {
        // Your context has been configured to use a 'StudentRegistrationEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'StudentRegistrationCodeFirstApp.EF_Classes.StudentRegistrationEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StudentRegistrationEntities' 
        // connection string in the application configuration file.
        public StudentRegistrationEntities()
            : base("name=StudentRegistrationConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("StudentCourses")
                .MapLeftKey(new[] { "CourseId", "DepartmentId" }).MapRightKey("StudentId"));

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(true);
        }
    }
}