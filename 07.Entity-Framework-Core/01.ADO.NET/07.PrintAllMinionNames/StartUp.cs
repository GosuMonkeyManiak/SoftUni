using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace _07.PrintAllMinionNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = @"";

            List<string> minionNames = new List<string>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                SqlCommand getAllMinionsName = new SqlCommand(@"SELECT [Name] FROM Minions", connection);

                SqlDataReader data = getAllMinionsName.ExecuteReader();

                using (data)
                {
                    while (data.Read())
                    {
                        minionNames.Add((string) data["Name"]);
                    }
                }
            }

            int left = 0;
            int right = minionNames.Count - 1;

            while (left <= right)
            {
                if (left == right)
                {
                    Console.WriteLine($"{minionNames[left]}");
                    left++;
                    continue;
                }

                Console.WriteLine($"{minionNames[left]}");
                Console.WriteLine($"{minionNames[right]}");

                left++;
                right -= 1;
            }
        }
    }
}
