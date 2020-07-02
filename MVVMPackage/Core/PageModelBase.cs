using System.Threading.Tasks;

namespace MvvmPackage.Core
{
    public class PageModelBase
    {
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

    public abstract class PageModelBase<TParameter> : PageModelBase
    {
        public TParameter Parameter { get; set; }
    }
}
