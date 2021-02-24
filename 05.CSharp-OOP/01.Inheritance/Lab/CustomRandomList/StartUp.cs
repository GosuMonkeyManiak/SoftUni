using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("pesho");
            list.Add("Gigi");
            list.Add("dimitricko");
            list.Add("gosho");

            Console.WriteLine(list.RandomString());
        }
    }
}
