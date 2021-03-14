using System;

namespace SquareRoot
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                uint number = uint.Parse(Console.ReadLine());

                Console.WriteLine(Math.Sqrt(number));
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid number");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }


        }
    }
}
