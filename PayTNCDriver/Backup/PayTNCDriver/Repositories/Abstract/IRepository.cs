using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PayTNCDriver.Repositories.Abstract
{
    public interface IRepository<E> where E :class
    {
        E FindById(int? id);
        IEnumerable<E> SelectAll();
        IEnumerable<E> Find(Expression<Func<E, bool>> predicate);
        void Insert(E entity);
        void Delete(E entity);
        bool SaveChanges();
        bool Any(Func<E, bool> predicate);
    }
}
