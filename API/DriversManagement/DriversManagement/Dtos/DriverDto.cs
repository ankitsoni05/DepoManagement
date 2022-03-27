using DriversManagement.Models;
using System.Collections.Generic;

namespace DriversManagement.Dtos
{
    public class DriverDto
    {
        public Driver driver { get; set; }
        public IEnumerable<Depo> depos { get; set; }
        public IEnumerable<Division> divisions { get; set; }
    }
}
