using System;

namespace DataTypeFinder
{
    class DataTypeFinder
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string someType = Console.ReadLine();
                if (someType == "END")
                {
                    break;
                }

                long intResult = 0;
                double doubleResult = 0.0;
                bool boolResult = false;
                char charResult = '\0';

                if (Int64.TryParse(someType, out intResult))
                {
                    Console.WriteLine($"{someType} is integer type");
                }
                else if (Double.TryParse(someType, out doubleResult))
                {
                    Console.WriteLine($"{someType} is floating point type"); 
                }
                else if (Boolean.TryParse(someType, out boolResult))
                {
                    Console.WriteLine($"{someType} is boolean type");
                }
                else if (Char.TryParse(someType, out charResult))
                {
                    Console.WriteLine($"{someType} is character type");
                }
                else
                {
                    Console.WriteLine($"{someType} is string type");
                }
            }
        }
    }
}
