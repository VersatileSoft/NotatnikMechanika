using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Server.Controllers
{
    [Authorize]
    [Route(CustomerPaths.Name)]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _CustomerService;
        public CustomerController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        [HttpGet(CustomerPaths.GetCustomersPath)]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomersAsync()
        {
            return Ok(await _CustomerService.GetCustomersAsync(int.Parse(User.Identity.Name)));
        }

        [HttpGet(CustomerPaths.GetCustomerPath)]
        public async Task<ActionResult<CustomerModel>> GetCustomerAsync(int id)
        {
            return Ok(await _CustomerService.GetCustomerAsync(int.Parse(User.Identity.Name), id));
        }

        [HttpPost(CustomerPaths.CreatePath)]
        public async Task<ActionResult> CreateCustomerAsync([FromBody] CustomerModel value)
        {
            await _CustomerService.CreateAsync(int.Parse(User.Identity.Name), value);
            return Ok();
        }

        [HttpPut(CustomerPaths.UpdatePath)]
        public async Task<ActionResult> UpdateCustomerAsync(int id, [FromBody] CustomerModel value)
        {
            await _CustomerService.UpdateAsync(int.Parse(User.Identity.Name), id, value);
            return Ok();
        }

        [HttpDelete(CustomerPaths.DeletePath)]
        public async Task<ActionResult> DeleteCustomerAsync(int id)
        {
            await _CustomerService.DeleteAsync(int.Parse(User.Identity.Name), id);
            return Ok();
        }
    }
}
