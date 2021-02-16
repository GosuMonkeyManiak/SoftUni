using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            students = new List<Student>();
            Capacity = capacity;
        }

        public int Capacity { get; set; }

        public int Count { get => students.Count; }

        public string RegisterStudent(Student student)
        {
            if (Capacity == students.Count)
            {
                return "No seats in the classroom";
            }

            students.Add(student);

            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }

            return $"Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> subjectStudents = students
                .Where(x => x.Subject == subject)
                .ToList();

            if (subjectStudents.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine($"Students:");

            foreach (var student in subjectStudents)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString().Trim();
        }

        public int GetStudentsCount() => Count;

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
