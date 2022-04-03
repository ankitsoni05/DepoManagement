using System;

namespace DriversManagement.Models
{
    public class DriverPay
    {
        public DateTime payDate { get; set; }
        public decimal overTimeAmount { get; set; }
        public decimal basicSalary { get; set; }
        public decimal pf { get; set; }
        public decimal esic { get; set; }
    }
}
