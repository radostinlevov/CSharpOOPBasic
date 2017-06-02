using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    private string name;
    private static int count = 0;

    public Student(string name)
    {
        this.name = name;
        count++;
    }

    public static int Count { get { return count; } set { count = value; } }
}
public class StartUp
{
    public static void Main()
    {
        string inputLine = Console.ReadLine();

        while (inputLine != "End")
        {
            Student student = new Student(inputLine);

            inputLine = Console.ReadLine();
        }

        Console.WriteLine(Student.Count);
    }
}