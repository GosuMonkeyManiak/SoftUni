namespace ChallengeTheWedding
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());

            int takenTables = 0;

            for (int i = 1; i <= men; i++)
            {
                for (int j = 1; j <= women; j++)
                {
                    if (takenTables == tables)
                    {
                        return;
                    }

                    takenTables++;
                    Console.Write($"({i} <-> {j}) ");
                }
            }
        }
    }
}
