using Acr.UserDialogs;
using NotatnikMechanika.Core.Interfaces;
using System.Threading.Tasks;

namespace NotatnikMechanika.Forms.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        /* public Task ShowMessageDialog(string message)
         {
             return UserDialogs.Instance.AlertAsync(message, "Notatnik Mechanika");
         }*/
        public Task ShowMessageDialog(string message, MessageDialogType type, string title = null)
        {
            throw new System.NotImplementedException();
        }
    }
}