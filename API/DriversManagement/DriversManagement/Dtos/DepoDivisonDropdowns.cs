using DriversManagement.Models;
using System.Collections.Generic;

namespace DriversManagement.Dtos
{
    public class DepoDivisonDropdowns
    {
        public IEnumerable<Depo> depos { get; set; }
        public IEnumerable<Division> divisions { get; set; }
    }
}
