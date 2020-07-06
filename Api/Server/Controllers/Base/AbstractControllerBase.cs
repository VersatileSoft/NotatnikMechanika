using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Server.Controllers.Base
{
    public abstract class AbstractControllerBase<T> : ControllerBase
    {
        private readonly IServiceBase<T> _serviceBase;
        public AbstractControllerBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        [HttpGet(CRUDPaths.GetAllPath)]
        public async Task<ActionResult<GetAllResult<T>>> GetAllAsync()
        {
            return Ok(await _serviceBase.GetAllAsync(User.Identity.Name));
        }

        [HttpGet(CRUDPaths.GetPath)]
        public async Task<ActionResult<T>> GetAsync(int id)
        {
            return Ok(await _serviceBase.GetAsync(User.Identity.Name, id));
        }

        [HttpPost(CRUDPaths.CreatePath)]
        public async Task<ActionResult<ResultBase>> CreateAsync([FromBody] T value)
        {
            return Ok(await _serviceBase.CreateAsync(User.Identity.Name, value));
        }

        [HttpPut(CRUDPaths.UpdatePath)]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] T value)
        {
            await _serviceBase.UpdateAsync(User.Identity.Name, id, value);
            return Ok();
        }

        [HttpDelete(CRUDPaths.DeletePath)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _serviceBase.DeleteAsync(User.Identity.Name, id);
            return Ok();
        }
    }
}
