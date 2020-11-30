using System;

namespace ExamCategories
{
    class ExamCategories
    {
        static void Main(string[] args)
        {
            int complexsity = int.Parse(Console.ReadLine());
            int daze = int.Parse(Console.ReadLine());
            int pages = int.Parse(Console.ReadLine());

            if (complexsity >= 80)
            {
                if (daze >= 80 && pages >= 8)
                {
                    Console.WriteLine("Legacy");
                }
                else if (daze <= 10)
                {
                    Console.WriteLine("Master");
                }
                else if (daze >= 50 && pages >= 2)
                {
                    Console.WriteLine("Hard");
                }
                else
                {
                    Console.WriteLine("Regular");
                }
            }
            else if (complexsity <= 10)
            {
                if (daze >= 50 && pages >= 2)
                {
                    Console.WriteLine("Hard");
                }
                else
                {
                    Console.WriteLine("Elementary");
                }
            }
            else if (complexsity <= 30)
            {
                if (daze >= 50 && pages >= 2)
                {
                    Console.WriteLine("Hard");
                }
                else if (pages <= 1)
                {
                    Console.WriteLine("Easy");
                }
                else
                {
                    Console.WriteLine("Regular");
                }
            }
            else
            {
                if (daze >= 50 && pages >= 2)
                {
                    Console.WriteLine("Hard");
                }
                else
                {
                    Console.WriteLine("Regular");
                }
            }
        }
    }
}
