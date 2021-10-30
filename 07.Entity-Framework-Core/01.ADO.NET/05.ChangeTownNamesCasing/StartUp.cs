using System;
using Microsoft.Data.SqlClient;

namespace _05.ChangeTownNamesCasing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = @"";

            string countryName = Console.ReadLine();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                SqlCommand checkForCountryExist = new SqlCommand(
                    @"SELECT t.Name 
                            FROM Towns as t
                            JOIN Countries AS c 
                            ON c.Id = t.CountryCode
                            WHERE c.Name = @countryName", connection);
                checkForCountryExist.Parameters.AddWithValue("countryName", countryName);

                SqlDataReader dataReader = checkForCountryExist.ExecuteReader();

                using (dataReader)
                {
                    if (!dataReader.HasRows)
                    {
                        Console.WriteLine("No town names were affected.");
                        dataReader.Close();
                        return;
                    }
                }

                SqlCommand updateTowns = new SqlCommand(
                    @"UPDATE Towns
                            SET Name = UPPER(Name)
                            WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)",
                    connection);
                updateTowns.Parameters.AddWithValue("countryName", countryName);

                int affectedRows = (int) updateTowns.ExecuteNonQuery();

                dataReader = checkForCountryExist.ExecuteReader();

                using (dataReader)
                {
                    Console.WriteLine($"{affectedRows} town names were affected.");

                    string result = "[";

                    while (dataReader.Read())
                    {
                        result += $"{dataReader["Name"]}, ";
                    }

                    result = result.Substring(0, result.Length - 2);
                    result += "]";

                    Console.WriteLine(result);
                }
            }
        }
    }
}
