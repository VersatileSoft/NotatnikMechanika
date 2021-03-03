using Material.Blazor;
using NotatnikMechanika.Core.Interfaces;

namespace NotatnikMechanika.Client.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        private readonly IMBToastService _toastService;

        public MessageDialogService(IMBToastService toastService)
        {
            _toastService = toastService;
        }

        public void ShowMessageDialog(string message, MessageDialogType type, string title = null)
        {
            _toastService.ShowToast(type.ConvertTo<MBToastLevel>(), message, title);
        }
    }
}
