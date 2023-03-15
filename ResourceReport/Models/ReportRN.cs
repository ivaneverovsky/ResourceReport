namespace ResourceReport.Models
{
    internal class ReportRN
    {
        public string Number { get; set; }
        public string Service { get; set; }
        public string ServiceDescription { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public string ServiceDeliveryTime { get; set; }
        public string ServiceDownTime { get; set; }
        public string ServiceAvailability { get; set; }
        public string PricePerUnit { get; set; }
        public string PriceSum { get; set; }
        public string VAT { get; set; }
        public string VATSum { get; set; }
        public ReportRN(string number, string service, string serviceDescription, string unit, string quantity, string serviceDeliveryTime, string serviceDownTime, string serviceAvailability, string pricePerUnit, string priceSum, string vAT, string vATSum)
        {
            Number = number;
            Service = service;
            ServiceDescription = serviceDescription;
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
