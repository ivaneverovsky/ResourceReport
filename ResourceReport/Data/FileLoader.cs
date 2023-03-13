using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace ResourceReport.Data
{
    internal class FileLoader
    {
        public List<object> LoadFile(OpenFileDialog ofd)
        {
            List<object> fileData = new List<object>();

            //using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            //{
            //    using (var reader = ExcelReaderFactory.CreateReader(stream))
            //    {
            //        var result = reader.AsDataSet(); //get data from file

            //        //fileData.Add(result);

            //        for (int i = 0; i < result.Tables[0].Rows.Count; i++)
            //        {
            //            fileData.Add(result.Tables[0].Rows[i]);
            //        }
            //    }
            //}

            using (StreamReader sr = new StreamReader(ofd.FileName, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    fileData.Add(line);
            }

            //MessageBox.Show("Данные загружены.", "Готово");

            return fileData;
        }
    }
}
