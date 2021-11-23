using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using IMapper = AutoMapper.IMapper;
using MapperConfiguration = AutoMapper.MapperConfiguration;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile<CarDealerProfile>();
            });
            mapper = mapperConfiguration.CreateMapper();

            using (var context = new CarDealerContext())
            {
                //context.Database.EnsureCreated();
                //ImportSuppliers(context, File.ReadAllText("Datasets/suppliers.xml"));
                //ImportParts(context, File.ReadAllText("Datasets/parts.xml"));
                //ImportCars(context, File.ReadAllText("Datasets/cars.xml"));
                //ImportCustomers(context, File.ReadAllText("Datasets/customers.xml"));
                //ImportSales(context, File.ReadAllText("Datasets/sales.xml"));

                string result = GetSalesWithAppliedDiscount(context);
                Console.WriteLine(result);
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer serializer = new XmlSerializer(typeof(List<SupplierInputDto>), xmlRoot);

            var deserialized = (List<SupplierInputDto>)serializer.Deserialize(new StringReader(inputXml));

            List<Supplier> suppliersToBeAdd = new List<Supplier>();

            foreach (var supplierInputDto in deserialized)
            {
                suppliersToBeAdd.Add(mapper.Map<Supplier>(supplierInputDto));
            }

            context.Suppliers.AddRange(suppliersToBeAdd);
            context.SaveChanges();

            return $"Successfully imported {suppliersToBeAdd.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            List<int> supplierIds = context.Suppliers.Select(s => s.Id).ToList();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer serializer = new XmlSerializer(typeof(List<PartInputDto>), xmlRoot);

            List<PartInputDto> deserializedParts =
                (List<PartInputDto>)serializer.Deserialize(new StringReader(inputXml));

            List<Part> partsToBeAdd = new List<Part>();

            foreach (var partInputDto in deserializedParts)
            {
                if (supplierIds.Contains(partInputDto.SupplierId))
                {
                    partsToBeAdd.Add(mapper.Map<Part>(partInputDto));
                }
            }

            context.Parts.AddRange(partsToBeAdd);
            context.SaveChanges();

            return $"Successfully imported {partsToBeAdd.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");
            XmlSerializer serializer = new XmlSerializer(typeof(List<CarInputDto>), xmlRoot);

            List<int> partIds = context.Parts.Select(p => p.Id).ToList();

            List<CarInputDto> deserializedCars = (List<CarInputDto>) serializer.Deserialize(new StringReader(inputXml));

            List<Car> carsToBeAdd = new List<Car>();

            foreach (var carInputDto in deserializedCars)
            {
                carInputDto.PartIds = carInputDto.Parts.Select(p => p.Id).Distinct().ToList();

                if (carInputDto.PartIds.All(p => partIds.Contains(p)))
                {
                    carsToBeAdd.Add(mapper.Map<Car>(carInputDto));
                }
            }

            context.Cars.AddRange(carsToBeAdd);
            context.SaveChanges();

            return $"Successfully imported {carsToBeAdd.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Customers");
            XmlSerializer serializer = new XmlSerializer(typeof(List<CustomerInputDto>), xmlRoot);

            List<CustomerInputDto> deserializedCustomers =
                (List<CustomerInputDto>) serializer.Deserialize(new StringReader(inputXml));

            List<Customer> customersToBeAdd = new List<Customer>();

            foreach (var customerInputDto in deserializedCustomers)
            {
                customersToBeAdd.Add(mapper.Map<Customer>(customerInputDto));
            }

            context.Customers.AddRange(customersToBeAdd);
            context.SaveChanges();

            return $"Successfully imported {customersToBeAdd.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Sales");
            XmlSerializer serializer = new XmlSerializer(typeof(List<SaleInputDto>), xmlRoot);

            List<int> carIds = context.Cars.Select(c => c.Id).ToList();

            List<SaleInputDto> deserializedSales = (List<SaleInputDto>) serializer.Deserialize(new StringReader(inputXml));

            List<Sale> saleToBeAdd = new List<Sale>();

            foreach (var saleInputDto in deserializedSales)
            {
                if (carIds.Contains(saleInputDto.CarId))
                {
                    saleToBeAdd.Add(mapper.Map<Sale>(saleInputDto));
                }
            }

            context.Sales.AddRange(saleToBeAdd);
            context.SaveChanges();

            return $"Successfully imported {saleToBeAdd.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsWithDistance = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<CarWithDistanceDto>(mapper.ConfigurationProvider)
                .ToList();

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(String.Empty, String.Empty);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer serializer = new XmlSerializer(typeof(List<CarWithDistanceDto>), xmlRoot);

            StringBuilder sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), carsWithDistance, xmlNamespaces);

            return sb.ToString().Trim();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmwCars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<BMWCarDto>(mapper.ConfigurationProvider)
                .ToList();

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(String.Empty, String.Empty);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer serializer = new XmlSerializer(typeof(List<BMWCarDto>), xmlRoot);

            StringBuilder sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), bmwCars, xmlNamespaces);

            return sb.ToString().Trim();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<LocalSupplierDto>(mapper.ConfigurationProvider)
                .ToList();

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(String.Empty, String.Empty);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("suppliers");
            XmlSerializer serializer = new XmlSerializer(typeof(List<LocalSupplierDto>), xmlRoot);

            StringBuilder sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), localSuppliers, xmlNamespaces);

            return sb.ToString().Trim();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Include(c => c.PartCars)
                .ThenInclude(c => c.Part)
                .ProjectTo<CarWithParts>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToList();

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer serializer = new XmlSerializer(typeof(List<CarWithParts>), xmlRoot);

            StringBuilder sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            return sb.ToString().Trim();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new CustomerTotalSales()
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.SelectMany(s => s.Car.PartCars).Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToList();

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("customers");
            XmlSerializer serializer = new XmlSerializer(typeof(List<CustomerTotalSales>), xmlRoot);

            StringBuilder sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), customers, xmlNamespaces);

            return sb.ToString().Trim();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Include(s => s.Car)
                .ThenInclude(c => c.PartCars)
                .ThenInclude(p => p.Part)
                .Include(s => s.Customer)
                .ToList()
                .Select(s => new CustomerTotalSalesWithDiscount()
                {
                    Car = new CarDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance.ToString(CultureInfo.InvariantCulture)
                    },
                    CustomerName = s.Customer.Name,
                    Discount = Math.Truncate(s.Discount).ToString(CultureInfo.InvariantCulture),
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) * (1 - (s.Discount / 100))) / 1.000000000000000000000000000000000m
                })
                .ToList();

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("sales");
            XmlSerializer serializer = new XmlSerializer(typeof(List<CustomerTotalSalesWithDiscount>), xmlRoot);

            StringBuilder sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), sales, xmlNamespaces);

            return sb.ToString().Trim();
        }
    }
}