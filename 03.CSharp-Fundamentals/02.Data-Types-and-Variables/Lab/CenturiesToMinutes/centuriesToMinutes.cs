using System;

namespace CenturiesToMinutes
{
    class centuriesToMinutes
    {
        static void Main(string[] args)
        {
            byte century = byte.Parse(Console.ReadLine());
            ushort years = (ushort)(century * 100);
            uint days = (uint)(years * 365.2422);
            ulong hours = days * 24;
            ulong minutes = hours * 60;

            Console.WriteLine($"{century} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
