using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogeer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, FollowersAndFollowing> vLoggers = new Dictionary<string, FollowersAndFollowing>();

            while (true)
            {
                string[] inPut = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (inPut[0] == "Statistics")
                {
                    break;
                }

                string command = inPut[1];

                if (command == "joined") //{vloggername} joined The V-Logger 
                {
                    string vlogger = inPut[0];

                    if (!vLoggers.ContainsKey(vlogger)) //unique usernames
                    {
                        vLoggers.Add(vlogger, new FollowersAndFollowing()
                        {
                            Followers = new SortedSet<string>(),
                            Following = new SortedSet<string>()
                        });
                    }
                    //if exists ignore the command

                }
                else if (command == "followed") // {vloggername} followed {vloggername}
                {
                    string firstVLogger = inPut[0];
                    string secondVLogger = inPut[2];

                    if (vLoggers.ContainsKey(firstVLogger) && vLoggers.ContainsKey(secondVLogger) && firstVLogger != secondVLogger)
                    {
                        vLoggers[firstVLogger].Following.Add(secondVLogger); //add following
                        vLoggers[secondVLogger].Followers.Add(firstVLogger); //add follower
                    }
                    //ignore
                }


            }

            Console.WriteLine($"The V-Logger has a total of {vLoggers.Count} vloggers in its logs.");

            vLoggers = vLoggers.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count).ToDictionary(x => x.Key, y => y.Value);

            var first = vLoggers.First(); //get the most famous vlogger
            string name = first.Key; //get his name
            var value = first.Value; //get his follower and following

            Dictionary<string, FollowersAndFollowing> firstVlogger = new Dictionary<string, FollowersAndFollowing>
            {
                { name, value }
            };

            vLoggers.Remove(name); //remove the famous from all vloggers

            int index = 1;

            foreach (var famous in firstVlogger)
            {
                Console.WriteLine($"{index}. {famous.Key} : {famous.Value.Followers.Count} followers, {famous.Value.Following.Count} following");

                foreach (var followers in famous.Value.Followers)
                {
                    Console.WriteLine($"*  {followers}");
                }

                index++;
            }


            vLoggers = vLoggers.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count).ToDictionary(x => x.Key, y => y.Value);

            foreach (var vlogger in vLoggers)
            {
                Console.WriteLine($"{index}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");

                index++;
            }

        }
    }
}
