namespace CarShop.Controllers
{
    using System.Linq;
    using MyWebServer.Controllers;
    using MyWebServer.Results;
    using Services.Contracts;

    public class IssuesController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IUsersService usersService;
        private readonly IIssuesService issuesService;

        public IssuesController(
            ICarsService carsService,
            IUsersService usersService,
            IIssuesService issuesService)
        {
            this.carsService = carsService;
            this.usersService = usersService;
            this.issuesService = issuesService;
        }

        [Authorize]
        public ActionResult CarIssues(string carId)
        {
            if (!this.carsService.IsCarExist(carId))
            {
                return Error("Car does not exist!");
            }

            var carWithIssues = this.carsService
                .AllIssuesByCarId(
                    carId, 
                    this.usersService.IsMechanic(this.User.Id));

            return View(carWithIssues);
        }

        [Authorize]
        public ActionResult Add()
            => View();

        [HttpPost]
        [Authorize]
        public ActionResult Add(string carId, string description)
        {
            if (!this.carsService.IsCarExist(carId))
            {
                return Error("Car does not exist!");
            }

            this.issuesService.AddIssue(carId, description);

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public ActionResult Delete(string issueId, string carId)
        {
            if (!this.carsService.IsCarExist(carId) ||
                !this.issuesService.IsIssueExist(issueId))
            {
                return Error("Car or Issue does not exist!");
            }

            this.issuesService.Delete(issueId);

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public ActionResult Fix(string issueId, string carId)
        {
            if (!this.usersService.IsMechanic(this.User.Id))
            {
                return Error("Access denied!");
            }

            if (!this.carsService.IsCarExist(carId) ||
                !this.issuesService.IsIssueExist(issueId))
            {
                return Error("Car or Issue does not exist!");
            }

            this.issuesService.Fix(issueId);

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
