﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    [Table("Courses")]
    public class Course
    {
        public Course()
        {
            Resources = new List<Resource>();
            HomeworkSubmissions = new List<Homework>();
            StudentsEnrolled = new List<StudentCourse>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [DataType("nvarchar(80)")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }

        public ICollection<StudentCourse> StudentsEnrolled { get; set; }
    }
}