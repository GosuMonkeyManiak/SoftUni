using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numbersTeam = int.Parse(Console.ReadLine());

            List<Team> allTeams = new List<Team>();

            for (int i = 0; i < numbersTeam; i++)
            {
                string[] inPut = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Team newTeam = new Team(inPut[1], inPut[0]);

                if (!allTeams.Select(x => x.TeamName).Contains(inPut[1]))
                {
                    if (!allTeams.Select(x => x.Founder).Contains(inPut[0]))
                    {
                        allTeams.Add(newTeam);
                        Console.WriteLine($"Team {inPut[1]} has been created by {inPut[0]}!");
                    }
                    else
                    {
                        Console.WriteLine($"{inPut[0]} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {inPut[1]} was already created!");
                }
            }


            while (true)
            {
                string members = Console.ReadLine();
                if (members == "end of assignment")
                {
                    break;
                }

                string[] splitMembers = members
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!allTeams.Select(x => x.TeamName).Contains(splitMembers[1]))
                {
                    Console.WriteLine($"Team {splitMembers[1]} does not exist!");
                }
                else if (allTeams.Select(x => x.Members).Any(x => x.Contains(splitMembers[0])))
                {
                    Console.WriteLine($"Member {splitMembers[0]} cannot join team {splitMembers[1]}!");
                }
                else
                {
                    int indexTeam = allTeams.FindIndex(x => x.TeamName == splitMembers[1]);
                    allTeams[indexTeam].Members.Add(splitMembers[0]);
                }
            }

            List<Team> disband = new List<Team>();

            for (int i = 0; i < allTeams.Count; i++)
            {
                allTeams[i].Members.RemoveAt(0);
            }

            disband = allTeams.
                OrderBy(x => x.TeamName).
                Where(x => x.Members.Count == 0).
                ToList();

            allTeams = allTeams.
                OrderByDescending(m => m.Members.Count)
                .ThenBy(n => n.TeamName)
                .Where(x => x.Members.Count > 0)
                .ToList();

            for (int i = 0; i < allTeams.Count; i++) //outPut
            {
                Console.WriteLine(allTeams[i].TeamName);

                Console.WriteLine($"- {allTeams[i].Founder}");

                foreach (var item in allTeams[i].Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {item}");
                }
            }

            Console.WriteLine("Teams to disband:"); //outPut
            for (int i = 0; i < disband.Count; i++)
            {
                Console.WriteLine(disband[i].TeamName);
            }

        }
    }
}
