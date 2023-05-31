using Microsoft.Win32;
using ResourceReport.Data;
using ResourceReport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace ResourceReport
{
    public partial class MainWindow : Window
    {
        FileLoader _fl = new FileLoader();
        public MainWindow() { InitializeComponent(); }
        private void Upload(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "All files (*.*)|*.*",
                Multiselect = true,
            };
            ofd.ShowDialog();

            if (ofd.FileName == "")
            {
                MessageBox.Show("Файлы не выбраны.", "Внимание");
                return;
            }

            _fl.Upload(ofd);
        }
        private void Count(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string> { "Экспертек", "ДИТиАВП", "УСИиТО", "Сибинтек-софт" };

            for (int i = 0; i < list.Count; i++)
                _fl.AddContract(list[i]);

            _fl.ClearLogs();
            _fl.Work();

            logListView.Items.Clear();

            List<LogClass> logs = _fl.Logs();
            foreach (LogClass log in logs)
                logListView.Items.Add(log.Message);
        }
        private void DeleteUploads(object sender, RoutedEventArgs e) { _fl.ClearUploads(); }
        private void Export(object sender, RoutedEventArgs e)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter sw = new StreamWriter(filePath + @"\ResourceReport.csv", false, Encoding.Default);
            try
            {
                foreach (var contract in _fl.CollectContracts())
                {
                    sw.WriteLine(contract.ContractName);
                    sw.WriteLine("Услуга;Описание услуги;Единица измерения;Количество;Время предоставления услуги в часах за отчетный период;Время простоя услуги в часах за отчетный период;Доступность услуги, %;Стоимость за единицу в месяц, без НДС;Сумма в месяц, без НДС;НДС;Итого, с НДС");
                    foreach (var report in _fl.CollectReports())
                        if (contract.ContractName == report.ContractName)
                        {
                            if (report.Quantity == "0")
                                continue;
                            sw.WriteLine(report.Service + ";" + report.Description + ";" + report.Unit + ";" + Convert.ToDouble(report.Quantity) + ";" + report.ServiceDeliveryTime + ";" + report.ServiceDownTime + ";" + report.ServiceAvailability + ";" + Math.Round(Convert.ToDouble(report.PricePerUnit), 2) + ";" + Math.Round(Convert.ToDouble(report.PriceSum), 2) + ";" + Math.Round(Convert.ToDouble(report.VAT), 2) + ";" + Math.Round(Convert.ToDouble(report.VATSum), 2));
                        }
                    sw.WriteLine();
                }
                MessageBox.Show("Файл успешно сохранен на рабочий стол.", "Готово");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка во время экспорта данных.\n" + ex.Message, "Ошибка");
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
