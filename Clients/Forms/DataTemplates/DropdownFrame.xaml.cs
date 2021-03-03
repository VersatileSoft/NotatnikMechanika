using System;

using Xamarin.Forms;

namespace NotatnikMechanika.Forms.DataTemplates
{
    public partial class DropdownFrame : ContentView
    {

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            "Title",
            typeof(string),
            typeof(DropdownFrame),
            string.Empty,
            propertyChanged: TitlePropertyChanged);

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public bool ShowProgress { get; set; }

        public View FrameBody
        {
            get => Details.Content;
            set => Details.Content = value;
        }

        private double _detailsHeight;
        private bool _isOpen = true;

        public DropdownFrame()
        {
            InitializeComponent();
        }

        private static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (DropdownFrame)bindable;
            control.TitleLabel.Text = newValue.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (_detailsHeight == 0)
            {
                _detailsHeight = Details.Height;
            }

            void Callback(double input)
            {
                Details.HeightRequest = input;
                Details.Opacity = input / _detailsHeight;
                ProgressBar.Opacity = ShowProgress ? 1 - (input / _detailsHeight) : 0;
            }

            Details.Animate("invis", Callback, Details.Height, _isOpen ? 0 : _detailsHeight, 16, 500, Easing.CubicInOut);
            _isOpen = !_isOpen;
        }
    }
}