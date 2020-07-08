using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Server.Controllers.Base
{
    public abstract class AbstractControllerBase<TModel> : ControllerBase
    {
        private readonly IServiceBase<TModel> _serviceBase;
        protected AbstractControllerBase(IServiceBase<TModel> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        [HttpGet(CRUDPaths.GetAllPath)]
        public async Task<ActionResult<Response<IEnumerable<TModel>>>> GetAllAsync()
        {
            return Ok(await _serviceBase.GetAllAsync(User.Identity.Name));
        }

        [HttpGet(CRUDPaths.GetPath)]
        public async Task<ActionResult<Response<TModel>>> GetAsync(int id)
        {
            return Ok(await _serviceBase.GetAsync(User.Identity.Name, id));
        }

        [HttpPost(CRUDPaths.CreatePath)]
        public async Task<ActionResult<Response>> CreateAsync([FromBody] TModel value)
        {
            return Ok(await _serviceBase.CreateAsync(User.Identity.Name, value));
        }

        [HttpPut(CRUDPaths.UpdatePath)]
        public async Task<ActionResult<Response>> UpdateAsync(int id, [FromBody] TModel value)
        {
            await _serviceBase.UpdateAsync(User.Identity.Name, id, value);
            return Ok();
        }

        [HttpDelete(CRUDPaths.DeletePath)]
        public async Task<ActionResult<Response>> DeleteAsync(int id)
        {
            await _serviceBase.DeleteAsync(User.Identity.Name, id);
            return Ok();
        }
    }
}
