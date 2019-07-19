using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Customer;
using PropertyChanged;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CustomersViewModel : MvxViewModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }
        private readonly IHttpRequestService _httpRequestService;
        public CustomersViewModel(IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
        }

        public override async Task Initialize()
        {
            Response<List<CustomerModel>> response = await _httpRequestService.SendGet<List<CustomerModel>>(CustomerPaths.GetFullPath(CRUDPaths.GetAllPath), true);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Customers = response.Content;
            }
        }
    }
}
