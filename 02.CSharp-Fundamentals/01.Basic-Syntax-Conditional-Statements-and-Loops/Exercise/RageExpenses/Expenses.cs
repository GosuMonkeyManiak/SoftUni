using System;

namespace RageExpenses
{
    class Expenses
    {
        static void Main(string[] args)
        {
            int loseGame = int.Parse(Console.ReadLine());
            double headSetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyBoardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double needePrice = 0;
            int headSet = (int)Math.Floor(loseGame / 2.0);
            int mouse = (int)Math.Floor(loseGame / 3.0);
            int keyBoard = (int)Math.Floor(loseGame / 6.0);
            int display = (int)Math.Floor(loseGame / 12.0);

            needePrice = (headSet * headSetPrice) + (mouse * mousePrice) + (keyBoard * keyBoardPrice) + (display * displayPrice);
            Console.WriteLine($"Rage expenses: {needePrice:f2} lv.");
        }
    }
}
