using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces.Base
{
    public interface IServiceBase<TModel>
    {
        Task<ActionResult<IEnumerable<TModel>>> AllAsync();
        Task<ActionResult<TModel>> ByIdAsync(int id);
        Task<ActionResult> CreateAsync(TModel value);
        Task<ActionResult> UpdateAsync(int id, TModel value);
        Task<ActionResult> DeleteAsync(int id);
    }
}
