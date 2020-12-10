using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_S00199895
{
    public abstract class Employee
    {
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }

        public abstract decimal CalculateMonthlyPay();
    }
}
