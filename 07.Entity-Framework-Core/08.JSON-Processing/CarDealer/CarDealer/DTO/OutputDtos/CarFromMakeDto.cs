﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.OutputDtos
{
    public class CarFromMakeDto
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }
    }
}
