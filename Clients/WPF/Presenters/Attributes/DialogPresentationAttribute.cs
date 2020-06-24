namespace NotatnikMechanika.WPF.Presenters.Attributes
{
    //public class DialogPresentationAttribute : MvxBasePresentationAttribute
    //{
    //}

    //public class DialogPresentationAction : MvxPresentationAttributeAction
    //{
    //    public DialogPresentationAction(ContentControl contentControl, Dispatcher uiThreadDispatcher)
    //    {
    //        ShowAction = (type, attribute, request) =>
    //        {
    //            DialogPresentationAttribute dialogPresentationAttribute = (DialogPresentationAttribute)attribute;

    //            IMvxWpfPageLoader loader = Mvx.IoCProvider.Resolve<IMvxWpfPageLoader>();
    //            FrameworkElement page = loader.CreatePage(request);

    //            IEnumerable<DialogHost> dialogHosts = FindVisualChildren<DialogHost>(contentControl);

    //            if (!dialogHosts.Any())
    //            {
    //                throw new Exception("Can not find dialog host in current logical tree");
    //            }

    //            DialogHost dialogHost = dialogHosts.ElementAt(0);

    //            uiThreadDispatcher.Invoke(() =>
    //            {
    //                dialogHost.ShowDialog(page);
    //            });
    //            return Task.FromResult(true);
    //        };
    //        CloseAction = (a, b) =>
    //        {
    //            return Task.FromResult(true);
    //        };
    //    }

    //    public static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent)
    //    where T : DependencyObject
    //    {
    //        int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
    //        for (int i = 0; i < childrenCount; i++)
    //        {
    //            DependencyObject child = VisualTreeHelper.GetChild(parent, i);

    //            T childType = child as T;
    //            if (childType != null)
    //            {
    //                yield return (T)child;
    //            }

    //            foreach (T other in FindVisualChildren<T>(child))
    //            {
    //                yield return other;
    //            }
    //        }
    //    }
    //}
}