using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using PropertyChanged;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class CommoditiesPageModel : PageModelBase
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvNavigationService _navigationService;
        private readonly IMessageDialogService _messageDialogService;
        public IEnumerable<CommodityModel> Commodities { get; set; }
        public ICommand AddCommodityCommand { get; set; }
        public ICommand CommoditySelectedCommand { get; set; }
        public ICommand RemoveCommodityCommand { get; set; }

        public CommoditiesPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            _messageDialogService = messageDialogService;
            AddCommodityCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddCommodityPageModel>());
            CommoditySelectedCommand = new AsyncCommand<int>((id) => _navigationService.NavigateToAsync<CommodityPageModel>(id));
            RemoveCommodityCommand = new AsyncCommand<int>(RemoveCommodityAction);
        }

        private async Task RemoveCommodityAction(int id)
        {
            Response response = await _httpRequestService.SendDelete(new CommodityPaths().GetFullPath(id.ToString()));

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    await _messageDialogService.ShowMessageDialog("Pomyślnie usunięto towar", MessageDialogType.Success);
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd podczas usuwania towaru");
                    break;
            }
            await Initialize();
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            Response<List<CommodityModel>> response = await _httpRequestService.SendGet<List<CommodityModel>>(new CommodityPaths().GetFullPath(CRUDPaths.GetAllPath));

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    Commodities = response.Content;
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania towarów");
                    break;
            }

            IsLoading = false;
        }
    }
}