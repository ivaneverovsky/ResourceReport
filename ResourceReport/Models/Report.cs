using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceReport.Models
{
    internal class Report
    {
        public double Number { get; set; }
        public string Service { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public int ServiceDeliveryTime { get; set; }
        public int ServiceDownTime { get; set; }
        public double ServiceAvailability { get; set; }
        public double PricePerUnit { get; set; }
        public double PriceSum { get; set; }
        public double VAT { get; set; }
        public double VATSum { get; set; }
        public Report(double number, string service, string unit, double quantity, int serviceDeliveryTime, int serviceDownTime, double serviceAvailability, double pricePerUnit, double priceSum, double vAT, double vATSum)
        {
            Number = number;
            Service = service;
            Unit = unit;
            Quantity = quantity;
            ServiceDeliveryTime = serviceDeliveryTime;
            ServiceDownTime = serviceDownTime;
            ServiceAvailability = serviceAvailability;
            PricePerUnit = pricePerUnit;
            PriceSum = priceSum;
            VAT = vAT;
            VATSum = vATSum;
        }
    }
}
