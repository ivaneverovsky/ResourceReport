namespace ResourceReport.Models
{
    internal class Report
    {
        public string ContractName { get; set; }
        public string Number { get; set; }
        public string Service { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public string ServiceDeliveryTime { get; set; }
        public string ServiceDownTime { get; set; }
        public string ServiceAvailability { get; set; }
        public string PricePerUnit { get; set; }
        public string PriceSum { get; set; }
        public string VAT { get; set; }
        public string VATSum { get; set; }
        public Report(string contractName, string number, string service, string description, string unit, string quantity, string serviceDeliveryTime, string serviceDownTime, string serviceAvailability, string pricePerUnit, string priceSum, string vAT, string vATSum)
        {
            ContractName = contractName;
            Number = number;
            Service = service;
            Description = description;
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
