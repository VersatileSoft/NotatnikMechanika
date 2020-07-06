using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Shared.Models.Car
{
    public class CarsResult : ResultBase
    {
        public IEnumerable<CarModel> Cars { get; set; }
    }
}
