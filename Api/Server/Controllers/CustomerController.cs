using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Api.Controllers.Base;
using NotatnikMechanika.Api.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Customer;

namespace NotatnikMechanika.Api.Controllers
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
