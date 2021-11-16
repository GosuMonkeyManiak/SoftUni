using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProductShop.Dtos.Output
{
    public class UserWithSoldProductDto
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public IEnumerable<SoldProductDto> SoldProducts { get; set; }
    }
}
