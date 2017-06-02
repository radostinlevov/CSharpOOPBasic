using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRoster
{
    public class Employee
    {
        public string name;
        public decimal salary;
        public string position;
        public string department;
        public string email;
        public int age;

        public Employee(string name, decimal salary, string position, string department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.email = "n/a";
            this.age = -1;
        }

        public Employee(string name, decimal salary, string position, string department, string email, int age)
            : this(name, salary, position, department)
        {
            this.email = email;
            this.age = age;
        }
    }
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> employeesList = new List<Employee>();

            for (int i = 0; i < n; i++)
            {

                string[] employeeInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var employee = new Employee(employeeInfo[0], decimal.Parse(employeeInfo[1]),
                                            employeeInfo[2], employeeInfo[3]);

                if (employeeInfo.Length > 4)
                {
                    if (employeeInfo[4].Contains("@"))
                    {
                        employee.email = employeeInfo[4];
                    }
                    else
                    {
                        employee.age = int.Parse(employeeInfo[4]);
                    }
                }

                if (employeeInfo.Length > 5)
                {
                    employee.age = int.Parse(employeeInfo[5]);
                }

                employeesList.Add(employee);
            }

            var employeesGroup = employeesList.GroupBy(e => e.department,
                                                      e => new
                                                      {
                                                          Name = e.name,
                                                          Salary = e.salary,
                                                          Email = e.email,
                                                          Age = e.age
                                                      })
                                                      .OrderByDescending(e => e.Average(s => s.Salary))
                                                      .ToList();

            Console.WriteLine();
            Console.WriteLine($"Highest Average Salary: {employeesGroup[0].Key}");

            employeesGroup[0].OrderByDescending(e => e.Salary)
                             .ToList()
                             .ForEach(e => Console.WriteLine($"{e.Name} {e.Salary:f2} {e.Email} {e.Age}"));
        }
    }
}
