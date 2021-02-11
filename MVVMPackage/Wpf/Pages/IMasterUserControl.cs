using System;

namespace MvvmPackage.Wpf.Pages
{
    public interface IMasterUserControl
    {
        event EventHandler<MenuButtonClickArgs> MenuButtonClick;
    }

    public class MenuButtonClickArgs
    {
        public Type PageModelType { get; set; }
        public int? Parameter { get; set; }
    }
}
