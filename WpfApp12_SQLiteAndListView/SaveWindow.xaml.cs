using SQLite;
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
using System.Windows.Shapes;
using WpfApp12_SQLiteAndListView.Objects;

namespace WpfApp12_SQLiteAndListView
{
    /// <summary>
    /// SaveWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SaveWindow : Window
    {
        public enum SaveType
        {
            Add,
            Update,
        }

        private SaveType _saveType;
        private Customer _selectedCustomer;

        public SaveWindow(SaveType saveType, Customer selectedCustomer = null)
        {
            InitializeComponent();

            _saveType = saveType;
            _selectedCustomer = selectedCustomer;

            if (saveType == SaveType.Update)
            {
                if (selectedCustomer != null)
                {
                    this.CustomerNameTextBox.Text = selectedCustomer.Name;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.CustomerNameTextBox.Text))
            {
                MessageBox.Show("名前を入力してください。", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var conn = new SQLiteConnection(App.DbFilePath))
            {
                switch (_saveType)
                {
                    case SaveType.Add:
                        var existingInsertingCustomers = conn.Table<Customer>().Where(x => x.Name == this.CustomerNameTextBox.Text);
                        if (!existingInsertingCustomers.Any())
                        {
                            Customer newCustomer = new Customer(this.CustomerNameTextBox.Text);
                            conn.Insert(newCustomer);
                        }
                        break;
                    case SaveType.Update:
                        var existingUpdatingCustomers = conn.Table<Customer>().Where(x => x.Name == _selectedCustomer.Name);
                        if (existingUpdatingCustomers.Any())
                        {
                            Customer existingUpdatingCustomer = existingUpdatingCustomers.First();
                            existingUpdatingCustomer.Name = this.CustomerNameTextBox.Text;
                            conn.Update(existingUpdatingCustomer);
                        }
                        break;
                    default:
                        break;
                }
            }

            this.Close();
        }
    }
}
