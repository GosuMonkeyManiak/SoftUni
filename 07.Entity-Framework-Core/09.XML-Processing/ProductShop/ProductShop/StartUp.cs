using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper.QueryableExtensions;
using ProductShop.Dtos.Export;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;
        private static MapperConfiguration mapperConfiguration;

        public static void Main(string[] args)
        {
            mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile<ProductShopProfile>();
            });
            mapper = mapperConfiguration.CreateMapper();


            using (var context = new ProductShopContext())
            {
                //context.Database.EnsureCreated();
                //ImportUsers(context, File.ReadAllText("Datasets/users.xml"));
                //ImportProducts(context, File.ReadAllText("Datasets/products.xml"));
                //ImportCategories(context, File.ReadAllText("Datasets/categories.xml"));
                //ImportCategoryProducts(context, File.ReadAllText("Datasets/categories-products.xml"));

                string result = GetUsersWithProducts(context);
                Console.WriteLine(result);
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var root = new XmlRootAttribute("Users");
            var serializer = new XmlSerializer(typeof(List<UserInputDto>), root);

            var deserializedUsers = (List<UserInputDto>) serializer.Deserialize(new StringReader(inputXml));

            var usersToBeAdd = new List<User>();

            foreach (var userInputDto in deserializedUsers)
            {
                usersToBeAdd.Add(mapper.Map<User>(userInputDto));
            }

            context.Users.AddRange(usersToBeAdd);
            context.SaveChanges();

            return $"Successfully imported {usersToBeAdd.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var root = new XmlRootAttribute("Products");
            var serializer = new XmlSerializer(typeof(List<ProductInputDto>), root);

            var deserializedProducts = (List<ProductInputDto>) serializer.Deserialize(new StringReader(inputXml));

            List<Product> productToBeAdd = new List<Product>();

            foreach (var productInputDto in deserializedProducts)
            {
                productToBeAdd.Add(mapper.Map<Product>(productInputDto));
            }

            context.Products.AddRange(productToBeAdd);
            context.SaveChanges();

            return $"Successfully imported {productToBeAdd.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var root = new XmlRootAttribute("Categories");

            var serializer = new XmlSerializer(typeof(CategoryInputDto[]), root);

            var deserializedCategories = (CategoryInputDto[])serializer.Deserialize(new StringReader(inputXml));

            List<Category> categoriesToBeAdd = new List<Category>();

            foreach (var categoryInputDto in deserializedCategories)
            {
                if (categoryInputDto.Name != null)
                {
                    categoriesToBeAdd.Add(mapper.Map<Category>(categoryInputDto));
                }
            }

            context.Categories.AddRange(categoriesToBeAdd);
            context.SaveChanges();

            return $"Successfully imported {categoriesToBeAdd.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var root = new XmlRootAttribute("CategoryProducts");

            var serializer = new XmlSerializer(typeof(CategoryProductInputDto[]), root);

            var deserializerdCategoryProducts = (CategoryProductInputDto[]) serializer.Deserialize(new StringReader (inputXml));

            var categoryIds = context.Categories.Select(c => c.Id);
            var productIds = context.Products.Select(p => p.Id);

            var categoryProductToBeAdd = new List<CategoryProduct>();

            foreach (var categoryProductInputDto in deserializerdCategoryProducts)
            {
                if (categoryIds.Contains(categoryProductInputDto.CategoryId) && 
                    productIds.Contains(categoryProductInputDto.ProductId))
                {
                    categoryProductToBeAdd.Add(mapper.Map<CategoryProduct>(categoryProductInputDto));
                }
            }

            context.CategoryProducts.AddRange(categoryProductToBeAdd);
            context.SaveChanges();

            return $"Successfully imported {categoryProductToBeAdd.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile<ProductShopProfile>();
            });
            var mapper = mapperConfiguration.CreateMapper();

            StringBuilder sb = new StringBuilder();

            var productInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ProductInRangeDto>(mapper.ConfigurationProvider)
                .ToArray();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var root = new XmlRootAttribute("Products");
            var serializer = new XmlSerializer(typeof(ProductInRangeDto[]), root);

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                serializer.Serialize(stringWriter, productInRange, namespaces);
            }
            
            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var usersWithSoldProducts = context.Users
                .Where(s => s.ProductsSold.Count(ps => ps.Buyer != null) > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<UserWithSoldProductsDto>(mapper.ConfigurationProvider)
                .ToList();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var root = new XmlRootAttribute("Users");
            var serializer = new XmlSerializer(typeof(List<UserWithSoldProductsDto>), root);

            using (var stringWriter = new StringWriter(sb))
            {
                serializer.Serialize(stringWriter, usersWithSoldProducts, namespaces);
            }


            return sb.ToString().Trim();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductCount = context.Categories
                .Include(c => c.CategoryProducts)
                .ThenInclude(cp => cp.Product)
                .ToList()
                .Select(c => new CategoryByProdcutCountDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = !c.CategoryProducts.Any() ? 0m : c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = !c.CategoryProducts.Any() ? 0m : c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(String.Empty, String.Empty);

            var root = new XmlRootAttribute("Categories");
            XmlSerializer serializer = new XmlSerializer(typeof(List<CategoryByProdcutCountDto>), root);

            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                serializer.Serialize(stringWriter, categoriesByProductCount, xmlNamespaces);
            }

            return sb.ToString().Trim();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                .Include(u => u.ProductsSold)
                .Where(u => u.ProductsSold.Count(ps => ps.Buyer != null) >= 1)
                .OrderByDescending(u => u.ProductsSold.Count(ps => ps.Buyer != null))
                .Take(10)
                .ToList()
                .Select(u => new UserWithProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductDto()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                            .Select(p => new ProductDto()
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToList()
                    }
                })
                .ToList();

            UsersDto users = new UsersDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any(ps => ps.Buyer != null)), 
                Users = usersWithProducts
            };

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(String.Empty, String.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(UsersDto), new XmlRootAttribute("Users"));

            StringBuilder sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            return sb.ToString().Trim();
        }
    }
}