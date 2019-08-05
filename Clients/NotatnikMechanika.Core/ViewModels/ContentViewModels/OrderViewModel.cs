using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Models;
using PropertyChanged;

namespace NotatnikMechanika.Core.ViewModels.ContentViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrderViewModel : MvxViewModel<OrderExtendedModel>
    {
        private readonly IHttpRequestService _httpRequestService;

        public ICommand GoBackCommand { get; set; }

        public OrderExtendedModel OrderModel { get; set; }

        public OrderViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        {
            OrderModel = new OrderExtendedModel();
            _httpRequestService = httpRequestService;
            GoBackCommand = new MvxAsyncCommand(() => navigationService.Navigate<MainPageViewModel>());
        }

        public override void Prepare(OrderExtendedModel model)
        {
            OrderModel = model;
        }
    }
}
