using Microsoft.Win32;
using ResourceReport.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ResourceReport
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
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
                Filter = "Excel files (*.csv)|*.csv"
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
