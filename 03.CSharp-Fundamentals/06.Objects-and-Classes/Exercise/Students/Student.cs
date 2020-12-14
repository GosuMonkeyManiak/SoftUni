using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
    class Student
    {
        private string firstName;
        private string secondName;
        private double grade;

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        public string SecondName
        {
            get { return this.secondName; }
            set { this.secondName = value; }
        }
        public double Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }

        public Student(string firstName, string secondName, double grade)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.grade = grade;
        }
    }
}
