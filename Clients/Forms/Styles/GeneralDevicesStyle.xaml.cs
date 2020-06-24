using Xamarin.Forms;

namespace NotatnikMechanika.Forms.Styles
{
    public partial class GeneralDevicesStyle : ResourceDictionary
    {
        public static GeneralDevicesStyle SharedInstance { get; } = new GeneralDevicesStyle();
        public GeneralDevicesStyle()
        {
            InitializeComponent();
        }
    }
}