using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_S00199895
{
    class PartTimeEmployee : Employee
    {
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public override decimal CalculateMonthlyPay()
        {
            return HourlyRate * (decimal)HoursWorked;
        }
    }
}
