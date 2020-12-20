using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IServiceService : IServiceBase<ServiceModel>
    {
        Task<ActionResult<IEnumerable<ServiceModel>>> ByOrderAsync(int orderId);
    }
}
