using PropertyChanged;
using System;
using Xamarin.MVVMPackage;

namespace NotatnikMechanika.Core.PageModels.ContentViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ServiceViewModel : PageModelBase<int>
    {
        public ServiceViewModel()
        {
        }

        //public override void Prepare(int parameter)
        //{
        //    throw new NotImplementedException();
        //}
    }
}