using MaterialDesignThemes.Wpf;
using MvvmCross;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.Presenters;
using MvvmCross.Presenters.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace NotatnikMechanika.WPF.Presenters.Attributes
{
    public class DialogPresentationAttribute : MvxBasePresentationAttribute
    {
    }

    public class DialogPresentationAction : MvxPresentationAttributeAction
    {

        public DialogPresentationAction(ContentControl contentControl, Dispatcher uiThreadDispatcher)
        {
            ShowAction = (type, attribute, request) =>
            {
                DialogPresentationAttribute dialogPresentationAttribute = (DialogPresentationAttribute)attribute;

                IMvxWpfViewLoader loader = Mvx.IoCProvider.Resolve<IMvxWpfViewLoader>();
                FrameworkElement view = loader.CreateView(request);

                var dialogHosts = FindVisualChildren<DialogHost>(contentControl);

                if (!dialogHosts.Any())
                {
                    throw new Exception("Can not find dialog host in current logical tree");
                }

                DialogHost dialogHost = dialogHosts.ElementAt(0);


                uiThreadDispatcher.Invoke(() =>
                {
                    dialogHost.ShowDialog(view);
                });
                return Task.FromResult(true);
            };
            CloseAction = (a, b) =>
            {
                return Task.FromResult(true);
            };
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent)
        where T : DependencyObject
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                var childType = child as T;
                if (childType != null)
                {
                    yield return (T)child;
                }

                foreach (var other in FindVisualChildren<T>(child))
                {
                    yield return other;
                }
            }
        }
    }
}
