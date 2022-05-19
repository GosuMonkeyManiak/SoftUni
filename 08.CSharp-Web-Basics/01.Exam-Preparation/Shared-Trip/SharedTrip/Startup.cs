namespace SharedTrip
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Services;
    using Services.Contracts;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<SharedTripDbContext>()
                    .Add<IValidationService, ValidationService>()
                    .Add<IUserService, UserService>()
                    .Add<IHashingService, HashingService>()
                    .Add<ITripService, TripService>())
                .WithConfiguration<SharedTripDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
