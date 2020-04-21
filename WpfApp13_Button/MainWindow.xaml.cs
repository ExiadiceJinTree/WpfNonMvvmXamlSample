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

namespace WpfApp13_Button
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

        private void NormalButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Normal Button Clicked!!");
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "RepeatButton");
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("toggle button clicked:" + this.ToggleButton.IsChecked);
        }
    }
}
