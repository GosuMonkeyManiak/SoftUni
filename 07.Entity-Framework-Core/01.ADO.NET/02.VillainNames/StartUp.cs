using System;
using Microsoft.Data.SqlClient;

namespace _02.VillainNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.;
                                        Database=MinionsDB;
                                        User Id=sa;
                                        Password=Mitko875486123;";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                using (SqlCommand command = new SqlCommand(
                    @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                            FROM Villains AS v 
                            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                            GROUP BY v.Id, v.Name 
                            HAVING COUNT(mv.VillainId) > 3 
                            ORDER BY COUNT(mv.VillainId)", connection))
                {

                    using (SqlDataReader data = command.ExecuteReader())
                    {
                        while (data.Read())
                        {
                            Console.WriteLine($"{data["Name"]} - {data["MinionsCount"]}");
                        }
                    }
                }
            }


        }
    }
}
