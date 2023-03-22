using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceReport.ModelsUpload
{
    internal class BackupsRepo
    {
        public string A { get; set; }
        public string B { get; set; }
        public string VirtualMachine { get; set; }
        public string D { get; set; }
        public string E { get; set; }
        public string FullBackups { get; set; }
        public string Increments { get; set; }
        public string RestorePoints { get; set; }
        public string FullBackupsSize { get; set; }
        public string IncrementsSize { get; set; }
        public string TotalBackupsSize { get; set; }
        public string ParentJobs { get; set; }
        public string LatestRestorePoint { get; set; }
        public BackupsRepo(string a, string b, string virtualMachine, string d, string e, string fullBackups, string increments, string restorePoints, string fullBackupsSize, string incrementsSize, string totalBackupsSize, string parentJobs, string latestRestorePoint)
        {
            A = a;
            B = b;
            VirtualMachine = virtualMachine;
            D = d;
            E = e;
            FullBackups = fullBackups;
            Increments = increments;
            RestorePoints = restorePoints;
            FullBackupsSize = fullBackupsSize;
            IncrementsSize = incrementsSize;
            TotalBackupsSize = totalBackupsSize;
            ParentJobs = parentJobs;
            LatestRestorePoint = latestRestorePoint;
        }
    }
}
