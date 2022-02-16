namespace SMS.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface ICartService
    {
        bool AddProductToUser(string productId, string userId);

        IEnumerable<ProductDto> AllProductsForUser(string userId);

        void RemoveProductsForUser(string userId);
    }
}
