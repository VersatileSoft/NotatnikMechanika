using System;

namespace MvvmPackage.Wpf.Pages
{
    public interface IMasterUserControl
    {
        event EventHandler<Type> MenuButtonClick;
    }
}
