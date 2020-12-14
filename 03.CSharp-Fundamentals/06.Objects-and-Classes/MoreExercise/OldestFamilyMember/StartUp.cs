using System;
using System.Collections.Generic;
using System.Linq;

namespace OldestFamilyMember
{
    class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    class Family
    {
        private List<Person> people;

        public List<Person> People
        {
            get { return this.people; }
            set { this.people = value; }
        }

        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            var temp = people.OrderByDescending(x => x.Age).FirstOrDefault();

            return temp;
        }
    }

    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Person newPerson = new Person(info[0], int.Parse(info[1]));
                family.AddMember(newPerson);
            }

            Person result = family.GetOldestMember();

            Console.WriteLine($"{result.Name} {result.Age}");
        }
    }
}
