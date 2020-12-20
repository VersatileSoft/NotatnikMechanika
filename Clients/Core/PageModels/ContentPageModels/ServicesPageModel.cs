using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Service;
using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

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
            if(await _httpRequestService.Delete<ServiceModel>(id, "Błąd podczas usuwania ułsugi"))
            {
                Services.Remove(Services.Single(s => s.Id == id));
                _messageDialogService.ShowMessageDialog("Pomyślnie usunięto usługę", MessageDialogType.Success);
            }
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            var services = await _httpRequestService.All<ServiceModel>("Błąd ładowania usług");
            if (services != null)
            {
                Services.Clear();
                services.ForEach(s => Services.Add(s));
            }
            IsLoading = false;
        }
    }
}