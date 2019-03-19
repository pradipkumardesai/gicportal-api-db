using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace GicPortal.Data.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(long Id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);

        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork();

        public void CommitChanges()
        {
            uow.Commit();
        }
        protected GicDbEntities _dbContext { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public Repository()
        {
            _dbContext = uow.Context;
            _dbSet = uow.Context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }


        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new GicDbEntities())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery.AsNoTracking().ToList<T>();
            }
            return list;
        }


        public T GetById(long Id)
        {
            return _dbSet.Find(Id);
        }

        public void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                _dbSet.Add(entity);
                _dbContext.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
