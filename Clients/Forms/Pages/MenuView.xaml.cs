using MvvmPackage.Xamarin.Pages;
using NotatnikMechanika.Core.PageModels;

namespace NotatnikMechanika.Forms.Pages
{
    public partial class MenuView : MvContentPage<MenuPageModel>
    {
        public MenuView()
        {
            InitializeComponent();
        }

        //protected override void OnViewModelSet()
        //{
        //    ViewModel.NavigateCommand = new MvxAsyncCommand<string>(NavigateTo);
        //}

        //private async Task NavigateTo(string param)
        //{
        //    //Nothing bad in this code, the fastest way ;P

        //    if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
        //    {
        //        masterDetailPage.IsPresented = false;
        //    }
        //    else if (Application.Current.MainPage is NavigationPage navigationPage && navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail)
        //    {
        //        nestedMasterDetail.IsPresented = false;
        //    }

        //    await ViewModel.NavigateTo(param);
        //}
    }
}