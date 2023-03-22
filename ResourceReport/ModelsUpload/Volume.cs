using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceReport.ModelsUpload
{
    internal class Volume
    {
        public string VolumeMain { get; set; }
        public string UsedCapacity { get; set; }
        public string AvailableCapacity { get; set; }
        public string TotalCapacity { get; set; }
        public string MountPath { get; set; }
        public Volume(string volumeMain, string usedCapacity, string availableCapacity, string totalCapacity, string mountPath)
        {
            VolumeMain = volumeMain;
            UsedCapacity = usedCapacity;
            AvailableCapacity = availableCapacity;
            TotalCapacity = totalCapacity;
            MountPath = mountPath;
        }
    }
}
