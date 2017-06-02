using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Person
{
    public string name;
    public int age;
    public string occupation;

    public Person(string name, int age, string occupation)
    {
        this.name = name;
        this.age = age;
        this.occupation = occupation;
    }

    public override string ToString()
    {
        return $"{this.name} - age: {this.age}, occupation: {this.occupation}";
    }
}
public class StartUp
{
    public static void Main()
    {
        List<Person> people = new List<Person>();

        string inputLine = Console.ReadLine();

        while (inputLine != "END")
        {
            string[] inputInfo = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string name = inputInfo[0];
            int age = int.Parse(inputInfo[1]);
            string occupation = inputInfo[2];

            Person person = new Person(name, age, occupation);
            people.Add(person);

            inputLine = Console.ReadLine();
        }

        var peopleSort = people.OrderBy(p => p.age).ToList();

        peopleSort.ForEach(p => Console.WriteLine(p));
    }
}