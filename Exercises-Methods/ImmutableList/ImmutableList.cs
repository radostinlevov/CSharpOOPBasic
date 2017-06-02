using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class ImmutableList
{
    public List<int> numbers;

    public ImmutableList()
    {
        this.numbers = new List<int>();
    }
    public ImmutableList(List<int> numbers) : this()
    {
        this.numbers = numbers;
    }

    public ImmutableList GetCopyOfNumbers()
    {
        List<int> copyOfNumbers = new List<int>(this.numbers);
        ImmutableList newImmutable = new ImmutableList(copyOfNumbers);
        return newImmutable;
    }
}
public class StartUp
{
    static void Main()
    {

        //ImmutableList first = new ImmutableList();
        //ImmutableList copyOfFirst = first.GetCopyOfNumbers();
        //first.Numbers.Add(10);

        //Console.WriteLine(first.Numbers.Count + " -> " + copyOfFirst.Numbers.Count);

        Type immutableList = typeof(ImmutableList);
        FieldInfo[] fields = immutableList.GetFields();
        if (fields.Length < 1)
        {
            throw new Exception();
        }
        else
        {
            Console.WriteLine(fields.Length);
        }

        MethodInfo[] methods = immutableList.GetMethods();
        bool containsMethod = methods.Any(m => m.ReturnType.Name.Equals("ImmutableList"));
        if (!containsMethod)
        {
            throw new Exception();
        }
        else
        {
            Console.WriteLine(methods[0].ReturnType.Name);
        }

    }
}