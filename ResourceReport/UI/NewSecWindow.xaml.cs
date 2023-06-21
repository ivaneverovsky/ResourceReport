using System;
using System.Windows;

namespace ResourceReport.UI
{
    public partial class NewSecWindow : Window
    {
        public string dit_ext { get; set; }
        public string dit_int { get; set; }
        public string usi_int { get; set; }
        public string sib_int { get; set; }
        public NewSecWindow()
        {
            InitializeComponent();
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            dit_ext = DIT_EXT.Text;
            dit_int = DIT_INT.Text;
            usi_int = USI_INT.Text;
            sib_int = SIB_INT.Text;

            try
            {
                Convert.ToDouble(DIT_EXT.Text);
                Convert.ToDouble(DIT_INT.Text);
                Convert.ToDouble(USI_INT.Text);
                Convert.ToDouble(SIB_INT.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nВведите целые числа.", "Ошибка");

                DIT_EXT.Clear();
                DIT_INT.Clear();
                USI_INT.Clear();
                SIB_INT.Clear();

                return;
            }

            Close();
        }
    }
}
