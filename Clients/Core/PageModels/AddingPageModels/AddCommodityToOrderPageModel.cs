using System;
using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

// ReSharper disable once CheckNamespace
namespace NotatnikMechanika.Core.PageModels
{
    public class AddCommodityToOrderPageModel : PageModelBase
    {
        private int _orderId;
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;

        public List<CommodityModel> CommodityModels { get; private set; }

        public ICommand CloseCommand { get; }
        public ICommand AddRemoveCommodityCommand { get; }

        public AddCommodityToOrderPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            CloseCommand = new AsyncCommand(navigationService.CloseDialog);
            AddRemoveCommodityCommand = new AsyncCommand<CommodityModel>(AddRemoveCommodityAction);
        }

        private async Task AddRemoveCommodityAction(CommodityModel commodityModel)
        {
            IsLoading = true;
            Response response;
            if (commodityModel.IsInOrder)
            {
                var path = OrderPaths.DeleteCommodity(_orderId, commodityModel.Id);
                response = await _httpRequestService.SendDelete(path);
            }
            else
            {
                var path = OrderPaths.AddCommodity(_orderId, commodityModel.Id);
                response = await _httpRequestService.SendPost(path);
            }

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    await _messageDialogService.ShowMessageDialog($"Pomyślnie {(commodityModel.IsInOrder ? "usunięto" : "dodano")} towar", MessageDialogType.Success);
                    await Initialize();
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Coś poszło nie tak");
                    break;

                case ResponseType.BadModelState:
                    await _messageDialogService.ShowMessageDialog("Wypełnij dane poprawnie", MessageDialogType.Error);
                    break;
                case ResponseType.Unauthorized:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            IsLoading = false;
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            _orderId = Parameter ?? 0;
            var path = CommodityPaths.All(_orderId);
            var response = await _httpRequestService.SendGet<List<CommodityModel>>(path);

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    CommodityModels = response.Content;
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