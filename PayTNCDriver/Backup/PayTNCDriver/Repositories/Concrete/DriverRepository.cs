using PayTNCDriver.Model;
using PayTNCDriver.Repositories.Abstract;
using PayTNCDriver.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTNCDriver.Repositories.Concrete
{
    public class DriverRepository : Repository<CARSEntities, Driver>, IDriverRepository
    {
        public DriverRepository() : base(new CARSEntities())
        {
        }



    }
}
