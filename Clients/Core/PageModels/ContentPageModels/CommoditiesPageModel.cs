using MvvmPackage.Core;
using MvvmPackage.Core.Commands;
using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Commodity;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class CommoditiesPageModel : PageModelBase
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;
        public ObservableCollection<CommodityModel> Commodities { get; }
        public ICommand AddCommodityCommand { get; }
        public ICommand CommoditySelectedCommand { get; }
        public ICommand RemoveCommodityCommand { get; }

        public CommoditiesPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            Commodities = new ObservableCollection<CommodityModel>();
            AddCommodityCommand = new AsyncCommand(navigationService.NavigateToAsync<AddCommodityPageModel>);
            CommoditySelectedCommand = new AsyncCommand<int>(navigationService.NavigateToAsync<CommodityPageModel>);
            RemoveCommodityCommand = new AsyncCommand<int>(RemoveCommodityAction);
        }

        private async Task RemoveCommodityAction(int id)
        {
            if (await _httpRequestService.Delete<CommodityModel>(id, "Błąd podczas usuwania towaru"))
            {
                Commodities.Remove(Commodities.Single(c => c.Id == id));
                _messageDialogService.ShowMessageDialog("Pomyślnie usunięto towar", MessageDialogType.Success);
            }
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            var commodities = await _httpRequestService.All<CommodityModel>();
            commodities?.ForEach(c => Commodities.Add(c));

            IsLoading = false;
        }
    }
}