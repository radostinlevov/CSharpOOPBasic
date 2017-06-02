using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpinionPoll
{
    class Person
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
    public class StartUp
    {
       public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(personInfo[0], int.Parse(personInfo[1]));
                people.Add(person);
            }

            people.Where(p => p.age > 30)
                  .OrderBy(p => p.name)
                  .ToList()
                  .ForEach(p => Console.WriteLine(p.name + " - " + p.age));
        }
    }
}
