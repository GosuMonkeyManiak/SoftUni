using System;
using Microsoft.Data.SqlClient;

namespace _03.MinionNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.;
                                        Database=MinionsDB;
                                        User Id=sa;
                                        Password=Mitko875486123;";

            int villainId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand(@"SELECT [Name] FROM Villains WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("Id", villainId);

                SqlDataReader dataReader = command.ExecuteReader();

                if (!dataReader.HasRows)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                }
                else
                {
                    while (dataReader.Read())
                    {
                        Console.WriteLine($"Villain: {dataReader["Name"]}");
                    }

                    command = new SqlCommand(
                        @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                       m.Name,
                                       m.Age
                                FROM MinionsVillains AS mv
                                JOIN Minions As m ON mv.MinionId = m.Id
                                WHERE mv.VillainId = 1
                                ORDER BY m.Name", connection);

                    dataReader.Close();

                    dataReader = command.ExecuteReader();

                    if (!dataReader.HasRows)
                    {
                        Console.WriteLine("(no minions)");
                    }
                    else
                    {
                        while (dataReader.Read())
                        {
                            Console.WriteLine($"{dataReader["RowNum"]}. {dataReader["Name"]} {dataReader["Age"]}");
                        }
                    }
                }
                
                dataReader.Close();
            }
        }
    }
}
