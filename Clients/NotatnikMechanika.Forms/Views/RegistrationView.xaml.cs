using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using NotatnikMechanika.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotatnikMechanika.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(NoHistory = false, WrapInNavigationPage = true)]
    public partial class RegistrationView : MvxContentPage<RegistrationViewModel>
    {
        public RegistrationView()
        {
            InitializeComponent();
        }
    }
}