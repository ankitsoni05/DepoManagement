using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.DataAccessModels
{
    public class Division
    {
        [Key]
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public virtual IEnumerable<Depo> depos { get; set; }
    }
}
