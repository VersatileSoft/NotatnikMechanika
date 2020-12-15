using PropertyChanged;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MvvmPackage.Core
{
    [AddINotifyPropertyChangedInterface]
    public class PageModelBase : INotifyPropertyChanged
    {
        public bool IsLoading { get; protected set; } 
        public int? Parameter { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when page is disappearing
        /// </summary>
        public virtual void OnDisappearing()
        {

        }

        /// <summary>
        /// Called when page is appearing
        /// </summary>
        public virtual void OnAppearing()
        {

        }
        /// <summary>
        /// Override to initialize page model,
        /// called after OnAppearing
        /// </summary>
        public virtual Task Initialize()
        {
            return Task.CompletedTask;
        }
    }
}
