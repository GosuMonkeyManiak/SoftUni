using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb
{
    public static class Configuration
    {
        public const string SQLConnection = @"Server=.;Database=SoftUni;User Id=sa;Password=Mitko875486123";

        public const string MongoConnection = @"mongodb://mongoAdmin:mongo@localhost:27017/?authSource=admin";
    }
}
