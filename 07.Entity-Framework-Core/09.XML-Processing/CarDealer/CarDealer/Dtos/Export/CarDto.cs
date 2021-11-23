﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    public class CarDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public string TravelledDistance { get; set; }
    }
}
