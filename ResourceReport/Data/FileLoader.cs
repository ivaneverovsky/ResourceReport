using ExcelDataReader;
using Microsoft.Win32;
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
                                //case "iaas":
                                //    List<object> iaas = new List<object>();
                                //    for (int j = 0; j < table.Rows.Count; j++)
                                //    {
                                //        List<object> rows = new List<object>();
                                //        for (int k = 0; k < table.Columns.Count; k++)
                                //            rows.Add(table.Rows[j][k]);
                                //        iaas.Add(rows);
                                //    }
                                //    _calc.CreateIaaS(iaas);
                                //    break;
                                //case "eml":
                                //    List<object> eml = new List<object>();
                                //    for (int j = 0; j < table.Rows.Count; j++)
                                //    {
                                //        List<object> rows = new List<object>();
                                //        for (int k = 0; k < table.Columns.Count; k++)
                                //            rows.Add(table.Rows[j][k]);
                                //        eml.Add(rows);
                                //    }
                                //    _calc.CreateEML(eml);
                                //    break;
                                //case "eml архив":
                                //    List<object> eml_rec = new List<object>();
                                //    for (int j = 0; j < table.Rows.Count; j++)
                                //    {
                                //        List<object> rows = new List<object>();
                                //        for (int k = 0; k < table.Columns.Count; k++)
                                //            rows.Add(table.Rows[j][k]);
                                //        eml_rec.Add(rows);
                                //    }
                                //    _calc.CreateEMLRec(eml_rec);
                                //    break;
                                //case "vds":
                                //    List<object> vds = new List<object>();
                                //    for (int j = 0; j < table.Rows.Count; j++)
                                //    {
                                //        List<object> rows = new List<object>();
                                //        for (int k = 0; k < table.Columns.Count; k++)
                                //            rows.Add(table.Rows[j][k]);
                                //        vds.Add(rows);
                                //    }
                                //    _calc.CreateVDS(vds);
                                //    break;
                                //case "vds архив":
                                //    List<object> vds_rec = new List<object>();
                                //    for (int j = 0; j < table.Rows.Count; j++)
                                //    {
                                //        List<object> rows = new List<object>();
                                //        for (int k = 0; k < table.Columns.Count; k++)
                                //            rows.Add(table.Rows[j][k]);
                                //        vds_rec.Add(rows);
                                //    }
                                //    _calc.CreateVDSRec(vds_rec);
                                //    break;
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
                                case "работы по тксс":
                                    List<object> tkss = new List<object>();
                                    for (int j = 0; j < table.Rows.Count; j++)
                                    {
                                        List<object> rows = new List<object>();
                                        for (int k = 0; k < table.Columns.Count; k++)
                                            rows.Add(table.Rows[j][k]);
                                        tkss.Add(rows);
                                    }
                                    _calc.CreateTKSS(tkss);
                                    break;
                                case "отчет":
                                    List<object> report = new List<object>();
                                    for (int j = 0; j < table.Rows.Count; j++)
                                    {
                                        List<object> rows = new List<object>();
                                        for (int k = 0; k < table.Columns.Count; k++)
                                            rows.Add(table.Rows[j][k]);
                                        report.Add(rows);
                                    }
                                    _calc.CreateReport(report);
                                    break;
                                case "для рну":
                                    List<object> reportRN = new List<object>();
                                    for (int j = 0; j < table.Rows.Count; j++)
                                    {
                                        List<object> rows = new List<object>();
                                        for (int k = 0; k < table.Columns.Count; k++)
                                            rows.Add(table.Rows[j][k]);
                                        reportRN.Add(rows);
                                    }
                                    _calc.CreateReportRN(reportRN);
                                    break;
                                case "рн учет":
                                    List<object> reportRN1 = new List<object>();
                                    for (int j = 0; j < table.Rows.Count; j++)
                                    {
                                        List<object> rows = new List<object>();
                                        for (int k = 0; k < table.Columns.Count; k++)
                                            rows.Add(table.Rows[j][k]);
                                        reportRN1.Add(rows);
                                    }
                                    _calc.CreateReportRN(reportRN1);
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
    }
}
