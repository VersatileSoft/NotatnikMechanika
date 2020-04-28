using MvvmPackage.Xamarin.Pages;
using NotatnikMechanika.Core.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotatnikMechanika.Forms.Pages.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAccountPage : MvContentPage<MyAccountPageModel>
    {
        public MyAccountPage()
        {
            InitializeComponent();
        }
    }
}