using System;

namespace ResourceReport.Models
{
    internal class EML
    {
        public string MailBoxType { get; set; }
        public string Company { get; set; }
        public string SAMAccountName { get; set; }
        public string Tenant { get; set; }
        public string Department { get; set; }
        public string Occupation { get; set; }
        public string Owner { get; set; }
        public string OwnerMail { get; set; }
        public string TenantMail { get; set; }
        public double UtilizeTenant { get; set; }
        public double UtilizeBackup { get; set; }
        public double UtilizeBackupTape { get; set; }
        public int Quota { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastConnection { get; set; }
        public DateTime VMValidity { get; set; }
        public string Description { get; set; }
        public string Reason { get; set; }
        public double Price { get; set; }
        public bool AccountStatus { get; set; }
        public bool Security { get; set; }
        public EML(string mailBoxType, string company, string sAMAccountName, string tenant, string department, string occupation, string owner, string ownerMail, string tenantMail, double utilizeTenant, double utilizeBackup, double utilizeBackupTape, int quota, DateTime creationDate, DateTime lastConnection, DateTime vMValidity, string description, string reason, double price, bool accountStatus, bool security)
        {
            MailBoxType = mailBoxType;
            Company = company;
            SAMAccountName = sAMAccountName;
            Tenant = tenant;
            Department = department;
            Occupation = occupation;
            Owner = owner;
            OwnerMail = ownerMail;
            TenantMail = tenantMail;
            UtilizeTenant = utilizeTenant;
            UtilizeBackup = utilizeBackup;
            UtilizeBackupTape = utilizeBackupTape;
            Quota = quota;
            CreationDate = creationDate;
            LastConnection = lastConnection;
            VMValidity = vMValidity;
            Description = description;
            Reason = reason;
            Price = price;
            AccountStatus = accountStatus;
            Security = security;
        }
    }
}
