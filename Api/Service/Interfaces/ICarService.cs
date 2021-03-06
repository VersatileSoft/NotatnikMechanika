﻿using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface ICarService : IServiceBase<CarModel>
    {
        Task<ActionResult<IEnumerable<CarModel>>> ByCustomerAsync(int customerId);
    }
}
