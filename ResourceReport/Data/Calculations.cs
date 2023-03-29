using ResourceReport.Models;
using ResourceReport.ModelsUpload;
using ResourceReport.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;

namespace ResourceReport.Data
{
    internal class Calculations
    {
        Storage _stor = new Storage();

        //reports
        public void AddContract(string contract)
        {
            var contract_item = new Contract(contract);
            _stor.AddContract(contract_item);
        }
        public void CreateIaaS(List<object> iaas)
        {
            List<object> columns = (List<object>)iaas[0];

            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].ToString() == "")
                {
                    columns.RemoveAt(i);
                    i--;
                }
            }
            columns.Add("(нет)");

            NewIaaSWindow nisw = new NewIaaSWindow
            {
                DataContext = columns,
                Title = "IaaS"
            };
            nisw.ShowDialog();

            if (!nisw.Bull)
            {
                MessageBox.Show("Данные на листе IaaS не были обработаны.", "Внимание");
                return;
            }

            for (int i = 1; i < iaas.Count - 1; i++)
            {
                List<object> value = (List<object>)iaas[i];

                while (value.Count < 23)
                    value.Add("");

                try
                {
                    string virtualizationPlatform = value[nisw.id0].ToString();
                    string project = value[nisw.id1].ToString();
                    string vmName = value[nisw.id2].ToString();
                    string fqdn = value[nisw.id3].ToString();
                    string ip = value[nisw.id4].ToString();
                    string disk = value[nisw.id5].ToString();
                    string cpu = value[nisw.id6].ToString();
                    string ram = value[nisw.id7].ToString();
                    string os = value[nisw.id8].ToString();
                    string backup = value[nisw.id9].ToString();
                    string backupTape = value[nisw.id10].ToString();
                    string vmCreation = value[nisw.id11].ToString();
                    string isName = value[nisw.id12].ToString();
                    string tenant = value[nisw.id13].ToString();
                    string owner = value[nisw.id14].ToString();
                    string price = value[nisw.id15].ToString();
                    string reqCreate = value[nisw.id16].ToString();
                    string reqDelete = value[nisw.id17].ToString();
                    string reqChange = value[nisw.id18].ToString();
                    string avz = value[nisw.id19].ToString();
                    string siem = value[nisw.id20].ToString();
                    string skazi = value[nisw.id21].ToString();

                    var iaasItem = new IaaS(virtualizationPlatform, project, vmName, fqdn, ip, disk, cpu, ram, os, backup, backupTape, vmCreation, isName, tenant, owner, price, reqCreate, reqDelete, reqChange, avz, siem, skazi);
                    _stor.AddIaaS(iaasItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент IaaS: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (_stor.IaaS.Count == 0)
                MessageBox.Show("Данных IaaS не найдено.", "Внимание");
        }
        public void CreateEML(List<object> eml) 
        {
            List<object> columns = (List<object>)eml[0];

            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].ToString() == "")
                {
                    columns.RemoveAt(i);
                    i--;
                }
            }
            columns.Add("(нет)");

            NewEMLWindow nemlw = new NewEMLWindow
            {
                DataContext = columns,
                Title = "EML"
            };
            nemlw.ShowDialog();

            if (!nemlw.Bull)
            {
                MessageBox.Show("Данные на листе EML не были обработаны.", "Внимание");
                return;
            }

            for (int i = 1; i < eml.Count - 1; i++)
            {
                List<object> value = (List<object>)eml[i];
                while (value.Count < 22)
                    value.Add("");

                try
                {
                    string mailBoxType = value[nemlw.id0].ToString();
                    string company = value[nemlw.id1].ToString();
                    string samAccountName = value[nemlw.id2].ToString();
                    string tenant = value[nemlw.id3].ToString();
                    string department = value[nemlw.id4].ToString();
                    string occupation = value[nemlw.id5].ToString();
                    string owner = value[nemlw.id6].ToString();
                    string ownerMail = value[nemlw.id7].ToString();
                    string tenantMail = value[nemlw.id8].ToString();
                    string utilizeTenant = value[nemlw.id9].ToString();
                    string utilizeBackup = value[nemlw.id10].ToString();
                    string utilizeBackupTape = value[nemlw.id11].ToString();
                    string quota = value[nemlw.id12].ToString();
                    string creationDate = value[nemlw.id13].ToString();
                    string lastConnection = value[nemlw.id14].ToString();
                    string vmValidity = value[nemlw.id15].ToString();
                    string description = value[nemlw.id16].ToString();
                    string reason = value[nemlw.id17].ToString();
                    string price = value[nemlw.id18].ToString();
                    string accountStatus = value[nemlw.id19].ToString();
                    string extensionAttribute = value[nemlw.id20].ToString();
                    string security = value[nemlw.id21].ToString();

                    var eml_item = new EML(mailBoxType, company, samAccountName, tenant, department, occupation, owner, ownerMail, tenantMail, utilizeTenant, utilizeBackup, utilizeBackupTape, quota, creationDate, lastConnection, vmValidity, description, reason, price, accountStatus, extensionAttribute, security);
                    _stor.AddEML(eml_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент EML: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (_stor.EML.Count == 0)
                MessageBox.Show("Данных EML не найдено.", "Внимание");
        }
        public void CreateEMLRec(List<object> eml_rec)
        {
            List<object> columns = (List<object>)eml_rec[0];

            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].ToString() == "")
                {
                    columns.RemoveAt(i);
                    i--;
                }
            }
            columns.Add("(нет)");

            NewEMLRecordWindow nemlrw = new NewEMLRecordWindow
            {
                DataContext = columns,
                Title = "EML Record"
            };
            nemlrw.ShowDialog();

            if (!nemlrw.Bull)
            {
                MessageBox.Show("Данные на листе EML Архив не были обработаны.", "Внимание");
                return;
            }

            for (int i = 1; i < eml_rec.Count - 1; i++)
            {
                List<object> value = (List<object>)eml_rec[i];
                while (value.Count < 15)
                    value.Add("");

                try
                {
                    string mailBoxType = value[nemlrw.id0].ToString();
                    string company = value[nemlrw.id1].ToString();
                    string samAccountName = value[nemlrw.id2].ToString();
                    string tenant = value[nemlrw.id3].ToString();
                    string department = value[nemlrw.id4].ToString();
                    string occupation = value[nemlrw.id5].ToString();
                    string tenantMail = value[nemlrw.id6].ToString();
                    string utilizeTenant = value[nemlrw.id7].ToString();
                    string utilizeBackup = value[nemlrw.id8].ToString();
                    string utilizeBackupTape = value[nemlrw.id9].ToString();
                    string quota = value[nemlrw.id10].ToString();
                    string lastConnection = value[nemlrw.id11].ToString();
                    string price = value[nemlrw.id12].ToString();
                    string security = value[nemlrw.id13].ToString();

                    var eml_rec_item = new EMLRecord(mailBoxType, company, samAccountName, tenant, department, occupation, tenantMail, utilizeTenant, utilizeBackup, utilizeBackupTape, quota, lastConnection, price, security);
                    _stor.AddEMLRecord(eml_rec_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент EML Архив: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (_stor.EMLRecord.Count == 0)
                MessageBox.Show("Данных EML Архив не найдено.", "Внимание");
        }
        public void CreateVDS(List<object> vds)
        {
            List<object> columns = (List<object>)vds[0];

            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].ToString() == "")
                {
                    columns.RemoveAt(i);
                    i--;
                }
            }
            columns.Add("(нет)");

            NewVDSWindow nvdsw = new NewVDSWindow
            {
                DataContext = columns,
                Title = "VDS"
            };
            nvdsw.ShowDialog();

            if (!nvdsw.Bull)
            {
                MessageBox.Show("Данные на листе VDS не были обработаны.", "Внимание");
                return;
            }

            for (int i = 1; i < vds.Count - 1; i++)
            {
                List<object> value = (List<object>)vds[i];
                while (value.Count < 10)
                    value.Add("");

                try
                {
                    string samAccountName = value[nvdsw.id0].ToString();
                    string company = value[nvdsw.id1].ToString();
                    string tenant = value[nvdsw.id2].ToString();
                    string department = value[nvdsw.id3].ToString();
                    string occupation = value[nvdsw.id4].ToString();
                    string profileCapacity = value[nvdsw.id5].ToString();
                    string utilizeBackup = value[nvdsw.id6].ToString();
                    string lastConnection = value[nvdsw.id7].ToString();
                    string price = value[nvdsw.id8].ToString();
                    string extensionAttribute = value[nvdsw.id9].ToString();

                    var vds_item = new VDS(samAccountName, company, tenant, department, occupation, profileCapacity, utilizeBackup, lastConnection, price, extensionAttribute);
                    _stor.AddVDS(vds_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент VDS: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (_stor.VDS.Count == 0)
                MessageBox.Show("Данных VDS не найдено.", "Внимание");
        }
        public void CreateVDSRec(List<object> vds_rec)
        {
            List<object> columns = (List<object>)vds_rec[0];

            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].ToString() == "")
                {
                    columns.RemoveAt(i);
                    i--;
                }
            }
            columns.Add("(нет)");

            NewVDSRecordWindow nvdsrw = new NewVDSRecordWindow
            {
                DataContext = columns,
                Title = "VDS Record"
            };
            nvdsrw.ShowDialog();

            if (!nvdsrw.Bull)
            {
                MessageBox.Show("Данные на листе VDS Архив не были обработаны.", "Внимание");
                return;
            }

            for (int i = 1; i < vds_rec.Count - 1; i++)
            {
                List<object> value = (List<object>)vds_rec[i];
                while (value.Count < 9)
                    value.Add("");

                try
                {
                    string samAccountName = value[nvdsrw.id0].ToString();
                    string company = value[nvdsrw.id1].ToString();
                    string tenant = value[nvdsrw.id2].ToString();
                    string department = value[nvdsrw.id3].ToString();
                    string occupation = value[nvdsrw.id4].ToString();
                    string profileCapacity = value[nvdsrw.id5].ToString();
                    string utilizeBackup = value[nvdsrw.id6].ToString();
                    string lastConnection = value[nvdsrw.id7].ToString();
                    string price = value[nvdsrw.id8].ToString();

                    var vds_rec_item = new VDSRecord(samAccountName, company, tenant, department, occupation, profileCapacity, utilizeBackup, lastConnection, price);
                    _stor.AddVDSRecord(vds_rec_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент VDS Архив: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (_stor.VDSRecord.Count == 0)
                MessageBox.Show("Данных VDS Архив не найдено.", "Внимание");
        }
        public void CreateFPS(List<object> fps)
        {
            List<object> columns = (List<object>)fps[0];

            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].ToString() == "")
                {
                    columns.RemoveAt(i);
                    i--;
                }
            }
            columns.Add("(нет)");

            NewFPSWindow nfpsw = new NewFPSWindow
            {
                DataContext = columns,
                Title = "FPS"
            };
            nfpsw.ShowDialog();

            if (!nfpsw.Bull)
            {
                MessageBox.Show("Данные на листе FPS не были обработаны.", "Внимание");
                return;
            }

            for (int i = 1; i < fps.Count - 1; i++)
            {
                List<object> value = (List<object>)fps[i];
                while (value.Count < 5)
                    value.Add("");

                try
                {
                    string volume = value[nfpsw.id0].ToString();
                    string volumeCapacity = value[nfpsw.id1].ToString();
                    string freeSapce = value[nfpsw.id2].ToString();
                    string backup = value[nfpsw.id3].ToString();
                    string sharingFolder = value[nfpsw.id4].ToString();

                    var fps_item = new FPS(volume, volumeCapacity, freeSapce, backup, sharingFolder);
                    _stor.AddFPS(fps_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент FPS: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (_stor.FPS.Count == 0)
                MessageBox.Show("Данных FPS не найдено.", "Внимание");
        }
        public void CreateReport()
        {
            
        }
        public void CreateReportRN()
        {
           
        }
        public void ClearStore()
        {
            _stor.ClearStore();
        }

        //upload's reports
        public void CreateMURS(List<object> murs)
        {
            for (int i = 1; i < murs.Count; i++)
            {
                List<object> value = (List<object>)murs[i];

                try
                {
                    var murs_item = new Murs(value[0].ToString(), value[1].ToString(), value[2].ToString(), value[3].ToString(), value[4].ToString(), value[5].ToString(), value[6].ToString(), value[7].ToString(), value[8].ToString(), value[9].ToString(), value[10].ToString(), value[11].ToString(), value[12].ToString(), value[13].ToString(), value[14].ToString(), value[15].ToString(), value[16].ToString(), value[17].ToString(), value[18].ToString());
                    _stor.AddMURS(murs_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MURS: " + ex.Message, "Ошибка");
                    return;
                }
            }
        }
        public void CreateRDS(List<object> rds)
        {
            for (int i = 1; i < rds.Count; i++)
            {
                List<object> value = (List<object>)rds[i];

                try
                {
                    var rds_item = new Rds(value[0].ToString(), value[1].ToString(), value[2].ToString(), value[3].ToString(), value[4].ToString(), value[5].ToString(), value[6].ToString(), value[7].ToString(), value[8].ToString(), value[9].ToString());
                    _stor.AddRDS(rds_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("RDS: " + ex.Message, "Ошибка");
                    return;
                }
            }
        }
        public void CreateBackup(List<object> backup)
        {
            for (int i = 1; i < backup.Count; i++)
            {
                List<object> value = (List<object>)backup[i];

                try
                {
                    var backup_item = new Backup(value[0].ToString(), value[1].ToString(), value[2].ToString(), value[3].ToString(), value[4].ToString());
                    _stor.AddBackup(backup_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Backup: " + ex.Message, "Ошибка");
                    return;
                }
            }
        }
        public void CreateVolume(List<object> volume)
        {
            for (int i = 1; i < volume.Count; i++)
            {
                List<object> value = (List<object>)volume[i];

                try
                {
                    var volume_item = new Volume(value[0].ToString(), value[1].ToString(), value[2].ToString(), value[3].ToString(), value[4].ToString());
                    _stor.AddVolume(volume_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Volume: " + ex.Message, "Ошибка");
                    return;
                }
            }
        }
        public void CreateBackupsOnRepo(List<object> backupsrepo)
        {
            for (int i = 1; i < backupsrepo.Count; i++)
            {
                List<object> value = (List<object>)backupsrepo[i];

                try
                {
                    var backupsrepo_item = new BackupsRepo(value[0].ToString(), value[1].ToString(), value[2].ToString(), value[3].ToString(), value[4].ToString(), value[5].ToString(), value[6].ToString(), value[7].ToString(), value[8].ToString(), value[9].ToString(), value[10].ToString(), value[11].ToString(), value[12].ToString());
                    _stor.AddBackupsRepo(backupsrepo_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("BackupsOnRepo: " + ex.Message, "Ошибка");
                    return;
                }
            }
        }
        public void CreateCDCTapeBackup(List<object> cdcTapeBackup)
        {
            for (int i = 0; i < cdcTapeBackup.Count; i++)
            {
                List<object> value = (List<object>)cdcTapeBackup[i];

                try
                {
                    var cdcTapeBackup_item = new CDCTapeBackup(value[0].ToString(), value[1].ToString(), value[2].ToString(), value[3].ToString(), value[4].ToString());
                    _stor.AddCDCTapeBackup(cdcTapeBackup_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CDCTapeBackup: " + ex.Message, "Ошибка");
                    return;
                }
            }
        }
        public void CreateSIBCDCTapeBackup(List<object> sibCDCTapeBackup)
        {
            for (int i = 0; i < sibCDCTapeBackup.Count; i++)
            {
                List<object> value = (List<object>)sibCDCTapeBackup[i];

                try
                {
                    var sibCDCTapeBackup_item = new SIBCDCTapeBackup(value[0].ToString(), value[1].ToString(), value[2].ToString(), value[3].ToString(), value[4].ToString());
                    _stor.AddSIBCDCTapeBackup(sibCDCTapeBackup_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SIBCDCTapeBackup: " + ex.Message, "Ошибка");
                    return;
                }
            }
        }
        public void CreateVMSIBIaaS(List<object> vmSIBIaaS)
        {
            for (int i = 1; i < vmSIBIaaS.Count - 1; i++)
            {
                List<object> value = (List<object>)vmSIBIaaS[i];

                try
                {
                    var vmSIBIaaS_item = new SIBIaaS(value[0].ToString(), value[1].ToString(), value[2].ToString(), value[3].ToString(), value[4].ToString(), value[5].ToString(), value[6].ToString(), value[7].ToString(), value[8].ToString(), value[9].ToString(), value[10].ToString(), value[11].ToString());
                    _stor.AddSIBIaaS(vmSIBIaaS_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("VMSIBIaaS: " + ex.Message, "Ошибка");
                    return;
                }
            }
        }
        public void CreateAllSibintek(List<object> allSibintek)
        {
            for (int i = 1; i < allSibintek.Count - 1; i++)
            {
                List<object> value = (List<object>)allSibintek[i];

                try
                {
                    var allSibintek_item = new AllSibintek(value[0].ToString(), value[1].ToString(), value[2].ToString(), value[3].ToString(), value[4].ToString(), value[5].ToString(), value[6].ToString(), value[7].ToString(), value[8].ToString(), value[9].ToString(), value[10].ToString(), value[11].ToString());
                    _stor.AddAllSibintek(allSibintek_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("AllSibintek: " + ex.Message, "Ошибка");
                    return;
                }
            }
        }

        //collect results  
        public int CollectCounter() { return _stor.EML.Count + _stor.EMLRecord.Count + _stor.FPS.Count + _stor.IaaS.Count + _stor.VDS.Count + _stor.VDSRecord.Count; }

        //result builder
        public void MursCount()
        {
            List<Murs> mursList = new List<Murs>();
            List<EML> emlList = new List<EML>();
            List<EMLRecord> emlRecordList = new List<EMLRecord>();

            foreach (var item in _stor.Murs)
                if (item.Company.ToLower().Contains("айэмти") || item.Company.ToLower().Contains("экспертек") || item.Company.ToLower().Contains("сибинтек-софт") || item.ExtensionAttribute7.ToLower().Contains("усиито") || item.ExtensionAttribute7.ToLower().Contains("дитиавп"))
                    mursList.Add(item);

            for (int i = 0; i < _stor.EML.Count; i++)
                for (int j = 0; j < mursList.Count; j++)
                    if (_stor.EML[i].SAMAccountName == mursList[j].SAMAccountName && mursList[j].Enabled == "True")
                    {
                        _stor.RemoveEML(_stor.EML[i]);

                        var eml_item = new EML(mursList[j].MailBoxType, mursList[j].Company, mursList[j].SAMAccountName, mursList[j].Name, mursList[j].Department, mursList[j].Title, mursList[j].Manager, mursList[j].ManagerMail, mursList[j].Mail, mursList[j].TotalItemsSize.Replace(",", "."), (Convert.ToDouble(mursList[j].TotalItemsSize.Replace(",", ".")) * 3.67).ToString().Trim(new char[] {'(', ')'}), (Convert.ToDouble(mursList[j].TotalItemsSize.Replace(",", ".")) * 29.62).ToString().Trim(new char[] { '(', ')' }), mursList[j].Database, mursList[j].Created, mursList[j].LastLogonTimeDate, mursList[j].Enabled, mursList[j].DescriptionAppeal, mursList[j].ExtensionAttribute3, "стоимость", mursList[j].Enabled, mursList[j].ExtensionAttribute7, "защита");
                        _stor.AddEML(eml_item);
                        emlList.Add(eml_item);

                        mursList.RemoveAt(j);
                        j--;
                    }
                    else if (_stor.EML[i].SAMAccountName == mursList[j].SAMAccountName && mursList[j].ExtensionAttribute7.ToLower() == "дитиавп")
                    {
                        _stor.RemoveEML(_stor.EML[i]);

                        var eml_item = new EML(mursList[j].MailBoxType, mursList[j].Company, mursList[j].SAMAccountName, mursList[j].Name, mursList[j].Department, mursList[j].Title, mursList[j].Manager, mursList[j].ManagerMail, mursList[j].Mail, mursList[j].TotalItemsSize.Replace(",", "."), (Convert.ToDouble(mursList[j].TotalItemsSize.Replace(",", ".")) * 3.67).ToString().Trim(new char[] { '(', ')' }), (Convert.ToDouble(mursList[j].TotalItemsSize.Replace(",", ".")) * 29.62).ToString().Trim(new char[] { '(', ')' }), mursList[j].Database, mursList[j].Created, mursList[j].LastLogonTimeDate, mursList[j].Enabled, mursList[j].DescriptionAppeal, mursList[j].ExtensionAttribute3, "стоимость", mursList[j].Enabled, mursList[j].ExtensionAttribute7, "защита");
                        _stor.AddEML(eml_item);
                        emlList.Add(eml_item);

                        mursList.RemoveAt(j);
                        j--;
                    }

            for (int i = 0; i < _stor.EMLRecord.Count; i++)
                for (int j = 0; j < mursList.Count; j++)
                    if (_stor.EMLRecord[i].SAMAccountName == mursList[j].SAMAccountName)
                    {
                        _stor.RemoveEMLRecord(_stor.EMLRecord[i]);

                        var emlRecord_item = new EMLRecord(mursList[j].MailBoxType, mursList[j].Company, mursList[j].SAMAccountName, mursList[j].Name, mursList[j].Department, mursList[j].Title, mursList[j].Mail, mursList[j].TotalItemsSize.Replace(",", "."), (Convert.ToDouble(mursList[j].TotalItemsSize.Replace(",", ".")) * 3.67).ToString().Trim(new char[] { '(', ')' }), (Convert.ToDouble(mursList[j].TotalItemsSize.Replace(",", ".")) * 29.62).ToString().Trim(new char[] { '(', ')' }), mursList[j].Database, mursList[j].LastLogonTimeDate, "стоимость", "защита");
                        _stor.AddEMLRecord(emlRecord_item);
                        emlRecordList.Add(emlRecord_item);

                        mursList.RemoveAt(j);
                        j--;
                    }
        }
    }
}
