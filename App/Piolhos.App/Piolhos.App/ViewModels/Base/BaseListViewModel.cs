using System.ComponentModel;

namespace Piolhos.App.ViewModels.Base
{
    public abstract class BaseListViewModel<T> : BaseViewModel<T>, INotifyPropertyChanged where T : class, new()
    {
        private T _item;
        public T Item
        {
            get { return _item; }
            set
            {
                _item = value;
                RaisedPropertyChanged(() => Item);

                if (_item != null)
                    ItemTapped();
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisedPropertyChanged(() => IsRefreshing);
            }
        }

        public virtual void ItemTapped() { }
    }
}
