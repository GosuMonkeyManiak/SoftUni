using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Principal;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, ISoldier> soldiersById = new Dictionary<string, ISoldier>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] parts = line.Split();

                string type = parts[0];
                string id = parts[1];
                string firstName = parts[2];
                string lastName = parts[3];

                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(parts[4]);

                    soldiersById[id] = new Private(id, firstName, lastName, salary);
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(parts[4]);

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < parts.Length; i++)
                    {
                        string currentId = parts[i];

                        if (!soldiersById.ContainsKey(currentId))
                        {
                            continue;
                        }

                        lieutenantGeneral.AddPrivate((IPrivate)soldiersById[currentId]);
                    }

                    soldiersById[id] = lieutenantGeneral;
                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(parts[4]);

                    bool isCorpsValid = Enum.TryParse(parts[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < parts.Length; i += 2)
                    {
                        string partName = parts[i];
                        int hoursWorked = int.Parse(parts[i + 1]);

                        engineer.AddRepair(new Repair(partName, hoursWorked));
                    }

                    soldiersById[id] = engineer;
                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(parts[4]);

                    bool isCorpsValid = Enum.TryParse(parts[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < parts.Length; i += 2)
                    {
                        string codeName = parts[i];
                        string state = parts[i + 1];

                        bool isMissionValid = Enum.TryParse(state, out MissionState missionState);

                        if (!isMissionValid)
                        {
                            continue;
                        }

                        commando.AddMission(new Mission(codeName, missionState));
                    }

                    soldiersById[id] = commando;
                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(parts[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiersById[id] = spy;
                }

            }

            foreach (var soldier in soldiersById)
            {
                Console.WriteLine(soldier.Value.ToString());
            }
        }
    }
}
