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
        public string UtilizeTenant { get; set; }
        public string UtilizeBackup { get; set; }
        public string UtilizeBackupTape { get; set; }
        public string Quota { get; set; }
        public string CreationDate { get; set; }
        public string LastConnection { get; set; }
        public string VMValidity { get; set; }
        public string Description { get; set; }
        public string Reason { get; set; }
        public string Price { get; set; }
        public string AccountStatus { get; set; }
        public string ExtensionAttribute { get; set; }
        public string Security { get; set; }
        public EML(string mailBoxType, string company, string sAMAccountName, string tenant, string department, string occupation, string owner, string ownerMail, string tenantMail, string utilizeTenant, string utilizeBackup, string utilizeBackupTape, string quota, string creationDate, string lastConnection, string vMValidity, string description, string reason, string price, string accountStatus, string extensionAttribute, string security)
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
            ExtensionAttribute = extensionAttribute;
            Security = security;
        }
    }
}
