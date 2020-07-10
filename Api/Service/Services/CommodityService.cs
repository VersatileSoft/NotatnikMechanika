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

        public async Task<Response<IEnumerable<CommodityForOrderModel>>> GetCommoditiesForOrder(string userId, int orderId)
        {
            return CreateResponse(await _commodityRepository.GetCommoditiesForOrder(userId, orderId));
        }

        public async Task<Response<IEnumerable<CommodityModel>>> GetCommoditiesInOrder(string userId, int orderId)
        {
            return CreateResponse(await _commodityRepository.GetCommoditiesInOrder(userId, orderId));
        }
    }
}
