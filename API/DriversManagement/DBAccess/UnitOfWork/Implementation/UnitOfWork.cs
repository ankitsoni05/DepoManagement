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
            Divisions = new DivisionAccessRepo(context);
            Depos = new DepoAccessRepo(context);
        }
        public IDriverDataAccessRepo Drivers { get; set; }
        public IDivisionAccessRepo Divisions { get; }
        public IDepoAccessRepo Depos { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
