using MvvmCross.Forms.Presenters;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Forms
{
    public class CustomPresenter : MvxFormsPagePresenter
    {
        private IMvxFormsViewPresenter _platformPresenter;
        public CustomPresenter(IMvxFormsViewPresenter platformPresenter) : base(platformPresenter)
        {
            _platformPresenter = platformPresenter;
        }

        public override void RegisterAttributeTypes()
        {
            AttributeTypesToActionsDictionary.Add(typeof(ShellContentPageAttribute), new ShellContentPageAttributeAction(_platformPresenter));
            base.RegisterAttributeTypes();
        }
    }
}
