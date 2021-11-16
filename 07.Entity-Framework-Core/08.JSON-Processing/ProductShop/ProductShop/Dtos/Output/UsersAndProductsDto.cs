using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.Output
{
    public class UsersAndProductsDto
    {
        public int UsersCount { get; set; }

        public IEnumerable<UserAndProductsDto> Users { get; set; }
    }
}
