using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Linq;

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
                .ForMember(m => m.BuyerName, 
                    opt => opt.MapFrom(
                        f => string.Concat(f.Buyer.FirstName, " ", f.Buyer.LastName).Trim()));

            CreateMap<User, UserWithSoldProductsDto>()
                .ForMember(m => m.Products,
                    opt => opt.MapFrom(
                        f => f.ProductsSold.Select(ps => new ProductDto()
                        {
                            Name = ps.Name,
                            Price = ps.Price,
                        }).ToArray()));

            CreateMap<Category, CategoryByProdcutCountDto>()
                .ForMember(m => m.Count,
                    opt => opt.MapFrom(f => f.CategoryProducts.Count))
                .ForMember(m => m.AveragePrice,
                    opt => opt.MapFrom(f => f.CategoryProducts.Average(cp => cp.Product.Price)))
                .ForMember(m => m.TotalRevenue,
                    opt => opt.MapFrom(f => f.CategoryProducts.Sum(cp => cp.Product.Price)));
        }
    }
}
