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
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2_S00199895
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FullTimeEmployee fullTime1 = new FullTimeEmployee("Mr", "Burnham", 40000);
        FullTimeEmployee fullTime2 = new FullTimeEmployee("Hanzo", "Hasashi", 55000);

        PartTimeEmployee partTime1 = new PartTimeEmployee("Bigby", "Wolf", 12, 25);
        PartTimeEmployee partTime2 = new PartTimeEmployee("Jack", "Morrisson", 15, 30);
        public MainWindow()
        {
            InitializeComponent();
            LbxAddEmployees();        
        }

        public void LbxAddEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
            employees.Add(fullTime1);
            employees.Add(fullTime2);
            employees.Add(partTime1);
            employees.Add(partTime2);

            lbx.ItemsSource = employees;
        }
    }
}
