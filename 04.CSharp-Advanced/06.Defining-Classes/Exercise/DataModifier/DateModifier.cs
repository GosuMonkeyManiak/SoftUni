using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        private int diffrent;

        public int Diffrent
        {
            get { return diffrent; }
        }

        public void GetDiffrent(string firstDate, string secondDate)
        {
            string[] firstTokens = firstDate
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] secondTokens = secondDate
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int firstYear = int.Parse(firstTokens[0]);
            int firstMonth = int.Parse(firstTokens[1]);
            int firstDay = int.Parse(firstTokens[2]);

            int secondYear = int.Parse(secondTokens[0]);
            int secondMonth = int.Parse(secondTokens[1]);
            int secondDay = int.Parse(secondTokens[2]);

            DateTime dateOne = new DateTime(firstYear, firstMonth, firstDay);
            DateTime dateTwo = new DateTime(secondYear, secondMonth, secondDay);

            TimeSpan diff = dateOne - dateTwo;

            diffrent = Math.Abs(int.Parse(diff.Days.ToString()));
        }

    }
}
