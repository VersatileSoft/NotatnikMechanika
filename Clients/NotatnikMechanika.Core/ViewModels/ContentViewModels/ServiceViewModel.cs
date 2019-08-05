using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using PropertyChanged;

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
