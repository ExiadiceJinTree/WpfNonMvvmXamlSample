using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp20_ComboBox
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();

        public MainWindow()
        {
            InitializeComponent();

            // [単純な方法(非推奨)]
            this.MyCmbBox.Items.Add("111");
            this.MyCmbBox.Items.Add("222");
            this.MyCmbBox.Items.Add("333");

            _customers.Add(new Customer() { Id = 1, Name = "name 1", Phone = "Phone1" });
            _customers.Add(new Customer() { Id = 2, Name = "name 2", Phone = "Phone2" });
            _customers.Add(new Customer() { Id = 3, Name = "name 3", Phone = "Phone3" });

            // [データソース指定 & SelectedValuePath,DisplayMemberPath指定方法] * XAML側でSelectedValuePathとDisplayMemberPathを設定
            ACmbBox.ItemsSource = _customers;

            // [データソース指定 & データバインディング方法] * XAML側でComboBox.ItemTemplaでBinding設定
            BCmbBox.ItemsSource = _customers;
        }

        private void MyBtn_Click(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("MyCmbBox.SelectedIndex:" + this.MyCmbBox.SelectedIndex);
            sb.AppendLine("MyCmbBox.SelectedValue:" + this.MyCmbBox.SelectedValue);
            sb.AppendLine("MyCmbBox.Text:" + this.MyCmbBox.Text);

            MessageBox.Show(sb.ToString());
        }

        private void ABtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = this.ACmbBox.SelectedItem as Customer;
            if (selectedCustomer != null)
            {
                var sb = new StringBuilder();
                sb.AppendLine("MyCmbBox.SelectedIndex:" + this.ACmbBox.SelectedIndex);
                // ACmbBox.SelectedValue値はSelectedValuePath設定の値に、ACmbBox.TextはDisplayMemberPath設定の値になる。
                sb.AppendLine("MyCmbBox.SelectedValue:" + this.ACmbBox.SelectedValue);
                sb.AppendLine("MyCmbBox.Text:" + this.ACmbBox.Text);
                sb.AppendLine("-------------------------");
                sb.AppendLine("selectedCustomer.Id:" + selectedCustomer.Id);
                sb.AppendLine("selectedCustomer.Name:" + selectedCustomer.Name);
                sb.AppendLine("selectedCustomer.Phone:" + selectedCustomer.Phone);

                MessageBox.Show(sb.ToString());
            }
        }

        private void BBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = this.BCmbBox.SelectedItem as Customer;
            if (selectedCustomer != null)
            {
                var sb = new StringBuilder();
                sb.AppendLine("MyCmbBox.SelectedIndex:" + this.BCmbBox.SelectedIndex);
                // SelectedValuePathとDisplayMemberPathを設定していないので、
                // BCmbBox.SelectedValue値とBCmbBox.Text値はCustomerクラスオブジェクトをToString()した"～.Customer"という文字列になり利用価値なし。
                sb.AppendLine("MyCmbBox.SelectedValue:" + this.BCmbBox.SelectedValue);
                sb.AppendLine("MyCmbBox.Text:" + this.BCmbBox.Text);
                sb.AppendLine("-------------------------");
                // この方法だとSelectedValueは使わずSelectedItemを利用する。
                sb.AppendLine("selectedCustomer.Id:" + selectedCustomer.Id);
                sb.AppendLine("selectedCustomer.Name:" + selectedCustomer.Name);
                sb.AppendLine("selectedCustomer.Phone:" + selectedCustomer.Phone);

                MessageBox.Show(sb.ToString());
            }
        }
    }
}
