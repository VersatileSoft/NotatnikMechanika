using Autofac;
using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Core.PageModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NotatnikMechanika.WPF.Pages.Utils
{
    /// <summary>
    /// Interaction logic for TopBar.xaml
    /// </summary>
    public partial class TopBar : UserControl
    {
        private bool _restoreForDragMove;
        private readonly Window _mainWindow = Application.Current.MainWindow;

        public TopBar()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            _mainWindow.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            _mainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            if (e.ClickCount == 2)
            {
                if (_mainWindow.ResizeMode != ResizeMode.CanResize &&
                    _mainWindow.ResizeMode != ResizeMode.CanResizeWithGrip)
                {
                    return;
                }

                _mainWindow.WindowState = _mainWindow.WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized;
            }
            else
            {
                _restoreForDragMove = _mainWindow.WindowState == WindowState.Maximized;
                _mainWindow.DragMove();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_restoreForDragMove)
            {
                _restoreForDragMove = false;

                var point = PointToScreen(e.MouseDevice.GetPosition(this));

                _mainWindow.Left = point.X - (_mainWindow.RestoreBounds.Width * 0.5);
                _mainWindow.Top = point.Y;

                _mainWindow.WindowState = WindowState.Normal;

                _mainWindow.DragMove();
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            _restoreForDragMove = false;
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState == WindowState.Normal
                ? WindowState.Maximized : WindowState.Normal;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            IoC.Container.Resolve<IMvNavigationService>().NavigateToAsync<MainPageModel>();
        }
    }
}