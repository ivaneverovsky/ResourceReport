using ResourceReport.Models;
using System.Collections.Generic;

namespace ResourceReport.Data
{
    internal class Storage
    {
        private List<IaaS> _iaas = new List<IaaS>();
        public List<IaaS> IaaS { get { return _iaas; } }
        public void AddIaaS(IaaS iaas)
        {
            _iaas.Add(iaas);
        }

        private List<EML> _eml = new List<EML>();
        public List<EML> EML { get { return _eml; } }
        public void AddEML(EML eml)
        {
            _eml.Add(eml);
        }

        private List<EMLRecord> _emlrecord = new List<EMLRecord>();
        public List<EMLRecord> EMLRecord { get { return _emlrecord; } }
        public void AddEMLRecord(EMLRecord record)
        {
            _emlrecord.Add(record);
        }

        private List<VDS> _vds = new List<VDS>();
        public List<VDS> VDS { get { return _vds; } }
        public void AddVDS(VDS vds)
        {
            _vds.Add(vds);
        }

        private List<VDSRecord> _vdsrecord = new List<VDSRecord>();
        public List<VDSRecord> VDSRecord { get { return _vdsrecord; } }
        public void AddVDSRecord(VDSRecord record)
        {
            _vdsrecord.Add(record);
        }

        private List<FPS> _fps = new List<FPS>();
        public List<FPS> FPS { get { return _fps; } }
        public void AddFPS(FPS fps)
        {
            _fps.Add(fps);
        }

        private List<Report> _report = new List<Report>();
        public List<Report> Report { get { return _report; } }
        public void AddReport(Report report)
        {
            _report.Add(report);
        }

        private List<ReportRN> _reportrn = new List<ReportRN>();
        public List<ReportRN> ReportRN { get { return _reportrn; } }
        public void AddReportRN(ReportRN reportRN)
        {
            _reportrn.Add(reportRN);
        }
    }
}
