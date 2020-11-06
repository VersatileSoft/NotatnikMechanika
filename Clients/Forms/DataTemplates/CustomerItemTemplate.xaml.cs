using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotatnikMechanika.Forms.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerItemTemplate : ContentView
    {
        private double detailsHeight;
        private bool isOpen = true;

        public CustomerItemTemplate()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(detailsHeight == 0) detailsHeight = Details.Height;

            void callback(double input)
            {
                Details.HeightRequest = input;
                Details.Opacity = input / detailsHeight;
            }

            Details.Animate("invis", callback, Details.Height, isOpen ? 0 : detailsHeight, 16, 500, Easing.CubicInOut);
            isOpen = !isOpen;
        }
    }
}