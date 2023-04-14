using ResourceReport.Models;
using ResourceReport.ModelsUpload;
using ResourceReport.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;

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
        public void CreateIaaS(List<object> iaas, string contractName)
        {
            List<object> columns = (List<object>)iaas[0];
            bool bull = false;

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

                    var iaasItem = new IaaS(contractName, virtualizationPlatform, project, vmName, fqdn, ip, disk, cpu, ram, os, backup, backupTape, vmCreation, isName, tenant, owner, price, reqCreate, reqDelete, reqChange, avz, siem, skazi, "color");
                    _stor.AddIaaS(iaasItem);

                    bull = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент IaaS: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (!bull)
                MessageBox.Show("Данных IaaS не найдено.", "Внимание");
        }
        public void CreateEML(List<object> eml) 
        {
            List<object> columns = (List<object>)eml[0];
            bool bull = false;

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

                    if (samAccountName == "")
                        return;

                    var eml_item = new EML(mailBoxType, company, samAccountName, tenant, department, occupation, owner, ownerMail, tenantMail, utilizeTenant, utilizeBackup, utilizeBackupTape, quota, creationDate, lastConnection, vmValidity, description, reason, price, accountStatus, extensionAttribute, security);
                    _stor.AddEML(eml_item);

                    bull = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент EML: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (!bull)
                MessageBox.Show("Данных EML не найдено.", "Внимание");
        }
        public void CreateEMLRec(List<object> eml_rec)
        {
            List<object> columns = (List<object>)eml_rec[0];
            bool bull = false;

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

                    bull = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент EML Архив: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (!bull)
                MessageBox.Show("Данных EML Архив не найдено.", "Внимание");
        }
        public void CreateVDS(List<object> vds)
        {
            List<object> columns = (List<object>)vds[0];
            bool bull = false;

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

                    if (tenant == "")
                        return;

                    var vds_item = new VDS(samAccountName, company, tenant, department, occupation, profileCapacity, utilizeBackup, lastConnection, price, extensionAttribute);
                    _stor.AddVDS(vds_item);

                    bull = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент VDS: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (!bull)
                MessageBox.Show("Данных VDS не найдено.", "Внимание");
        }
        public void CreateVDSRec(List<object> vds_rec)
        {
            List<object> columns = (List<object>)vds_rec[0];
            bool bull = false;

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

                    bull = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент VDS Архив: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (!bull)
                MessageBox.Show("Данных VDS Архив не найдено.", "Внимание");
        }
        public void CreateFPS(List<object> fps)
        {
            List<object> columns = (List<object>)fps[0];
            bool bull = false;

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

                    bull = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать элемент FPS: " + ex.Message, "Ошибка");
                    return;
                }
            }
            if (!bull)
                MessageBox.Show("Данных FPS не найдено.", "Внимание");
        }
        public void CreateReport()
        {
            foreach (var contract in _stor.Contract)
            {
                double CPU = 0.0;
                double RAM = 0.0;
                double HDD = 0.0;
                double SSD = 0.0;
                double BACKUPTAPE = 0.0;
                double BACKUP = 0.0;
                double EML = 0.0;
                double ASPAM = 0.0;
                double VDS = 0.0;
                double FPS = 0.0;
                double VAV_SRV = 0.0;
                double SCAZI_INT = 0.0;
                double SCAZI_EXT = 0.0;
                double SIEM = 0.0;
                double NGFW = 0.0;
                double SECSIB = 0.0;
                double CPU_DH2 = 0.0;
                double RAM_DH2 = 0.0;
                double HDD_DH2 = 0.0;
                double BACKUPTAPE_DH2 = 0.0;

                //IaaS
                double BACKUPTAPE_IAAS = 0.0;
                double BACKUP_IAAS = 0.0;
                for (int i = 0; i < _stor.IaaS.Count; i++)
                {
                    if (_stor.IaaS[i].ContractName.ToLower().Contains(contract.ContractName.ToLower()))
                    {
                        try
                        {
                            CPU += Convert.ToDouble(_stor.IaaS[i].CPU);
                            RAM += Convert.ToDouble(_stor.IaaS[i].RAM);
                            SSD += Convert.ToDouble(_stor.IaaS[i].Disk);
                            BACKUPTAPE_IAAS += Convert.ToDouble(_stor.IaaS[i].BackupTape);
                            BACKUP_IAAS += Convert.ToDouble(_stor.IaaS[i].Backup);
                            NGFW++;
                            if (_stor.IaaS[i].AVZ == "+")
                                VAV_SRV++;
                            if (_stor.IaaS[i].SKAZI == "+")
                                SCAZI_INT++;
                            if (_stor.IaaS[i].SIEM == "+")
                                SIEM++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "\nIaaS", "Ошибка");
                            continue;
                        }
                    }
                }
                if (contract.ContractName.ToLower() == "дитиавп")
                {
                    SIEM = 1.0;
                    NGFW = 1.0;
                    CPU_DH2 = 1248.0;
                    RAM_DH2 = 12288.0;
                    HDD_DH2 = 400832.0;
                    BACKUPTAPE_DH2 = 480000.0;
                }

                //EML & EML Record
                double BACKUPTAPE_EML = 0.0;
                double BACKUP_EML = 0.0;
                for (int i = 0; i < _stor.EML.Count; i++)
                {
                    if (_stor.EML[i].Company.ToLower().Contains(contract.ContractName.ToLower()) || _stor.EML[i].ExtensionAttribute.ToLower().Contains(contract.ContractName.ToLower()))
                    {
                        try
                        {
                            HDD += Convert.ToDouble(_stor.EML[i].UtilizeTenant);
                            BACKUPTAPE_EML += Convert.ToDouble(_stor.EML[i].UtilizeBackupTape);
                            BACKUP_EML += Convert.ToDouble(_stor.EML[i].UtilizeBackup);
                            EML++;
                            ASPAM++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "\nEML", "Ошибка");
                            continue;
                        }
                    }
                }
                for (int i = 0; i < _stor.EMLRecord.Count; i++)
                {
                    if (_stor.EMLRecord[i].Company.ToLower().Contains(contract.ContractName.ToLower()))
                    {
                        try
                        {
                            HDD += Convert.ToDouble(_stor.EMLRecord[i].UtilizeTenant);
                            BACKUPTAPE_EML += Convert.ToDouble(_stor.EMLRecord[i].UtilizeBackupTape);
                            BACKUP_EML += Convert.ToDouble(_stor.EMLRecord[i].UtilizeBackup);
                            EML++;
                            ASPAM++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "\nEML Record", "Ошибка");
                            continue;
                        }
                    }
                }

                //VDS & VDS Record
                double BACKUP_FPS = 0.0;
                for (int i = 0; i < _stor.VDS.Count; i++)
                {
                    if (_stor.VDS[i].Company.ToLower().Contains(contract.ContractName.ToLower()) || _stor.VDS[i].ExtensionAttribute.ToLower().Contains(contract.ContractName.ToLower()))
                    {
                        try
                        {
                            BACKUP_FPS += Convert.ToDouble(_stor.VDS[i].UtilizeBackup);
                            VDS++;
                            FPS += Convert.ToDouble(_stor.VDS[i].ProfileCapacity);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "\nVDS", "Ошибка");
                            continue;
                        }
                    }
                }
                for (int i = 0; i < _stor.VDSRecord.Count; i++)
                {
                    if (_stor.VDSRecord[i].Company.ToLower().Contains(contract.ContractName.ToLower()))
                    {
                        try
                        {
                            BACKUP_FPS += Convert.ToDouble(_stor.VDSRecord[i].UtilizeBackup);
                            FPS += Convert.ToDouble(_stor.VDSRecord[i].ProfileCapacity);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "\nVDS Record", "Ошибка");
                            continue;
                        }
                    }
                }
                if (contract.ContractName.ToLower() == "дитиавп")
                {
                    BACKUP_FPS = 0.0;
                    FPS = 0.0;
                    SECSIB = 1.0;
                }

                BACKUPTAPE = BACKUPTAPE_IAAS + BACKUPTAPE_EML;
                BACKUP = BACKUP_IAAS + BACKUP_EML + BACKUP_FPS;

                double sumCPU = 0.0;
                double sumRAM = 0.0;
                double sumHDD = 0.0;
                double sumSSD = 0.0;
                double sumTAPE = 0.0;
                double sumBACKUP = 0.0;
                double sumEML = 0.0;
                double sumVDS = 0.0;
                double sumFPS = 0.0;
                double sumASPAM = 0.0;
                double sumVAV_SRV = 0.0;
                double sumSCAZI_INT = 0.0;
                double sumSCAZI_EXT = 0.0;
                double sumSIEM = 0.0;
                double sumCPU_DH2 = 0.0;
                double sumRAM_DH2 = 0.0;
                double sumHDD_DH2 = 0.0;
                double sumBACKUPTAPE_DH2 = 0.0;
                double sumSECSIB = 0.0;
                double sumNGFW = 0.0;
                for (int i = 0; i < _stor.Prices.Count; i++)
                {
                    if (_stor.Prices[i].Item.ToLower().Contains("cpu_dh-1"))
                    {
                        sumCPU = _stor.Prices[i].Price * CPU;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, CPU.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumCPU.ToString(), (sumCPU * 0.2).ToString(), (sumCPU * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("ram_dh-1"))
                    {
                        sumRAM = _stor.Prices[i].Price * RAM;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, RAM.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumRAM.ToString(), (sumRAM * 0.2).ToString(), (sumRAM * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("slow"))
                    {
                        sumHDD = _stor.Prices[i].Price * HDD;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, HDD.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumHDD.ToString(), (sumHDD * 0.2).ToString(), (sumHDD * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("ssd"))
                    {
                        sumSSD = _stor.Prices[i].Price * SSD;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, SSD.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumSSD.ToString(), (sumSSD * 0.2).ToString(), (sumSSD * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("tape_dh-1"))
                    {
                        sumTAPE = _stor.Prices[i].Price * BACKUPTAPE;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, BACKUPTAPE.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumTAPE.ToString(), (sumTAPE * 0.2).ToString(), (sumTAPE * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("backup_dh-1"))
                    {
                        sumBACKUP = _stor.Prices[i].Price * BACKUP;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, BACKUP.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumBACKUP.ToString(), (sumBACKUP * 0.2).ToString(), (sumBACKUP * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("eml"))
                    {
                        sumEML = _stor.Prices[i].Price * EML;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, EML.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumEML.ToString(), (sumEML * 0.2).ToString(), (sumEML * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("vds"))
                    {
                        sumVDS = _stor.Prices[i].Price * VDS;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, VDS.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumVDS.ToString(), (sumVDS * 0.2).ToString(), (sumVDS * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("fps"))
                    {
                        sumFPS = _stor.Prices[i].Price * FPS;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, FPS.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumFPS.ToString(), (sumFPS * 0.2).ToString(), (sumFPS * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("aspam"))
                    {
                        sumASPAM = _stor.Prices[i].Price * ASPAM;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, ASPAM.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumASPAM.ToString(), (sumASPAM * 0.2).ToString(), (sumASPAM * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("vav-srv"))
                    {
                        sumVAV_SRV = _stor.Prices[i].Price * VAV_SRV;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, VAV_SRV.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumVAV_SRV.ToString(), (sumVAV_SRV * 0.2).ToString(), (sumVAV_SRV * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("scazi_int"))
                    {
                        sumSCAZI_INT = _stor.Prices[i].Price * SCAZI_INT;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, SCAZI_INT.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumSCAZI_INT.ToString(), (sumSCAZI_INT * 0.2).ToString(), (sumSCAZI_INT * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("scazi_ext"))
                    {
                        sumSCAZI_EXT = _stor.Prices[i].Price * SCAZI_EXT;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, SCAZI_EXT.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumSCAZI_EXT.ToString(), (sumSCAZI_EXT * 0.2).ToString(), (sumSCAZI_EXT * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("siem"))
                    {
                        sumSIEM = _stor.Prices[i].Price * SIEM;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, SIEM.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumSIEM.ToString(), (sumSIEM * 0.2).ToString(), (sumSIEM * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("cpu_dh-2"))
                    {
                        sumCPU_DH2 = _stor.Prices[i].Price * CPU_DH2;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, CPU_DH2.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumCPU_DH2.ToString(), (sumCPU_DH2 * 0.2).ToString(), (sumCPU_DH2 * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("ram_dh-2"))
                    {
                        sumRAM_DH2 = _stor.Prices[i].Price * RAM_DH2;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, RAM_DH2.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumRAM_DH2.ToString(), (sumRAM_DH2 * 0.2).ToString(), (sumRAM_DH2 * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("hdd_sib_dh-2"))
                    {
                        sumHDD_DH2 = _stor.Prices[i].Price * HDD_DH2;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, HDD_DH2.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumHDD_DH2.ToString(), (sumHDD_DH2 * 0.2).ToString(), (sumHDD_DH2 * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("tape_dh-2"))
                    {
                        sumBACKUPTAPE_DH2 = _stor.Prices[i].Price * BACKUPTAPE_DH2;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, BACKUPTAPE_DH2.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumBACKUPTAPE_DH2.ToString(), (sumBACKUPTAPE_DH2 * 0.2).ToString(), (sumBACKUPTAPE_DH2 * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("secsib"))
                    {
                        sumSECSIB = _stor.Prices[i].Price * SECSIB;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, SECSIB.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumSECSIB.ToString(), (sumSECSIB * 0.2).ToString(), (sumSECSIB * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("ngfw"))
                    {
                        sumNGFW = _stor.Prices[i].Price * NGFW;
                        var report = new Report(contract.ContractName, _stor.Prices[i].Item, _stor.Prices[i].Description, _stor.Prices[i].Unit, NGFW.ToString(), "24x7", "0", "100%", _stor.Prices[i].Price.ToString(), sumNGFW.ToString(), (sumNGFW * 0.2).ToString(), (sumNGFW * 1.2).ToString());
                        _stor.AddReport(report);
                        continue;
                    }
                }
            }
        }

        //clear store
        public void ClearStore() { _stor.ClearStore(); }
        public void ClearUploads() { _stor.ClearUploads(); }
        public void ClearLogs() { _stor.ClearLogs(); }

        //upload's reports
        public void CreatePriceList(List<object> priceList)
        {
            for (int i = 1; i < priceList.Count; i++)
            {
                List<object> value = (List<object>)priceList[i];

                try
                {
                    var item = new PriceList(value[0].ToString(), Convert.ToDouble(value[1]), value[2].ToString(), value[3].ToString());
                    _stor.AddItem(item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Price list: " + ex.Message, "Ошибка");
                    continue;
                }
            }
        }
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
                    var volume_item = new Volume(value[0].ToString(), value[1].ToString(), value[2].ToString(), value[3].ToString(), value[4].ToString(), "0");
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
                    if (value[0].ToString() == "NULL")
                        continue;
                        
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
        public void CreateReportIaaS(List<object> reportIaaS)
        {
            for (int i = 1; i < reportIaaS.Count; i++)
            {
                List<object> value = (List<object>)reportIaaS[i];

                try
                {
                    var reportIaaS_item = new IaaSInfo(value[0].ToString(), value[1].ToString(), value[2].ToString(), value[3].ToString(), value[4].ToString(), value[5].ToString(), value[6].ToString(), value[7].ToString(), value[8].ToString(), value[9].ToString(), value[10].ToString(), value[11].ToString(), value[12].ToString(), value[13].ToString(), value[14].ToString(), value[15].ToString(), value[16].ToString(), value[17].ToString(), value[18].ToString(), value[19].ToString(), value[20].ToString(), value[21].ToString(), value[22].ToString(), value[23].ToString(), value[24].ToString(), value[25].ToString());
                    _stor.AddReportIaaS(reportIaaS_item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ReportIaaS: " + ex.Message, "Ошибка");
                    return;
                }
            }
        }

        //collect results  
        public int CollectCounter() { return _stor.EML.Count + _stor.EMLRecord.Count + _stor.FPS.Count + _stor.IaaS.Count + _stor.VDS.Count + _stor.VDSRecord.Count; }
        public List<LogClass> CollectLogs() { return _stor.Logs; }
        public List<Report> CollectReports() { return _stor.Report; }
        public List<Contract> CollectContracts() { return _stor.Contract; }

        //result builder
        public void MursCount()
        {
            List<Murs> mursList = _stor.Murs;

            for (int i = 0; i < _stor.EML.Count; i++)
                for (int j = 0; j < mursList.Count; j++)
                    try
                    {
                        if (_stor.EML[i].SAMAccountName == mursList[j].SAMAccountName && mursList[j].Enabled == "True")
                        {
                            _stor.RemoveEML(_stor.EML[i]);

                            var eml_item = new EML(mursList[j].MailBoxType, mursList[j].Company, mursList[j].SAMAccountName, mursList[j].Name, mursList[j].Department, mursList[j].Title, mursList[j].Manager, mursList[j].ManagerMail, mursList[j].Mail, mursList[j].TotalItemsSize.Replace(",", "."), (Convert.ToDouble(mursList[j].TotalItemsSize.Replace(",", ".")) * 3.67).ToString().Trim(new char[] { '(', ')' }), (Convert.ToDouble(mursList[j].TotalItemsSize.Replace(",", ".")) * 29.62).ToString().Trim(new char[] { '(', ')' }), mursList[j].Database, mursList[j].Created, mursList[j].LastLogonTimeDate, mursList[j].Enabled, mursList[j].DescriptionAppeal, mursList[j].ExtensionAttribute3, "стоимость", mursList[j].Enabled, mursList[j].ExtensionAttribute7, "защита");
                            _stor.AddEML(eml_item);
                            //emlList.Add(eml_item);

                            mursList.RemoveAt(j);
                            j--;
                        }
                        else if (_stor.EML[i].SAMAccountName == mursList[j].SAMAccountName && mursList[j].ExtensionAttribute7.ToLower() == "дитиавп")
                        {
                            _stor.RemoveEML(_stor.EML[i]);

                            var eml_item = new EML(mursList[j].MailBoxType, mursList[j].Company, mursList[j].SAMAccountName, mursList[j].Name, mursList[j].Department, mursList[j].Title, mursList[j].Manager, mursList[j].ManagerMail, mursList[j].Mail, mursList[j].TotalItemsSize.Replace(",", "."), "", "", mursList[j].Database, mursList[j].Created, mursList[j].LastLogonTimeDate, mursList[j].Enabled, mursList[j].DescriptionAppeal, mursList[j].ExtensionAttribute3, "стоимость", mursList[j].Enabled, mursList[j].ExtensionAttribute7, "защита");
                            _stor.AddEML(eml_item);

                            mursList.RemoveAt(j);
                            j--;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка EML");
                        continue;
                    }

            for (int i = 0; i < _stor.EMLRecord.Count; i++)
                for (int j = 0; j < mursList.Count; j++)
                    try
                    {
                        if (_stor.EMLRecord[i].SAMAccountName == mursList[j].SAMAccountName && mursList[j].Enabled == "False")
                        {
                            _stor.RemoveEMLRecord(_stor.EMLRecord[i]);

                            var emlRecord_item = new EMLRecord(mursList[j].MailBoxType, mursList[j].Company, mursList[j].SAMAccountName, mursList[j].Name, mursList[j].Department, mursList[j].Title, mursList[j].Mail, mursList[j].TotalItemsSize.Replace(",", "."), "", "", mursList[j].Database, mursList[j].LastLogonTimeDate, "стоимость", "защита");
                            _stor.AddEMLRecord(emlRecord_item);

                            mursList.RemoveAt(j);
                            j--;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка EMLRecord");
                        continue;
                    }
            string time = DateTime.Now.ToShortTimeString();
            var log = new LogClass(time + ": EML посчитан");
            _stor.AddLog(log);
        }
        public void VDSCount()
        {
            List<Rds> rdsList = _stor.Rds;

            DateTime last30 = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 21);
            DateTime currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            
            for (int i = 0; i < _stor.VDS.Count; i++)
                for (int j = 0; j < rdsList.Count; j++)
                    try
                    {
                        if (_stor.VDS[i].SAMAccountName == rdsList[j].SAMAccountName && DateTime.Parse(rdsList[j].LastConnection) >= last30 && rdsList[j].ExtensionAttribute.ToLower() == "дитиавп")
                        {
                            _stor.RemoveVDS(_stor.VDS[i]);

                            var vds_item = new VDS(rdsList[j].SAMAccountName, rdsList[j].Company, rdsList[j].Tenant, rdsList[j].Department, rdsList[j].Occupation, rdsList[j].ActualProfileSize, "", rdsList[j].LastConnection, "стоимость", rdsList[j].ExtensionAttribute);
                            _stor.AddVDS(vds_item);

                            rdsList.RemoveAt(j);
                            j--;
                        }
                        else if (_stor.VDS[i].SAMAccountName == rdsList[j].SAMAccountName && DateTime.Parse(rdsList[j].LastConnection) >= currentMonth)
                        {
                            _stor.RemoveVDS(_stor.VDS[i]);

                            var vds_item = new VDS(rdsList[j].SAMAccountName, rdsList[j].Company, rdsList[j].Tenant, rdsList[j].Department, rdsList[j].Occupation, rdsList[j].ActualProfileSize, "", rdsList[j].LastConnection, "стоимость", rdsList[j].ExtensionAttribute);
                            _stor.AddVDS(vds_item);

                            rdsList.RemoveAt(j);
                            j--;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка VDS");
                        continue;
                    }

            for (int i = 0; i < _stor.VDSRecord.Count; i++)
                for (int j = 0; j < rdsList.Count; j++)
                    if (_stor.VDSRecord[i].SAMAccountName == rdsList[j].SAMAccountName)
                    {
                        try
                        {
                            _stor.RemoveVDSRecord(_stor.VDSRecord[i]);

                            var vdsRecord_item = new VDSRecord(rdsList[j].SAMAccountName, rdsList[j].Company, rdsList[j].Tenant, rdsList[j].Department, rdsList[j].Occupation, rdsList[j].ActualProfileSize, "", rdsList[j].LastConnection, "стоимость");
                            _stor.AddVDSRecord(vdsRecord_item);

                            rdsList.RemoveAt(j);
                            j--;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка VDSRecord");
                            continue;
                        }
                    }
            string time = DateTime.Now.ToShortTimeString();
            var log = new LogClass(time + ": VDS посчитан");
            _stor.AddLog(log);
        }
        public void BackupVDSCount()
        {
            double counter = 0.0;
            double counterDit = 0.0;
            double counterSibSoft = 0.0;
            double counterExpertek = 0.0;
            double counterUsiito = 0.0;

            for (int i = 0; i < _stor.Backup.Count; i++)
                if (_stor.Backup[i].Volume.Contains("RD"))
                    try
                    {
                        counter += Convert.ToDouble(_stor.Backup[i].TotalCapacity);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка Backup");
                        continue;
                    }

            for (int i = 0; i < _stor.VDS.Count; i++)
                try
                {
                    if (_stor.VDS[i].ExtensionAttribute.ToLower().Contains("дитиавп"))
                        counterDit += Convert.ToDouble(_stor.VDS[i].ProfileCapacity);
                    else if (_stor.VDS[i].Company.ToLower().Contains("сибинтек-софт"))
                        counterSibSoft += Convert.ToDouble(_stor.VDS[i].ProfileCapacity);
                    else if (_stor.VDS[i].Company.ToLower().Contains("экспертек"))
                        counterExpertek += Convert.ToDouble(_stor.VDS[i].ProfileCapacity);
                    else
                        counterUsiito += Convert.ToDouble(_stor.VDS[i].ProfileCapacity);

                    //OPTIONAL: add info from RDS-users for Snegir and Sphera
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка VDSBackup");
                    continue;
                }
            double k_b = counter / (counterDit + counterSibSoft + counterExpertek + counterUsiito);

            if (_stor.KoefBackup.Count == 0)
            {
                var koefBackup = new KoefBackup(k_b, 0.0, 0.0);
                _stor.AddKoefBackup(koefBackup);
            }
            else
                _stor.KoefBackup[0].BackupRDS = k_b;

            string time = DateTime.Now.ToShortTimeString();
            var log = new LogClass(time + ": BackupVDS посчитан");
            _stor.AddLog(log);
        }
        public void BackupEMLCount()
        {
            double counter = 0.0;
            double counterTape = 0.0;

            double counterDit = 0.0;
            double counterSibSoft = 0.0;
            double counterExpertek = 0.0;
            double counterUsiito = 0.0;

            for (int i = 0; i < _stor.BackupsRepo.Count; i++)
                try
                {
                    if (_stor.BackupsRepo[i].VirtualMachine.ToLower().Contains("cdc-exch-") || _stor.BackupsRepo[i].VirtualMachine.ToLower().Contains("cdc-knot-"))
                        counter += Convert.ToDouble(_stor.BackupsRepo[i].TotalBackupsSize);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка BackupRepo");
                    continue;
                }

            for (int i = 0; i < _stor.EML.Count; i++)
                try
                {
                    if (_stor.EML[i].ExtensionAttribute.ToLower().Contains("дитиавп"))
                        counterDit += Convert.ToDouble(_stor.EML[i].UtilizeTenant);
                    else if (_stor.EML[i].Company.ToLower().Contains("сибинтек-софт") || _stor.EML[i].Company.ToLower().Contains("сфера"))
                        counterSibSoft += Convert.ToDouble(_stor.EML[i].UtilizeTenant);
                    else if (_stor.EML[i].Company.ToLower().Contains("экспертек"))
                        counterExpertek += Convert.ToDouble(_stor.EML[i].UtilizeTenant);
                    else
                        counterUsiito += Convert.ToDouble(_stor.EML[i].UtilizeTenant);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка EMLBackup");
                    continue;
                }
            double k_bEML = counter / (counterDit + counterSibSoft + counterExpertek + counterUsiito);
        
            for (int i = 0; i < _stor.SIBCDCTapeBackup.Count; i++)
            {
                try
                {
                    counterTape += Convert.ToDouble(_stor.SIBCDCTapeBackup[i].Size) / Math.Pow(1024, 3);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка SIBCDCTapeBackup");
                    continue;
                }
            }
            double k_bEMLTape = counterTape / (counterDit + counterSibSoft + counterExpertek + counterUsiito);

            if (_stor.KoefBackup.Count == 0)
            {
                var koefBackup = new KoefBackup(0.0, k_bEML, k_bEMLTape);
                _stor.AddKoefBackup(koefBackup);
            }
            else
            {
                _stor.KoefBackup[0].BackupEML = k_bEML;
                _stor.KoefBackup[0].BackupEMLTape = k_bEMLTape;
            }

            string time = DateTime.Now.ToShortTimeString();
            var log = new LogClass(time + ": BackupEML посчитан");
            _stor.AddLog(log);
        }
        public void FPSCount()
        {
            for (int i = 0; i < _stor.Backup.Count; i++)
                for (int j = 0; j < _stor.Volume.Count; j++)
                    if (_stor.Backup[i].Volume.Contains(_stor.Volume[j].VolumeMain))
                        _stor.Volume[j].Backup = _stor.Backup[i].UsedCapacity;

            for (int i = 0; i < _stor.FPS.Count; i++)
                for (int j = 0; j < _stor.Volume.Count; j++)
                    if (_stor.FPS[i].Volume.Contains(_stor.Volume[j].VolumeMain))
                    {
                        _stor.FPS[i].VolumeCapacity = _stor.Volume[j].UsedCapacity;
                        _stor.FPS[i].FreeSpace = _stor.Volume[j].AvailableCapacity;
                        _stor.FPS[i].Backup = _stor.Volume[j].Backup;
                    }
            string time = DateTime.Now.ToShortTimeString();
            var log = new LogClass(time + ": FPS посчитан");
            _stor.AddLog(log);
        }
        public void IaaSCount()
        {
            for (int i = 0; i < _stor.IaaS.Count; i++)
            {
                bool bull = false;
                for (int j = 0; j < _stor.ReportIaaS.Count; j++)
                {
                    if (_stor.IaaS[i].FQDN.Contains(_stor.ReportIaaS[j].VMName) || _stor.IaaS[i].FQDN == _stor.ReportIaaS[j].FQDN)
                    {
                        bull = true;
                        if (_stor.IaaS[i].Disk != _stor.ReportIaaS[j].Disk || _stor.IaaS[i].CPU != _stor.ReportIaaS[j].CPU || _stor.IaaS[i].RAM != _stor.ReportIaaS[j].Ram || _stor.IaaS[i].Backup != _stor.ReportIaaS[j].Backup || _stor.IaaS[i].BackupTape != _stor.ReportIaaS[j].BackupTape)
                        {
                            _stor.IaaS[i].Disk = _stor.ReportIaaS[j].Disk;
                            _stor.IaaS[i].CPU = _stor.ReportIaaS[j].CPU;
                            _stor.IaaS[i].RAM = _stor.ReportIaaS[j].Ram;
                            _stor.IaaS[i].Backup = _stor.ReportIaaS[j].Backup;
                            _stor.IaaS[i].BackupTape = _stor.ReportIaaS[j].BackupTape;
                            _stor.IaaS[i].Color = "Blue";
                            _stor.IaaS[i].ReqChange = _stor.IaaS[i].ReqChange + " + NEW REQUEST NUMBER";
                            _stor.IaaS[i].Price = "0";

                            _stor.RemoveReportIaaS(_stor.ReportIaaS[j]);
                            if (j != 0)
                                j--;
                        }
                        else
                        {
                            _stor.RemoveReportIaaS(_stor.ReportIaaS[j]);
                            if (j != 0)
                                j--;
                        }
                    }
                }
                if (!bull)
                {
                    _stor.IaaS[i].Color = "Red";
                    _stor.IaaS[i].ReqDelete = " + NEW REQUEST NUMBER";
                }
            }
            if (_stor.ReportIaaS.Count != 0)
            {
                for (int j = 0; j < _stor.ReportIaaS.Count; j++)
                {
                    string contractName = _stor.ReportIaaS[j].ContractName;
                    string virtualizationPlatform = _stor.ReportIaaS[j].VirtualizationPlatform;
                    string project = _stor.ReportIaaS[j].Project;
                    string vmName = _stor.ReportIaaS[j].VMName;
                    string fqdn = _stor.ReportIaaS[j].FQDN;
                    string ip = _stor.ReportIaaS[j].IP;
                    string disk = _stor.ReportIaaS[j].Disk;
                    string cpu = _stor.ReportIaaS[j].CPU;
                    string ram = _stor.ReportIaaS[j].Ram;
                    string os = _stor.ReportIaaS[j].OS;
                    string backup = _stor.ReportIaaS[j].Backup;
                    string backupTape = _stor.ReportIaaS[j].BackupTape;
                    string vmCreation = _stor.ReportIaaS[j].CreationDate;
                    string isName = _stor.ReportIaaS[j].SystemName;
                    string tenant = _stor.ReportIaaS[j].ResponsibleName;
                    string owner = _stor.ReportIaaS[j].Owner;
                    string price = "0";
                    string reqCreate = _stor.ReportIaaS[j].RequestCreate;
                    string reqDelete = _stor.ReportIaaS[j].RequestDelete;
                    string reqChange = _stor.ReportIaaS[j].RequestChange;
                    string avz = _stor.ReportIaaS[j].AVZ;
                    string siem = _stor.ReportIaaS[j].SIEM;
                    string skazi = "";
                    string color = "Yellow";

                    try
                    {
                        var iaasItem = new IaaS(contractName, virtualizationPlatform, project, vmName, fqdn, ip, disk, cpu, ram, os, backup, backupTape, vmCreation, isName, tenant, owner, price, reqCreate, reqDelete, reqChange, avz, siem, skazi, color);
                        _stor.AddIaaS(iaasItem);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "IaaS j: " + j, "Ошибка IaaSCount (Create)");
                        continue;
                    }
                }

            }
            string time = DateTime.Now.ToShortTimeString();
            var log = new LogClass(time + ": IaaS посчитан");
            _stor.AddLog(log);
        }
        public void UtilEMLCount()
        {
            for (int i = 0; i < _stor.EML.Count; i++)
            {
                _stor.EML[i].UtilizeBackup = (Convert.ToDouble(_stor.EML[i].UtilizeTenant) * _stor.KoefBackup[0].BackupEML).ToString();
                _stor.EML[i].UtilizeBackupTape = (Convert.ToDouble(_stor.EML[i].UtilizeTenant) * _stor.KoefBackup[0].BackupEMLTape).ToString();
            }
            string time = DateTime.Now.ToShortTimeString();
            var log = new LogClass(time + ": Util EML посчитан");
            _stor.AddLog(log);
        }
        public void UtilEMLRecordCount()
        {
            for (int i = 0; i < _stor.EMLRecord.Count; i++)
            {
                _stor.EMLRecord[i].UtilizeBackup = (Convert.ToDouble(_stor.EMLRecord[i].UtilizeTenant) * _stor.KoefBackup[0].BackupEML).ToString();
                _stor.EMLRecord[i].UtilizeBackupTape = (Convert.ToDouble(_stor.EMLRecord[i].UtilizeTenant) * _stor.KoefBackup[0].BackupEMLTape).ToString();
            }
            string time = DateTime.Now.ToShortTimeString();
            var log = new LogClass(time + ": Util EMLRecord посчитан");
            _stor.AddLog(log);
        }
        public void UtilVDSCount()
        {
            for (int i = 0; i < _stor.VDS.Count; i++)
                _stor.VDS[i].UtilizeBackup = (Convert.ToDouble(_stor.VDS[i].ProfileCapacity) * _stor.KoefBackup[0].BackupRDS).ToString();

            string time = DateTime.Now.ToShortTimeString();
            var log = new LogClass(time + ": Util VDS посчитан");
            _stor.AddLog(log);
        }
        public void UtilVDSRecordCount()
        {
            for (int i = 0; i < _stor.VDSRecord.Count; i++)
                _stor.VDSRecord[i].UtilizeBackup = (Convert.ToDouble(_stor.VDSRecord[i].ProfileCapacity) * _stor.KoefBackup[0].BackupRDS).ToString();

            string time = DateTime.Now.ToShortTimeString();
            var log = new LogClass(time + ": Util VDS Record посчитан");
            _stor.AddLog(log);
        }

        //money counter
        public void IaaSMoneyCounter()
        {
            foreach (var item in _stor.IaaS)
                item.Price = IaaSPriceCount(item).ToString();

            string time = DateTime.Now.ToShortTimeString();
            var log = new LogClass(time + ": IaaS Money посчитан");
            _stor.AddLog(log);
        }
        public void EMLMoneyCounter()
        {
            foreach (var item in _stor.EML)
                item.Price = EMLPriceCount(item).ToString();

            string time = DateTime.Now.ToShortTimeString();
            var log = new LogClass(time + ": EML Money посчитан");
            _stor.AddLog(log);
        }
        public void VDSMoneyCounter()
        {
            foreach (var item in _stor.VDS)
                item.Price = VDSPriceCount(item).ToString();

            string time = DateTime.Now.ToShortTimeString();
            var log = new LogClass(time + ": VDS Money посчитан");
            _stor.AddLog(log);
        }
        private double IaaSPriceCount(IaaS iaas)
        {
            double price = 0.0;
            try
            {
                double cpu = Convert.ToDouble(iaas.CPU);
                double ram = Convert.ToDouble(iaas.RAM);
                double disk = Convert.ToDouble(iaas.Disk);
                double backup = 0.0;
                double backupTape = 0.0;
                double avz = 0.0;
                double siem = 0.0;
                if (iaas.Backup != "")
                    backup = Convert.ToDouble(iaas.Backup);
                else if (iaas.BackupTape != "")
                    backupTape = Convert.ToDouble(iaas.BackupTape);
                
                if (iaas.AVZ == "+")
                {
                    for (int i = 0; i < _stor.Prices.Count; i++)
                        if (_stor.Prices[i].Item.ToLower().Contains("vav-srv"))
                        {
                            avz = _stor.Prices[i].Price;
                            break;
                        }
                }
                else if (iaas.SIEM == "+")
                {
                    for (int i = 0; i < _stor.Prices.Count; i++)
                        if (_stor.Prices[i].Item.ToLower().Contains("siem"))
                        {
                            siem = _stor.Prices[i].Price;
                            break;
                        }
                }

                double cpuPrice = 0.0;
                double ramPrice = 0.0;
                double diskPrice = 0.0;
                double backupPrice = 0.0;
                double backupTapePrice = 0.0;
                for (int i = 0; i < _stor.Prices.Count; i++)
                {
                    if (_stor.Prices[i].Item.ToLower().Contains("cpu_dh-1"))
                    {
                        cpuPrice = _stor.Prices[i].Price;
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("ram_dh-1"))
                    {
                        ramPrice = _stor.Prices[i].Price;
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("ssd"))
                    {
                        diskPrice = _stor.Prices[i].Price;
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("tape_dh-1"))
                    {
                        backupTapePrice = _stor.Prices[i].Price;
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("backup_dh-1"))
                    {
                        backupPrice = _stor.Prices[i].Price;
                        continue;
                    }
                }

                price = cpuPrice * cpu + ramPrice * ram + diskPrice * disk + backupPrice * backup + backupTapePrice * backupTape + avz + siem;
            }
            catch (Exception ex)
            {
                MessageBox.Show("IaaSPriceCount: " + ex.Message + "\nОшибка в расчете стоимости ВМ (FQDN): " + iaas.FQDN, "Ошибка");
                return price;
            }

            return price;
        }
        private double EMLPriceCount(EML eml)
        {
            double price = 0.0;
            try
            {
                double uUser = Convert.ToDouble(eml.UtilizeTenant);
                double uBackup = Convert.ToDouble(eml.UtilizeBackup);
                double uTape = Convert.ToDouble(eml.UtilizeBackupTape);
                double emlPrice = 0.0;
                double backupPrice = 0.0;
                double backupTapePrice = 0.0;
                double diskPrice = 0.0;
                for (int i = 0; i < _stor.Prices.Count; i++)
                {
                    if (_stor.Prices[i].Item.ToLower().Contains("eml"))
                    {
                        emlPrice = _stor.Prices[i].Price;
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("slow"))
                    {
                        diskPrice = _stor.Prices[i].Price;
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("tape_dh-1"))
                    {
                        backupTapePrice = _stor.Prices[i].Price;
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("backup_dh-1"))
                    {
                        backupPrice = _stor.Prices[i].Price;
                        continue;
                    }
                }

                price = emlPrice + uUser * diskPrice + uBackup * backupPrice + uTape * backupTapePrice;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EMLPriceCount: " + ex.Message + "\nОшибка в расчете стоимости ящика (SAMAccountName): " + eml.SAMAccountName, "Ошибка");
                return price;
            }

            return price;
        }
        private double VDSPriceCount(VDS vds)
        {
            double price = 0.0;
            try
            {
                double capacity = Convert.ToDouble(vds.ProfileCapacity);
                double uBackup = Convert.ToDouble(vds.UtilizeBackup);
                double vdsPrice = 0.0;
                double fpsPrice = 0.0;
                double backupPrice = 0.0;
                for (int i = 0; i < _stor.Prices.Count; i++)
                {
                    if (_stor.Prices[i].Item.ToLower().Contains("vds"))
                    {
                        vdsPrice = _stor.Prices[i].Price;
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("backup_dh-1"))
                    {
                        backupPrice = _stor.Prices[i].Price;
                        continue;
                    }
                    else if (_stor.Prices[i].Item.ToLower().Contains("fps"))
                    {
                        fpsPrice = _stor.Prices[i].Price;
                        continue;
                    }
                }

                price = vdsPrice + capacity * fpsPrice + uBackup * backupPrice;
            }
            catch (Exception ex)
            {
                MessageBox.Show("VDSPriceCount: " + ex.Message + "\nОшибка в расчете стоимости VDS (SAMAccountName): " + vds.SAMAccountName, "Ошибка");
                return price;
            }

            return price;
        }
    }
}