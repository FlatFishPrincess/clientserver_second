namespace StudentRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        CourseDepartmentId = c.String(nullable: false, maxLength: 10),
                        CourseName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.CourseId, t.CourseDepartmentId })
                .ForeignKey("dbo.Departments", t => t.CourseDepartmentId)
                .Index(t => t.CourseDepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.String(nullable: false, maxLength: 10),
                        DepartmentName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentFirstName = c.String(nullable: false, maxLength: 50),
                        StudentLastName = c.String(nullable: false, maxLength: 50),
                        StudentMajor = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Registration",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        DepartmentId = c.String(nullable: false, maxLength: 10),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.DepartmentId, t.StudentId })
                .ForeignKey("dbo.Courses", t => new { t.CourseId, t.DepartmentId }, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => new { t.CourseId, t.DepartmentId })
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registration", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Registration", new[] { "CourseId", "DepartmentId" }, "dbo.Courses");
            DropForeignKey("dbo.Courses", "CourseDepartmentId", "dbo.Departments");
            DropIndex("dbo.Registration", new[] { "StudentId" });
            DropIndex("dbo.Registration", new[] { "CourseId", "DepartmentId" });
            DropIndex("dbo.Courses", new[] { "CourseDepartmentId" });
            DropTable("dbo.Registration");
            DropTable("dbo.Students");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
        }
    }
}
