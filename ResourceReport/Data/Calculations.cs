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

namespace ResourceReport.Data
{
    internal class Calculations
    {
        Storage _stor = new Storage();

        //reports
        public void CreateIaaS(List<object> iaas)
        {
            string virtualizationPlatform = "";
            string project = "";
            string vmName = "";
            string fqdn = "";
            string ip = "";
            string disk = "";
            string cpu = "";
            string ram = "";
            string os = "";
            string backup = "";
            string backupTape = "";
            string vmCreation = "";
            string isName = "";
            string tenant = "";
            string owner = "";
            string price = "";
            string reqCreate = "";
            string reqDelete = "";
            string reqChange = "";
            string avz = "";
            string siem = "";
            string skazi = "";

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
                    virtualizationPlatform = value[nisw.id0].ToString();
                    project = value[nisw.id1].ToString();
                    vmName = value[nisw.id2].ToString();
                    fqdn = value[nisw.id3].ToString();
                    ip = value[nisw.id4].ToString();
                    disk = value[nisw.id5].ToString();
                    cpu = value[nisw.id6].ToString();
                    ram = value[nisw.id7].ToString();
                    os = value[nisw.id8].ToString();
                    backup = value[nisw.id9].ToString();
                    backupTape = value[nisw.id10].ToString();
                    vmCreation = value[nisw.id11].ToString();
                    isName = value[nisw.id12].ToString();
                    tenant = value[nisw.id13].ToString();
                    owner = value[nisw.id14].ToString();
                    price = value[nisw.id15].ToString();
                    reqCreate = value[nisw.id16].ToString();
                    reqDelete = value[nisw.id17].ToString();
                    reqChange = value[nisw.id18].ToString();
                    avz = value[nisw.id19].ToString();
                    siem = value[nisw.id20].ToString();
                    skazi = value[nisw.id21].ToString();

                    var iaasItem = new IaaS(virtualizationPlatform, project, vmName, fqdn, ip, disk, cpu, ram, os, backup, backupTape, vmCreation, isName, tenant, owner, price, reqCreate, reqDelete, reqChange, avz, siem, skazi);
                    _stor.AddIaaS(iaasItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент IaaS: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (_stor.IaaS.Count != 0)
                MessageBox.Show("Данные IaaS записаны.", "Внимание");
            else
                MessageBox.Show("Данных IaaS не найдено.", "Внимание");
        }
        public void CreateEML(List<object> eml) 
        {
            string mailBoxType = "";
            string company = "";
            string samAccountName = "";
            string tenant = "";
            string department = "";
            string occupation = "";
            string owner = "";
            string ownerMail = "";
            string tenantMail = "";
            string utilizeTenant = "";
            string utilizeBackup = "";
            string utilizeBackupTape = "";
            string quota = "";
            string creationDate = "";
            string lastConnection = "";
            string vmValidity = "";
            string description = "";
            string reason = "";
            string price = "";
            string accountStatus = "";
            string extensionAttribute = "";
            string security = "";

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
                    mailBoxType = value[nemlw.id0].ToString();
                    company = value[nemlw.id1].ToString();
                    samAccountName = value[nemlw.id2].ToString();
                    tenant = value[nemlw.id3].ToString();
                    department = value[nemlw.id4].ToString();
                    occupation = value[nemlw.id5].ToString();
                    owner = value[nemlw.id6].ToString();
                    ownerMail = value[nemlw.id7].ToString();
                    tenantMail = value[nemlw.id8].ToString();
                    utilizeTenant = value[nemlw.id9].ToString();
                    utilizeBackup = value[nemlw.id10].ToString();
                    utilizeBackupTape = value[nemlw.id11].ToString();
                    quota = value[nemlw.id12].ToString();
                    creationDate = value[nemlw.id13].ToString();
                    lastConnection = value[nemlw.id14].ToString();
                    vmValidity = value[nemlw.id15].ToString();
                    description = value[nemlw.id16].ToString();
                    reason = value[nemlw.id17].ToString();
                    price = value[nemlw.id18].ToString();
                    accountStatus = value[nemlw.id19].ToString();
                    extensionAttribute = value[nemlw.id20].ToString();
                    security = value[nemlw.id21].ToString();

                    var eml_item = new EML(mailBoxType, company, samAccountName, tenant, department, occupation, owner, ownerMail, tenantMail, utilizeTenant, utilizeBackup, utilizeBackupTape, quota, creationDate, lastConnection, vmValidity, description, reason, price, accountStatus, extensionAttribute, security);
                    _stor.AddEML(eml_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент EML: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (_stor.EML.Count != 0)
                MessageBox.Show("Данные EML записаны.", "Внимание");
            else
                MessageBox.Show("Данных EML не найдено.", "Внимание");
        }
        public void CreateEMLRec(List<object> eml_rec)
        {
            string mailBoxType = "";
            string company = "";
            string samAccountName = "";
            string tenant = "";
            string department = "";
            string occupation = "";
            string tenantMail = "";
            string utilizeTenant = "";
            string utilizeBackup = "";
            string utilizeBackupTape = "";
            string quota = "";
            string lastConnection = "";
            string price = "";
            string security = "";

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
                    mailBoxType = value[nemlrw.id0].ToString();
                    company = value[nemlrw.id1].ToString();
                    samAccountName = value[nemlrw.id2].ToString();
                    tenant = value[nemlrw.id3].ToString();
                    department = value[nemlrw.id4].ToString();
                    occupation = value[nemlrw.id5].ToString();
                    tenantMail = value[nemlrw.id6].ToString();
                    utilizeTenant = value[nemlrw.id7].ToString();
                    utilizeBackup = value[nemlrw.id8].ToString();
                    utilizeBackupTape = value[nemlrw.id9].ToString();
                    quota = value[nemlrw.id10].ToString();
                    lastConnection = value[nemlrw.id11].ToString();
                    price = value[nemlrw.id12].ToString();
                    security = value[nemlrw.id13].ToString();

                    var eml_rec_item = new EMLRecord(mailBoxType, company, samAccountName, tenant, department, occupation, tenantMail, utilizeTenant, utilizeBackup, utilizeBackupTape, quota, lastConnection, price, security);
                    _stor.AddEMLRecord(eml_rec_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент EML Архив: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (_stor.EMLRecord.Count != 0)
                MessageBox.Show("Данные EML Архив записаны.", "Внимание");
            else
                MessageBox.Show("Данных EML Архив не найдено.", "Внимание");
        }
        public void CreateVDS(List<object> vds)
        {
            string samAccountName = "";
            string company = "";
            string tenant = "";
            string department = "";
            string occupation = "";
            string profileCapacity = "";
            string utilizeBackup = "";
            string lastConnection = "";
            string price = "";
            string extensionAttribute = "";

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
                    samAccountName = value[nvdsw.id0].ToString();
                    company = value[nvdsw.id1].ToString();
                    tenant = value[nvdsw.id2].ToString();
                    department = value[nvdsw.id3].ToString();
                    occupation = value[nvdsw.id4].ToString();
                    profileCapacity = value[nvdsw.id5].ToString();
                    utilizeBackup = value[nvdsw.id6].ToString();
                    lastConnection = value[nvdsw.id7].ToString();
                    price = value[nvdsw.id8].ToString();
                    extensionAttribute = value[nvdsw.id9].ToString();

                    var vds_item = new VDS(samAccountName, company, tenant, department, occupation, profileCapacity, utilizeBackup, lastConnection, price, extensionAttribute);
                    _stor.AddVDS(vds_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент VDS: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (_stor.VDS.Count != 0)
                MessageBox.Show("Данные VDS записаны.", "Внимание");
            else
                MessageBox.Show("Данных VDS не найдено.", "Внимание");
        }
        public void CreateVDSRec(List<object> vds_rec)
        {
            string samAccountName = "";
            string company = "";
            string tenant = "";
            string department = "";
            string occupation = "";
            string profileCapacity = "";
            string utilizeBackup = "";
            string lastConnection = "";
            string price = "";

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
                    samAccountName = value[nvdsrw.id0].ToString();
                    company = value[nvdsrw.id1].ToString();
                    tenant = value[nvdsrw.id2].ToString();
                    department = value[nvdsrw.id3].ToString();
                    occupation = value[nvdsrw.id4].ToString();
                    profileCapacity = value[nvdsrw.id5].ToString();
                    utilizeBackup = value[nvdsrw.id6].ToString();
                    lastConnection = value[nvdsrw.id7].ToString();
                    price = value[nvdsrw.id8].ToString();

                    var vds_rec_item = new VDSRecord(samAccountName, company, tenant, department, occupation, profileCapacity, utilizeBackup, lastConnection, price);
                    _stor.AddVDSRecord(vds_rec_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент VDS Архив: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (_stor.VDSRecord.Count != 0)
                MessageBox.Show("Данные VDS Архив записаны.", "Внимание");
            else
                MessageBox.Show("Данных VDS Архив не найдено.", "Внимание");
        }
        public void CreateFPS(List<object> fps)
        {
            string volume = "";
            string volumeCapacity = "";
            string freeSapce = "";
            string backup = "";
            string sharingFolder = "";

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
                    volume = value[nfpsw.id0].ToString();
                    volumeCapacity = value[nfpsw.id1].ToString();
                    freeSapce = value[nfpsw.id2].ToString();
                    backup = value[nfpsw.id3].ToString();
                    sharingFolder = value[nfpsw.id4].ToString();

                    var fps_item = new FPS(volume, volumeCapacity, freeSapce, backup, sharingFolder);
                    _stor.AddFPS(fps_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент FPS: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (_stor.FPS.Count != 0)
                MessageBox.Show("Данные FPS записаны.", "Внимание");
            else
                MessageBox.Show("Данных FPS не найдено.", "Внимание");
        }
        public void CreateReport()
        {
            
        }
        public void CreateReportRN()
        {
           
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
            for (int i = 1; i < cdcTapeBackup.Count; i++)
            {
                List<object> value = (List<object>)cdcTapeBackup[i];

                try
                {

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

                }
                catch (Exception ex)
                {
                    MessageBox.Show("SIBCDCTapeBackup: " + ex.Message, "Ошибка");
                    return;
                }
            }
        }
        //collect results  
        public List<IaaS> CollectIaaS()
        {
            return _stor.IaaS;
        }
        public List<EML> CollectEML()
        {
            return _stor.EML;
        }
        public List<EMLRecord> CollectEMLRecord()
        {
            return _stor.EMLRecord;
        }
        public List<VDS> CollectVDS()
        {
            return _stor.VDS;
        }
        public List<VDSRecord> CollectVDSRecord()
        {
            return _stor.VDSRecord;
        }
        public List<FPS> CollectFPS()
        {
            return _stor.FPS;
        }
    }
}
