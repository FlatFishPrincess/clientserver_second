using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace StudentRegistrationCodeFirstApp.EF_Classes
{
    // classes for initializing database tables for CodeFirstFromBlank
    //  not used for anything else!!

    // Student - corresponds to Students table records
    [Table("Students")]
    public class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }

        [DisplayName("Student ID")]
        public int StudentId { get; set; } // Key automatically set with IDENTITY

        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string StudentFirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string StudentLastName { get; set; }

        [StringLength(10)]
        [DisplayName("Major")]
        public string StudentMajor { get; set; }

        // can't find a way to disable autogen for datagridview
        // have to do it manually

        public virtual ICollection<Course> Courses { get; set; }
    }

    // Department - corresponds to Departments table records

    [Table("Departments")]
    public class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
        }
        [Key]
        [StringLength(10)]
        [DisplayName("Department ID")]
        public string DepartmentId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }

    // Course - corresponds to Courses table records

    [Table("Courses")]
    public class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        [Column(Order = 0)]
        [DisplayName("Course ID")]
        // use the following if we do not want IDENTITY set
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Department")]
        [DisplayName("Department")]
        public string DepartmentId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Course Name")]
        public string CourseName { get; set; }

        public Department Department { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }

}
