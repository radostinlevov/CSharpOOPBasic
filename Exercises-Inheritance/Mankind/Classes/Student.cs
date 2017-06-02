using System;
using System.Text;

namespace Mankind.Classes
{
    class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) 
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }
        
        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            private set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
           StringBuilder sb = new StringBuilder();
            sb.Append($"First Name: {this.FirstName}")
                .Append(Environment.NewLine)
                .Append($"Last Name: {this.LastName}")
                .Append(Environment.NewLine)
                .Append($"Faculty number: {this.FacultyNumber}")
                .Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
