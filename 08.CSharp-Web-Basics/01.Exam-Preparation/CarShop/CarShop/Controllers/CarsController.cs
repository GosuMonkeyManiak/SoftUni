namespace CarShop.Controllers
{
    using System.Linq;
    using MyWebServer.Controllers;
    using MyWebServer.Results;
    using Services.Contracts;
    using ViewModels;

    public class CarsController : Controller
    {
        private IUsersService usersService;
        private IValidationService validationService;
        private ICarsService carsService;

        public CarsController(
            IUsersService usersService,
            IValidationService validationService,
            ICarsService carsService)
        {
            this.usersService = usersService;
            this.validationService = validationService;
            this.carsService = carsService;
        }

        [Authorize]
        public ActionResult All()
        {
            if (this.usersService.IsMechanic(this.User.Id))
            {
                return View(this.carsService.All());
            }

            return View(this.carsService.All(this.User.Id));
        }

        [Authorize]
        public ActionResult Add()
        {
            if (this.usersService.IsMechanic(this.User.Id))
            {
                return Error("Access denied!");
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(CarFormModel formModel)
        {
            if (this.usersService.IsMechanic(this.User.Id))
            {
                return Error("Access denied!");
            }

            var (validationResult, errors) = this.validationService
                .IsModelValid(formModel);

            if (!validationResult)
            {
                return Error(errors.ToList());
            }

            var isSucceed = this.carsService
                .Add(
                    this.User.Id,
                    formModel.Model,
                    formModel.Year,
                    formModel.Image,
                    formModel.PlateNumber);

            if (!isSucceed)
            {
                return Error("Car already exist!");
            }

            return Redirect("/Cars/All");
        }
    }
}
