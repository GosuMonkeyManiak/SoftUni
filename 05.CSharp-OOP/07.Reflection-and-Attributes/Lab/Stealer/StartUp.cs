using System;

namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.MethodsInfo("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
