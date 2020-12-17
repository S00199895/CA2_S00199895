using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_S00199895
{
    /*
     *Abstract class
     *Cannot be instantiated itself, it can only have
     *other classes inherit from it
     *Methods can only be declared here, not implemented
     */
    public abstract class Employee
    {
        //Properties
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        
        //Put the pay properties here because of a 
        //problem with Adding or Updating Employees
        public decimal Salary { get; set; }
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }
        
        //Gets the monthly pay for an employee
        public abstract decimal CalculateMonthlyPay();
        
        //Tidies the output for an object ToString()
        public abstract override string ToString();
    }
}
