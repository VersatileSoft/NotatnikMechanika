using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Commodity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Service.Services
{
    public class CommodityService : ServiceBase<CommodityModel>, ICommodityService
    {
        public CommodityService(ICommodityRepository commodityRepository) : base(commodityRepository) { }
    }
}
