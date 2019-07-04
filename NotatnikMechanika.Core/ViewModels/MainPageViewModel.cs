using MvvmCross.Commands;
using MvvmCross.ViewModels;
using PropertyChanged;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel : MvxViewModel
    {
        public string Text { get; set; } = "elo";

        public ICommand Click { get; set; }

        public MainPageViewModel()
        {
            Click = new MvxCommand(ClickEvent);
        }

        public void ClickEvent()
        {
            Text = "Dupa";
        }
    }
}