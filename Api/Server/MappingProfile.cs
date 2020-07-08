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
            CreateMap<Customer, CustomerModel>();
            CreateMap<Car, CarModel>();
            CreateMap<Data.Models.Service, ServiceModel>();
            CreateMap<Commodity, CommodityModel>();
        }
    }
}
