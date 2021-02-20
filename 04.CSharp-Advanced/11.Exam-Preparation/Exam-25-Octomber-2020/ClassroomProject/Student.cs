﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Student
    {
        public Student(string firstName, string lastname, string subject)
        {
            FirstName = firstName;
            LastName = lastname;
            Subject = subject;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Subject { get; set; }

        public override string ToString()
        {
            return $"Student: First Name = {FirstName}, Last Name = {LastName}, Subject = {Subject}";
        }
    }
}