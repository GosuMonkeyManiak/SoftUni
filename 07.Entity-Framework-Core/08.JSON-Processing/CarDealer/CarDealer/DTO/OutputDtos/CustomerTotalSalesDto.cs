using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer.DTO.OutputDtos
{
    public class CustomerTotalSalesDto
    {
        public string FullName { get; set; }

        public int BoughtCars { get; set; }

        public decimal SpentMoney { get; set; }
    }
}
