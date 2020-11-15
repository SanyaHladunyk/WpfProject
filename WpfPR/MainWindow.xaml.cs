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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfPR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class MyClass:INotifyPropertyChanged 
    {
        private string name;
        private string surname;
        private string age;
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public string Surname { get { return surname; } set { surname = value; OnPropertyChanged("Surname"); } }
        public string Age { get { return age; } set { age = value; OnPropertyChanged("Age"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
    
    public partial class MainWindow : Window
    {
        ObservableCollection<MyClass> MyCollections;
        public MainWindow()
        {
            InitializeComponent();
            MyCollections = new ObservableCollection<MyClass>
            {
                new MyClass{Name = "Dima", Surname = "Linkevych",Age = "18"},
                new MyClass{Name = "Sasha", Surname = "Hladunyk", Age = "18"}
            };
            Data.ItemsSource = MyCollections;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd add = new WindowAdd(MyCollections);
            add.Show();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MyClass obj = Data.SelectedItem as MyClass;
            WindowAdd edit = new WindowAdd(MyCollections, obj);
            edit.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MyCollections.Remove(Data.SelectedItem as MyClass);
        }

        private void Data_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (Data.SelectedItem != null)
            {
                Delete.IsEnabled = true;
                Edit.IsEnabled = true;
            }
            else
            {
                Delete.IsEnabled = false;
                Edit.IsEnabled = false;
            }
        }

    }
}
