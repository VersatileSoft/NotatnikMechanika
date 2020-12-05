using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Api.Extensions;
using NotatnikMechanika.Api.Service.Interfaces.Base;
using NotatnikMechanika.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Api.Controllers.Base
{
    public abstract class AbstractControllerBase<TModel> : ControllerBase
    {
        private readonly IServiceBase<TModel> _serviceBase;
        protected AbstractControllerBase(IServiceBase<TModel> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        [HttpGet(CrudPaths.AllPath)]
        public async Task<ActionResult<Response<IEnumerable<TModel>>>> AllAsync()
        {
            return Ok(await _serviceBase.AllAsync(User.Id()));
        }

        [HttpGet(CrudPaths.ByIdPath)]
        public async Task<ActionResult<Response<TModel>>> ByIdAsync(int id)
        {
            return Ok(await _serviceBase.ByIdAsync(User.Id(), id));
        }

        [HttpPost(CrudPaths.CreatePath)]
        public async Task<ActionResult<Response>> CreateAsync([FromBody] TModel value)
        {
            return Ok(await _serviceBase.CreateAsync(User.Id(), value));
        }

        [HttpPut(CrudPaths.UpdatePath)]
        public async Task<ActionResult<Response>> UpdateAsync(int id, [FromBody] TModel value)
        {
            return Ok(await _serviceBase.UpdateAsync(User.Id(), id, value));
        }

        [HttpDelete(CrudPaths.DeletePath)]
        public async Task<ActionResult<Response>> DeleteAsync(int id)
        {   
            return Ok(await _serviceBase.DeleteAsync(User.Id(), id));
        }
    }
}
