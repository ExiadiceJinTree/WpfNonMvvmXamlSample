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

namespace WpfApp19_ProgressBar
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.ATxtBlock.Text = this.AProgressBar.Value.ToString() + "%";
            this.BTxtBlock.Text = this.BProgressBar.Value.ToString() + "%";
        }

        private void AProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.ATxtBlock.Text = this.AProgressBar.Value.ToString() + "%";
        }

        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            // 非同期処理
            Task.Run(() => 
            {
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(500);

                    // UIスレッド上でプログレスバーの進捗を変更
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        this.AProgressBar.Value += 10;
                    });
                }
            });
        }

        private void BProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.BTxtBlock.Text = this.BProgressBar.Value.ToString() + "%";
        }

        private void BButton_Click(object sender, RoutedEventArgs e)
        {
            // 非同期処理
            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(500);

                    // UIスレッド上でプログレスバーの進捗を変更
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        this.BProgressBar.Value += 10;
                    });
                }
            });
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            this.CProgressBar.IsIndeterminate = true;
            this.CTxtBlock.Text = "Searchig...";
        }
    }
}
