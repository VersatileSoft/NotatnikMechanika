using System.Threading.Tasks;
using System.Windows.Input;

namespace Xamarin.MVVMPackage.Commands
{
	public interface IAsyncCommand : ICommand
	{
		Task ExecuteAsync();
	}
	public interface IAsyncCommand<T> : ICommand
	{
		Task ExecuteAsync(T parameter);
	}

}