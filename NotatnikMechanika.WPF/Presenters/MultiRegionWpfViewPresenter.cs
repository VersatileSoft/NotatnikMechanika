using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using MvvmCross;
using MvvmCross.Platforms.Wpf.Presenters;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.Presenters;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using NotatnikMechanika.WPF.Presenters.Attributes;
using NotatnikMechanika.WPF.Views;

namespace NotatnikMechanika.WPF.Presenters
{
    public class MultiRegionWpfViewPresenter : MvxWpfViewPresenter
    {
        private readonly ContentControl _contentControl;
        private Dispatcher _uiThreadDispatcher;

        public MultiRegionWpfViewPresenter(ContentControl contentControl, Dispatcher uiThreadDispatcher)
            : base(contentControl)
        {
            _contentControl = contentControl;
            _uiThreadDispatcher = uiThreadDispatcher;
        }

        //public override async Task<bool> Show(MvxViewModelRequest request)
        //{
        //    //var viewType = GetViewType(request);

        //    //if (viewType.HasRegionAttribute())
        //    //{
        //    //    var loader = Mvx.IoCProvider.Resolve<IMvxWpfViewLoader>();
        //    //    var view = loader.CreateView(request);

        //    //    var region = viewType.GetRegionName();
        //    //    var containerView = GetChild<Frame>(_contentControl, region);

        //    //    if (containerView != null)
        //    //    {
        //    //        containerView.Navigate(view);
        //    //        return true;
        //    //    }
        //    //}

        //    return await base.Show(request);
        //}

        public override void RegisterAttributeTypes()
        {
            AttributeTypesToActionsDictionary.Add(
                typeof(MasterDetailPageAttribute), new MvxPresentationAttributeAction
                {
                    //Type, IMvxPresentationAttribute, MvxViewModelRequest, Task<bool>
                    ShowAction = (type, attribute, request) =>
                    {
                        MasterDetailPageAttribute masterDetailPageAttribute = (MasterDetailPageAttribute)attribute;

                        var loader = Mvx.IoCProvider.Resolve<IMvxWpfViewLoader>();
                        var view = loader.CreateView(request);
                        ContentControl containerView = null;
                        if (masterDetailPageAttribute.Position == MasterDetailPageAttribute.MasterDetailPosition.Master)
                            containerView = GetChild<ContentControl>(_contentControl, "Master");
                        else
                            containerView = GetChild<ContentControl>(_contentControl, "Detail");

                        if (containerView != null)
                        {
                            _uiThreadDispatcher.Invoke(() =>
                            {
                               containerView.Content = view;
                            });
                            return Task.FromResult(true);
                        }
                        return Task.FromResult(false);
                    },

                    CloseAction = (a, b) => { return Task.Run(() => true); }


                });
            base.RegisterAttributeTypes();
        }

        //private static Type GetViewType(MvxViewModelRequest request)
        //{
        //    var viewFinder = Mvx.IoCProvider.Resolve<IMvxViewsContainer>();
        //    return viewFinder.GetViewType(request.ViewModelType);
        //}

        private static T GetChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            return LogicalTreeHelper.FindLogicalNode(parent, childName) as T;
        }
    }
}
