using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDb.Dtos;
using MongoDb.Models;

namespace MongoDb
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<TownDto> sqlServerTowns = null;

            using (SoftUniContext context = new SoftUniContext())
            {
                sqlServerTowns = context.Towns
                    .Select(t => new TownDto()
                    {
                        Name = t.Name
                    })
                    .ToList();
            }

            var client = new MongoClient(Configuration.MongoConnection);
            var mongoSoftUni = client.GetDatabase("SoftUni");

            var softUniCollection = mongoSoftUni.GetCollection<TownDto>("Towns");

            softUniCollection.InsertMany(sqlServerTowns);
        }
    }
}
