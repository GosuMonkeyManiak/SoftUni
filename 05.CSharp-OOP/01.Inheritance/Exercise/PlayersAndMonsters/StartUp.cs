using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Elf elf = new Elf("Peho", 120);

            Console.WriteLine(elf);

            SoulMaster soulMaster = new SoulMaster("Gigi", 525);

            Console.WriteLine(soulMaster);
        }
    }
}