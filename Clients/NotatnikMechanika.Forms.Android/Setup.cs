using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Presenters;
using MvvmCross.Views;
using NotatnikMechanika.Core;
using NotatnikMechanika.Core.ViewModels;
using NotatnikMechanika.Forms.Views;

namespace NotatnikMechanika.Forms.Android
{
    public sealed class Setup : MvxFormsAndroidSetup<CoreApp, App>
    {

    }
}