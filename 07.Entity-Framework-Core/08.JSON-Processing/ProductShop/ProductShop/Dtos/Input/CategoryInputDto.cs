using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProductShop.Dtos.Input
{
    public class CategoryInputDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
