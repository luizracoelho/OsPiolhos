using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Piolhos.App.ViewModels.Base
{
    public class ObservableGroupCollection<T> : ObservableCollection<T>
    {
        private readonly string _key;
        public string Key
        {
            get { return _key; }
        }

        public ObservableGroupCollection(IGrouping<string, T> group)
            : base(group)
        {
            _key = group.Key;
        }
    }

    public abstract class GroupingViewModel<T> : BaseListViewModel<T>, INotifyPropertyChanged where T : class, new()
    {
        private ObservableCollection<ObservableGroupCollection<T>> _model;
        public ObservableCollection<ObservableGroupCollection<T>> Model
        {
            get { return _model; }
            set
            {
                _model = value;
                RaisedPropertyChanged(() => Model);
            }
        }

        protected GroupingViewModel()
        {
            _model = new ObservableCollection<ObservableGroupCollection<T>>();
            _model.CollectionChanged += _model_CollectionChanged;
        }

        private void _model_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
        }
    }
}
