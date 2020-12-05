using AutoMapper;
using NotatnikMechanika.Api.Data.Models;
using NotatnikMechanika.Api.Repository.Interfaces;
using NotatnikMechanika.Api.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Api.Service.Services
{
    public class CommodityService : ServiceBase<CommodityModel, Commodity>, ICommodityService
    {
        private readonly ICommodityRepository _commodityRepository;

        public CommodityService(ICommodityRepository commodityRepository, IMapper mapper) : base(commodityRepository, mapper)
        {
            _commodityRepository = commodityRepository;
        }

        public async Task<Response<IEnumerable<CommodityModel>>> AllAsync(string userId, int orderId)
        {
            return SuccessResponse(await _commodityRepository.AllAsync(userId, orderId));
        }

        public async Task<Response<IEnumerable<CommodityModel>>> ByOrderAsync(string userId, int orderId)
        {
            return SuccessResponse(await _commodityRepository.ByOrderAsync(userId, orderId));
        }
    }
}
