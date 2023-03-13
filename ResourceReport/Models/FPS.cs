using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceReport.Models
{
    internal class FPS
    {
        public string Volume { get; set; }
        public double VolumeCapacity { get; set; }
        public double FreeSpace { get; set; }
        public double Backup { get; set; }
        public string SharingFolder { get; set; }
        public FPS(string volume, double volumeCapacity, double freeSpace, double backup, string sharingFolder)
        {
            Volume = volume;
            VolumeCapacity = volumeCapacity;
            FreeSpace = freeSpace;
            Backup = backup;
            SharingFolder = sharingFolder;
        }
    }
}
