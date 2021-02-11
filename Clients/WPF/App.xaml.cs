using Autofac;
using MvvmPackage.Wpf;
using NotatnikMechanika.Core;
using System;
using System.Net.Http;

namespace NotatnikMechanika.WPF
{
    public partial class App : MvWpfApplication<MainPageService>
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterInstance(new HttpClient
            {
                BaseAddress = new Uri("https://www.mechanicstoolkit.tk/")
               // BaseAddress = new Uri("https://localhost:44357/")
            });
        }
    }
}