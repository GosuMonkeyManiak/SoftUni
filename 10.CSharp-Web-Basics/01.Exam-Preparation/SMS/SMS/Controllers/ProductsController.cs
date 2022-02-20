namespace SMS.Controllers
{
    using System.Linq;
    using Models;
    using MyWebServer.Controllers;
    using MyWebServer.Results;
    using Services.Contracts;

    public class ProductsController : Controller
    {
        private readonly IValidationService validationService;
        private readonly IProductsService productsService;

        public ProductsController(
            IValidationService validationService,
            IProductsService productsService)
        {
            this.validationService = validationService;
            this.productsService = productsService;
        }

        [Authorize]
        public ActionResult Create()
            => View();

        [HttpPost]
        [Authorize]
        public ActionResult Create(ProductFormModel formModel)
        {
            var (validationResult, errors) = this.validationService.IsModelValid(formModel);

            if (!validationResult)
            {
                return Error(errors.ToList());
            }

            bool IsSucceed = this.productsService
                .Add(formModel.Name, formModel.Price);

            if (!IsSucceed)
            {
                return Error("Product already exist!");
            }

            return Redirect("/Home/Index");
        }
    }
}
