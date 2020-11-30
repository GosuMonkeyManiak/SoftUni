using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBAChallenger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] separators = { " -> ", " vs " };

            Dictionary<string, List<Positions>> allPlayers = new Dictionary<string, List<Positions>>();

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Season end")
                {
                    break;
                }

                string firstPlayer = command[0];

                if (command.Length <= 2) //vs
                {
                    string secondPlayer = command[1];

                    if (allPlayers.ContainsKey(firstPlayer) && allPlayers.ContainsKey(secondPlayer))
                    {
                        int firstPositionIndex = -1;
                        int secondPositionIndex = -1;

                        foreach (var first in allPlayers[firstPlayer])
                        {
                            Positions temp = allPlayers[secondPlayer].Where(x => x.Position == first.Position).FirstOrDefault();

                            if (temp != null)
                            {
                                firstPositionIndex = allPlayers[firstPlayer].FindIndex(x => x.Position == first.Position);
                                secondPositionIndex = allPlayers[secondPlayer].FindIndex(x => x.Position == first.Position);
                                break;
                            }
                        }

                        if (firstPositionIndex == -1 && secondPositionIndex == -1)
                        {
                            continue;
                        }

                        if (allPlayers[firstPlayer][firstPositionIndex].Skill > allPlayers[secondPlayer][secondPositionIndex].Skill)
                        {
                            allPlayers.Remove(secondPlayer);
                        }
                        else if (allPlayers[firstPlayer][firstPositionIndex].Skill < allPlayers[secondPlayer][secondPositionIndex].Skill)
                        {
                            allPlayers.Remove(firstPlayer);
                        }
                    }
                }
                else //add
                {
                    string currentPosition = command[1];
                    int currentSkill = int.Parse(command[2]);

                    if (allPlayers.ContainsKey(firstPlayer))
                    {
                        Positions thatPosition = allPlayers[firstPlayer]
                            .Where(x => x.Position == currentPosition)
                            .FirstOrDefault();

                        if (thatPosition == null)
                        {
                            allPlayers[firstPlayer].Add(new Positions() 
                            {
                                Position = currentPosition,
                                Skill = currentSkill
                            });
                        }
                        else
                        {
                            int thatPositionIndex = allPlayers[firstPlayer].FindIndex(x => x.Position == currentPosition);

                            if (allPlayers[firstPlayer][thatPositionIndex].Skill < currentSkill)
                            {
                                allPlayers[firstPlayer][thatPositionIndex].Skill = currentSkill;
                            }
                        }
                    }
                    else
                    {
                        allPlayers.Add(firstPlayer, new List<Positions>());

                        Positions newPosition = new Positions()
                        {
                            Position = currentPosition,
                            Skill = currentSkill
                        };

                        allPlayers[firstPlayer].Add(newPosition);
                    }

                }

            }


            allPlayers = allPlayers.
                OrderByDescending(x => x.Value.Sum(x => x.Skill))
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var player in allPlayers)
            {
                Console.WriteLine($"{player.Key}: {player.Value.Sum(x => x.Skill)} skill");

                foreach (var position in player.Value.OrderByDescending(x => x.Skill).ThenBy(x => x.Position))
                {
                    Console.WriteLine($"- {position.Position} <::> {position.Skill}");
                }
            }

        }
    }

    
}
