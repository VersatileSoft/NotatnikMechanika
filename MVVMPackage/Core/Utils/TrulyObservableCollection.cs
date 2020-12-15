using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace MvvmPackage.Core.Utils
{
    public sealed class TrulyObservableCollection<T> : ObservableCollection<T>
    {

        public event PropertyChangedEventHandler ItemChanged;

        public TrulyObservableCollection()
        {
            CollectionChanged += FullObservableCollectionCollectionChanged;
        }

        public TrulyObservableCollection(IEnumerable<T> pItems) : this()
        {
            foreach (var item in pItems)
            {
                this.Add(item);
            }
        }

        private void FullObservableCollectionCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (T item in e.NewItems)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged += ItemChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (T item in e.OldItems)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged -= ItemChanged;
                }
            }
        }

        public void Add(List<T> items)
        {
            foreach(T item in items)
            {
                Add(item);
            }
        }

        //protected override void ClearItems()
        //{
        //    foreach (INotifyPropertyChanged item in Items)
        //        item.PropertyChanged -= ItemPropertyChanged;

        //    base.ClearItems();
        //}
    }
}
