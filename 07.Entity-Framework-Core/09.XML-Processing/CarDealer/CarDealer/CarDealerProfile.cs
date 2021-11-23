using System.Linq;
using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierInputDto, Supplier>();
            CreateMap<PartInputDto, Part>();
            CreateMap<CustomerInputDto, Customer>();
            CreateMap<SaleInputDto, Sale>();
            CreateMap<Car, CarWithDistanceDto>();
            CreateMap<Car, BMWCarDto>();
            CreateMap<Supplier, LocalSupplierDto>();

            CreateMap<CarInputDto, Car>()
                .ForMember(m => m.PartCars,
                    opt => opt.MapFrom(
                        f => f.PartIds.Select(p => new PartCar()
                        {
                            PartId = p
                        })));

            CreateMap<Car, CarWithParts>()
                .ForMember(m => m.Parts,
                    opt => opt.MapFrom(
                        f => f.PartCars.Select(pc => new PartDto()
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        }).OrderByDescending(p => p.Price)));
        }
    }
}
