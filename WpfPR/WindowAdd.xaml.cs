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
using System.Windows.Shapes;

namespace WpfPR
{
    /// <summary>
    /// Логика взаимодействия для WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        ObservableCollection<MyClass> MyCollections;
        MyClass Obj;
        public WindowAdd(ObservableCollection<MyClass> myCollections = null, MyClass obj = null)
        {
            InitializeComponent();
            if(obj != null)
            {
                Name.Text = obj.Name;
                Surname.Text = obj.Surname;
                Age.Text = obj.Age;
                Obj = obj;
            }
            MyCollections = myCollections;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Obj == null)
            {
                MyClass m = new MyClass { Name = Name.Text, Surname = Surname.Text, Age = Age.Text };
                MyCollections.Add(m);
            }
            else
            {
                var item = MyCollections.FirstOrDefault(x => x.Name == Obj.Name && x.Surname == Obj.Surname && x.Age == Obj.Age);
                int i = MyCollections.IndexOf(item);
                MyCollections[i] = new MyClass { Name = Name.Text, Surname = Surname.Text, Age = Age.Text };

            }
            Close();
        }
    }
}
