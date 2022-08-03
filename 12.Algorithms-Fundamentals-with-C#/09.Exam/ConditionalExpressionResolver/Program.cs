namespace ConditionalExpressionResolver
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder(input, input.Length);

            string lastResult = null;

            while (true)
            {
                int lastQuestionMark = sb.ToString().LastIndexOf('?');
                int lastColon = sb.ToString().LastIndexOf(':');

                if (lastQuestionMark == -1 || lastColon == -1)
                {
                    break;
                }

                if (Math.Abs(lastQuestionMark - lastColon) != 4)
                {
                    lastColon = sb.ToString().IndexOf(':');
                }

                string firstArgument = sb[lastQuestionMark - 2].ToString();
                string secondArgument = sb[lastQuestionMark + 2].ToString();
                string thirdArgumnet = sb[lastColon + 2].ToString();

                if (firstArgument == "t")
                {
                    lastResult = secondArgument;
                }
                else if (firstArgument == "f")
                {
                    lastResult = thirdArgumnet;
                }

                int start = lastQuestionMark - 2;
                int end = lastColon + 2;

                if (start >= 0 && start < input.Length && end >= 0 && end < input.Length && start < end)
                {
                    sb = sb.Remove(start, end - start + 1).Insert(start, lastResult);
                }
            }

            Console.WriteLine(lastResult);
        }
    }
}