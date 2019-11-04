using MvvmCross.ViewModels;
using PropertyChanged;
using System;

namespace NotatnikMechanika.Core.ViewModels.ContentViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ServiceViewModel : MvxViewModel<int>
    {
        public ServiceViewModel()
        {
        }

        public override void Prepare(int parameter)
        {
            throw new NotImplementedException();
        }
    }
}