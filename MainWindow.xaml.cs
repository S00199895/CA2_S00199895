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

        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            LbxAddEmployees();
        }

        public void LbxAddEmployees()
        {
            employees.Add(fullTime1);
            employees.Add(fullTime2);
            employees.Add(partTime1);
            employees.Add(partTime2);

            employees = new ObservableCollection<Employee>(employees.OrderBy(x => x.LastName));

            lbx.ItemsSource = employees;
        }

        private void checkFT_Checked(object sender, RoutedEventArgs e)
        {
            lbx.ItemsSource = null;

            ObservableCollection<Employee> filteredEmployees = new ObservableCollection<Employee>();

            foreach (Employee emp in employees)
            {
                if (emp is FullTimeEmployee)
                {
                    filteredEmployees.Add(emp);
                }
            }

            lbx.ItemsSource = filteredEmployees;
        }

        private void checkPT_Checked(object sender, RoutedEventArgs e)
        {
            lbx.ItemsSource = null;

            ObservableCollection<Employee> filteredEmployees = new ObservableCollection<Employee>();

            foreach (Employee emp in employees)
            {
                if (emp is PartTimeEmployee)
                {
                    filteredEmployees.Add(emp);
                }
            }

            lbx.ItemsSource = filteredEmployees;
        }
    }
}
