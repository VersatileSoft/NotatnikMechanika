using System;
using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Order;
using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrdersPageModel : PageModelBase
    {
        public ObservableCollection<OrderExtendedModel> Orders { get; set; }
        public ICommand AddOrderCommand { get; }
        public ICommand OrderSelectedCommand { get; set; }
        public ICommand RemoveOrderCommand { get; }
        public ICommand RefreshOrdersCommand { get; set; }

        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;
        private readonly IAuthService _authService;

        public OrdersPageModel(IMvNavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService, IAuthService authService)
        {
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            _authService = authService;
            Orders = new ObservableCollection<OrderExtendedModel>();
            AddOrderCommand = new AsyncCommand(navigationService.NavigateToAsync<AddOrderPageModel>);
            OrderSelectedCommand = new AsyncCommand<int>(async (int _) => await navigationService.NavigateToAsync<OrderPageModel>().ConfigureAwait(false));
            RemoveOrderCommand = new AsyncCommand<int>(RemoveOrderAction);
            RefreshOrdersCommand = new AsyncCommand(Initialize);
        }

        private async Task RemoveOrderAction(int id)
        {
            var response = await _httpRequestService.Delete<OrderModel>(id);

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    await _messageDialogService.ShowMessageDialog("Pomyślnie usunięto zlecenie", MessageDialogType.Success).ConfigureAwait(false);
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd podczas usuwania zlecenia").ConfigureAwait(false);
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
            var response = await _httpRequestService.SendGet<List<OrderExtendedModel>>(OrderPaths.Extended(Parameter.HasValue));

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    Orders.Clear();
                    response.Content.ForEach(i => Orders.Add(i));
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania zleceń").ConfigureAwait(false);
                    break;

                case ResponseType.Unauthorized:
                    await _authService.LogoutAsync().ConfigureAwait(false);
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