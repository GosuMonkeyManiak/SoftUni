using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CarDealer.DTO.OutputDtos
{
    public class CarWithPartsDto
    {
        [JsonProperty("car")]
        public CarDto Car { get; set; }

        [JsonProperty("parts")]
        public IEnumerable<PartDto> Parts { get; set; }
    }
}
