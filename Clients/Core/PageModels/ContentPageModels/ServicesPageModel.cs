using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Service;
using PropertyChanged;
using System.Collections.Generic;
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
        private readonly IMvNavigationService _navigationService;
        private readonly IMessageDialogService _messageDialogService;
        public IEnumerable<ServiceModel> Services { get; set; }
        public ICommand AddServiceCommand { get; set; }
        public ICommand ServiceSelectedCommand { get; set; }
        public ICommand RemoveServiceCommand { get; set; }

        public ServicesPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            _messageDialogService = messageDialogService;

            AddServiceCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddServicePageModel>());
            ServiceSelectedCommand = new AsyncCommand<int>((id) => _navigationService.NavigateToAsync<ServicePageModel>(id));
            RemoveServiceCommand = new AsyncCommand<int>(RemoveServiceAction);
        }
        private async Task RemoveServiceAction(int id)
        {
            Response response = await _httpRequestService.SendDelete(new ServicePaths().GetFullPath(id.ToString()));

            switch (response.ResponseResult)
            {
                case ResponseResult.Successful:
                    await _messageDialogService.ShowMessageDialog("Pomyślnie usunięto usługę", MessageDialogType.Success);
                    break;

                case ResponseResult.BadRequest:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd podczas usuwania ułsugi");
                    break;
            }

            await Initialize();
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            Response<List<ServiceModel>> response = await _httpRequestService.SendGet<List<ServiceModel>>(new ServicePaths().GetFullPath(CRUDPaths.GetAllPath));

            switch (response.ResponseResult)
            {
                case ResponseResult.Successful:
                    Services = response.Content;
                    break;

                case ResponseResult.BadRequest:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania usługi");
                    break;
            }
            IsLoading = false;
        }
    }
}