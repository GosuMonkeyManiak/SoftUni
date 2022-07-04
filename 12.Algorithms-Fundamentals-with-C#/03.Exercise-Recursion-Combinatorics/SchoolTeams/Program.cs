namespace SchoolTeams
{
    using System;

    class Program
    {
        static string[] girls;
        static string[] boys;
        static string[] teams;

        static void Main(string[] args)
        {
            girls = Console.ReadLine().Split(", ");
            boys = Console.ReadLine().Split(", ");
            teams = new string[5];

            GenerateTeams(0, 0, 0);
        }

        static void GenerateTeams(int index, int boysStart, int girlStart)
        {
            if (index >= teams.Length)
            {
                Console.WriteLine(string.Join(", ", teams));
                return;
            }

            if (index <= 2)
            {
                for (int i = girlStart; i < girls.Length; i++)
                {
                    teams[index] = girls[i];
                    GenerateTeams(index + 1, boysStart, i + 1);
                }
            }
            else
            {
                for (int i = boysStart; i < boys.Length; i++)
                {
                    teams[index] = boys[i];
                    GenerateTeams(index + 1, i + 1, girlStart);
                }
            }
        }
    }
}