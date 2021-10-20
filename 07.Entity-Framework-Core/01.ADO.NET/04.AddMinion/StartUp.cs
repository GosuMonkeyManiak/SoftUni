using System;
using Microsoft.Data.SqlClient;

namespace _04.AddMinion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.;
                                        Database=MinionsDB;
                                        User Id=sa;
                                        Password=Mitko875486123;";

            string[] minionInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] villainInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int townId;
                int minionId;
                int villainId;

                SqlCommand checkForTownExist = new SqlCommand(@"SELECT Id FROM Towns WHERE Name = @townName", connection);
                checkForTownExist.Parameters.AddWithValue("townName", minionInfo[3]);

                using (SqlDataReader dataReader = checkForTownExist.ExecuteReader())
                {
                    if (!dataReader.HasRows)
                    {
                        dataReader.Close();

                        SqlCommand insertTown = new SqlCommand(@"INSERT INTO Towns ([Name]) VALUES (@townName)", connection);
                        insertTown.Parameters.AddWithValue("townName", minionInfo[3]);
                        insertTown.ExecuteNonQuery();

                        Console.WriteLine($"Town {minionInfo[3]} was added to the database.");
                    }
                }

                //townId
                townId = (int) checkForTownExist.ExecuteScalar();

                SqlCommand checkForVillainExist = new SqlCommand(@"SELECT Id FROM Villains WHERE Name = @Name", connection);
                checkForVillainExist.Parameters.AddWithValue("Name", villainInfo[1]);

                using (SqlDataReader dataReader = checkForVillainExist.ExecuteReader())
                {
                    if (!dataReader.HasRows)
                    {
                        dataReader.Close();

                        SqlCommand insertVillain =
                            new SqlCommand(@"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)", connection);
                        insertVillain.Parameters.AddWithValue("villainName", villainInfo[1]);
                        insertVillain.ExecuteNonQuery();

                        Console.WriteLine($"Villain {villainInfo[1]} was added to the database.");
                    }
                }

                //villainId
                villainId = (int) checkForVillainExist.ExecuteScalar();

                SqlCommand insertMinion = new
                    SqlCommand(@"INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)", connection);
                insertMinion.Parameters.AddWithValue("nam", minionInfo[1]);
                insertMinion.Parameters.AddWithValue("age", minionInfo[2]);
                insertMinion.Parameters.AddWithValue("townId", townId);

                insertMinion.ExecuteNonQuery();

                SqlCommand getMinionId = new SqlCommand($"SELECT Id FROM Minions WHERE Name = @Name", connection);
                getMinionId.Parameters.AddWithValue("Name", minionInfo[1]);

                minionId = (int) getMinionId.ExecuteScalar();

                SqlCommand addMinionToVillain =
                    new SqlCommand(@"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)",
                        connection);
                addMinionToVillain.Parameters.AddWithValue("villainId", villainId);
                addMinionToVillain.Parameters.AddWithValue("minionId", minionId);

                Console.WriteLine($"Successfully added {minionInfo[1]} to be minion of {villainInfo[1]}.");
            }
        }
    }
}
