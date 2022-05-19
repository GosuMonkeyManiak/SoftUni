namespace SMS.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CartService : ICartService
    {
        private readonly SMSDbContext dbContext;
        private readonly IProductsService productsService;

        public CartService(
            SMSDbContext dbContext,
            IProductsService productsService)
        {
            this.dbContext = dbContext;
            this.productsService = productsService;
        }

        public bool AddProductToUser(string productId, string userId)
        {
            var user = this.dbContext
                .Users
                .Include(u => u.Cart)
                .ThenInclude(u => u.Products)
                .FirstOrDefault(u => u.Id == userId);

            var isUserHasProduct = user
                .Cart
                .Products
                .Any(p => p.Id == productId);

            if (isUserHasProduct)
            {
                return false;
            }

            var product = GetProductById(productId);

            if (product.CartId != null)
            {
                return false;
            }

            product.CartId = user.CartId;

            this.dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<ProductDto> AllProductsForUser(string userId)
            => this.dbContext
                .Users
                .Include(u => u.Cart)
                .ThenInclude(u => u.Products)
                .FirstOrDefault(u => u.Id == userId)
                .Cart
                .Products
                .Select(p => new ProductDto()
                {
                    Name = p.Name,
                    Price = p.Price
                })
                .ToList();

        public void RemoveProductsForUser(string userId)
        {
            this.dbContext
                .Users
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault(u => u.Id == userId)
                .Cart
                .Products
                .Clear();

            this.dbContext.SaveChanges();
        }

        public Product GetProductById(string productId)
            => this.dbContext
                .Products
                .FirstOrDefault(p => p.Id == productId);
    }
}
