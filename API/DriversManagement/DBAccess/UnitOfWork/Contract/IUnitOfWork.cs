using DBAccess.DataAccess.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.UnitOfWork.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        IDriverDataAccessRepo Drivers { get; }
        IDivisionAccessRepo Divisions { get; }
        IDepoAccessRepo Depos { get; }
        IPayAttributeAccessRepo payAttributes { get; }
        Task<int> CompleteAsync();
    }
}
