using System;
using System.Collections.Generic;
using System.Linq;

namespace FootBallTeamGenerator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                string[] parts = line
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                switch (command.ToLower())
                {
                    case "team":

                        if (teams.ContainsKey(parts[1]))
                        {
                            continue;
                        }

                        try
                        {
                            teams.Add(parts[1], new Team(parts[1]));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    case "add":
                        //Add;{TeamName};{PlayerName};{Endurance};{Sprint};{Dribble};{Passing};{Shooting}" 

                        string teamName = parts[1];
                        string playerName = parts[2];

                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        int endurance = int.Parse(parts[3]);
                        int sprint = int.Parse(parts[4]);
                        int dribble = int.Parse(parts[5]);
                        int passing = int.Parse(parts[6]);
                        int shooting = int.Parse(parts[7]);

                        try
                        {
                            teams[teamName].AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    case "remove":
                        teamName = parts[1];
                        playerName = parts[2];

                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        try
                        {
                            teams[teamName].RemovePlayer(playerName);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    case "rating":
                        teamName = parts[1];

                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        Console.WriteLine($"{teams[teamName].Name} - {teams[teamName].Rating}");
                        break;
                }
            }
        }
    }
}
