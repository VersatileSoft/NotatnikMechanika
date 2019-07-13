using MvvmCross;
using MvvmCross.Exceptions;
using MvvmCross.Forms.Presenters;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvvmCross.Presenters;
using MvvmCross.Presenters.Attributes;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotatnikMechanika.Forms
{
    public class ShellContentPageAttribute : MvxPagePresentationAttribute
    {
    }

    public class ShellContentPageAttributeAction : MvxPresentationAttributeAction
    {

        public ShellContentPageAttributeAction(IMvxFormsViewPresenter platformPresenter)
        {

            PlatformPresenter = platformPresenter;

            ShowAction = Show;

            //TODO implement close action
            CloseAction = (a, b) => { return Task.FromResult(true); };
        }

        protected IMvxFormsViewPresenter PlatformPresenter { get; }

        private Application _formsApplication;
        public Application FormsApplication
        {
            get
            {
                if (_formsApplication == null)
                    _formsApplication = PlatformPresenter.FormsApplication;
                return _formsApplication;
            }
            set { _formsApplication = value; }
        }

        public Task<bool> Show(Type type, IMvxPresentationAttribute attribute, MvxViewModelRequest request)
        {
            if(FormsApplication.MainPage is Shell shellPage)
            {
                ShellContentPageAttribute shellContentPageAttribute = (ShellContentPageAttribute)attribute;

                IMvxPage contentPage = CreateView(request);

                FlyoutItem flyoutItem = new FlyoutItem();
                
                ShellContent shellContent = new ShellContent
                {
                    Content = contentPage
                };
                Tab tab = new Tab();
                tab.Items.Add(shellContent);
                flyoutItem.Title = shellContentPageAttribute.Title;
                flyoutItem.Icon = shellContentPageAttribute.Icon;
                flyoutItem.Items.Add(tab);
                shellPage.Items.Add(flyoutItem);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        private IMvxPage CreateView(MvxViewModelRequest request)
        {

            IMvxViewsContainer container = Mvx.IoCProvider.Resolve<IMvxViewsContainer>();
            var viewType = container.GetViewType(request.ViewModelType);
            if (viewType == null)
                throw new MvxException("View Type not found for " + request.ViewModelType);

            var view = CreateView(viewType) as IMvxPage;

            if (request is MvxViewModelInstanceRequest instanceRequest)
            {
                view.ViewModel = instanceRequest.ViewModelInstance;
            }
            else
            {
                var viewModelLoader = Mvx.IoCProvider.Resolve<IMvxViewModelLoader>();
                view.ViewModel = viewModelLoader.LoadViewModel(request, null);
            }

            return view;
        }

        public IMvxPage CreateView(Type viewType)
        {
            var viewObject = Activator.CreateInstance(viewType);
            if (viewObject == null)
                throw new MvxException("View not loaded for " + viewType);

            if (!(viewObject is IMvxPage view))
                throw new MvxException("Loaded View does not have IMvxWpfView interface " + viewType);

            return view;
        }
    }
}
