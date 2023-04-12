namespace ResourceReport.ModelsUpload
{
    internal class Rds
    {
        public string SAMAccountName { get; set; }
        public string Company { get; set; }
        public string Tenant { get; set; }
        public string Department { get; set; }
        public string Occupation { get; set; }
        public string ActualProfileSize { get; set; }
        public string Validity { get; set; }
        public string ExtensionAttribute { get; set; }
        public string RunoverProfileSize { get; set; }
        public string LastConnection { get; set; }
        public Rds(string sAMAccountName, string company, string tenant, string department, string occupation, string actualProfileSize, string validity, string extensionAttribute, string runoverProfileSize, string lastConnection)
        {
            SAMAccountName = sAMAccountName;
            Company = company;
            Tenant = tenant;
            Department = department;
            Occupation = occupation;
            ActualProfileSize = actualProfileSize;
            Validity = validity;
            ExtensionAttribute = extensionAttribute;
            RunoverProfileSize = runoverProfileSize;
            LastConnection = lastConnection;
        }
    }
}
