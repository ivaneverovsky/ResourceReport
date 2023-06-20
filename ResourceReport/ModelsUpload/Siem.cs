using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceReport.ModelsUpload
{
    internal class Siem
    {
        public string Vmname { get; set; }
        public string FQDN { get; set; }
        public string IP { get; set; }
        public string OS { get; set; }
        public string DZO { get; set; }
        public string SIEM { get; set; }
        public Siem(string vmname, string fqdn, string ip, string os, string dzo, string siem)
        {
            Vmname = vmname;
            FQDN = fqdn;
            IP = ip;
            OS = os;
            DZO = dzo;
            SIEM = siem;
        }
    }
}
