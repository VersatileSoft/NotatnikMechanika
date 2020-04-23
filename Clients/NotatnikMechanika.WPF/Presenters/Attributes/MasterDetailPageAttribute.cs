namespace NotatnikMechanika.WPF.Presenters.Attributes
{
    //public class MasterDetailPageAttribute : MvxBasePresentationAttribute
    //{
    //    public enum MasterDetailPosition
    //    {
    //        Master,
    //        Detail
    //    }
    //    public MasterDetailPosition Position { get; set; }
    //}

    //public class MasterDetailPageAction : MvxPresentationAttributeAction
    //{
    //    public MasterDetailPageAction(ContentControl contentControl, Dispatcher uiThreadDispatcher)
    //    {
    //        ShowAction = (type, attribute, request) =>
    //        {
    //            MasterDetailPageAttribute masterDetailPageAttribute = (MasterDetailPageAttribute)attribute;

    //            IMvxWpfPageLoader loader = Mvx.IoCProvider.Resolve<IMvxWpfPageLoader>();
    //            FrameworkElement page = loader.CreatePage(request);
    //            ContentControl containerPage = null;
    //            if (masterDetailPageAttribute.Position == MasterDetailPageAttribute.MasterDetailPosition.Master)
    //            {
    //                containerPage = GetChild<ContentControl>(contentControl, "Master");
    //            }
    //            else
    //            {
    //                containerPage = GetChild<ContentControl>(contentControl, "Detail");
    //            }

    //            if (containerPage != null)
    //            {
    //                uiThreadDispatcher.Invoke(() =>
    //                {
    //                    containerPage.Content = page;
    //                });
    //                return Task.FromResult(true);
    //            }
    //            return Task.FromResult(false);
    //        };

    //        CloseAction = (a, b) => { return Task.Run(() => true); };
    //    }

    //    private static T GetChild<T>(DependencyObject parent, string childName) where T : DependencyObject
    //    {
    //        return LogicalTreeHelper.FindLogicalNode(parent, childName) as T;
    //    }
    //}
}