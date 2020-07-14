using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Interfaces
{
    public interface IMessageDialogService
    {
        Task ShowMessageDialog(string message, MessageDialogType type, string title = null);
    }

    public enum MessageDialogType
    {
        Success,
        Error
    }
}