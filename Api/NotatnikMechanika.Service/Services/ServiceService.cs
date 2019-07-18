using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Service.Services
{
    public class ServiceService : ServiceBase<ServiceModel>, IServiceService
    {
        public ServiceService(IServiceRepository serviceRepository) : base(serviceRepository) { }
    }
}
