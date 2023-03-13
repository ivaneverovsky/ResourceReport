using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceReport.Models
{
    internal class IaaS
    {
        public string VirtualizationPlatform { get; set; }
        public string Project { get; set; }
        public string VMName { get; set; }
        public string FQDN { get; set; }
        public string IP { get; set; }
        public double Disk { get; set; }
        public int CPU { get; set; }
        public int RAM { get; set; }
        public string OS { get; set; }
        public double Backup { get; set; }
        public double BackupTape { get; set; }
        public DateTime VMCreation { get; set; }
        public string ISName { get; set; }
        public string Tenant { get; set; }
        public string Owner { get; set; }
        public double Price { get; set; }
        public string ReqCreate { get; set; }
        public string ReqDelete { get; set; }
        public string ReqChange { get; set; }
        public bool AVZ { get; set; }
        public bool SIEM { get; set; }
        public bool SKAZI { get; set; }

        public IaaS(string virtualizationPlatform, string project, string vMName, string fQDN, string iP, double disk, int cPU, int rAM, string oS, double backup, double backupTape, DateTime vMCreation, string iSName, string tenant, string owner, double price, string reqCreate, string reqDelete, string reqChange, bool aVZ, bool sIEM, bool sKAZI)
        {
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
        }
    }
}
