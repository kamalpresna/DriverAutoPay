using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTNCDriver.Repositories.Concrete
{
    public class RepositoryBase <T> where T : class, new()
    {
        private T _context;

        public RepositoryBase(T context)
        {
            _context = DbContext();
        }

        public T DbContext()
        {
            if (_context == null)
                return (T)Activator.CreateInstance(typeof(T));
            else
                return _context;
        }

    }
}
