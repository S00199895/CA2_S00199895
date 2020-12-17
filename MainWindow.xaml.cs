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
        //Making employees
        FullTimeEmployee fullTime1 = new FullTimeEmployee("Mr", "Burnham", 40000);
        FullTimeEmployee fullTime2 = new FullTimeEmployee("Hanzo", "Hasashi", 55000);

        PartTimeEmployee partTime1 = new PartTimeEmployee("Bigby", "Wolf", 12, 25);
        PartTimeEmployee partTime2 = new PartTimeEmployee("Jack", "Morrisson", 15, 30);

        //Make an observable collection of employees (Auto-Updates itself in the listbox)
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        //Add Employees to the listbox (called in Window_Loaded)
        public void LbxAddEmployees()
        {
            employees.Add(fullTime1);
            employees.Add(fullTime2);
            employees.Add(partTime1);
            employees.Add(partTime2);

            //Order the employees by LastName
            employees = new ObservableCollection<Employee>(employees.OrderBy(x => x.LastName));

            //Sets the source for the listbox
            lbx.ItemsSource = employees;
        }//End of LbxAddEmployees()

        //Event listener for FT is checked
        private void checkFT_Checked(object sender, RoutedEventArgs e)
        {
            //Set the source to null for now
            lbx.ItemsSource = null;

            //Make a new ObservableCollection for filtering
            ObservableCollection<Employee> filteredEmployees = new ObservableCollection<Employee>();

            foreach (Employee emp in employees)
            {
                //Only show FullTimeEmployees
                if (emp is FullTimeEmployee)
                {
                    filteredEmployees.Add(emp);
                }
            }

            //reset the source to the filtered employees
            lbx.ItemsSource = filteredEmployees;
        }

        //Event listener for PT is checked
        private void checkPT_Checked(object sender, RoutedEventArgs e)
        {
            lbx.ItemsSource = null;

            ObservableCollection<Employee> filteredEmployees = new ObservableCollection<Employee>();

            foreach (Employee emp in employees)
            {
                //Only show ParttimeEmployees
                if (emp is PartTimeEmployee)
                {
                    filteredEmployees.Add(emp);
                }
            }

            lbx.ItemsSource = filteredEmployees;
        }

        //Event listener for Listbox selection changed
        private void lbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Clear the textboxes
            btn_clear_Click(sender, e);
            
            /*Try catch*/
            try
            {
                //Get the selected employee
                Employee selectedEmp = (Employee)lbx.SelectedItem;

                //Show this employee's details in the corresponding textboxes
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
                //Catch NullReferenceException
            }
        }

        //Event listener for Clear button clicked
        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            //Clears/resets all of the textboxes
            tbx_fName.Clear();
            tbx_lName.Clear();
            tbx_Salary.Clear();
            tbx_hoursWorked.Clear();
            tbx_rate.Clear();
            tblk_monthlyPay.Text = "Monthly Pay : ";
            //Unchecks radio buttons
            radio_FT.IsChecked = false;
            radio_PT.IsChecked = false;
        }

        //Event listener for Delete button clicked
        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            //Select the employee
            Employee empToDelete = (Employee)lbx.SelectedItem;
            
            //Remove them from the collection
            employees.Remove(empToDelete);
        }

        //Event listener for the Add button being clicked
        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            //Select the employee
            Employee toAdd;

            /*
             *Wrapped in try catch in case the user tries to
             *enter a Salary for a PartTime Customer, vice versa
             */
            try
            {
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
            catch (FormatException fE)
            {
                MessageBox.Show(fE.Message);
            }
            employees = new ObservableCollection<Employee>(employees.OrderBy(x => x.LastName));

        }

        //Event listener for the Update button being clicked
        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            //Select the employee
            Employee toUpdate = (Employee)lbx.SelectedItem;

            //Update their details
            toUpdate.FirstName = tbx_fName.Text;
            toUpdate.LastName = tbx_lName.Text;

            if (radio_FT.IsChecked == true)
            {
                toUpdate.Salary = decimal.Parse(tbx_Salary.Text);
                //Tried to set up casts to make
                //a FullTimeEmployee a PartTimeEmployee here
                //But couldn't figure it out
            }
            else if (radio_PT.IsChecked == true)
            {
                toUpdate.HoursWorked = double.Parse(tbx_hoursWorked.Text);
                toUpdate.HourlyRate = decimal.Parse(tbx_rate.Text);
            }
            //Remove the employee
            employees.Remove((Employee)lbx.SelectedItem);
            //Re-add the employee updated
            employees.Add(toUpdate);
            //Re-order the employees
            employees = new ObservableCollection<Employee>(employees.OrderBy(x => x.LastName));
        }

        //Event listener for PT check box unchecked
        private void checkPT_Unchecked(object sender, RoutedEventArgs e)
        {
            //Re-shows all the employees
            lbx.ItemsSource = employees;
        }

        //Event listener for FT checkbox unchecked
        private void checkFT_Unchecked(object sender, RoutedEventArgs e)
        {
            //Re-shows all the employees
            lbx.ItemsSource = employees;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            LbxAddEmployees();
        }
    }
}