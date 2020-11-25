using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Services
{
    public class CommodityService : ServiceBase<CommodityModel>, ICommodityService
    {
        private readonly ICommodityRepository _commodityRepository;

        public CommodityService(ICommodityRepository commodityRepository) : base(commodityRepository)
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
