using System;
using System.IO;

namespace PaySlipGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] a = File.ReadAllBytes(@"D:\Projects\Depot Management\API\DriversManagement\PaySlipGenerator\PaySlipFormat\PaySlipArch.pdf");

            string s = Convert.ToBase64String(a);
            s.Replace("{{EmployeeFullName}}", "Ankit Hemant Soni");

            File.WriteAllBytes(@"D:\Projects\Depot Management\API\DriversManagement\PaySlipGenerator\GeneratedSlips\myfile.pdf", );
        }
    }
}
