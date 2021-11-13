using FastFood.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Importer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new FastFoodContext();
            db.Database.Migrate();
        }
    }
}
