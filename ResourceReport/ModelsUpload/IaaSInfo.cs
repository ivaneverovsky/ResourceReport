using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceReport.ModelsUpload
{
    internal class IaaSInfo
    {
        public string VirtualizationPlatform { get; set; }
        public string Model { get; set; }
        public string ContractName { get; set; }
        public string Project { get; set; }
        public string VMName { get; set; }
        public string FQDN { get; set; }
        public string IP { get; set; }
        public string Disk { get; set; }
        public string CPU { get; set; }
        public string Ram { get; set; }
        public string OS { get; set; }
        public string Backup { get; set; }
        public string BackupTape { get; set; }
        public string CreationDate { get; set; }
        public string SystemName { get; set; }
        public string Owner { get; set; }
        public string OwnerOccupation { get; set; }
        public string ResponsibleName { get; set; }
        public string ResponsibleOccupation { get; set; }
        public string ResponsibleDepartment { get; set; }
        public string RequestCreate { get; set; }
        public string RequestDelete { get; set; }
        public string RequestChange { get; set; }
        public string Price { get; set; }
        public string AVZ { get; set; }
        public string SIEM { get; set; }
        public IaaSInfo(string virtualizationPlatform, string model, string contractName, string project, string vMName, string fQDN, string iP, string disk, string cPU, string ram, string oS, string backup, string backupTape, string creationDate, string systemName, string owner, string ownerOccupation, string responsibleName, string responsibleOccupation, string responsibleDepartment, string requestCreate, string requestDelete, string requestChange, string price, string aVZ, string sIEM)
        {
            VirtualizationPlatform = virtualizationPlatform;
            Model = model;
            ContractName = contractName;
            Project = project;
            VMName = vMName;
            FQDN = fQDN;
            IP = iP;
            Disk = disk;
            CPU = cPU;
            Ram = ram;
            OS = oS;
            Backup = backup;
            BackupTape = backupTape;
            CreationDate = creationDate;
            SystemName = systemName;
            Owner = owner;
            OwnerOccupation = ownerOccupation;
            ResponsibleName = responsibleName;
            ResponsibleOccupation = responsibleOccupation;
            ResponsibleDepartment = responsibleDepartment;
            RequestCreate = requestCreate;
            RequestDelete = requestDelete;
            RequestChange = requestChange;
            Price = price;
            AVZ = aVZ;
            SIEM = sIEM;
        }
    }
}
