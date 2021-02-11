using MaterialDesignThemes.Wpf;
using System.Windows.Controls;

namespace NotatnikMechanika.WPF.Pages.Utils
{
    /// <summary>
    /// Interaction logic for GroupBoxHeaderTemplate.xaml
    /// </summary>
    public partial class GroupBoxHeaderTemplate : UserControl
    {

        public PackIconKind IconKind
        {
            set
            {
                Icon.Kind = value;
            }
        }

        public GroupBoxHeaderTemplate()
        {
            InitializeComponent();
        }
    }
}
