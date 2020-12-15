using Material.Blazor;
using NotatnikMechanika.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace NotatnikMechanika.Client.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        private readonly IMBToastService _toastService;

        public MessageDialogService(IMBToastService toastService)
        {
            _toastService = toastService;
        }

        public Task ShowMessageDialog(string message, MessageDialogType type, string title = null)
        {
            _toastService.ShowToast(type.ConvertTo<MBToastLevel>(), message, title);
            return Task.CompletedTask;
        }
    }
}
