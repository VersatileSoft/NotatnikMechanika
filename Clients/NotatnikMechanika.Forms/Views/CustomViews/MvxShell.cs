using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Views;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NotatnikMechanika.Forms.Views.CustomViews
{
    public class MvxShell : Shell, IMvxPage
    {
        public object DataContext
        {
            get
            {
                return BindingContext.DataContext;
            }
            set
            {
                if (value != null && !(_bindingContext != null && ReferenceEquals(DataContext, value)))
                    BindingContext = new MvxBindingContext(value);
            }
        }

        private IMvxBindingContext _bindingContext;
        public new IMvxBindingContext BindingContext
        {
            get
            {
                if (_bindingContext == null)
                    BindingContext = new MvxBindingContext(base.BindingContext);
                return _bindingContext;
            }
            set
            {
                _bindingContext = value;
                base.BindingContext = _bindingContext.DataContext;
            }
        }

        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(IMvxViewModel), typeof(IMvxElement), default(MvxViewModel), BindingMode.Default, null, ViewModelChanged, null, null);

        internal static void ViewModelChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != null)
            {
                if (bindable is IMvxElement element)
                    element.DataContext = newvalue;
                else
                    bindable.BindingContext = newvalue;
            }
        }

        public IMvxViewModel ViewModel
        {
            get
            {
                return DataContext as IMvxViewModel;
            }
            set
            {
                DataContext = value;
                SetValue(ViewModelProperty, value);
                OnViewModelSet();
            }
        }

        protected virtual void OnViewModelSet()
        {
            ViewModel?.ViewCreated();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.ViewAppearing();
            ViewModel?.ViewAppeared();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel?.ViewDisappearing();
            ViewModel?.ViewDisappeared();
            ViewModel?.ViewDestroy();
        }
    }

    public class MvxShell<TViewModel>
        : MvxShell
    , IMvxPage<TViewModel> where TViewModel : class, IMvxViewModel
    {
        public new static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(TViewModel), typeof(IMvxElement<TViewModel>), default(TViewModel), BindingMode.Default, null, ViewModelChanged, null, null);

        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}
