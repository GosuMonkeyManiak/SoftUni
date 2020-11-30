using System;

namespace PersonalTitles
{
    class PersonalTitles
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            char mOrf = char.Parse(Console.ReadLine());

            if (mOrf == 'm')
            {
                if (age >= 16)
                {
                    Console.WriteLine("Mr.");
                }
                else
                {
                    Console.WriteLine("Master");
                }
            }
            else
            {
                if (age >= 16)
                {
                    Console.WriteLine("Ms.");
                }
                else
                {
                    Console.WriteLine("Miss");
                }
            }
        }
    }
}
