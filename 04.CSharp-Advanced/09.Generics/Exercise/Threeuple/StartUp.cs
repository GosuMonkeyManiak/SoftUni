using System;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstTupleData = Console.ReadLine()
                .Split(" ");

            string fullname = $"{firstTupleData[0]} {firstTupleData[1]}";

            string town = firstTupleData[3];

            if (firstTupleData.Length > 4)
            {
                town = $"{firstTupleData[3]} {firstTupleData[4]}";
            }

            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullname, firstTupleData[2], town);

            string[] secondTupleData = Console.ReadLine()
                .Split(" ");

            bool isDrunk = false;

            if (secondTupleData[2] == "drunk")
            {
                isDrunk = true;
            }

            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(secondTupleData[0], int.Parse(secondTupleData[1]), isDrunk);

            string[] thirdTupleData = Console.ReadLine()
                .Split(" ");

            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(thirdTupleData[0], double.Parse(thirdTupleData[1]), thirdTupleData[2]);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
