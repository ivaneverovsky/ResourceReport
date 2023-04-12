namespace ResourceReport.ModelsUpload
{
    internal class Murs
    {
        public string MailBoxType { get; set; }
        public string Company { get; set; }
        public string SAMAccountName { get; set; }
        public string Name { get; set; }
        public string Enabled { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public string Manager { get; set; }
        public string ManagerMail { get; set; }
        public string Mail { get; set; }
        public string TotalItemsSize { get; set; }
        public string Database { get; set; }
        public string DatabaseName { get; set; }
        public string Created { get; set; }
        public string LastLogonTimeDate { get; set; }
        public string AccountExpirationDate { get; set; }
        public string DescriptionAppeal { get; set; }
        public string ExtensionAttribute3 { get; set; }
        public string ExtensionAttribute7 { get; set; }
        public Murs(string mailBoxType, string company, string sAMAccountName, string name, string enabled, string department, string title, string manager, string managerMail, string mail, string totalItemsSize, string database, string databaseName, string created, string lastLogonTimeDate, string accountExpirationDate, string descriptionAppeal, string extensionAttribute3, string extensionAttribute7)
        {
            MailBoxType = mailBoxType;
            Company = company;
            SAMAccountName = sAMAccountName;
            Name = name;
            Enabled = enabled;
            Department = department;
            Title = title;
            Manager = manager;
            ManagerMail = managerMail;
            Mail = mail;
            TotalItemsSize = totalItemsSize;
            Database = database;
            DatabaseName = databaseName;
            Created = created;
            LastLogonTimeDate = lastLogonTimeDate;
            AccountExpirationDate = accountExpirationDate;
            DescriptionAppeal = descriptionAppeal;
            ExtensionAttribute3 = extensionAttribute3;
            ExtensionAttribute7 = extensionAttribute7;
        }
    }
}
