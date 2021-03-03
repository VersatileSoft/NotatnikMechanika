using AutoMapper;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Shared.Models.Car;
using NotatnikMechanika.Shared.Models.Commodity;
using NotatnikMechanika.Shared.Models.Customer;
using NotatnikMechanika.Shared.Models.Order;
using NotatnikMechanika.Shared.Models.Service;

namespace NotatnikMechanika.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderExtendedModel>()
                .ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.Car))
                .ForMember(dest => dest.CustomerModel, opt => opt.MapFrom(src => src.Car.Customer));
            CreateMap<OrderModel, Order>();
            CreateMap<Order, OrderModel>();
            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>();
            CreateMap<Car, CarModel>();
            CreateMap<CarModel, Car>();
            CreateMap<Data.Models.Service, ServiceModel>();
            CreateMap<ServiceModel, Data.Models.Service>();
            CreateMap<Commodity, CommodityModel>();
            CreateMap<CommodityModel, Commodity>();

            //TODO Maping not working as expected, Finished property always false
            CreateMap<OrderToCommodity, CommodityModel>()
                .ForMember(model => model.Finished,
                    opt => opt.MapFrom(otc => otc.Finished))
                .IncludeMembers(a => a.Commodity);

            CreateMap<OrderToService, ServiceModel>()
                .ForMember(model => model.Finished,
                    opt => opt.MapFrom(otc => otc.Finished))
                .IncludeMembers(a => a.Service);
        }
    }
}
