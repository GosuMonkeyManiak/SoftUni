using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> individualStatistics = new Dictionary<string, int>();
            Dictionary<string, List<Person>> allContest = new Dictionary<string, List<Person>>();

            while (true)
            {
                string[] inPut = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (inPut[0] == "no more time")
                {
                    break;
                }

                string username = inPut[0];
                string contest = inPut[1];
                int points = int.Parse(inPut[2]);

                if (allContest.ContainsKey(contest))
                {
                    Person temp = allContest[contest].Where(x => x.Username == username).FirstOrDefault();

                    if (temp == null)
                    {
                        allContest[contest].Add(new Person() 
                        {
                            Username = username,
                            Score = points
                        });
                    }
                    else
                    {
                        int index = allContest[contest].FindIndex(x => x.Username == username);

                        if (temp.Score < points)
                        {
                            allContest[contest][index].Score = points;
                        }
                    }
                }
                else
                {
                    allContest.Add(contest, new List<Person>());
                    Person newPerson = new Person
                    {
                        Username = username,
                        Score = points
                    };
                    allContest[contest].Add(newPerson);
                }

            }

            foreach (var contest in allContest)
            {
                foreach (var item in contest.Value)
                {
                    if (individualStatistics.ContainsKey(item.Username))
                    {
                        individualStatistics[item.Username] += item.Score;
                    }
                    else
                    {
                        individualStatistics.Add(item.Username, item.Score);
                    }
                }
            }

            int count = 1;

            foreach (var contest in allContest)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                count = 1;
                foreach (var item in contest.Value.OrderByDescending(x => x.Score).ThenBy(x => x.Username))
                {
                    Console.WriteLine($"{count}. {item.Username} <::> {item.Score}");
                    count++;
                }
            }

            Console.WriteLine($"Individual standings: ");

            count = 1;

            foreach (var student in individualStatistics.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{count}. {student.Key} -> {student.Value}");
                count++;
            }
        }
    }
}
