﻿using Microsoft.Win32;
using ResourceReport.Data;
using ResourceReport.Models;
using ResourceReport.UI;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace ResourceReport
{
    public partial class MainWindow : Window
    {
        FileLoader _fl = new FileLoader();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel files|*.xlsx;*.xlsb;*.xls|All files (*.*)|*.*"
            };
            ofd.ShowDialog();

            if (ofd.FileName == "")
            {
                MessageBox.Show("Файл не выбран.", "Внимание");
                return;
            }

            _fl.LoadFile(ofd);
        }
        private void Upload(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "All files (*.*)|*.*",
                Multiselect= true,
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
            if (_fl.Check() == 0)
            {
                MessageBox.Show("Данных для отчета не обнаружено. Попробуйте загрузить новые.", "Внимание");
                return;
            }

            BuildUI();
        }
        private void Export(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Здесь будет выгружаться файл");
        }


        private void BuildUI()
        {
            List<IaaS> iaasList = _fl.CollectIaaS();
            for (int i = 0; i < iaasList.Count; i++)
            {
                IaaSListView.Items.Add(iaasList[i]);
            }
        }
    }
}
