using MvvmCross.Forms.Presenters;
using MvvmCross.Presenters.Attributes;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotatnikMechanika.Forms
{
    public class CustomPresenter : MvxFormsPagePresenter
    {
        private IMvxFormsViewPresenter _platformPresenter;
        public CustomPresenter(IMvxFormsViewPresenter platformPresenter) : base(platformPresenter)
        {
            _platformPresenter = platformPresenter;
        }

        public override Task<bool> Show(MvxViewModelRequest request)
        {
            return base.Show(request);
        }

        public override Page CreatePage(Type viewType, MvxViewModelRequest request, MvxBasePresentationAttribute attribute)
        {
            var i = base.CreatePage(viewType, request, attribute);
            return i;
        }

        public override void RegisterAttributeTypes()
        {
            AttributeTypesToActionsDictionary.Add(typeof(ShellContentPageAttribute), new ShellContentPageAttributeAction(_platformPresenter));
            base.RegisterAttributeTypes();
        }
    }
}
