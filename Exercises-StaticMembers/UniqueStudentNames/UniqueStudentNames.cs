using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class Student
{
    private string name;

    public Student(string name)
    {
        this.name = name;
    }
}

public class StudentGroup
{
    public static HashSet<string> UniqueNames = new HashSet<string>();

    public static int CountOfUniqueNames()
    {
        return UniqueNames.Count;
    }

    public static void Add(string name)
    {
        UniqueNames.Add(name);
    }
}
public class StartUp
{
    public static void Main()
    {
        string name = Console.ReadLine();

        while (name != "End")
        {
            Student student = new Student(name);

            StudentGroup.UniqueNames.Add(name);

            name = Console.ReadLine();
        }

        Console.WriteLine(StudentGroup.CountOfUniqueNames());
    }
}