using Microsoft.Win32;
using ResourceReport.Data;
using System.Collections.Generic;
using System.Windows;

namespace ResourceReport
{
    public partial class MainWindow : Window
    {
        FileLoader _fl = new FileLoader();

        List<object> fileRows = new List<object>(); //store data from file

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadFile(object sender, RoutedEventArgs e) //load file
        {
            fileRows.Clear(); //clear file dictionary first

            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx"
            };
            ofd.ShowDialog();

            if (ofd.FileName == "")
            {
                MessageBox.Show("Файл не выбран.", "Внимание");
                return;
            }

            fileRows = _fl.LoadFile(ofd);
        }
    }
}
