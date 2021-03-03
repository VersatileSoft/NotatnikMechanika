using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

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
                Add(item);
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
            foreach (var item in items)
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
