using Autofac;
using MvvmPackage.Core;
using MvvmPackage.Wpf.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MvvmPackage.Wpf.Pages
{
    public abstract class MvWpfMasterDetailPage<TPageModel, TMasterPageModel, TDetailPageModel> : MvWpfPage<TPageModel>
        where TPageModel : PageModelBase
        where TMasterPageModel : PageModelBase
        where TDetailPageModel : PageModelBase
    {
        protected IWpfPageActivatorService wpfPageActivatorService;

        protected abstract ContentControl MasterContent { set; }
        protected abstract ContentControl DetailContent { set; }

        protected void Init()
        {
            wpfPageActivatorService = IoC.Container.Resolve<IWpfPageActivatorService>();
            IMasterUserControl menuPage = (IMasterUserControl)wpfPageActivatorService.CreatePageFromPageModel<TMasterPageModel>();
            menuPage.MenuButtonClick += MainPage_MenuButtonClick;
            MasterContent = (ContentControl)menuPage;
            DetailContent = wpfPageActivatorService.CreatePageFromPageModel<TDetailPageModel>();
        }

        private void MainPage_MenuButtonClick(object sender, Type e)
        {
            DetailContent = wpfPageActivatorService.CreatePageFromPageModel(e);
        }
    }
}
