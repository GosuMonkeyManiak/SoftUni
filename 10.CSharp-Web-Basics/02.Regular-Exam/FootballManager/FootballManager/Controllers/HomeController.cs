namespace FootballManager.Controllers
{
    using MyWebServer.Http;
    using MyWebServer.Controllers;

    public class HomeController : Controller
    {
        public HttpResponse Index()
            => this.User.IsAuthenticated
                ? Redirect("/Players/All")
                : View();
    }
}
