using SQLite;
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
using WpfApp12_SQLiteAndListView.Objects;

namespace WpfApp12_SQLiteAndListView
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

            this.CustomerListView.ItemsSource = _customers;
            this.RefleshCustomerListView();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            SaveWindow saveWindow = new SaveWindow(SaveWindow.SaveType.Add);
            saveWindow.ShowDialog();
            this.RefleshCustomerListView();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.CustomerListView.SelectedItem == null)
            {
                MessageBox.Show("行を選択してください。", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SaveWindow saveWindow = new SaveWindow(SaveWindow.SaveType.Update, (Customer)this.CustomerListView.SelectedItem);
            saveWindow.ShowDialog();
            this.RefleshCustomerListView();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.CustomerListView.SelectedItem == null)
            {
                MessageBox.Show("行を選択してください。", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Customer deletingCustomer = (Customer)this.CustomerListView.SelectedItem;

            using (var conn = new SQLiteConnection(App.DbFilePath))
            {
                var existingDeletingCustomers = conn.Table<Customer>().Where(x => x.Name == deletingCustomer.Name);
                if (existingDeletingCustomers.Any())
                {
                    Customer existingDeletingCustomer = existingDeletingCustomers.First();
                    conn.Delete(existingDeletingCustomer);
                }
            }

            this.RefleshCustomerListView();
        }

        private void RefleshCustomerListView()
        {
            List<Customer> customers = null;

            using (var conn = new SQLiteConnection(App.DbFilePath))
            {
                conn.CreateTable<Customer>();
                customers = conn.Table<Customer>().OrderBy(x => x.Name).ToList();
            }

            _customers.Clear();
            foreach (var customer in customers)
            {
                _customers.Add(customer);
            }
        }
    }
}
