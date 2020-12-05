using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using PropertyChanged;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

// ReSharper disable once CheckNamespace
namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class AddingPageModelBase<TModel> : PageModelBase where TModel : ValidateModelBase, new()
    {
        public TModel Model { get; }
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

        private async Task AddAction()
        {
            IsLoading = true;
            Response response = await HttpRequestService.Create(Model);

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    await MessageDialogService.ShowMessageDialog(SuccesMessage, MessageDialogType.Success, "Operacja powiodła się");
                    await NavigationService.NavigateToAsync<MainPageModel>();
                    break;

                case ResponseType.Failure:
                    ErrorMessage = response.ErrorMessages?.FirstOrDefault();
                    await MessageDialogService.ShowMessageDialog(ErrorMessage, MessageDialogType.Error, "Wystąpił błąd");
                    break;

                case ResponseType.BadModelState:
                    await MessageDialogService.ShowMessageDialog("Wypełnij formularz poprawnie", MessageDialogType.Error);
                    break;
                case ResponseType.Unauthorized:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            IsLoading = false;
        }
    }
}