using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string username = Console.ReadLine();

                usernames.Add(username);
            }

            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
