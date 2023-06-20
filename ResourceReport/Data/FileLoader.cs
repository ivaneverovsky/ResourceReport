using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using ExcelDataReader;
using Microsoft.Win32;
using ResourceReport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ResourceReport.Data
{
    internal class FileLoader
    {
        Calculations _calc = new Calculations();
        public void LoadFile(OpenFileDialog ofd)
        {
            string[] files = ofd.FileNames;

            try
            {
                foreach (var item in files)
                {
                    using (var stream = File.Open(item, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet(); //get data from file
                            string contract = item.ToLower();
                            for (int i = 0; i < contract.Length; i++)
                                if (char.IsPunctuation(contract[i]))
                                    contract = contract.Replace(contract[i].ToString(), "");

                            if (contract.Contains("экспертек"))
                            {
                                contract = "Экспертек";
                                _calc.AddContract(contract);
                                MessageBox.Show("Загружаемый контракт: " + contract, "Внимание");
                            }
                            else if (contract.Contains("дитиавп"))
                            {
                                contract = "ДИТиАВП";
                                _calc.AddContract(contract);
                                MessageBox.Show("Загружаемый контракт: " + contract, "Внимание");
                            }
                            else if (contract.Contains("усиито"))
                            {
                                contract = "УСИиТО";
                                _calc.AddContract(contract);
                                MessageBox.Show("Загружаемый контракт: " + contract, "Внимание");
                            }
                            else if (contract.Contains("сибинтексофт") || contract.Contains("сибинтек софт"))
                            {
                                contract = "Сибинтек софт";
                                _calc.AddContract(contract);
                                MessageBox.Show("Загружаемый контракт: " + contract, "Внимание");
                            }
                            else
                            {
                                MessageBox.Show("Не удалось определить контракт.", "Ошибка");
                                return;
                            }

                            for (int i = 0; i < result.Tables.Count; i++)
                            {
                                var table = result.Tables[i];
                                string tablename = table.TableName.ToLower().Replace("ё", "е");

                                for (int j = 0; j < tablename.Length; j++)
                                    if (char.IsPunctuation(tablename[j]))
                                        tablename = tablename.Replace(tablename[j].ToString(), "");

                                switch (tablename)
                                {
                                    case "iaas":
                                        List<object> iaas = new List<object>();
                                        for (int j = 0; j < table.Rows.Count; j++)
                                        {
                                            List<object> rows = new List<object>();
                                            for (int k = 0; k < table.Columns.Count; k++)
                                                rows.Add(table.Rows[j][k]);
                                            iaas.Add(rows);
                                        }
                                        _calc.CreateIaaS(iaas, contract);
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно загрузить файл: " + ex.Message, "Ошибка");
                return;
            }
        }
        public void Upload(OpenFileDialog ofd)
        {
            string[] files = ofd.FileNames;

            foreach (var item in files)
            {
                if (Path.GetExtension(item) == ".csv")
                {
                    try
                    {
                        using (var stream = File.Open(item, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (var readerCSV = ExcelReaderFactory.CreateCsvReader(stream))
                            {
                                var result = readerCSV.AsDataSet();
                                var table = result.Tables[0];

                                List<object> data = new List<object>();

                                for (int i = 0; i < table.Rows.Count; i++)
                                {
                                    List<object> rows = new List<object>();
                                    for (int j = 0; j < table.Columns.Count; j++)
                                        rows.Add(table.Rows[i][j]);
                                    data.Add(rows);
                                }

                                if (item.ToLower().Contains("murs"))
                                    _calc.CreateMURS(data);
                                else if (item.ToLower().Contains("rds"))
                                    _calc.CreateRDS(data);
                                else if (item.ToLower().Contains("sib-cdc-tape-backups"))
                                    _calc.CreateSIBCDCTapeBackup(data);
                                else if (item.ToLower().Contains("cdc-tape-backups"))
                                    _calc.CreateCDCTapeBackup(data);
                                else if (item.ToLower().Contains("vmreport"))
                                    _calc.CreateReportIaaS(data);
                                else
                                    MessageBox.Show("Не удалось определить имя файла. \nФайл будет пропущен: " + item, "Внимание");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Невозможно загрузить файл: " + item + "\nОшибка: " + ex.Message, "Ошибка");
                        continue;
                    }
                }
                else if (Path.GetExtension(item) == ".xlsx")
                {
                    try
                    {
                        using (var stream = File.Open(item, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                var result = reader.AsDataSet();
                                if (item.ToLower().Contains("(volume)"))
                                {
                                    var table = result.Tables[1];
                                    List<object> data = new List<object>();

                                    for (int i = 0; i < table.Rows.Count; i++)
                                    {
                                        List<object> rows = new List<object>();
                                        for (int j = 0; j < table.Columns.Count; j++)
                                            rows.Add(table.Rows[i][j]);
                                        data.Add(rows);
                                    }
                                    _calc.CreateVolume(data);
                                }
                                else if (item.ToLower().Contains("(backup)"))
                                {
                                    var table = result.Tables[1];
                                    List<object> data = new List<object>();

                                    for (int i = 0; i < table.Rows.Count; i++)
                                    {
                                        List<object> rows = new List<object>();
                                        for (int j = 0; j < table.Columns.Count; j++)
                                            rows.Add(table.Rows[i][j]);
                                        data.Add(rows);
                                    }
                                    _calc.CreateBackup(data);
                                }
                                else if (item.ToLower().Contains("backups on repository"))
                                {
                                    var table = result.Tables[1];
                                    List<object> data = new List<object>();

                                    for (int i = 0; i < table.Rows.Count; i++)
                                    {
                                        List<object> rows = new List<object>();
                                        for (int j = 0; j < table.Columns.Count; j++)
                                            rows.Add(table.Rows[i][j]);
                                        data.Add(rows);
                                    }
                                    _calc.CreateBackupsOnRepo(data);
                                }
                                else if (item.ToLower().Contains("pricelist"))
                                {
                                    var table = result.Tables[0];
                                    List<object> data = new List<object>();

                                    for (int i = 0; i < table.Rows.Count; i++)
                                    {
                                        List<object> rows = new List<object>();
                                        for (int j = 0; j < table.Columns.Count; j++)
                                            rows.Add(table.Rows[i][j]);
                                        data.Add(rows);
                                    }
                                    _calc.CreatePriceList(data);
                                }
                                else if (item.ToLower().Contains("сцсас"))
                                {
                                    var table = result.Tables[0];
                                    List<object> data = new List<object>();

                                    for (int i = 0; i < table.Rows.Count; i++)
                                    {
                                        List<object> rows = new List<object>();
                                        for (int j = 0; j < table.Columns.Count; j++)
                                            rows.Add(table.Rows[i][j]);
                                        data.Add(rows);
                                    }
                                    _calc.CreateSiem(data);
                                }
                                else
                                    MessageBox.Show("Не удалось определить имя файла. \nФайл будет пропущен: " + item, "Внимание");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Невозможно загрузить файл: " + item + "\nОшибка: " + ex.Message, "Ошибка");
                        continue;
                    }
                }
                else if (Path.GetExtension(item) == ".docx")
                {
                    try
                    {
                        using (WordprocessingDocument wpd = WordprocessingDocument.Open(item, false))
                        {
                            if (item.ToLower().Contains("отчет об объемах оказания услуг диб"))
                            {
                                Body body = wpd.MainDocumentPart.Document.Body;
                                var result = body.InnerText.ToString();


                            }
                            else
                                throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Невозможно загрузить файл: " + item + "\nОшибка: " + ex.Message, "Ошибка");
                        continue;
                    }
                }
                else
                {
                    try
                    {
                        throw new Exception();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Невозможно загрузить файл: " + item + "\nОшибка: " + ex.Message + "\nФайл не поддерживается.", "Ошибка");
                        continue;
                    }
                }
            }
            MessageBox.Show("Загрузка завершена.", "Готово");
        }

        public List<LogClass> Logs() { return _calc.CollectLogs(); }
        public List<Report> CollectReports() { return _calc.CollectReports(); }
        public List<Contract> CollectContracts() { return _calc.CollectContracts(); }

        public void ClearUploads() { _calc.ClearUploads(); }
        public void ClearLogs() { _calc.ClearLogs(); }
        public void Work()
        {
            _calc.MursCount();
            _calc.VDSCount();
            _calc.BackupVDSCount();
            _calc.BackupEMLCount();
            _calc.FPSCount();
            _calc.IaaSCount();

            _calc.UtilEMLCount();
            _calc.UtilEMLRecordCount();
            _calc.UtilVDSCount();
            _calc.UtilVDSRecordCount();

            _calc.IaaSMoneyCounter();
            _calc.EMLMoneyCounter();
            _calc.VDSMoneyCounter();

            _calc.CreateReport();

            MessageBox.Show("Все вычисления выполнены.", "Готово");
        }
    }
}
