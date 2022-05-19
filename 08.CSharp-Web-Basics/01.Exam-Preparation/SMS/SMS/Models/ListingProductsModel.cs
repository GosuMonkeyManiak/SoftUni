namespace SMS.Models
{
    using System.Collections.Generic;
    using Services.Models;

    public class ListingProductsModel
    {
        public IEnumerable<ProductDto> Products { get; init; }

        public string Username { get; init; }
    }
}
