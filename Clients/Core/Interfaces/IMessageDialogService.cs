using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Interfaces
{
    public interface IMessageDialogService
    {
        Task ShowMessageDialog(string message);
    }
}