namespace SMS.Services.Contracts
{
    using System.Collections.Generic;
    using Data.Models;
    using Models;

    public interface IProductsService
    {
        IEnumerable<ProductDto> All();

        bool Add(string name, decimal price);

        bool IsProductExist(string productId);
    }
}
