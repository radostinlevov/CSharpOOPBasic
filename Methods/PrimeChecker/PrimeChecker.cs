using System;

public class Number
{
    private int valueOfNumber;
    private bool isPrimeNumber = true;

    public Number(int number)
    {
        this.valueOfNumber = number;
    }

    public int ValueOfNumber => this.valueOfNumber;
    public bool IsPrimeNumber => this.isPrimeNumber;

    public bool IsPrime()
    {
        for (int i = 2; i <= valueOfNumber / 2; i++)
        {
            if (valueOfNumber % i == 0)
            {
                isPrimeNumber = false;
            }
        }

        return isPrimeNumber;
    }

    public int NextPrime(int number)
    {
        return number;
    }


}
public class StartUp
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        Number firstNumber = new Number(number);
        firstNumber.IsPrime();

        Number nextNumber = null;
        while (true)
        {
            number++;
            nextNumber = new Number(number);

            if (nextNumber.IsPrime())
            {
                break;
            }
        }

        Console.WriteLine(nextNumber.NextPrime(nextNumber.ValueOfNumber) + ", " + firstNumber.IsPrimeNumber.ToString().ToLower());
    }
}