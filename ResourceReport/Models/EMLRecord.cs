using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double UtilizeTenant { get; set; }
        public double UtilizeBackup { get; set; }
        public double UtilizeBackupTape { get; set; }
        public int Quota { get; set; }
        public DateTime LastConnection { get; set; }
        public double Price { get; set; }
        public bool Security { get; set; }
        public EMLRecord(string mailBoxType, string company, string sAMAccountName, string tenant, string department, string occupation, string tenantMail, double utilizeTenant, double utilizeBackup, double utilizeBackupTape, int quota, DateTime lastConnection, double price, bool security)
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
            Price = price;
            Security = security;
        }
    }
}
