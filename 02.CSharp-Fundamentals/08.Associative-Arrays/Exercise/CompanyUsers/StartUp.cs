using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companys = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] inPut = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (inPut[0] == "End")
                {
                    break;
                }

                string companyName = inPut[0];
                string employeeId = inPut[1];

                if (companys.ContainsKey(companyName))
                {
                    if (companys[companyName].Contains(employeeId) == false)
                    {
                        companys[companyName].Add(employeeId);
                    }
                }
                else
                {
                    companys.Add(companyName, new List<string>());
                    companys[companyName].Add(employeeId);
                }
            }

            companys = companys
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var company in companys)
            {
                Console.WriteLine($"{company.Key}");

                foreach (var employeer in company.Value)
                {
                    Console.WriteLine($"-- {employeer}");
                }
            }
        }
    }
}
