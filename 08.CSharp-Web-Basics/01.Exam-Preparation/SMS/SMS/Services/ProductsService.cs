namespace SMS.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Data.Models;
    using Models;

    public class ProductsService : IProductsService
    {
        private readonly SMSDbContext dbContext;

        public ProductsService(SMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<ProductDto> All()
            => this.dbContext
                .Products
                .Where(p => p.CartId == null)
                .Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .ToList();

        public bool Add(string name, decimal price)
        {
            if (IsProductExist(name, price))
            {
                return false;
            }

            var product = new Product()
            {
                Name = name,
                Price = price
            };

            this.dbContext
                .Products
                .Add(product);

            this.dbContext.SaveChanges();

            return true;
        }

        public bool IsProductExist(string productId)
            => this.dbContext
                .Products
                .FirstOrDefault(p => p.Id == productId) != null;

        private bool IsProductExist(string name, decimal price)
            => this.dbContext
                .Products
                .FirstOrDefault(p => p.Name == name && p.Price == price) != null;
    }
}
