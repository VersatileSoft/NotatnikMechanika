using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Commodity;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Response response = await _httpRequestService.Delete<CommodityModel>(id);

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    await _messageDialogService.ShowMessageDialog("Pomyślnie usunięto towar", MessageDialogType.Success);
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd podczas usuwania towaru");
                    break;
                case ResponseType.Unauthorized:
                    break;
                case ResponseType.BadModelState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            await Initialize();
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            Response<List<CommodityModel>> response = await _httpRequestService.All<CommodityModel>();

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    response.Content.ForEach(c => Commodities.Add(c));
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania towarów");
                    break;
                case ResponseType.Unauthorized:
                    break;
                case ResponseType.BadModelState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            IsLoading = false;
        }
    }
}