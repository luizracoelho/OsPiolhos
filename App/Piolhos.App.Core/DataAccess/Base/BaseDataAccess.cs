using Piolhos.App.Core.Interfaces;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Piolhos.App.Core.DataAccess.Base
{
    public class BaseDataAccess<T> : IDisposable where T : class
    {
        public SQLiteConnection _conn;

        public BaseDataAccess()
        {
            var config = DependencyService.Get<IDataBaseConfig>();

            _conn = new SQLiteConnection(config.Platform, Path.Combine(config.Directory, "ospiolhos.db3"));

            //_conn.DropTable<T>();
            _conn.CreateTable<T>();
        }

        public void Insert(T entity)
        {
            _conn.Insert(entity);
        }

        public void Update(T entity)
        {
            _conn.Update(entity);
        }

        public void Save(T entity)
        {
            var entityDB = Get();

            if (entityDB == null)
                Insert(entity);
            else
                Update(entity);
        }

        public void Delete(T entity)
        {
            _conn.Delete(entity);
        }

        public T Get()
        {
            return _conn.Table<T>().FirstOrDefault();
        }

        public List<T> List()
        {
            return _conn.Table<T>().ToList();
        }

        public void Dispose()
        {
            _conn.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
