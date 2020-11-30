using System;

namespace BalancedBrackets
{
    class Brackets
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            byte bracketsCount = 0;
            bool isBalance = false;
            byte openBrackets = 0;

            for (int i = 0; i < n; i++)
            {
                string brackets = Console.ReadLine();

                
                if (brackets == "(")
                {
                    openBrackets++;

                    if (bracketsCount == 0)
                    {
                        bracketsCount++;
                        isBalance = false;
                    }
                    else if (openBrackets == 2)
                    {
                        break;
                    }

                }

                if (brackets == ")" && bracketsCount == 1)
                {
                    bracketsCount = 0;
                    isBalance = true;
                }
            }

            if (isBalance)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
