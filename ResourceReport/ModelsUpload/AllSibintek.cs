using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceReport.ModelsUpload
{
    internal class AllSibintek
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string Licenses { get; set; }
        public string RealSize { get; set; }
        public string ProcReserv { get; set; }
        public string Cloud { get; set; }
        public string FQDN { get; set; }
        public string OS { get; set; }
        public string AddedTime { get; set; }
        public string IP { get; set; }
        public AllSibintek(string name, string size, string processor, string memory, string licenses, string realSize, string procReserv, string cloud, string fQDN, string oS, string addedTime, string iP)
        {
            Name = name;
            Size = size;
            Processor = processor;
            Memory = memory;
            Licenses = licenses;
            RealSize = realSize;
            ProcReserv = procReserv;
            Cloud = cloud;
            FQDN = fQDN;
            OS = oS;
            AddedTime = addedTime;
            IP = iP;
        }
    }
}
