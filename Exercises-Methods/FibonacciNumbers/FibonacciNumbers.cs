using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Fibonacci
{
    private List<long> numbers = new List<long>();

    public List<long> Numbers => this.numbers;

    public List<long> GetNumbersInRange(int startIndex, int endIndex)
    {
        List<long> numbersInRange = new List<long>();

        for (int i = startIndex; i < endIndex; i++)
        {
            numbersInRange.Add(Numbers[i]);
        }

        return numbersInRange;
    }
}
public class StartUp
{
    public static void Main()
    {
        Fibonacci fibonacci = new Fibonacci();
        fibonacci.Numbers.Add(0);
        fibonacci.Numbers.Add(1);

        int startIndex = int.Parse(Console.ReadLine());
        int endIndex = int.Parse(Console.ReadLine());

        for (int i = 0; i < endIndex - 2; i++)
        {
            long currentNum = fibonacci.Numbers[i] + fibonacci.Numbers[i + 1];
            fibonacci.Numbers.Add(currentNum);
        }

        Console.WriteLine(string.Join(", ", fibonacci.GetNumbersInRange(startIndex, endIndex)));

    }
}