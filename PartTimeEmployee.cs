namespace CA2_S00199895
{
    class PartTimeEmployee : Employee
    {
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public PartTimeEmployee(string fName, string lName, decimal rate, double hours)
        {
            FirstName = fName;
            LastName = lName;
            HourlyRate = rate;
            HoursWorked = hours;
        }
        public PartTimeEmployee(string fName, string lName) : this(fName, lName, 0, 0) { }
        public PartTimeEmployee() : this("Unknown", "Unknown") { }
        public override decimal CalculateMonthlyPay()
        {
            return HourlyRate * (decimal)HoursWorked;
        }
    }
}
