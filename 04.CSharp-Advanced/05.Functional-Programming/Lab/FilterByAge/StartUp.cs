using System;
using System.Collections.Generic;

namespace FilterByAge
{
    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = GetInPut(n);

            //younger or older
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> conditionLamda = Condition(condition, age);
            Func<Person, string> formatLamda = Formater(format);

            List<Person> filterPeople = Filter(people, conditionLamda);

            Print(filterPeople, formatLamda);
        }

        static void Print(List<Person> filterPeople, Func<Person, string> formatLamda)
        {
            foreach (var person in filterPeople)
            {
                Console.WriteLine(formatLamda(person));
            }
        }

        static Func<Person, string> Formater(string format)
        {
            switch (format)
            {
                case "name": return x => $"{x.Name}";
                case "age": return x => $"{x.Age}";
                case "name age": return x => $"{x.Name} - {x.Age}";
                default: return null;
            }
        }

        static List<Person> Filter(List<Person> people, Func<int, bool> condition)
        {
            List<Person> filterPeople = new List<Person>();

            for (int i = 0; i < people.Count; i++)
            {
                if (condition(people[i].Age))
                {
                    filterPeople.Add(people[i]);
                }
            }

            return filterPeople;
        }

        static Func<int, bool> Condition(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return x => x < age;
                case "older": return x => x >= age;
                default: return null;
            }
        }

        static List<Person> GetInPut(int n)
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] inPut = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person()
                {
                    Name = inPut[0],
                    Age = int.Parse(inPut[1])
                };

                people.Add(person);
            }

            return people;
        }
    }
}
