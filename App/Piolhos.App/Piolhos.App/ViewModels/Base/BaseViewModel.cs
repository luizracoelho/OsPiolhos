using Piolhos.App.Interfaces;
using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Xamarin.Forms;

namespace Piolhos.App.ViewModels.Base
{
    public abstract class BaseViewModel : BaseViewModel<object> { }

    public abstract class BaseViewModel<T> : INotifyPropertyChanged where T : class, new()
    {
        public IMessage Message { get; set; }
        public INavigation Navigation { get; set; }

        public bool IsPreventedDefault<TPresentedDefault>()
        {
            if (Navigation.NavigationStack.Count > 0)
            {
                var existingPage = Navigation.NavigationStack.FirstOrDefault(x => x.GetType() == typeof(TPresentedDefault));
                return existingPage == null;
            }

            return true;
        }

        public bool IsPreventedDefaultModal<TPresentedDefault>()
        {
            if (Navigation.ModalStack.Count > 0)
            {
                var existingPage = Navigation.ModalStack.FirstOrDefault(x => x.GetType() == typeof(TPresentedDefault));
                return existingPage == null;
            }

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisedPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaisedPropertyChanged<TProperty>(Expression<Func<TProperty>> expression)
        {
            var member = expression.Body as MemberExpression;

            if (member.Member is PropertyInfo propertyInfo)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyInfo.Name));
        }

        private bool _isWaiting = false;
        public bool IsWaiting
        {
            get { return _isWaiting; }
            set
            {
                _isWaiting = value;
                RaisedPropertyChanged(() => IsWaiting);
            }
        }
    }
}
