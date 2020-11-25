using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMPackage.Core.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
    }
    public interface IAsyncCommand<in T> : ICommand
    {
        Task ExecuteAsync(T parameter);
    }

}