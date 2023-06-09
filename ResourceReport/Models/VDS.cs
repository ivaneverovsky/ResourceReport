﻿namespace ResourceReport.Models
{
    internal class VDS
    {
        public string SAMAccountName { get; set; }
        public string Company { get; set; }
        public string Tenant { get; set; }
        public string Department { get; set; }
        public string Occupation { get; set; }
        public string ProfileCapacity { get; set; }
        public string UtilizeBackup { get; set; }
        public string LastConnection { get; set; }
        public string Price { get; set; }
        public string ExtensionAttribute { get; set; }
        public VDS(string sAMAccountName, string company, string tenant, string department, string occupation, string profileCapacity, string utilizeBackup, string lastConnection, string price, string extensionAttribute)
        {
            SAMAccountName = sAMAccountName;
            Company = company;
            Tenant = tenant;
            Department = department;
            Occupation = occupation;
            ProfileCapacity = profileCapacity;
            UtilizeBackup = utilizeBackup;
            LastConnection = lastConnection;
            Price = price;
            ExtensionAttribute = extensionAttribute;
        }
    }
}
