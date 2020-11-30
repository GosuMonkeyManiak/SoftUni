using System;

namespace Building
{
    class Building
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            string typeRoom = ""; 

            for (int i = floors; i > 0; i--)
            {
                for (int j = 0; j < rooms; j++)
                {
                    if (i ==  floors)
                    {
                        typeRoom = "L";
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            typeRoom = "O";
                        }
                        else
                        {
                            typeRoom = "A";
                        }
                    }
                    Console.Write($"{typeRoom}{i}{j} ");
                }
                Console.WriteLine();
            }
        }
    }
}
