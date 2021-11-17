using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarDealer.Models
{
    public class PartCar
    {
        [ForeignKey(nameof(Part))]
        public int PartId { get; set; }
        public Part Part { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
