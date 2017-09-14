﻿using PayTNCDriver.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace PayTNCDriver.Repositories.Concrete
{
    public class Repository<E, T> : RepositoryBase<E>, IDisposable, IRepository<T>
        where T : class
         where E : DbContext, new()
    {
        protected readonly E _context;

        public Repository(E context) : base(context)
        {
            _context = context;
        }
        public virtual void Delete(T entity)
        {
            if (entity != null)
                _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public virtual T FindById(int? id)
        {
            if (id != null)
                return _context.Set<T>().Find(id);
            else
                return null;
        }

        public virtual void Insert(T entity)
        {
            if (entity != null)
            {
                _context.Set<T>().Add(entity);
            }
        }

        public virtual IEnumerable<T> SelectAll()
        {
            return _context.Set<T>().ToList();
        }

        public bool SaveChanges()
        {

            return _context.SaveChanges() > 0;
        }

        public IEnumerable<T> ExecStoreProcedure(string query, params object[] parameters)
        {
            return _context.Database.SqlQuery<T>(query, parameters).ToList();
        }

        public bool Any(Func<T, bool> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}


