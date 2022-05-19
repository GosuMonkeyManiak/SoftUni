namespace SharedTrip.Controllers
{
    using Models;
    using MyWebServer.Controllers;
    using MyWebServer.Results;
    using Services.Contracts;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IValidationService validationService;
        private readonly IUserService userService;

        public UsersController(
            IValidationService validationService,
            IUserService userService)
        {
            this.validationService = validationService;
            this.userService = userService;
        }

        public ActionResult Login()
        {
            if (this.User.IsAuthenticated)
            {
                Redirect("/Trips/All");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginFormModel formModel)
        {
            var (isSucceed, userId) = this.userService
                .ValidateUserCredentials(formModel.Username, formModel.Password);

            if (!isSucceed)
            {
                return Error("Incorrect Username or Password!");
;           }

            SignIn(userId);

            return Redirect("/Trips/All");
        }

        public ActionResult Register()
        {
            if (this.User.IsAuthenticated)
            {
                Redirect("/Trips/All");
            }

            return View();
        }


        [HttpPost]
        public ActionResult Register(RegisterFormModel formModel)
        {
            var (validationResult, errors) = this.validationService.IsModelValid(formModel);

            if (!validationResult)
            {
                return Error(errors.ToList());
            }

            bool isSucceed = this.userService
                .RegisterUser(formModel.Username, formModel.Email, formModel.Password);

            return isSucceed ? Redirect("/Users/Login") : Error("User already exists!");
        }

        [Authorize]
        public ActionResult Logout()
        {
            SignOut();

            return Redirect("/Home/Index");
        }
    }
}
