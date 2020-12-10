using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_S00199895
{
    class FullTimeEmployee : Employee
    {
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public decimal Salary { get; set; }

        public FullTimeEmployee(string fName, string lName, decimal sal)
        {
            FirstName = fName;
            LastName = lName;
            Salary = sal;
        }
        public FullTimeEmployee(string fName, string lName) : this(fName, lName, 0) { }
        public FullTimeEmployee() : this("Unknown", "Unknown") { }
        public override decimal CalculateMonthlyPay()
        {
            return Salary / 12;
        }
    }
}