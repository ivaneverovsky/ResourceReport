using System.Windows;

namespace ResourceReport.UI
{
    public partial class NewFPSWindow : Window
    {
        public int id0 { get; set; }
        public int id1 { get; set; }
        public int id2 { get; set; }
        public int id3 { get; set; }
        public int id4 { get; set; }
        public bool Bull { get; set; }
        public NewFPSWindow()
        {
            InitializeComponent();
            Bull = false;
            combo1.SelectedIndex = 0;
            combo1_Copy.SelectedIndex = 1;
            combo1_Copy1.SelectedIndex = 2;
            combo1_Copy2.SelectedIndex = 3;
            combo1_Copy3.SelectedIndex = 4;
        }
        private void ChooseColumns(object sender, RoutedEventArgs e)
        {
            id0 = combo1.SelectedIndex;
            id1 = combo1_Copy.SelectedIndex;
            id2 = combo1_Copy1.SelectedIndex;
            id3 = combo1_Copy2.SelectedIndex;
            id4 = combo1_Copy3.SelectedIndex;

            if (id0 != -1)
                Bull = true;

            Close();
        }
    }
}
