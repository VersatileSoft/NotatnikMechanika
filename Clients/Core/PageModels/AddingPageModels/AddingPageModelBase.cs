using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;

// ReSharper disable once CheckNamespace
namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class AddingPageModelBase<TModel> : PageModelBase where TModel : ValidateModelBase, new()
    {
        public virtual TModel Model { get; protected set; }
        public ICommand AddCommand { get; }
        public ICommand GoBackCommand { get; }

        protected readonly IHttpRequestService HttpRequestService;
        protected readonly IMvNavigationService NavigationService;
        protected readonly IMessageDialogService MessageDialogService;

        public virtual string ErrorMessage { get; set; }
        public virtual string SuccesMessage { get; set; }

        protected AddingPageModelBase(IMvNavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService)
        {
            HttpRequestService = httpRequestService;
            NavigationService = navigationService;
            MessageDialogService = messageDialogService;
            Model = new TModel();
            AddCommand = new AsyncCommand(AddAction);
            GoBackCommand = new AsyncCommand(NavigationService.PopAsync);
        }

        protected virtual async Task AddAction()
        {
            IsLoading = true;

            if (await HttpRequestService.Create(Model, ErrorMessage))
            {
                MessageDialogService.ShowMessageDialog(SuccesMessage, MessageDialogType.Success, "Operacja powiodła się");
                await NavigationService.NavigateToAsync<MainPageModel>();
            }

            IsLoading = false;
        }
    }
}