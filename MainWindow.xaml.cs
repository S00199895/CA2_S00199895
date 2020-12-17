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

        private void lbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Employee selectedEmp = (Employee)lbx.SelectedItem;

                tbx_fName.Text = selectedEmp.FirstName;
                tbx_lName.Text = selectedEmp.LastName;

                if (selectedEmp is FullTimeEmployee)
                {
                    tbx_Salary.Text = selectedEmp.Salary.ToString();
                }
                else if (selectedEmp is PartTimeEmployee)
                {
                    tbx_rate.Text = selectedEmp.HourlyRate.ToString();
                    tbx_hoursWorked.Text = selectedEmp.HoursWorked.ToString();
                }

                tblk_monthlyPay.Text = selectedEmp.CalculateMonthlyPay().ToString();
            }
            catch (NullReferenceException)
            {

            }
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            tbx_fName.Clear();
            tbx_lName.Clear();
            tbx_Salary.Clear();
            tbx_hoursWorked.Clear();
            tbx_rate.Clear();

            radio_FT.IsChecked = false;
            radio_PT.IsChecked = false;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            Employee empToDelete = (Employee)lbx.SelectedItem;

            employees.Remove(empToDelete);
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Employee toAdd;

            if (radio_FT.IsChecked == true)
            {
                toAdd = new FullTimeEmployee();
                toAdd.FirstName = tbx_fName.Text;
                toAdd.LastName = tbx_lName.Text;
                toAdd.Salary = decimal.Parse(tbx_Salary.Text);
                employees.Add(toAdd);
            }
            else if (radio_PT.IsChecked == true)
            {
                toAdd = new PartTimeEmployee();
                toAdd.FirstName = tbx_fName.Text;
                toAdd.LastName = tbx_lName.Text;
                toAdd.HourlyRate = decimal.Parse(tbx_rate.Text);
                toAdd.HoursWorked = double.Parse(tbx_hoursWorked.Text);
                employees.Add(toAdd);
            }

        }
    }
}
