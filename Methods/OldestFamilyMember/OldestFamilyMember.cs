using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

class Person
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public string Name => this.name;
    public int Age => this.age;
}
class Family
{
    private List<Person> members = new List<Person>();

    public List<Person> Members => this.members;

    public void AddMember(Person member)
    {
        members.Add(member);
    }

    public Person GetOldestMember()
    {
        var maxAge = Members.Select(p => p.Age).Max();
        var oldestPerson = Members.Find(p => p.Age == maxAge);
        return oldestPerson;
    }
}
class StartUp
{
    static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        Family family = new Family();

        int numberOfMembers = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfMembers; i++)
        {
            string[] memberInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Person member = new Person(memberInfo[0], int.Parse(memberInfo[1]));
            family.AddMember(member);
        }

        Person oldestMember = family.GetOldestMember();

        Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
    }
}