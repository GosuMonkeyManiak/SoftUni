using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Party!")
                {
                    break;
                }

                string removeOrDouble = tokens[0];
                string startEndLenght = tokens[1];
                string digitOrString = tokens[2];

                Func<string, bool> condition = GetCondition(removeOrDouble, startEndLenght, digitOrString);

                DoTheOperation(guests, removeOrDouble, condition);
            }

            string result = "";

            if (guests.Count > 0)
            {
                result = string.Join(", ", guests) + " are going to the party!";
            }
            else
            {
                result = "Nobody is going to the party!";
            }

            Console.WriteLine(result);
        }

        static void DoTheOperation(List<string> guests, string operation, Func<string, bool> condition)
        {
            for (int i = 0; i < guests.Count; i++)
            {
                if (operation.ToLower() == "remove" && condition(guests[i]))
                {
                    guests.RemoveAt(i);
                    i--;
                }
                else if (operation.ToLower() == "double" && condition(guests[i]))
                {
                    guests.Insert(i + 1, guests[i]);
                    i += 1;
                }

                
            }
        }

        static Func<string, bool> GetCondition(string first, string second, string third)
        {
            if (first.ToLower() == "remove")
            {
                switch (second.ToLower())
                {
                    case "startswith": return x => x.Substring(0, third.Length) == third;
                    case "endswith": return x => x.Substring(x.Length - third.Length, third.Length) == third;
                    case "length": return x => x.Length == int.Parse(third);
                    default: return null;
                }
            }
            else if (first.ToLower() == "double")
            {
                switch (second.ToLower())
                {
                    case "startswith": return x => x.Substring(0, third.Length) == third;
                    case "endswith": return x => x.Substring(x.Length - third.Length, third.Length) == third;
                    case "length": return x => x.Length == int.Parse(third);
                    default: return null;
                }
            }

            return null;    
        }
    }
}
