namespace NotatnikMechanika.WPF.Presenters
{
    //public class MultiRegionWpfPagePresenter : MvxWpfPagePresenter
    //{
    //    private readonly ContentControl _contentControl;
    //    private readonly Dispatcher _uiThreadDispatcher;

    //    public MultiRegionWpfPagePresenter(ContentControl contentControl, Dispatcher uiThreadDispatcher)
    //        : base(contentControl)
    //    {
    //        _contentControl = contentControl;
    //        _uiThreadDispatcher = uiThreadDispatcher;
    //    }

    //    //public override async Task<bool> Show(MvxPageModelRequest request)
    //    //{
    //    //    //var pageType = GetPageType(request);

    //    //    //if (pageType.HasRegionAttribute())
    //    //    //{
    //    //    //    var loader = Mvx.IoCProvider.Resolve<IMvxWpfPageLoader>();
    //    //    //    var page = loader.CreatePage(request);

    //    //    //    var region = pageType.GetRegionName();
    //    //    //    var containerPage = GetChild<Frame>(_contentControl, region);

    //    //    //    if (containerPage != null)
    //    //    //    {
    //    //    //        containerPage.Navigate(page);
    //    //    //        return true;
    //    //    //    }
    //    //    //}

    //    //    return await base.Show(request);
    //    //}

    //    public override Task<bool> Close(IMvxPageModel toClose)
    //    {
    //        if (toClose is AddServiceToOrderPageModel || toClose is AddCommodityToOrderPageModel)
    //        {
    //            System.Collections.Generic.IEnumerable<DialogHost> dialogHosts = DialogPresentationAction.FindVisualChildren<DialogHost>(_contentControl);

    //            if (!dialogHosts.Any())
    //            {
    //                throw new Exception("Can not find dialog host in current logical tree");
    //            }

    //            DialogHost dialogHost = dialogHosts.ElementAt(0);

    //            DialogHost.CloseDialogCommand.Execute(false, dialogHost);
    //        }

    //        return base.Close(toClose);
    //    }

    //    public override void RegisterAttributeTypes()
    //    {
    //        AttributeTypesToActionsDictionary.Add(typeof(MasterDetailPageAttribute), new MasterDetailPageAction(_contentControl, _uiThreadDispatcher));
    //        AttributeTypesToActionsDictionary.Add(typeof(DialogPresentationAttribute), new DialogPresentationAction(_contentControl, _uiThreadDispatcher));
    //        base.RegisterAttributeTypes();
    //    }

    //    //private static Type GetPageType(MvxPageModelRequest request)
    //    //{
    //    //    var pageFinder = Mvx.IoCProvider.Resolve<IMvxPagesContainer>();
    //    //    return pageFinder.GetPageType(request.PageModelType);
    //    //}
    //}
}