using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Piolhos.App.ViewModels.Base
{
    public abstract class ListViewModel<T> : BaseListViewModel<T>, INotifyPropertyChanged where T : class, new()
    {
        private ObservableCollection<T> _model;
        public ObservableCollection<T> Model
        {
            get { return _model; }
            set
            {
                _model = value;
                RaisedPropertyChanged(() => Model);
            }
        }

        protected ListViewModel()
        {
            _model = new ObservableCollection<T>();
            _model.CollectionChanged += _model_CollectionChanged;
        }

        private void _model_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
        }
    }
}
