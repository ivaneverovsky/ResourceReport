﻿using System;

namespace ResourceReport.Models
{
    internal class VDSRecord
    {
        public string SAMAccountName { get; set; }
        public string Company { get; set; }
        public string Tenant { get; set; }
        public string Department { get; set; }
        public string Occupation { get; set; }
        public double ProfileCapacity { get; set; }
        public double UtilizeBackup { get; set; }
        public DateTime LastConnection { get; set; }
        public double Price { get; set; }
        public VDSRecord(string sAMAccountName, string company, string tenant, string department, string occupation, double profileCapacity, double utilizeBackup, DateTime lastConnection, double price)
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
        }
    }
}
