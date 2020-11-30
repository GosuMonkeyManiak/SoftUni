using System;

namespace TimePlus15
{
    class TimePlus
    {
        static void Main(string[] args)
        {
			int hours = int.Parse(Console.ReadLine());
			int minuts = int.Parse(Console.ReadLine());

			string Hours = null;
			string Minuts = null;

			while (hours < 0 || hours > 24)
			{
				hours = int.Parse(Console.ReadLine());
			}

			while (minuts < 0 || minuts > 60)
			{
				minuts = int.Parse(Console.ReadLine());
			}

			minuts += 15;

			if (minuts > 60)
			{
				int remainMin = minuts - 60;
				hours++;

				if (hours == 24)
				{
					hours = 0;
				}

				minuts = remainMin;
			}
			else if (minuts == 60)
			{
				minuts = 0;
				hours++;

				if (hours == 24)
				{
					hours = 0;
				}
			}


			if (hours == 0)
			{
				Hours = hours.ToString();

				if (minuts < 10)
				{
					Minuts = "0" + minuts.ToString();
				}
				else
				{
					Minuts = minuts.ToString();
				}
			}
			else
			{
				if (hours < 10)
				{
					if (minuts < 10)
					{
						Hours = "0" + hours.ToString();
						Minuts = "0" + minuts.ToString();
					}
					else
					{
						Hours = "0" + hours.ToString();
						Minuts = minuts.ToString();
					}
				}
				else
				{
					if (minuts < 10)
					{
						Hours = hours.ToString();
						Minuts = "0" + minuts.ToString();
					}
					else
					{
						Hours = hours.ToString();
						Minuts = minuts.ToString();
					}
				}
			}

			Console.WriteLine($"{Hours}:{Minuts}");
		}
    }
}
