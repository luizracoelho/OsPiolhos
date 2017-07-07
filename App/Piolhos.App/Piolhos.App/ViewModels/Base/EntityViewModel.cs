using System.ComponentModel;

namespace Piolhos.App.ViewModels.Base
{
    public abstract class EntityViewModel<T> : BaseViewModel<T>, INotifyPropertyChanged where T : class, new()
    {
        private T _model;
        public T Model
        {
            get { return _model; }
            set
            {
                _model = value;
                RaisedPropertyChanged(() => Model);
            }
        }

        protected EntityViewModel()
        {
            Model = new T();
        }
    }
}
