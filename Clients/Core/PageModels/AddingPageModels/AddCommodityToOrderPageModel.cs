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

namespace NotatnikMechanika.Core.PageModels
{
    public class AddCommodityToOrderPageModel : PageModelBase
    {
        private int _orderId;
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;

        public List<CommodityForOrderModel> CommodityModels { get; set; }

        public ICommand CloseCommand { get; set; }
        public ICommand AddRemoveCommodityCommand { get; set; }

        public AddCommodityToOrderPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            CloseCommand = new AsyncCommand(() => navigationService.CloseDialog());
            AddRemoveCommodityCommand = new AsyncCommand<CommodityForOrderModel>(AddRemoveCommodityAction);
        }

        private async Task AddRemoveCommodityAction(CommodityForOrderModel commodityModel)
        {
            IsLoading = true;
            Response response;
            if (commodityModel.IsInOrder)
            {
                string path = new OrderPaths().GetFullPath(OrderPaths.DeleteCommodityFromOrder.Replace("{orderId}", _orderId.ToString()).Replace("{commodityId}", commodityModel.Id.ToString()));
                response = await _httpRequestService.SendDelete(path);
            }
            else
            {
                string path = new OrderPaths().GetFullPath(OrderPaths.AddCommodityToOrder.Replace("{orderId}", _orderId.ToString()).Replace("{commodityId}", commodityModel.Id.ToString()));
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
            }

            IsLoading = false;
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            _orderId = Parameter;
            string path = new CommodityPaths().GetFullPath(CommodityPaths.GetAllForOrderPath.Replace("{orderId}", _orderId.ToString()));
            Response<List<CommodityForOrderModel>> response = await _httpRequestService.SendGet<List<CommodityForOrderModel>>(path);

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    CommodityModels = response.Content;
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania towarów");
                    break;
            }
            IsLoading = false;
        }
    }
}