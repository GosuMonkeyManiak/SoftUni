namespace Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            List<int> arr = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                arr.Add(i);
            }

            List<List<int>> ans = CombinationSum(arr, number);

            if (ans.Any(x => x.Any()))
            {
                for (int i = 0; i < ans.Count; i++)
                {
                    ans[i] = ans[i].OrderByDescending(x => x).ToList();
                }

                ans = ans
                    .OrderBy(x => x.Count)
                    .OrderByDescending(x => x.First())
                    .ToList();

                for (int i = 0; i < ans.Count; i++)
                {
                    Console.WriteLine(string.Join(" + ", ans[i]));
                }
            }
        }

        static List<List<int>> CombinationSum(List<int> arr, int sum)
        {
            List<List<int>> ans = new List<List<int>>();
            List<int> temp = new List<int>();

            HashSet<int> set = new HashSet<int>(arr);
            arr.Clear();
            arr.AddRange(set);
            arr.Sort();

            FindNumbers(ans, arr, sum, 0, temp);
            return ans;
        }

        static void FindNumbers(List<List<int>> ans, List<int> arr, int sum, int index, List<int> temp)
        {
            if (sum == 0)
            {
                ans.Add(new List<int>(temp));
                return;
            }

            for (int i = index; i < arr.Count; i++)
            {
                if ((sum - arr[i]) >= 0)
                {
                    temp.Add(arr[i]);
                    FindNumbers(ans, arr, sum - arr[i], i, temp);
                    temp.Remove(arr[i]);
                }
            }
        }
    }
}