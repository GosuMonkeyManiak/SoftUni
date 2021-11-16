using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProductShop.Dtos.Input
{
    public class UserInputDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }
    }
}
