using Dommel;
using MySql.Data.MySqlClient;
using Piolhos.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Piolhos.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected string ConnectionString;

        protected BaseRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                return db.GetAll<TEntity>();
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                return await db.GetAllAsync<TEntity>();
            }
        }

        public virtual TEntity Get(int id)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                return db.Get<TEntity>(id);
            }
        }
        public virtual async Task<TEntity> GetAsync(int id)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                return await db.GetAsync<TEntity>(id);
            }
        }

        public virtual void Insert(TEntity entity)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                db.Insert(entity);
            }
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                await db.InsertAsync(entity);
            }
        }

        public virtual bool Update(TEntity entity)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                return db.Update(entity);
            }
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                return await db.UpdateAsync(entity);
            }
        }

        public virtual bool Delete(int id)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                var entity = Get(id);

                if (entity == null) throw new Exception("Registro não encontrado");

                return db.Delete(entity);
            }
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                var entity = await GetAsync(id);

                if (entity == null)
                    throw new Exception("Registro não encontrado");

                return await db.DeleteAsync(entity);
            }
        }

        public virtual IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                return db.Select(predicate);
            }
        }

        public virtual async Task<IEnumerable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                return await db.SelectAsync(predicate);
            }
        }
    }
}
