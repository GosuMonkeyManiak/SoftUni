namespace FootballManager.Controllers
{
    using System.Linq;
    using MyWebServer.Controllers;
    using MyWebServer.Results;
    using Services.Contracts;
    using ViewModels.Users;

    public class UsersController : Controller
    {
        private readonly IValidationService validationService;
        private readonly IUsersService usersService;

        public UsersController(
            IValidationService validationService,
            IUsersService usersService)
        {
            this.validationService = validationService;
            this.usersService = usersService;
        }

        public ActionResult Login() => 
            this.User.IsAuthenticated ? Error("Access denied!") : View();

        [HttpPost]
        public ActionResult Login(LoginFormModel formModel)
        {
            if (this.User.IsAuthenticated)
            {
                return Error("Access denied!");
            }

            var (validationResult, userId) = this.usersService
                .ValidateUserCredentials(formModel.Username, formModel.Password);

            if (!validationResult)
            {
                return Error("Incorrect Username or Password.");
            }

            SignIn(userId);

            return Redirect("/Players/All");
        }

        public ActionResult Register() 
            => this.User.IsAuthenticated ? Error("Access denied!") : View();

        [HttpPost]
        public ActionResult Register(RegisterFormModel formModel)
        {
            if (this.User.IsAuthenticated)
            {
                return Error("Access denied!");
            }

            var (validationResult, errors) = this.validationService
                .IsModelValid(formModel);

            if (!validationResult)
            {
                return Error(errors.ToList());
            }

            var isSucceed = this.usersService
                .RegisterUser(
                    formModel.Username,
                    formModel.Email,
                    formModel.Password);

            if (!isSucceed)
            {
                return Error("User already exist.");
            }

            return Redirect(nameof(Login));
        }

        [Authorize]
        public ActionResult Logout()
        {
            SignOut();

            return Redirect("/Home/Index");
        }
    }
}
