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

namespace WpfApp21_ListBox
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

            _dtos.Add(new Dto("Images/flower-5038110_640.jpg", "flower-5038110"));
            _dtos.Add(new Dto("Images/girl-fun-5046269_640.jpg", "girl-fun-5046269"));
            _dtos.Add(new Dto("Images/sketch-4917782_640.png", "sketch-4917782"));

            this.MyListBox.ItemsSource = _dtos;
            this.SingleModeRadioBtn.IsChecked = true;
        }

        private void SelectionModeRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (this.SingleModeRadioBtn.IsChecked.Value)
            {
                this.MyListBox.SelectionMode = SelectionMode.Single;
            }
            else if (this.ExtendedModeRadioBtn.IsChecked.Value)
            { 
                this.MyListBox.SelectionMode = SelectionMode.Extended;
            }
            else if (this.MultipleModeRadioBtn.IsChecked.Value)
            {
                this.MyListBox.SelectionMode = SelectionMode.Multiple;
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            // ブレイクポイントでMyListBox.SelectedItem, MyListBox.SelectedItemsの確認
        }
    }

    public sealed class Dto
    {
        public Dto(string fileName, string name)
        {
            this.FileName = fileName;
            this.Name = name;
        }

        public string FileName { get; set; }
        public string Name { get; set; }
    }
}
