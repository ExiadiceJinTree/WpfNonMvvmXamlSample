﻿using System;
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

namespace WpfApp23_TreeView
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Dto> _dtos = new ObservableCollection<Dto>();

        public MainWindow()
        {
            InitializeComponent();

            var dto1 = new Dto("Name1");
            dto1.Dtos.Add(new Dto("Name1-1"));
            dto1.Dtos.Add(new Dto("Name1-2"));
            _dtos.Add(dto1);

            this.CTreeView.ItemsSource = _dtos;
        }
    }

    public sealed class Dto
    {
        public string Name { get; set; }
        public List<Dto> Dtos { get; set; } = new List<Dto>();

        public Dto(string name)
        {
            this.Name = name;
        }
    }
}
