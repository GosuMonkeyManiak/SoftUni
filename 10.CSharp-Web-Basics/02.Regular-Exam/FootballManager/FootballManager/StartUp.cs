namespace FootballManager
{
    using MyWebServer;
    using FootballManager.Data;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;
    using Services;
    using Services.Contracts;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<FootballManagerDbContext>()
                .Add<IViewEngine, CompilationViewEngine>()
                .Add<IHashingService, HashingService>()
                .Add<IValidationService, ValidationService>()
                .Add<IUsersService, UsersService>()
                .Add<IPlayersService, PlayersService>())
                .WithConfiguration<FootballManagerDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
