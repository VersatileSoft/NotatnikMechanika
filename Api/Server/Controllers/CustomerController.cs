using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Server.Controllers.Base;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Customer;

namespace NotatnikMechanika.Server.Controllers
{
    [Authorize]
    [Route(CustomerPaths.Name)]
    public class CustomerController : AbstractControllerBase<CustomerModel>
    {

        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) : base(customerService)
        {
            _customerService = customerService;
        }
    }
}
