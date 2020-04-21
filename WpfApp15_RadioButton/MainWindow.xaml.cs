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

namespace WpfApp15_RadioButton
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ARadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BRadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CRadioButton_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == this.CRadioButton)
            {

            }
            else if (radioButton == this.DRadioButton)
            {

            }

            //radioButton.IsChecked;
            //CRadioButton.IsChecked;
        }
    }
}
