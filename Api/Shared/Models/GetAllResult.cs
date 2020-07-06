using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Shared.Models
{
    public class GetAllResult<TModel> : ResultBase
    {
        public IEnumerable<TModel> Models { get; set; }
    }
}
