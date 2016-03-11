namespace PhoneDirect3DXamlAppInterop.Database
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;

    public class TrulyObservableCollection<T> : ObservableCollection<T> where T: INotifyPropertyChanged
    {
        public TrulyObservableCollection()
        {
            this.CollectionChanged += new NotifyCollectionChangedEventHandler(this.TrulyObservableCollection_CollectionChanged);
        }

        public TrulyObservableCollection(IEnumerable<T> collection) : base(collection)
        {
            foreach (object obj2 in collection)
            {
                (obj2 as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(this.item_PropertyChanged);
            }
            this.CollectionChanged += new NotifyCollectionChangedEventHandler(this.TrulyObservableCollection_CollectionChanged);
        }

        public void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, sender, sender, base.IndexOf((T) sender));
            this.OnCollectionChanged(args);
        }

        private void TrulyObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (object obj2 in e.NewItems)
                {
                    (obj2 as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(this.item_PropertyChanged);
                }
            }
            if (e.OldItems != null)
            {
                foreach (object obj3 in e.OldItems)
                {
                    (obj3 as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(this.item_PropertyChanged);
                }
            }
        }
    }
}

