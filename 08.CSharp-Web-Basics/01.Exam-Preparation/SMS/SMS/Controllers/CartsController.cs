namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Results;
    using Services.Contracts;

    public class CartsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly ICartService cartService;

        public CartsController(
            IProductsService productsService,
            ICartService cartService)
        {
            this.productsService = productsService;
            this.cartService = cartService;
        }

        [Authorize]
        public ActionResult AddProduct(string productId)
        {
            if (!this.productsService.IsProductExist(productId))
            {
                return Error("Product does not exist!");
            }

            var isSucceed = this.cartService
                .AddProductToUser(productId, this.User.Id);

            if (!isSucceed)
            {
                return Error("Product is allready in the cart!");
            }

            return Redirect("/Carts/Details");
        }

        [Authorize]
        public ActionResult Details()
        {
            var productForUser = this.cartService
                .AllProductsForUser(this.User.Id);

            return View(productForUser);
        }

        [Authorize]
        public ActionResult Buy()
        {
            this.cartService
                .RemoveProductsForUser(this.User.Id);

            return Redirect("/Home/Index");
        }
    }
}
