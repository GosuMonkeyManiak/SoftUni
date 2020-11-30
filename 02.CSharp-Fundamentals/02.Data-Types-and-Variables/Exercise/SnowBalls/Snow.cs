using System;
using System.Dynamic;
using System.Numerics;

namespace SnowBalls
{
    class Snow
    {
        static void Main(string[] args)
        {
            byte snowBalls = byte.Parse(Console.ReadLine());

            BigInteger snowballValue = 0;
            ushort ourSnow = 0;
            ushort ourTime = 0;
            byte ourQuality = 0;

            for (int i = 0; i < snowBalls; i++)
            {
                ushort snowballSnow = ushort.Parse(Console.ReadLine());
                ushort snowballTime = ushort.Parse(Console.ReadLine());
                byte snowballQuality = byte.Parse(Console.ReadLine());

                if (snowballTime == 0)
                {
                    continue;
                }

                BigInteger currentSnowBallValue = BigInteger.Pow((snowballSnow / snowballTime),snowballQuality);

                if (currentSnowBallValue > snowballValue)
                {
                    snowballValue = currentSnowBallValue;
                    ourSnow = snowballSnow;
                    ourTime = snowballTime;
                    ourQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{ourSnow} : {ourTime} = {snowballValue} ({ourQuality})");
        }
    }
}
