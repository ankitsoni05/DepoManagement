using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.DataAccessModels
{
    public class DriverPay
    {
        [Key]
        public int payId { get; set; }
        public DateTime payDate { get; set; }
        public decimal overTimeAmount { get; set; }
        public virtual Driver Driver { get; set; }
        public int driverId { get; set; }
    }
}
