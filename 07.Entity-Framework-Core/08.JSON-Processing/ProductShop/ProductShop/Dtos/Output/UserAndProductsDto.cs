using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.Output
{
    public class UserAndProductsDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public ProductsDto SoldProducts { get; set; }
    }
}
