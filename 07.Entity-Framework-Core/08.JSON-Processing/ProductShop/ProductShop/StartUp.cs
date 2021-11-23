using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Dtos.Input;
using ProductShop.Dtos.Output;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static IMapper mapper;
        public static DefaultContractResolver resolver;
        public static JsonSerializerSettings jsonSettings;

        //C:\Exports\products-in-range.json
        //../../../Exports/products-in-range.json

        public static void Main(string[] args)
        {
            MapperConfiguring();
            JsonSettingConfiguring();
            ContractResolverConfiguring();
            
            using (var context = new ProductShopContext())
            {
                //context.Database.EnsureCreated();
                //ImportUsers(context, File.ReadAllText("../../../Datasets/users.json"));
                //ImportProducts(context, File.ReadAllText("../../../Datasets/products.json"));
                //ImportCategories(context, File.ReadAllText("../../../Datasets/categories.json"));
                //ImportCategoryProducts(context, File.ReadAllText("../../../Datasets/categories-products.json"));

                string result = GetUsersWithProducts(context);
                Console.WriteLine(result);
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var inputUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputDto>>(inputJson);

            List<User> usersToAdd = new List<User>(inputUsers.Count());

            foreach (var userInputDto in inputUsers)
            {
                if (!(userInputDto.LastName.Length < 3))
                {
                    User user = mapper.Map<User>(userInputDto);
                    usersToAdd.Add(user);
                }
            }

            context.Users.AddRange(usersToAdd);
            context.SaveChanges();

            return $"Successfully imported {usersToAdd.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var inputProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputDto>>(inputJson);

            List<Product> productsToAdd = new List<Product>(inputProducts.Count());

            foreach (var productInputDto in inputProducts)
            {
                if (!(productInputDto.Name.Length < 3))
                {
                    Product product = mapper.Map<Product>(productInputDto);
                    productsToAdd.Add(product);
                }
            }

            context.Products.AddRange(productsToAdd);
            context.SaveChanges();

            return $"Successfully imported {productsToAdd.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var inputCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputDto>>(inputJson);
            
            List<Category> categoriesToAdd = new List<Category>(inputCategories.Count());

            foreach (var categoryInputDto in inputCategories)
            {
                if (categoryInputDto.Name != null)
                {
                    Category category = mapper.Map<Category>(categoryInputDto);
                    categoriesToAdd.Add(category);
                }
            }

            context.Categories.AddRange(categoriesToAdd);
            context.SaveChanges();

            return $"Successfully imported {categoriesToAdd.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var inputCategoryProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputDto>>(inputJson);
            
            List<CategoryProduct> categoryProducts = new List<CategoryProduct>(inputCategoryProducts.Count());

            foreach (var inputCategoryProduct in inputCategoryProducts)
            {
                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(inputCategoryProduct);
                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productInRange = context.Products
                .Include(s => s.Seller)
                .Where(p => p.Price > 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ProductInRangeDto>(mapper.ConfigurationProvider);

            string productsInRangeJson = JsonConvert.SerializeObject(productInRange, Formatting.Indented);

            File.WriteAllText(@"../../../Exports/products-in-range.json", productsInRangeJson);
            
            return productsInRangeJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {

            var userWithSoldProduct = context.Users
                .Where(u => u.ProductsSold.Count(p => p.Buyer != null) >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<UserWithSoldProductDto>(mapper.ConfigurationProvider)
                .ToList();

            string userWithSoldProductJson = JsonConvert.SerializeObject(userWithSoldProduct, jsonSettings);

            File.WriteAllText(@"../../../Exports/users-sold-products.json", userWithSoldProductJson);

            return userWithSoldProductJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductCount = context.Categories
                .Include(c => c.CategoryProducts)
                .ThenInclude(cp => cp.Product)
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ProjectTo<CategoryByProductsDto>(mapper.ConfigurationProvider);

            string categoriesByProductCountJson = JsonConvert.SerializeObject(categoriesByProductCount, jsonSettings);

            File.WriteAllText(@"../../../Exports/categories-by-prodects.json", categoriesByProductCountJson);

            return categoriesByProductCountJson;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                .Include(u => u.ProductsSold)
                .Where(u => u.ProductsSold.Count(p => p.Buyer != null) >= 1)
                .ToList()
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null));

            List<UserAndProductsDto> userWithProducts = new List<UserAndProductsDto>();

            foreach (var user in usersWithProducts.ToList())
            {
                userWithProducts.Add(
                    mapper.Map<UserAndProductsDto>(user)
                    );
            }

            UsersAndProductsDto users = new UsersAndProductsDto()
            {
                UsersCount = usersWithProducts.ToList().Count,
                Users = userWithProducts
            };

            string usersJson = JsonConvert.SerializeObject(users, jsonSettings);

            File.WriteAllText("../../../Exports/users-and-products.json", usersJson);

            return usersJson;
        }

        private static void MapperConfiguring()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }

        private static void JsonSettingConfiguring()
        {
            var jsonSettingsCurrent = new JsonSerializerSettings()
            {
                ContractResolver = resolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            jsonSettings = jsonSettingsCurrent;
        }

        private static void ContractResolverConfiguring()
        {
            var currentResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            resolver = currentResolver;
        }
    }
}