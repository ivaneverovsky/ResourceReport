namespace ResourceReport.Models
{
    internal class EMLRecord
    {
        public string MailBoxType { get; set; }
        public string Company { get; set; }
        public string SAMAccountName { get; set; }
        public string Tenant { get; set; }
        public string Department { get; set; }
        public string Occupation { get; set; }
        public string TenantMail { get; set; }
        public string UtilizeTenant { get; set; }
        public string UtilizeBackup { get; set; }
        public string UtilizeBackupTape { get; set; }
        public string Quota { get; set; }
        public string LastConnection { get; set; }
        public string ExtensionAttribute { get; set; }
        public string Price { get; set; }
        public string Security { get; set; }
        public EMLRecord(string mailBoxType, string company, string sAMAccountName, string tenant, string department, string occupation, string tenantMail, string utilizeTenant, string utilizeBackup, string utilizeBackupTape, string quota, string lastConnection, string extensionAttribute, string price, string security)
        {
            MailBoxType = mailBoxType;
            Company = company;
            SAMAccountName = sAMAccountName;
            Tenant = tenant;
            Department = department;
            Occupation = occupation;
            TenantMail = tenantMail;
            UtilizeTenant = utilizeTenant;
            UtilizeBackup = utilizeBackup;
            UtilizeBackupTape = utilizeBackupTape;
            Quota = quota;
            LastConnection = lastConnection;
            ExtensionAttribute = extensionAttribute;
            Price = price;
            Security = security;
        }
    }
}
