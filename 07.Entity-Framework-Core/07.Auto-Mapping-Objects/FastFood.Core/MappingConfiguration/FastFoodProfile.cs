namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using System.Linq;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Position, RegisterEmployeeViewModel>();

            //Employee
            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(m => m.Position, opt => opt.MapFrom(f => f.Position.Name));

            //Order
            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(d => d.OrderItems, opt => opt.MapFrom(src => new OrderItem() { ItemId = src.ItemId}))
                .ForMember(d => d.OrderItems, opt => opt.MapFrom(src => new OrderItem() { Quantity = src.Quantity }));

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(m => m.OrderId, opt => opt.MapFrom(f => f.Id))
                .ForMember(m => m.Employee, opt => opt.MapFrom(f => f.Employee.Name));

        }
    }
}
