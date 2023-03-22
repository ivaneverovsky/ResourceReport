using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceReport.ModelsUpload
{
    internal class SIBIaaS
    {
        public string Name { get; set; }
        public string DiskSpace { get; set; }
        public string CPU { get; set; }
        public string Memory { get; set; }
        public string Tag { get; set; }
        public string GuestFileSystem { get; set; }
        public string Folder { get; set; }
        public string Hostname { get; set; }
        public string OS { get; set; }
        public string IPAddress { get; set; }
        public string PowerState { get; set; }
        public string Datastores { get; set; }
        public SIBIaaS(string name, string diskSpace, string cPU, string memory, string tag, string guestFileSystem, string folder, string hostname, string oS, string iPAddress, string powerState, string datastores)
        {
            Name = name;
            DiskSpace = diskSpace;
            CPU = cPU;
            Memory = memory;
            Tag = tag;
            GuestFileSystem = guestFileSystem;
            Folder = folder;
            Hostname = hostname;
            OS = oS;
            IPAddress = iPAddress;
            PowerState = powerState;
            Datastores = datastores;
        }
    }
}
