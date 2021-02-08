using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> number = new EqualityScale<int>(100, 100);

            Console.WriteLine(number.AreEqual());
        }
    }
}
