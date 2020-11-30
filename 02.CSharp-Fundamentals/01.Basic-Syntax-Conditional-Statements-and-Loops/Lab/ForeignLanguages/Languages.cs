using System;

namespace ForeignLanguages
{
    class Languages
    {
        static void Main(string[] args)
        {
            string contry = Console.ReadLine().ToLower();

            switch (contry)
            {
                case "usa":
                case "england": Console.WriteLine("English");
                    break;

                case "spain":
                case "argentina":
                case "mexico": Console.WriteLine("Spanish");
                    break;

                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
