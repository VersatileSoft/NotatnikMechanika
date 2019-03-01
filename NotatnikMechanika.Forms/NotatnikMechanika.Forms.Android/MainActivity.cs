using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using NotatnikMechanika.Core;

namespace NotatnikMechanika.Forms.Droid
{
    [Activity(Label = "NotatnikMechanika", Icon = "@mipmap/icon", MainLauncher = true, Theme = "@style/MainTheme", NoHistory = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : MvxFormsAppCompatActivity<Setup, CoreApp, App>
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
        }
    }
}