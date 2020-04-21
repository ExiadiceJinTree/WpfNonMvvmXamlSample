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

namespace WpfApp10_ListView
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        //private List<Customer> _customers = new List<Customer>();
        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();
        private int _index = 0;

        public MainWindow()
        {
            InitializeComponent();

            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });

            CustomerListView.ItemsSource = _customers;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });

            //CustomerListView.ItemsSource = null;
            //CustomerListView.ItemsSource = _customers;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*
            // [ダメな方法1]
            // LINQでフィルタ後のリストをListView.ItemsSourceに設定した後に、
            // ObservableCollectionのバインディングが切れて項目を追加してもListViewが更新されなくなってしまう。
            // 再度フィルタリングするとListViewが更新される。
            var qryFilteredCustomers = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = qryFilteredCustomers;
            */

            /*
            // [ダメな方法2]
            // このやり方でもだめ。フィルタされた新しいObservableCollectionオブジェクトを生成しListView.ItemsSourceに設定しても、
            // ListView項目追加イベントで項目追加するObservableCollectionが別物のためListViewが更新されない。再度フィルタリングするとListViewが更新される。
            var qryFilteredCustomers = _customers.Where(x => x.Name.Contains(SearchTextBox.Text));
            ObservableCollection<Customer> filteredCustomers = new ObservableCollection<Customer>(qryFilteredCustomers);
            CustomerListView.ItemsSource = filteredCustomers;
            */

            // [及第点な方法]
            if (string.IsNullOrEmpty(SearchTextBox.Text))
            {
                CustomerListView.ItemsSource = _customers;
                return;
            }
            var qryFilteredCustomers = _customers.Where(x => x.Name.Contains(SearchTextBox.Text));
            CustomerListView.ItemsSource = qryFilteredCustomers;
        }
    }
}
