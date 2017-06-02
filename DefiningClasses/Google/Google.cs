using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Person
{
    public string name;
    public Stack<Company> company = new Stack<Company>();
    public Stack<Car> car = new Stack<Car>();
    public List<Pokemon> pokemons = new List<Pokemon>();
    public List<Parent> parents = new List<Parent>();
    public List<Child> children = new List<Child>();

    public Person(string name)
    {
        this.name = name;
    }
}

class Company
{
    public string name;
    public string department;
    public decimal salary;

    public Company(string name, string department, decimal salary)
    {
        this.name = name;
        this.department = department;
        this.salary = salary;
    }
}
class Car
{
    public string model;
    public int speed;

    public Car(string model, int speed)
    {
        this.model = model;
        this.speed = speed;
    }
}
class Pokemon
{
    public string name;
    public string type;

    public Pokemon(string name, string type)
    {
        this.name = name;
        this.type = type;
    }
}
class Parent
{
    public string name;
    public string birthday;

    public Parent(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }
}
class Child
{
    public string name;
    public string birthday;

    public Child(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }
}
class StartUp
{
    static void Main()
    {
        var infoByPerson = new Dictionary<string, List<string[]>>();
        List<Person> people = new List<Person>();
        string inputLine = Console.ReadLine();

        while (inputLine != "End")
        {
            string[] inputInfo = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string nameOfPerson = inputInfo[0];
            string[] personInfo = inputInfo.Skip(1).Take(inputInfo.Length - 1).ToArray();

            if (!infoByPerson.ContainsKey(nameOfPerson))
            {
                infoByPerson.Add(nameOfPerson, new List<string[]>());
                infoByPerson[nameOfPerson].Add(personInfo);
            }
            else
            {
                infoByPerson[nameOfPerson].Add(personInfo);
            }

            inputLine = Console.ReadLine();
        }

        foreach (var personInfo in infoByPerson)
        {
            Person person = new Person(personInfo.Key);
            foreach (var info in personInfo.Value)
            {
                string infoLine = info[0];
                switch (infoLine)
                {
                    case "company":
                        Company company = new Company(info[1], info[2], decimal.Parse(info[3]));
                        person.company.Push(company);
                        break;
                    case "car":
                        Car car = new Car(info[1], int.Parse(info[2]));
                        person.car.Push(car);
                        break;
                    case "pokemon":
                        Pokemon pokemon = new Pokemon(info[1], info[2]);
                        person.pokemons.Add(pokemon);
                        break;
                    case "parents":
                        Parent parent = new Parent(info[1], info[2]);
                        person.parents.Add(parent);
                        break;
                    case "children":
                        Child child = new Child(info[1], info[2]);
                        person.children.Add(child);
                        break;
                }
            }
            people.Add(person);
        }

        string singleName = Console.ReadLine().Trim();
        Console.WriteLine();

        foreach (var person in people)
        {
            if (person.name == singleName)
            {
                Console.WriteLine(person.name);
                Console.WriteLine("Company:");
                if (person.company.Count > 0)
                {
                    Console.WriteLine($"{person.company.Peek().name} {person.company.Peek().department} {person.company.Peek().salary:f2}");
                }
                Console.WriteLine("Car:");
                if (person.car.Count > 0)
                {
                    Console.WriteLine($"{person.car.Peek().model} {person.car.Peek().speed}");
                }
                Console.WriteLine("Pokemon:");
                person.pokemons.ForEach(p => Console.WriteLine($"{p.name} {p.type}"));
                Console.WriteLine("Parents:");
                person.parents.ForEach(p => Console.WriteLine($"{p.name} {p.birthday}"));
                Console.WriteLine("Children:");
                person.children.ForEach(p => Console.WriteLine($"{p.name} {p.birthday}"));
            }
        }
    }
}