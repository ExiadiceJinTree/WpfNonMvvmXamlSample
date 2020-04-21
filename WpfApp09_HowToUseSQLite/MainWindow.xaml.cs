﻿using SQLite;
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
using WpfApp9.Objects;

namespace WpfApp9
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer()
            {
                Name = this.NameTextBox.Text,
                Phone = this.PhoneTextBox.Text,
            };

            using (var conn = new SQLiteConnection(App.DbPath))
            {
                conn.CreateTable<Customer>();

                conn.Insert(customer);
            }
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            using (var conn = new SQLiteConnection(App.DbPath))
            {
                conn.CreateTable<Customer>();

                var customers = conn.Table<Customer>().ToList();
            }
        }
    }
}
