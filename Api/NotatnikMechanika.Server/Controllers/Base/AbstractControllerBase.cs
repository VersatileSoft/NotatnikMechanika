﻿using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<IEnumerable<T>>> GetCarsAsync()
        {
            return Ok(await _serviceBase.GetAllAsync(int.Parse(User.Identity.Name)));
        }

        [HttpGet(CRUDPaths.GetPath)]
        public async Task<ActionResult<T>> GetCarAsync(int id)
        {
            return Ok(await _serviceBase.GetAsync(int.Parse(User.Identity.Name), id));
        }

        [HttpPost(CRUDPaths.CreatePath)]
        public async Task<ActionResult> CreateCarAsync([FromBody] T value)
        {
            await _serviceBase.CreateAsync(int.Parse(User.Identity.Name), value);
            return Ok();
        }

        [HttpPut(CRUDPaths.UpdatePath)]
        public async Task<ActionResult> UpdateCarAsync(int id, [FromBody] T value)
        {
            await _serviceBase.UpdateAsync(int.Parse(User.Identity.Name), id, value);
            return Ok();
        }

        [HttpDelete(CRUDPaths.DeletePath)]
        public async Task<ActionResult> DeleteCarAsync(int id)
        {
            await _serviceBase.DeleteAsync(int.Parse(User.Identity.Name), id);
            return Ok();
        }
    }
}
