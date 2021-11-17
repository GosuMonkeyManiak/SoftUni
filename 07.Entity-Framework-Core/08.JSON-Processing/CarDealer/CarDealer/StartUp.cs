using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.InputDtos;
using CarDealer.DTO.OutputDtos;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;
        private static MapperConfiguration configurations;
        private static JsonSerializerSettings jsonSerializerSettings;
        private static DefaultContractResolver resolver;

        public static void Main(string[] args)
        {
            MapperConfiguring();
            ResolverConfiguring();
            JsonSettingsConfiguring();

            using (var context = new CarDealerContext())
            {
                //context.Database.EnsureCreated();
                //ImportSuppliers(context, File.ReadAllText("Datasets/suppliers.json"));
                //ImportParts(context, File.ReadAllText("Datasets/parts.json"));
                //ImportCars(context, File.ReadAllText("Datasets/cars.json"));
                //ImportCustomers(context, File.ReadAllText("Datasets/customers.json"));
                //ImportSales(context, File.ReadAllText("Datasets/sales.json"));

                string result = GetSalesWithAppliedDiscount(context);
                Console.WriteLine(result);
            }
        }

        private static void MapperConfiguring()
        {
            configurations = new MapperConfiguration(config =>
            {
                config.AddProfile<CarDealerProfile>();
            });

            mapper = configurations.CreateMapper();
        }

        private static void JsonSettingsConfiguring()
        {
            jsonSerializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                //ContractResolver = resolver,
                //DateFormatString = "dd/MM/yyyy"
            };
        }

        private static void ResolverConfiguring()
        {
            resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var supplierDtos = JsonConvert.DeserializeObject<List<SupplierInputDto>>(inputJson);

            List<Supplier> suppliers = new List<Supplier>(supplierDtos.Count);

            foreach (var supplierDto in supplierDtos)
            {
                suppliers.Add(mapper.Map<Supplier>(supplierDto));
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var partInputDtos = JsonConvert.DeserializeObject<List<PartInputDto>>(inputJson);

            List<int> validSuppliersId = context.Suppliers.Select(s => s.Id).ToList();

            List<Part> parts = new List<Part>(partInputDtos.Count);

            foreach (var partInputDto in partInputDtos)
            {
                if (validSuppliersId.Contains(partInputDto.SupplierId))
                {
                    parts.Add(mapper.Map<Part>(partInputDto));
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carInputDtos = JsonConvert.DeserializeObject<List<CarInputDto>>(inputJson);

            List<Car> cars = new List<Car>(carInputDtos.Count);

            foreach (var carInputDto in carInputDtos)
            {
                cars.Add(mapper.Map<Car>(carInputDto));
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customerInputDtos = JsonConvert.DeserializeObject<List<CustomerInputDto>>(inputJson);

            List<Customer> customers = new List<Customer>(customerInputDtos.Count);

            foreach (var customerInputDto in customerInputDtos)
            {
                customers.Add(mapper.Map<Customer>(customerInputDto));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var saleInputDtos = JsonConvert.DeserializeObject<List<SaleInputDto>>(inputJson);

            List<Sale> sales = new List<Sale>(saleInputDtos.Count);

            foreach (var saleInputDto in saleInputDtos)
            {
                sales.Add(mapper.Map<Sale>(saleInputDto));
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var orderedCustomers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver ? 1 : 0)
                .ProjectTo<OrderedCustomerDto>(mapper.ConfigurationProvider)
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(orderedCustomers, jsonSerializerSettings);

            File.WriteAllText("../../../Exports/ordered-customers.json", jsonResult);
            
            return jsonResult;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<CarFromMakeDto>(mapper.ConfigurationProvider)
                .ToList();

            string resultJson = JsonConvert.SerializeObject(toyotaCars, jsonSerializerSettings);

            File.WriteAllText("../../../Exports/toyota-cars.json", resultJson);

            return resultJson;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Include(s => s.Parts)
                .Where(s => !s.IsImporter)
                .ProjectTo<LocalSuppliersDto>(mapper.ConfigurationProvider)
                .ToList();

            string resultJson = JsonConvert.SerializeObject(localSuppliers, jsonSerializerSettings);

            File.WriteAllText("../../../Exports/ordered-customers.json", resultJson);

            return resultJson;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carWithParsDto = context.Cars
                .Include(c => c.PartCars)
                .ThenInclude(p => p.Part)
                .ToList()
                .Select(c => new CarWithPartsDto()
                 {
                     Car = new CarDto() { Make = c.Make, Model = c.Model, TravelledDistance = c.TravelledDistance },
                     Parts = c.PartCars != null ? c.PartCars
                         .Where(p => p.Part != null)
                         .Select(p => new PartDto()
                         {
                             Name = p.Part.Name,
                             Price = $"{p.Part.Price:f2}"
                         }) : null
                 });

            string resultJson = JsonConvert.SerializeObject(carWithParsDto, jsonSerializerSettings);

            File.WriteAllText("../../../Exports/cars-and-parts.json", resultJson);

            return resultJson;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customerTotalSales = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new CustomerTotalSalesDto()
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales
                    .SelectMany(s => s.Car.PartCars)
                    .Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            string resultJson = JsonConvert.SerializeObject(customerTotalSales, jsonSerializerSettings);

            File.WriteAllText("//../../../Exports/customers-total-sales.json", resultJson);
            
            return resultJson;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var firstTenSales = context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Car)
                .ThenInclude(c => c.PartCars)
                .ThenInclude(pc => pc.Part)
                .ProjectTo<SaleInformationDto>(mapper.ConfigurationProvider)
                .Take(10)
                .ToList();

            string resultJson = JsonConvert.SerializeObject(firstTenSales, jsonSerializerSettings);

            File.WriteAllText($"../../../Exports/sale-discounts.json", resultJson);

            return resultJson;
        }
    }
}