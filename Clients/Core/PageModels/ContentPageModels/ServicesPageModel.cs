using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Service;
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
    public class ServicesPageModel : PageModelBase
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;
        public ObservableCollection<ServiceModel> Services { get; }
        public ICommand AddServiceCommand { get; }
        public ICommand ServiceSelectedCommand { get; }
        public ICommand RemoveServiceCommand { get; }

        public ServicesPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            Services = new ObservableCollection<ServiceModel>();
            AddServiceCommand = new AsyncCommand(navigationService.NavigateToAsync<AddServicePageModel>);
            ServiceSelectedCommand = new AsyncCommand<int>(navigationService.NavigateToAsync<ServicePageModel>);
            RemoveServiceCommand = new AsyncCommand<int>(RemoveServiceAction);
        }
        private async Task RemoveServiceAction(int id)
        {
            Response response = await _httpRequestService.Delete<ServiceModel>(id);

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    await _messageDialogService.ShowMessageDialog("Pomyślnie usunięto usługę", MessageDialogType.Success);
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd podczas usuwania ułsugi");
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
            Response<List<ServiceModel>> response = await _httpRequestService.All<ServiceModel>();

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    Services.Clear();
                    response.Content.ForEach(m => Services.Add(m));
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania usługi");
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