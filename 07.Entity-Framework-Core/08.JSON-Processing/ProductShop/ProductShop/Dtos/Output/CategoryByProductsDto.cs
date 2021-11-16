using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProductShop.Dtos.Output
{
    public class CategoryByProductsDto
    {
        [JsonProperty("category")]
        public string Name { get; set; }

        [JsonProperty("productsCount")]
        public int ProductCount { get; set; }

        public string AveragePrice { get; set; }

        public string TotalRevenue { get; set; }
    }
}
