namespace CA2_S00199895
{
    class PartTimeEmployee : Employee   //Derives from the abstract class employee
    {
        //Properties
        public override string FirstName { get; set; }
        public override string LastName { get; set; }

        //Linked constructors (4,2,0)
        public PartTimeEmployee(string fName, string lName, decimal rate, double hours)
        {
            FirstName = fName;
            LastName = lName;
            HourlyRate = rate;
            HoursWorked = hours;
        }
        public PartTimeEmployee(string fName, string lName) : this(fName, lName, 0, 0) { }
        public PartTimeEmployee() : this("Unknown", "Unknown") { }

        //Methods
        public override decimal CalculateMonthlyPay()
        {
            return HourlyRate * (decimal)HoursWorked;
        }

        public override string ToString()
        {
            return $"{LastName.ToUpper()}, {FirstName} - Part Time";
        }

    }
}
