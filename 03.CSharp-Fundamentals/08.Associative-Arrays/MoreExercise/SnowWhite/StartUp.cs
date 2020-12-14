using System;
using System.Collections.Generic;
using System.Linq;

namespace SnowWhite
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //{dwarfName} <:> {dwarfHatColor} <:> {dwarfPhysics}
            Dictionary<string, Dwarf> allDwarf = new Dictionary<string, Dwarf>();

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Once upon a time")
                {
                    break;
                }

                string dwarfName = commands[0];
                string dwarfHatColor = commands[1];
                int dwarfPhysics = int.Parse(commands[2]);

                if (allDwarf.ContainsKey(dwarfHatColor))
                {
                    if (allDwarf[dwarfHatColor].Name == dwarfName && allDwarf[dwarfHatColor].Physics < dwarfPhysics)
                    {
                        allDwarf[dwarfHatColor].Physics = dwarfPhysics;
                    }
                }
                if ()
                {

                }
                else
                {
                       
                }
            }
        }
    }
}
