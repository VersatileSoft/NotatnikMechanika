using MvvmCross.Navigation;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Commodity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Core.ViewModels
{
    class AddCommodityViewModel : AddingViewModelBase<CommodityModel>
    {
        public override string ErrorMessage { get; set; } = "Błąd podczas dodawania towaru.";
        public override string SuccesMessage { get; set; } = "Towar został dodany pomyślnie.";

        public AddCommodityViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
            : base(httpRequestService, navigationService, messageDialogService)
        {

        }
    }
}
