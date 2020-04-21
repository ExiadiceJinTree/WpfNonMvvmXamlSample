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

            CustomerListView.ItemsSource = _customers;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _customers.Add(new Customer() { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            
            //CustomerListView.ItemsSource = null;
            //CustomerListView.ItemsSource = _customers;

        }
    }
}
