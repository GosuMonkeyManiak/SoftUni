using System;
using System.Linq;
using AutoMapper;
using ProductShop.Dtos.Input;
using ProductShop.Dtos.Output;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserInputDto, User>();
            CreateMap<ProductInputDto, Product>();
            CreateMap<CategoryInputDto, Category>();
            CreateMap<CategoryProductInputDto, CategoryProduct>();

            CreateMap<Product, ProductInRangeDto>()
                .ForMember(m => m.SellerFullName,
                    opt => opt.MapFrom(f => string.Concat(f.Seller.FirstName, " ", f.Seller.LastName)));

            CreateMap<User, UserWithSoldProductDto>()
                .ForMember(m => m.SoldProducts,
                    opt => opt.MapFrom(f => f.ProductsSold
                        .Select(p => new SoldProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })));

            CreateMap<Category, CategoryByProductsDto>()
                .ForMember(m => m.ProductCount,
                    opt => opt.MapFrom(f => f.CategoryProducts.Count))
                .ForMember(m => m.AveragePrice,
                    opt => opt.MapFrom(f => $"{(f.CategoryProducts.Sum(p => p.Product.Price) / f.CategoryProducts.Count):f2}"))
                .ForMember(m => m.TotalRevenue,
                    opt => opt.MapFrom(f => 
                        $"{f.CategoryProducts.Sum(p => p.Product.Price):f2}"));

            CreateMap<User, UserAndProductsDto>()
                .ForMember(m => m.SoldProducts,
                    opt => opt.MapFrom(
                        f => new ProductsDto()
                        {
                            Count = f.ProductsSold.Count(p => p.Buyer != null),
                            Products = f.ProductsSold
                                .Where(p => p.Buyer != null)
                                .Select(p => new ProductDto() { Name = p.Name, Price = p.Price })
                        }));
        }
    }
}
