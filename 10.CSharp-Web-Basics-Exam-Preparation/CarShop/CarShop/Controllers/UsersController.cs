namespace CarShop.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using MyWebServer.Controllers;
    using MyWebServer.Results;
    using Services.Contracts;
    using ViewModels;

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
                return Error("Access denied!");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginFormModel formModel)
        {
            if (this.User.IsAuthenticated)
            {
                return Error("Access denied!");
            }

            var (loginValidation, userId) = this.usersService
                .Login(formModel.Username, formModel.Password);

            if (!loginValidation)
            {
                return Error("Incorrect Username or Password!");
            }

            SignIn(userId);

            return Redirect("/Cars/All");
        }

        public ActionResult Register()
        {
            if (this.User.IsAuthenticated)
            {
                return Error("Access denied!");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterFormModel formModel)
        {
            if (this.User.IsAuthenticated)
            {
                return Error("Access denied!");
            }

            var (validationResult, errors) = this.validationService
                .IsModelValid(formModel);

            var userTypeValidationResult = this.validationService
                .IsUserTypeValid(formModel.UserType);

            if (!validationResult ||
                !userTypeValidationResult)
            {
                var allErrors = errors != null
                    ? errors.ToList()
                    : new List<string>();

                if (!userTypeValidationResult)
                {
                    allErrors.Add("User should be client or mechanic!");
                }

                return Error(allErrors);
            }

            bool isSucceed = this.usersService
                .Register(
                    formModel.Username,
                    formModel.Email,
                    formModel.Password,
                    formModel.UserType);

            if (!isSucceed)
            {
                return Error("User already exist!");
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
