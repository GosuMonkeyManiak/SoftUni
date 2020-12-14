using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemThree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> allUsers = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Statistics")
                {
                    break;
                }

                string commnad = tokens[0];
                string userName = tokens[1];

                switch (commnad)
                {
                    case "Add":

                        if (allUsers.ContainsKey(userName))
                        {
                            Console.WriteLine($"{userName} is already registered");
                        }
                        else
                        {
                            allUsers.Add(userName, new List<string>());
                        }
                        break;

                    case "Send":
                        string toThisEmail = tokens[2];

                        if (allUsers.ContainsKey(userName))
                        {
                            allUsers[userName].Add(toThisEmail);
                        }
                        break;

                    case "Delete":

                        if (allUsers.ContainsKey(userName))
                        {
                            allUsers.Remove(userName);
                        }
                        else
                        {
                            Console.WriteLine($"{userName} not found!");
                        }
                        break;
                    
                }

            }

            Console.WriteLine($"Users count: {allUsers.Count}");

            allUsers = allUsers.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var user in allUsers)
            {
                Console.WriteLine($"{user.Key}");

                foreach (var sendEmail in user.Value)
                {
                    Console.WriteLine($"- {sendEmail}");
                }
            }
        }
    }
}
