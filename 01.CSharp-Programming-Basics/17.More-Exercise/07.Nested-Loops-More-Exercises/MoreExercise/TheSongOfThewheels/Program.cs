namespace TheSongOfThewheels
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            int controlValue = int.Parse(Console.ReadLine());

            int numberOfPair = 0;
            string fourPair = null;
            string result = string.Empty;

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d < 9; d++)
                        {
                            if ((a < b && c > d) && ((a * b) + (c * d) == controlValue))
                            {
                                numberOfPair++;
                                if (numberOfPair == 4)
                                {
                                    fourPair = $"Password: {a}{b}{c}{d}";
                                }

                                result += $"{a}{b}{c}{d} ";
                            }
                        }
                    }
                }
            }

            Console.WriteLine(result.Trim());

            if (fourPair == null)
            {
                Console.WriteLine("No!");
            }
            else
            {
                Console.Write(fourPair);
            }
        }
    }
}
