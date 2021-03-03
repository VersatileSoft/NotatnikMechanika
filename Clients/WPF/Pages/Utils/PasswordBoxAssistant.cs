using System.Windows;
using System.Windows.Controls;

namespace NotatnikMechanika.WPF.Pages.Utils
{
    public static class PasswordBoxAssistant
    {
        private static bool _updating;

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password",
                typeof(string),
                typeof(PasswordBoxAssistant),
                new FrameworkPropertyMetadata(string.Empty, OnPasswordChanged));

        public static string GetPassword(DependencyObject d)
        {
            return (string)d.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject d, string value)
        {
            d.SetValue(PasswordProperty, value);
        }

        private static void OnPasswordChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var password = d as PasswordBox;
            if (password != null)
            {
                password.PasswordChanged -= PasswordChanged;
            }

            if (e.NewValue != null)
            {
                if (!_updating)
                {
                    password.Password = e.NewValue.ToString();
                }
            }
            else
            {
                password.Password = string.Empty;
            }
            password.PasswordChanged += PasswordChanged;
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var password = sender as PasswordBox;
            _updating = true;
            SetPassword(password, password.Password);
            _updating = false;
        }
    }
}
