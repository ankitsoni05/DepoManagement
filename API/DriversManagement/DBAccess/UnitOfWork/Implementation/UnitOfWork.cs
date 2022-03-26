using DBAccess.DataAccess.Contract;
using DBAccess.DataAccess.Implementation;
using DBAccess.DBContext;
using DBAccess.UnitOfWork.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DriverContext _context;

        public UnitOfWork(DriverContext context)
        {
            this._context = context;
            Drivers = new DriverDataAccessRepo(context);
        }
        public IDriverDataAccessRepo Drivers { get; set; }

        public int CompleteAsync()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
