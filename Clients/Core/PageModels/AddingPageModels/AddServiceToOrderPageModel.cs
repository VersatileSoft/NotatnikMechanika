using System;
using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

// ReSharper disable once CheckNamespace
namespace NotatnikMechanika.Core.PageModels
{
    public class AddServiceToOrderPageModel : PageModelBase
    {
        private int _orderId;
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;

        public List<ServiceModel> ServiceModels { get; private set; }

        public ICommand CloseCommand { get; }
        public ICommand AddRemoveServiceCommand { get; }

        public AddServiceToOrderPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            CloseCommand = new AsyncCommand(navigationService.CloseDialog);
            AddRemoveServiceCommand = new AsyncCommand<ServiceModel>(AddRemoveServiceAction);
        }

        private async Task AddRemoveServiceAction(ServiceModel serviceModel)
        {
            IsLoading = true;
            Response response;

            if (serviceModel.IsInOrder)
            {
                var path = OrderPaths.DeleteService(_orderId, serviceModel.Id);
                response = await _httpRequestService.SendDelete(path);
            }
            else
            {
                var path = OrderPaths.AddService(_orderId, serviceModel.Id);
                response = await _httpRequestService.SendPost(path);
            }

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    await _messageDialogService.ShowMessageDialog($"Pomyślnie {(serviceModel.IsInOrder ? "usunięto" : "dodano")} towar", MessageDialogType.Success);
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
            _orderId = Parameter;

            var path = ServicePaths.All(_orderId);
            var response = await _httpRequestService.SendGet<List<ServiceModel>>(path);

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    ServiceModels = response.Content;
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania usług");
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