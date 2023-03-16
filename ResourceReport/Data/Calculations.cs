using ResourceReport.Models;
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

namespace ResourceReport.Data
{
    internal class Calculations
    {
        Storage _stor = new Storage();

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
        }
        public void CreateTKSS(List<object> tkss)
        {
            List<object> columns = (List<object>)tkss[0];
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].ToString() == "")
                {
                    columns.RemoveAt(i);
                    i--;
                }
            }
            columns.Add("(нет)");
        }
        public void CreateReport(List<object> report)
        {
            List<object> columns = (List<object>)report[0];
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].ToString() == "")
                {
                    columns.RemoveAt(i);
                    i--;
                }
            }
            columns.Add("(нет)");
        }
        public void CreateReportRN(List<object> reportRN)
        {
            List<object> columns = (List<object>)reportRN[0];
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].ToString() == "")
                {
                    columns.RemoveAt(i);
                    i--;
                }
            }
            columns.Add("(нет)");
        }
    }
}
