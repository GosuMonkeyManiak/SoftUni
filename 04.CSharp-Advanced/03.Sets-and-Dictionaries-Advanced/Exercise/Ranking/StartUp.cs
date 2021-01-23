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
            SortedDictionary<string, Dictionary<string, int>> students = new SortedDictionary<string, Dictionary<string, int>>();


            while (true)
            {
                string[] contest = Console.ReadLine()
                    .Split(new char[] {':','=','>' }, StringSplitOptions.RemoveEmptyEntries);
                if (contest[0] == "end of contests")
                {
                    break;
                }

                string currentContest = contest[0];
                string passwordForContest = contest[1];

                if (!contests.ContainsKey(currentContest))
                {
                    contests.Add(currentContest, passwordForContest);
                }

            }

            while (true)
            {
                string[] examInfo = Console.ReadLine()
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                if (examInfo[0] == "end of submissions")
                {
                    break;
                }

                string contest = examInfo[0];
                string password = examInfo[1];
                string username = examInfo[2];
                int points = int.Parse(examInfo[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (students.ContainsKey(username) && students[username].ContainsKey(contest) && students[username][contest] < points)
                    {
                        students[username][contest] = points;
                    }
                    else if (!students.ContainsKey(username))
                    {
                        students.Add(username, new Dictionary<string, int>());
                        students[username].Add(contest, points);
                    }
                    else if (!students[username].ContainsKey(contest))
                    {
                        students[username].Add(contest, points);
                    }
                    
                }

            }

            int max = int.MinValue;
            string user = "";

            foreach (var student in students)
            {
                int currentSum = 0;
                foreach (var contest in student.Value)
                {
                    currentSum += contest.Value;
                }

                if (currentSum > max)
                {
                    max = currentSum;
                    user = student.Key;
                }
            }
            
            Console.WriteLine($"Best candidate is {user} with total {max} points.");
            Console.WriteLine("Ranking:");

            foreach (var student in students)
            {
                Console.WriteLine(student.Key);

                foreach (var contest in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }
    }
}
