using MvvmCross;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.Presenters;
using MvvmCross.Presenters.Attributes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NotatnikMechanika.WPF.Presenters.Attributes
{
    public class MasterDetailPageAttribute : MvxBasePresentationAttribute
    {
        public enum MasterDetailPosition
        {
            Master,
            Detail
        }
        public MasterDetailPosition Position { get; set; }
    }

    public class MasterDetailPageAction : MvxPresentationAttributeAction
    {

        public MasterDetailPageAction(ContentControl contentControl, Dispatcher uiThreadDispatcher)
        {
            ShowAction = (type, attribute, request) =>
            {
                MasterDetailPageAttribute masterDetailPageAttribute = (MasterDetailPageAttribute)attribute;

                IMvxWpfViewLoader loader = Mvx.IoCProvider.Resolve<IMvxWpfViewLoader>();
                FrameworkElement view = loader.CreateView(request);
                ContentControl containerView = null;
                if (masterDetailPageAttribute.Position == MasterDetailPageAttribute.MasterDetailPosition.Master)
                {
                    containerView = GetChild<ContentControl>(contentControl, "Master");
                }
                else
                {
                    containerView = GetChild<ContentControl>(contentControl, "Detail");
                }

                if (containerView != null)
                {
                    uiThreadDispatcher.Invoke(() =>
                    {
                        containerView.Content = view;
                    });
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            };

            CloseAction = (a, b) => { return Task.Run(() => true); };
        }

        private static T GetChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            return LogicalTreeHelper.FindLogicalNode(parent, childName) as T;
        }
    }
}
