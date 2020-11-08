using Acr.UserDialogs;
using NotatnikMechanika.Core.Interfaces;
using System.Threading.Tasks;

namespace NotatnikMechanika.Forms.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        /* public Task ShowMessageDialog(string message)
         {
             
         }*/
        public Task ShowMessageDialog(string message, MessageDialogType type, string title = null)
        {
            // throw new System.NotImplementedException();
            return UserDialogs.Instance.AlertAsync(message, "Notatnik Mechanika");
        }
    }
}