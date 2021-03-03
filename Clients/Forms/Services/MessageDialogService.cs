using Acr.UserDialogs;
using NotatnikMechanika.Core.Interfaces;

namespace NotatnikMechanika.Forms.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        /* public Task ShowMessageDialog(string message)
         {
             
         }*/

        public void ShowMessageDialog(string message, MessageDialogType type, string title = null)
        {
            UserDialogs.Instance.AlertAsync(message, "Notatnik Mechanika");
        }
    }
}