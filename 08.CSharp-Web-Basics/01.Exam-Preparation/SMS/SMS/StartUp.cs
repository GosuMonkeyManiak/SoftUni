namespace SMS
{
    using System.Threading.Tasks;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Services;
    using Services.Contracts;

    public class StartUp
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<SMSDbContext>()
                    .Add<IValidationService, ValidationService>()
                    .Add<IHashingService, HashingService>()
                    .Add<IUsersService, UsersService>()
                    .Add<IProductsService, ProductsService>()
                    .Add<ICartService, CartService>())
                .WithConfiguration<SMSDbContext>(dbContext => dbContext
                    .Database.Migrate())
                .Start();
    }
}