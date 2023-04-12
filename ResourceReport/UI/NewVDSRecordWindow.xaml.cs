using System.Windows;

namespace ResourceReport.UI
{
    /// <summary>
    /// Логика взаимодействия для NewVDSRecordWindow.xaml
    /// </summary>
    public partial class NewVDSRecordWindow : Window
    {
        public int id0 { get; set; }
        public int id1 { get; set; }
        public int id2 { get; set; }
        public int id3 { get; set; }
        public int id4 { get; set; }
        public int id5 { get; set; }
        public int id6 { get; set; }
        public int id7 { get; set; }
        public int id8 { get; set; }
        public bool Bull { get; set; }
        public NewVDSRecordWindow()
        {
            InitializeComponent();
            Bull = false;
            combo1.SelectedIndex = 0;
            combo1_Copy.SelectedIndex = 1;
            combo1_Copy1.SelectedIndex = 2;
            combo1_Copy2.SelectedIndex = 3;
            combo1_Copy3.SelectedIndex = 4;
            combo1_Copy4.SelectedIndex = 5;
            combo1_Copy5.SelectedIndex = 6;
            combo1_Copy6.SelectedIndex = 7;
            combo1_Copy7.SelectedIndex = 8;
        }
        private void ChooseColumns(object sender, RoutedEventArgs e)
        {
            id0 = combo1.SelectedIndex;
            id1 = combo1_Copy.SelectedIndex;
            id2 = combo1_Copy1.SelectedIndex;
            id3 = combo1_Copy2.SelectedIndex;
            id4 = combo1_Copy3.SelectedIndex;
            id5 = combo1_Copy4.SelectedIndex;
            id6 = combo1_Copy5.SelectedIndex;
            id7 = combo1_Copy6.SelectedIndex;
            id8 = combo1_Copy7.SelectedIndex;

            if (id0 != -1)
                Bull = true;

            Close();
        }
    }
}
