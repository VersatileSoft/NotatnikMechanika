using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NotatnikMechanika.Data.Models;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Services
{
    public class CommodityService : ServiceBase<CommodityModel, Commodity>, ICommodityService
    {
        private readonly ICommodityRepository _commodityRepository;

        public CommodityService(ICommodityRepository commodityRepository, IMapper mapper) : base(commodityRepository, mapper)
        {
            _commodityRepository = commodityRepository;
        }

        public async Task<Response<IEnumerable<CommodityModel>>> AllAsync(int orderId)
        {
            return SuccessResponse(await _commodityRepository.AllAsync(orderId));
        }

        public async Task<Response<IEnumerable<CommodityModel>>> ByOrderAsync(int orderId)
        {
            return SuccessResponse(await _commodityRepository.ByOrderAsync(orderId));
        }
    }
}
