using DBAccess.DataAccessModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.DBContext
{
    public class DriverContext : IdentityDbContext
    {
        public DriverContext(DbContextOptions<DriverContext> options)
           : base(options)
        {

        }
        public DbSet<Division> divisions { get; set; }
        public DbSet<Depo> depos { get; set; }
        public DbSet<Driver> drivers { get; set; }
    }
}
