namespace SMS.Controllers
{
    using Models;
    using MyWebServer.Controllers;
    using MyWebServer.Results;
    using Services.Contracts;

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

        public ActionResult Login()
        {
            if (this.User.IsAuthenticated)
            {
                return Error("Access denied");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginFormModel formModel)
        {
            if (this.User.IsAuthenticated)
            {
                return Error("Access denied");
            }

            var (loginValidation, userId) = this.usersService
                .Login(
                    formModel.Username,
                    formModel.Password);

            if (!loginValidation)
            {
                return Error("Incorrect Username or Password!");
            }

            SignIn(userId);

            return Redirect("/Home/Index");
        }

        public ActionResult Register()
        {
            if (this.User.IsAuthenticated)
            {
                return Error("Access denied");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterFormModel formModel)
        {
            if (this.User.IsAuthenticated)
            {
                return Error("Access denied");
            }

            var (validationResult, errors) = this.validationService.IsModelValid(formModel);

            if (!validationResult)
            {
                return Error(string.Join("\r\n", errors));
            }

            var isSucceed = this.usersService
                .Register(
                    formModel.Username,
                    formModel.Email,
                    formModel.Password);

            if (!isSucceed)
            {
                return Error("User already exist!");
            }

            return Redirect("/Users/Login");
        }

        [Authorize]
        public ActionResult Logout()
        {
            SignOut();

            return Redirect("/Home/Index");
        }
    }
}
