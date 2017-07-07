using SQLite.Net.Attributes;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Piolhos.Base
{
    public abstract class BaseEntity : INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id {
            get { return _id; }
            set
            {
                _id = value;
                RaisedPropertyChanged(() => Id);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisedPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaisedPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var member = expression.Body as MemberExpression;
            var propertyInfo = member.Member as PropertyInfo;

            if (propertyInfo != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyInfo.Name));
        }
    }
}
