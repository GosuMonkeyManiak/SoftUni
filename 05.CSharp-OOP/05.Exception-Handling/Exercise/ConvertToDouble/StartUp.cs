using System;

namespace ConvertToDouble
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            try
            {
                double result = Convert.ToDouble(number);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                throw new FormatException(e.Message, e);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.InnerException.Message);
            }


        }
    }
}
