using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmPackage.Wpf.Pages
{
    public interface IMasterUserControl
    {
        event EventHandler<Type> MenuButtonClick;
    }
}
