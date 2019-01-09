using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Database.Models
{
    [AddINotifyPropertyChangedInterface]
    public class OrderDTO
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public string Details { get; set; }
        public DateTime StartOrderDate { get; set; }
        public DateTime FinishOrderDate { get; set; }
        public List<int> ServicesIds;
        public List<int> GoodsIds;
    }
}
