using ResourceReport.Models;
using ResourceReport.ModelsUpload;
using System.Collections.Generic;

namespace ResourceReport.Data
{
    internal class Storage
    {
        //Reports
        private List<Contract> _contract = new List<Contract>();
        public List<Contract> Contract { get { return _contract; } }
        public void AddContract(Contract contract)
        {
            _contract.Add(contract);
        }
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

        //upload's reports
        private List<Murs> _murs = new List<Murs>();
        public List<Murs> Murs { get { return _murs; } }
        public void AddMURS(Murs murs)
        {
            _murs.Add(murs);
        }
        private List<Rds> _rds = new List<Rds>();
        public List<Rds> Rds { get { return _rds; } }
        public void AddRDS(Rds rds)
        {
            _rds.Add(rds);
        }
        private List<Backup> _backup = new List<Backup>();
        public List<Backup> Backup { get { return _backup;} }
        public void AddBackup(Backup backup)
        {
            _backup.Add(backup);
        }
        private List<Volume> _volume = new List<Volume>();
        public List<Volume> Volume { get { return _volume; } }
        public void AddVolume(Volume volume)
        {
            _volume.Add(volume);
        }
        private List<BackupsRepo> _backupsRepo = new List<BackupsRepo>();
        public List<BackupsRepo> BackupsRepo { get { return _backupsRepo; } }
        public void AddBackupsRepo(BackupsRepo backupsRepo)
        {
            _backupsRepo.Add(backupsRepo);
        }
        private List<CDCTapeBackup> _cdcTapeBackup = new List<CDCTapeBackup>();
        public List<CDCTapeBackup> CDCTapeBackup { get { return _cdcTapeBackup; } }
        public void AddCDCTapeBackup(CDCTapeBackup backup)
        {
            _cdcTapeBackup.Add(backup);
        }
        private List<SIBCDCTapeBackup> _sibCDCTapeBackup = new List<SIBCDCTapeBackup>();
        public List<SIBCDCTapeBackup> SIBCDCTapeBackup { get { return _sibCDCTapeBackup; } }
        public void AddSIBCDCTapeBackup(SIBCDCTapeBackup backup)
        {
            _sibCDCTapeBackup.Add(backup);
        }
        private List<SIBIaaS> _sibIaaS = new List<SIBIaaS>();
        public List<SIBIaaS> SIBIaaS { get { return _sibIaaS; } }
        public void AddSIBIaaS(SIBIaaS sibIaaS)
        {
            _sibIaaS.Add(sibIaaS);
        }
        private List<AllSibintek> _allSibintek = new List<AllSibintek>();
        public List<AllSibintek> AllSibintek { get { return _allSibintek; } }
        public void AddAllSibintek(AllSibintek allSibintek)
        {
            _allSibintek.Add(allSibintek);
        }

        //clear report store
        public void ClearStore()
        {
            _contract.Clear();
            _iaas.Clear();
            _eml.Clear();
            _emlrecord.Clear();
            _vds.Clear();
            _vdsrecord.Clear();
            _fps.Clear();
            _report.Clear();
            _reportrn.Clear();
        }
    }
}
