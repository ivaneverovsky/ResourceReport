﻿using System.Windows;

namespace ResourceReport.UI
{
    public partial class NewEMLRecordWindow : Window
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
        public int id9 { get; set; }
        public int id10 { get; set; }
        public int id11 { get; set; }
        public int id12 { get; set; }
        public int id13 { get; set; }
        public bool Bull { get; set; }
        public NewEMLRecordWindow()
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
            combo1_Copy8.SelectedIndex = 9;
            combo1_Copy9.SelectedIndex = 10;
            combo1_Copy10.SelectedIndex = 11;
            combo1_Copy11.SelectedIndex = 12;
            combo1_Copy12.SelectedIndex = 13;
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
            id9 = combo1_Copy8.SelectedIndex;
            id10 = combo1_Copy9.SelectedIndex;
            id11 = combo1_Copy10.SelectedIndex;
            id12 = combo1_Copy11.SelectedIndex;
            id13 = combo1_Copy12.SelectedIndex;

            if (id0 != -1)
                Bull = true;

            Close();
        }
    }
}
