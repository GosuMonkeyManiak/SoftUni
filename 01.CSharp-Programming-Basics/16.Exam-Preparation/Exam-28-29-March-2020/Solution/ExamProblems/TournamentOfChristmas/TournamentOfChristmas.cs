using System;

namespace TournamentOfChristmas
{
    class TournamentOfChristmas
    {
        static void Main(string[] args)
        {
            int tourDays = int.Parse(Console.ReadLine());

            int currentCountWins = 0;
            int currentCountLose = 0;

            double allWinMoneyForCharity = 0;
            double cuurentDayWinMoney = 0;

            int countWinDays = 0;

            for (int i = 1; i <= tourDays; i++)
            {
                while (true)
                {
                    string sport = Console.ReadLine();
                    if (sport == "Finish")
                    {
                        break;
                    }

                    string result = Console.ReadLine();

                    if (result == "win")
                    {
                        currentCountWins++;
                        cuurentDayWinMoney += 20;
                    }
                    else
                    {
                        currentCountLose++;
                    }
                }

                if (currentCountWins > currentCountLose)
                {
                    double bonus = cuurentDayWinMoney * 0.1;
                    cuurentDayWinMoney += bonus;
                    allWinMoneyForCharity += cuurentDayWinMoney;
                    countWinDays++;
                }
                else
                {
                    allWinMoneyForCharity += cuurentDayWinMoney;
                }

                cuurentDayWinMoney = 0;
                currentCountLose = 0;
                currentCountWins = 0;
            }

            if (countWinDays > tourDays / 2)
            {
                double bonus = allWinMoneyForCharity * 0.2;
                allWinMoneyForCharity += bonus;

                Console.WriteLine($"You won the tournament! Total raised money: {allWinMoneyForCharity:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {allWinMoneyForCharity:f2}");
            }
        }
    }
}
