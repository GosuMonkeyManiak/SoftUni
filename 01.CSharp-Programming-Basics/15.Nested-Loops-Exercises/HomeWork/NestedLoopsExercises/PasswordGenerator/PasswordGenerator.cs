using System;

namespace PasswordGenerator
{
    class PasswordGenerator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int first = 1; first <= n; first++)
            {
                for (int second = 1; second <= n; second++)
                {
                    for (int third = 97; third < 97 + l; third++) //small letter
                    {
                        for (int fourth = 97; fourth < 97 + l; fourth++) //small letter
                        {
                            for (int fifth = 2; fifth <= n; fifth++)
                            {
                                if (fifth > first && fifth > second)
                                {
                                    Console.Write($"{first}{second}{(char)third}{(char)fourth}{fifth} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
