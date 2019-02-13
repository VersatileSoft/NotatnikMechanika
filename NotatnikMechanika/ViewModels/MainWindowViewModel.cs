using NotatnikMechanika.Views;
using Prism.Mvvm;
using Prism.Regions;
using PropertyChanged;

namespace NotatnikMechanika.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(MainAppView));
        }
    }
}