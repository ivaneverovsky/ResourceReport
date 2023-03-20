﻿using Microsoft.Win32;
using ResourceReport.Data;
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

            MessageBox.Show("ya vse"); //show UI
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

            MessageBox.Show("zagruzil");
        }
    }
}
