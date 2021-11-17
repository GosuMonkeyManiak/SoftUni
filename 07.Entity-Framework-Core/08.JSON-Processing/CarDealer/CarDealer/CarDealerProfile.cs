using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO.InputDtos;
using CarDealer.DTO.OutputDtos;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //inputDtos
            CreateMap<SupplierInputDto, Supplier>();
            CreateMap<PartInputDto, Part>();

            CreateMap<CarInputDto, Car>()
                .ForMember(m => m.PartCars,
                    opt => opt.MapFrom(f => f.PartsId.Distinct()
                        .Select(p => new PartCar()
                        {
                            PartId = p
                        })));

            CreateMap<CustomerInputDto, Customer>();
            CreateMap<SaleInputDto, Sale>();

            //outputDtos

            CreateMap<Customer, OrderedCustomerDto>();
            CreateMap<Car, CarFromMakeDto>();

            CreateMap<Supplier, LocalSuppliersDto>()
                .ForMember(m => m.PartsCount,
                    opt => opt.MapFrom(
                        f => f.Parts.Count));

            CreateMap<Car, CarWithPartsDto>()
                .ForMember(m => m.Car,
                    opt => opt.MapFrom(
                        f => new CarDto()
                        {
                            Make = f.Make,
                            Model = f.Model,
                            TravelledDistance = f.TravelledDistance
                        }))
                .ForMember(m => m.Parts,
                    opt => opt.MapFrom(
                        f => f.PartCars
                            .Select(p => new PartDto()
                            {
                                Name = p.Part.Name,
                                Price = $"{p.Part.Price}"
                            })));

            CreateMap<Sale, SaleInformationDto>()
                .ForMember(m => m.Car, opt =>
                    opt.MapFrom(f => new CarDto()
                    {
                        Make = f.Car.Make,
                        Model = f.Car.Model,
                        TravelledDistance = f.Car.TravelledDistance
                    }))
                .ForMember(m => m.Discount, opt => opt.MapFrom(f => $"{f.Discount:f2}"))
                .ForMember(m => m.Price, opt =>
                    opt.MapFrom(f =>
                        $"{f.Car.PartCars.Sum(pc => pc.Part.Price):f2}"))
                .ForMember(m => m.PriceWithDiscount, opt => 
                    opt.MapFrom(f =>
                        $"{f.Car.PartCars.Sum(pc => pc.Part.Price) * (1 - (f.Discount / 100)):f2}"));
        }
    }
}
