using System;
using Microsoft.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.;
                                        Database=MinionsDB;
                                        User Id=sa;
                                        Password=Mitko875486123;";

            int minionId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                SqlCommand useUSP = new SqlCommand(@"EXEC usp_GetOlder @Id", connection);
                useUSP.Parameters.AddWithValue("Id", minionId);

                useUSP.ExecuteNonQuery();

                SqlCommand getMinionById =
                    new SqlCommand(@"SELECT [Name], [Age] FROM Minions WHERE Id = @Id", connection);
                getMinionById.Parameters.AddWithValue("Id", minionId);

                SqlDataReader data = getMinionById.ExecuteReader();

                using (data)
                {
                    while (data.Read())
                    {
                        Console.WriteLine($"{data["name"]} - {data["Age"]} years old");
                    }
                }
            }
        }
    }
}
