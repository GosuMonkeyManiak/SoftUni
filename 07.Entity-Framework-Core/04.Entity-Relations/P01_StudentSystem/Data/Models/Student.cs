using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    [Table("Students")]
    public class Student
    {
        public Student()
        {
            HomeworkSubmissions = new List<Homework>();
            CourseEnrollments = new List<StudentCourse>();
        }

        [Key]
        public int StudentId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [DataType("char(10)")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }
        
        public DateTime? Birthday { get; set; }
        
        public ICollection<Homework> HomeworkSubmissions { get; set; }
        
        public ICollection<StudentCourse> CourseEnrollments { get; set; }
    }
}