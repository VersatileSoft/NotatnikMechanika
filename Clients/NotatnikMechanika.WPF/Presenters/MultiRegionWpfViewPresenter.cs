using MaterialDesignThemes.Wpf;
using MvvmCross.Platforms.Wpf.Presenters;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.PageModels.AddingViewModels;
using NotatnikMechanika.WPF.Presenters.Attributes;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NotatnikMechanika.WPF.Presenters
{
    public class MultiRegionWpfViewPresenter : MvxWpfViewPresenter
    {
        private readonly ContentControl _contentControl;
        private readonly Dispatcher _uiThreadDispatcher;

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

        public override Task<bool> Close(IMvxViewModel toClose)
        {
            if (toClose is AddServiceToOrderViewModel || toClose is AddCommodityToOrderViewModel)
            {
                System.Collections.Generic.IEnumerable<DialogHost> dialogHosts = DialogPresentationAction.FindVisualChildren<DialogHost>(_contentControl);

                if (!dialogHosts.Any())
                {
                    throw new Exception("Can not find dialog host in current logical tree");
                }

                DialogHost dialogHost = dialogHosts.ElementAt(0);

                DialogHost.CloseDialogCommand.Execute(false, dialogHost);
            }

            return base.Close(toClose);
        }

        public override void RegisterAttributeTypes()
        {
            AttributeTypesToActionsDictionary.Add(typeof(MasterDetailPageAttribute), new MasterDetailPageAction(_contentControl, _uiThreadDispatcher));
            AttributeTypesToActionsDictionary.Add(typeof(DialogPresentationAttribute), new DialogPresentationAction(_contentControl, _uiThreadDispatcher));
            base.RegisterAttributeTypes();
        }

        //private static Type GetViewType(MvxViewModelRequest request)
        //{
        //    var viewFinder = Mvx.IoCProvider.Resolve<IMvxViewsContainer>();
        //    return viewFinder.GetViewType(request.ViewModelType);
        //}
    }
}