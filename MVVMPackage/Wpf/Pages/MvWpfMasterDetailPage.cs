using Autofac;
using MvvmPackage.Core;
using MvvmPackage.Wpf.Services;
using System;
using System.Windows.Controls;

namespace MvvmPackage.Wpf.Pages
{
    public abstract class MvWpfMasterDetailPage<TPageModel, TMasterPageModel, TDetailPageModel> : MvWpfPage<TPageModel>
        where TPageModel : PageModelBase
        where TMasterPageModel : PageModelBase
        where TDetailPageModel : PageModelBase
    {
        private IWpfPageActivatorService _wpfPageActivatorService;

        protected abstract ContentControl MasterContent { set; }
        protected abstract ContentControl DetailContent { set; }

        protected void Init()
        {
            _wpfPageActivatorService = IoC.Container.Resolve<IWpfPageActivatorService>();
            var menuPage = (IMasterUserControl)_wpfPageActivatorService.CreatePageFromPageModel<TMasterPageModel>();
            menuPage.MenuButtonClick += MainPage_MenuButtonClick;
            MasterContent = (ContentControl)menuPage;
            DetailContent = _wpfPageActivatorService.CreatePageFromPageModel<TDetailPageModel>();
        }

        private void MainPage_MenuButtonClick(object sender, MenuButtonClickArgs e)
        {
            DetailContent = _wpfPageActivatorService.CreatePageFromPageModel(e.PageModelType, e.Parameter);
        }
    }
}
