namespace SMS.Controllers
{
    using System.Linq;
    using Models;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using Services.Contracts;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;
        private readonly IUsersService usersService;

        public HomeController(
            IProductsService productsService,
            IUsersService usersService)
        {
            this.productsService = productsService;
            this.usersService = usersService;
        }

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return View(
                    "IndexLoggedIn", 
                    new ListingProductsModel()
                    {
                        Products = this.productsService
                            .All()
                            .ToList(),
                        Username = this.usersService
                            .GetUsernameById(this.User.Id)
                    });
            }

            return View();
        }
    }
}