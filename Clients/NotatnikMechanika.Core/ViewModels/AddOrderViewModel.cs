using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels
{
    public class AddOrderViewModel : MvxViewModel
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public ICommand AddOrder { get; set; }
        public AddOrderViewModel()
        {
            AddOrder = new MvxAsyncCommand(AddOrderAction);
        }

        private async Task AddOrderAction()
        {

        }
    }
}
