using MvvmPackage.Core;
using PropertyChanged;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class ServicePageModel : PageModelBase<int>
    {
        public ServicePageModel()
        {
        }

        //public override void Prepare(int parameter)
        //{
        //    throw new NotImplementedException();
        //}
    }
}