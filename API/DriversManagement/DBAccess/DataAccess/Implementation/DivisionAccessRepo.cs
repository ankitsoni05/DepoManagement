using DBAccess.DataAccess.Contract;
using DBAccess.DataAccessModels;
using DBAccess.DBContext;
using DBAccess.Repository.GenericRepository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.DataAccess.Implementation
{
    internal class DivisionAccessRepo : Repository<Division>, IDivisionAccessRepo
    {
        private readonly DriverContext driverContext;

        public DivisionAccessRepo(DriverContext driverContext) : base(driverContext)
        {
            this.driverContext = driverContext;
        }
    }
}
