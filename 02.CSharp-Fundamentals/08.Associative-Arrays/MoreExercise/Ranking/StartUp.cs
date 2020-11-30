using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            while (true)
            {
                string[] inPut = Console.ReadLine()
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);
                if (inPut[0] == "end of contests")
                {
                    break;
                }

                string contestName = inPut[0];
                string contestPassword = inPut[1];

                contests.Add(contestName, contestPassword);
            }

            Dictionary<string, List<Contests>> students = new Dictionary<string, List<Contests>>();

            while (true)
            {
                string[] inPut = Console.ReadLine()
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                if (inPut[0] == "end of submissions")
                {
                    break;
                }

                string contest = inPut[0];
                string password = inPut[1];
                string username = inPut[2];
                int points = int.Parse(inPut[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    Contests contestForAdd = new Contests
                    {
                        Contest = contest,
                        Points = points
                    };

                    if (students.ContainsKey(username))
                    {
                        Contests sample = students[username].Where(x => x.Contest == contestForAdd.Contest).FirstOrDefault();

                        if (sample == null)
                        {
                            students[username].Add(contestForAdd);
                        }
                        else
                        {
                            int cuurentContestIndex = students[username].FindIndex(x => x.Contest == contestForAdd.Contest);

                            if (students[username][cuurentContestIndex].Points < contestForAdd.Points)
                            {
                                students[username][cuurentContestIndex].Points = contestForAdd.Points;
                            }
                        }
                    }
                    else
                    {
                        students.Add(username, new List<Contests>());
                        students[username].Add(contestForAdd);
                    }

                }

            }

            int max = int.MinValue;
            string name = string.Empty;

            foreach (var student in students)
            {
                int currentSum = student.Value.Sum(x => x.Points);

                if (currentSum > max)
                {
                    max = currentSum;
                    name = student.Key;
                }
            }

            Console.WriteLine($"Best candidate is {name} with total {max} points.");
            Console.WriteLine("Ranking: ");

            students = students.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key}");

                foreach (var contest in student.Value.OrderByDescending(x => x.Points))
                {
                    Console.WriteLine($"#  {contest.Contest} -> {contest.Points}");
                }
            }

        }
    }
}
