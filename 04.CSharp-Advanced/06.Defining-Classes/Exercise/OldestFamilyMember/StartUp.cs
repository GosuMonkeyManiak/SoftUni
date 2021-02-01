using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = person[0];
                int age = int.Parse(person[1]);

                Person member = new Person(name, age);
                family.AddMember(member);
            }

            Person oldest = family.GetOldestMember();

            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
