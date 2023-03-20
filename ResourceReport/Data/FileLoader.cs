using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows;

namespace ResourceReport.Data
{
    internal class FileLoader
    {
        Calculations _calc = new Calculations();
        public void LoadFile(OpenFileDialog ofd)
        {
            using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно загрузить файл. Измените формат файла на *xlsx: " + ex.Message, "Ошибка");
                    return;
                }
            }
        }
        public void Upload(OpenFileDialog ofd)
        {
            string[] files = ofd.FileNames;
            foreach (var item in files)
            {
                if (Path.GetExtension(item) == ".csv")
                {
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        try
                        {
                            using (var readerCSV = ExcelReaderFactory.CreateCsvReader(stream))
                            {
                                var result = readerCSV.AsDataSet();
                                var table = result.Tables[0];
                                List<object> murs = new List<object>();
                                for (int i = 0; i < table.Rows.Count; i++)
                                {
                                    List<object> rows = new List<object>();
                                    for (int j = 0; j < table.Columns.Count; j++)
                                        rows.Add(table.Rows[i][j]);
                                    murs.Add(rows);
                                }
                                _calc.CreateMURS(murs);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Невозможно загрузить файл. Измените формат файла на *xlsx: " + ex.Message, "Ошибка");
                            return;
                        }
                    }
                }
                else if (Path.GetExtension(item) == ".xlsx")
                {
                    MessageBox.Show(".xlsx");
                }
                else
                {
                    MessageBox.Show(Path.GetExtension(item));
                }
            }
            //using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            //{
            //    try
            //    {

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Невозможно загрузить файл: " + ex.Message, "Ошибка");
            //        return;
            //    }
            //}
        }
    }
}
