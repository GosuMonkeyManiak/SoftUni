using System;
using Microsoft.Data.SqlClient;

namespace _06.RemoveVillain
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
                SqlTransaction transactionForVillainName = connection.BeginTransaction();

                SqlCommand getVillainName = new SqlCommand(@"SELECT [Name] FROM Villains WHERE Id = @villainId", connection);
                getVillainName.Parameters.AddWithValue("villainId", villainId);
                getVillainName.Transaction = transactionForVillainName;

                if (getVillainName.ExecuteScalar() == null)
                {
                    transactionForVillainName.Rollback();
                    connection.Close();
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                string villainName = (string) getVillainName.ExecuteScalar();
                transactionForVillainName.Commit();

                SqlTransaction transactionForDeleteMinions = connection.BeginTransaction();

                SqlCommand deleteMinions = new SqlCommand(@"DELETE FROM MinionsVillains WHERE VillainId = @villainId;", connection);
                deleteMinions.Parameters.AddWithValue("villainId", villainId);
                deleteMinions.Transaction = transactionForDeleteMinions;

                int deletedMinions;

                try
                {
                    deletedMinions = deleteMinions.ExecuteNonQuery();

                    transactionForDeleteMinions.Commit();
                }
                catch (Exception e)
                {
                    transactionForDeleteMinions.Rollback();
                    connection.Close();
                    return;
                }

                SqlTransaction transactionForDeleteVillain = connection.BeginTransaction();

                SqlCommand deleteVillain = new SqlCommand(@"DELETE FROM Villains WHERE Id = @villainId", connection);
                deleteVillain.Parameters.AddWithValue("villainId", villainId);
                deleteVillain.Transaction = transactionForDeleteVillain;

                try
                {
                    deleteVillain.ExecuteNonQuery();

                    transactionForDeleteVillain.Commit();
                }
                catch (Exception e)
                {
                    transactionForDeleteVillain.Rollback();
                    connection.Close();
                    return;
                }

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{deletedMinions} minions were released.");
            }
        }
    }
}
