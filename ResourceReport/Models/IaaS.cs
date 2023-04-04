using System;

namespace ResourceReport.Models
{
    internal class IaaS
    {
        public string ContractName { get; set; }
        public string VirtualizationPlatform { get; set; }
        public string Project { get; set; }
        public string VMName { get; set; }
        public string FQDN { get; set; }
        public string IP { get; set; }
        public string Disk { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string OS { get; set; }
        public string Backup { get; set; }
        public string BackupTape { get; set; }
        public string VMCreation { get; set; }
        public string ISName { get; set; }
        public string Tenant { get; set; }
        public string Owner { get; set; }
        public string Price { get; set; }
        public string ReqCreate { get; set; }
        public string ReqDelete { get; set; }
        public string ReqChange { get; set; }
        public string AVZ { get; set; }
        public string SIEM { get; set; }
        public string SKAZI { get; set; }
        public string Color { get; set; }

        public IaaS(string contractName, string virtualizationPlatform, string project, string vMName, string fQDN, string iP, string disk, string cPU, string rAM, string oS, string backup, string backupTape, string vMCreation, string iSName, string tenant, string owner, string price, string reqCreate, string reqDelete, string reqChange, string aVZ, string sIEM, string sKAZI, string color)
        {
            ContractName = contractName;
            VirtualizationPlatform = virtualizationPlatform;
            Project = project;
            VMName = vMName;
            FQDN = fQDN;
            IP = iP;
            Disk = disk;
            CPU = cPU;
            RAM = rAM;
            OS = oS;
            Backup = backup;
            BackupTape = backupTape;
            VMCreation = vMCreation;
            ISName = iSName;
            Tenant = tenant;
            Owner = owner;
            Price = price;
            ReqCreate = reqCreate;
            ReqDelete = reqDelete;
            ReqChange = reqChange;
            AVZ = aVZ;
            SIEM = sIEM;
            SKAZI = sKAZI;
            Color = color;
        }
    }
}
