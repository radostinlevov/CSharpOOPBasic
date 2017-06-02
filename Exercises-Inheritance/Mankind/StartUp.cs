using System;
using Mankind.Classes;

namespace Mankind
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                string[] studentTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = studentTokens[0];
                string lastName = studentTokens[1];
                string facultyNumber = studentTokens[2];

                Student student = new Student(firstName, lastName, facultyNumber);

                string[] workerTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string workerFirstName = workerTokens[0];
                string workerLastName = workerTokens[1];
                double weekSalary = double.Parse(workerTokens[2]);
                double workHoursPerDay = double.Parse(workerTokens[3]);

                Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, workHoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
