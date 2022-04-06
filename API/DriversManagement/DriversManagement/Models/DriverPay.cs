using System;

namespace DriversManagement.Models
{
    public class DriverPay
    {
        public int payId { get; set; }
        public DateTime payDate { get; set; }
        public decimal overTimeAmount { get; set; }
        public int driverId { get; set; }
    }
}
