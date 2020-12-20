using NotatnikMechanika.Core.Interfaces;
using System.Windows;

namespace NotatnikMechanika.WPF.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        public void ShowMessageDialog(string message, MessageDialogType type, string title = null)
        {
            if (Application.Current.MainWindow is MainWindow window)
            {
                window.Snackbar.IsActive = true;
                window.Snackbar.MessageQueue.Enqueue(message, "OK", () => window.Snackbar.IsActive = false);
            }
        }
    }
}