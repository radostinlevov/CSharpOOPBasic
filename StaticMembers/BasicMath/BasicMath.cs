using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class MathUtil
{
    public static double Sum(double firstNumber, double secondNumber)
    {
        return firstNumber + secondNumber;
    }

    public static double Subtract(double firstNumber, double secondNumber)
    {
        return firstNumber - secondNumber;
    }
    public static double Multiply(double firstNumber, double secondNumber)
    {
        return firstNumber * secondNumber;
    }
    public static double Devide(double dividend, double divisor)
    {
        return dividend / divisor;
    }
    public static double Percentage(double number, double percent)
    {
        return number * (percent / 100);
    }
}
public class BasicMath
{
    public static void Main()
    {
        string inputLine = Console.ReadLine();

        while (inputLine != "End")
        {
            string[] inputInfo = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputInfo[0];
            double firstNumber = double.Parse(inputInfo[1]);
            double secondNumber = double.Parse(inputInfo[2]);

            switch (command)
            {
                case "Sum":
                    Console.WriteLine($"{ MathUtil.Sum(firstNumber, secondNumber):f}");
                    break;
                case "Subtract":
                    Console.WriteLine($"{MathUtil.Subtract(firstNumber, secondNumber):f}");
                    break;
                case "Multiply":
                    Console.WriteLine($"{MathUtil.Multiply(firstNumber, secondNumber):f}");
                    break;
                case "Divide":
                    Console.WriteLine($"{MathUtil.Devide(firstNumber, secondNumber):f}");
                    break;
                case "Percentage":
                    Console.WriteLine($"{ MathUtil.Percentage(firstNumber, secondNumber):f}");
                    break;
            }

            inputLine = Console.ReadLine();
        }
    }
}