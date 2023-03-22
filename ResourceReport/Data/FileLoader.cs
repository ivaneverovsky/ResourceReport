using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace ResourceReport.Data
{
    internal class FileLoader
    {
        Calculations _calc = new Calculations();
        public void LoadFile(OpenFileDialog ofd)
        {
            try
            {
                using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(); //get data from file

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
                                    _calc.CreateIaaS(iaas);
                                    break;
                                case "eml":
                                    List<object> eml = new List<object>();
                                    for (int j = 0; j < table.Rows.Count; j++)
                                    {
                                        List<object> rows = new List<object>();
                                        for (int k = 0; k < table.Columns.Count; k++)
                                            rows.Add(table.Rows[j][k]);
                                        eml.Add(rows);
                                    }
                                    _calc.CreateEML(eml);
                                    break;
                                case "eml архив":
                                    List<object> eml_rec = new List<object>();
                                    for (int j = 0; j < table.Rows.Count; j++)
                                    {
                                        List<object> rows = new List<object>();
                                        for (int k = 0; k < table.Columns.Count; k++)
                                            rows.Add(table.Rows[j][k]);
                                        eml_rec.Add(rows);
                                    }
                                    _calc.CreateEMLRec(eml_rec);
                                    break;
                                case "vds":
                                    List<object> vds = new List<object>();
                                    for (int j = 0; j < table.Rows.Count; j++)
                                    {
                                        List<object> rows = new List<object>();
                                        for (int k = 0; k < table.Columns.Count; k++)
                                            rows.Add(table.Rows[j][k]);
                                        vds.Add(rows);
                                    }
                                    _calc.CreateVDS(vds);
                                    break;
                                case "vds архив":
                                    List<object> vds_rec = new List<object>();
                                    for (int j = 0; j < table.Rows.Count; j++)
                                    {
                                        List<object> rows = new List<object>();
                                        for (int k = 0; k < table.Columns.Count; k++)
                                            rows.Add(table.Rows[j][k]);
                                        vds_rec.Add(rows);
                                    }
                                    _calc.CreateVDSRec(vds_rec);
                                    break;
                                case "fps":
                                    List<object> fps = new List<object>();
                                    for (int j = 0; j < table.Rows.Count; j++)
                                    {
                                        List<object> rows = new List<object>();
                                        for (int k = 0; k < table.Columns.Count; k++)
                                            rows.Add(table.Rows[j][k]);
                                        fps.Add(rows);
                                    }
                                    _calc.CreateFPS(fps);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                MessageBox.Show("Отчет загружен.", "Готово");
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

                                else if (item.ToLower().Contains("cdc-tape-backups"))
                                    MessageBox.Show("cdc-tape-backups");
                                else if (item.ToLower().Contains("sib-cdc-tape-backups"))
                                    MessageBox.Show("sib-cdc-tape-backups");
                                else if (item.ToLower().Contains("vm_summary_sib_iaas"))
                                    MessageBox.Show("vm_summary_sib_iaas");
                                else if (item.ToLower().Contains("all sibintek"))
                                    MessageBox.Show("all sibintek");

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
    }
}
