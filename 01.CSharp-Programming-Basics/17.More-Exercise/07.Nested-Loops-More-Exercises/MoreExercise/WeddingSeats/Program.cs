namespace WeddingSeats
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine()); //start from A
            int numberRowInFirstSector = int.Parse(Console.ReadLine()); //every next row increase with 1
            int numberOfSeatOddRows = int.Parse(Console.ReadLine()); //even row seat + 2

            int numberOfSeat = 0;

            for (int i = 65; i <= (int) lastSector; i++)
            {
                for (int j = 1; j <= numberRowInFirstSector; j++)
                {
                    if (j % 2 == 0)
                    {
                        for (int k = 97; k < 97 + numberOfSeatOddRows + 2; k++)
                        {
                            Console.WriteLine($"{(char)i}{j}{(char)k}");
                            numberOfSeat++;
                        }
                    }
                    else if (j % 2 != 0)
                    {
                        for (int k = 97; k < 97 + numberOfSeatOddRows; k++)
                        {
                            Console.WriteLine($"{(char)i}{j}{(char)k}");
                            numberOfSeat++;
                        }
                    }
                }

                numberRowInFirstSector++;
            }

            Console.WriteLine(numberOfSeat);
        }
    }
}
