using System;
using System.Text;

namespace Mankind.Classes
{
    public class Worker : Human
    {
        private const double WorkDays = 5;
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workHoursPerDay = value;
            }
        }

        public double SalaryPerHour()
        {
            double salaryPerHour = (this.WeekSalary / this.WorkHoursPerDay) / WorkDays;

            return salaryPerHour;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"First Name: {this.FirstName}")
                .Append(Environment.NewLine)
                .Append($"Last Name: {this.LastName}")
                .Append(Environment.NewLine)
                .Append($"Week Salary: {this.WeekSalary:f2}")
                .Append(Environment.NewLine)
                .Append($"Hours per day: {this.WorkHoursPerDay:f2}")
                .Append(Environment.NewLine)
                .Append($"Salary per hour: {this.SalaryPerHour():f2}");

            return sb.ToString();
        }
    }
}
