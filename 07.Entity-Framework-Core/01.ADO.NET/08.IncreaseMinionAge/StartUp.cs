using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace _08.IncreaseMinionAge
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = @";";

            int[] minionsIds = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                SqlCommand updateMinionsAge = new SqlCommand(
                    @" UPDATE Minions
                             SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                             WHERE Id = @Id", connection);

                foreach (var element in minionsIds)
                {
                    updateMinionsAge.Parameters.AddWithValue("Id", element);
                    updateMinionsAge.ExecuteNonQuery();
                    updateMinionsAge.Parameters.Clear();
                }

                SqlCommand getAllMinions = new SqlCommand(@"SELECT [Name], [Age] FROM Minions", connection);

                SqlDataReader data = getAllMinions.ExecuteReader();

                using (data)
                {
                    while (data.Read())
                    {
                        Console.WriteLine($"{data["Name"]} {data["Age"]}");
                    }
                }

            }
        }
    }
}
