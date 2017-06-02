using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DecimalNumber
{
    private decimal number;

    public DecimalNumber(decimal number)
    {
        this.number = number;
    }

    public List<char> Reverse()
    {
        var numberAsList = number.ToString().ToList();
        numberAsList.Reverse();
        return numberAsList;
    }
}
class StartUp
{
    static void Main()
    {
        decimal number = decimal.Parse(Console.ReadLine());

        DecimalNumber decimalNum = new DecimalNumber(number);

        Console.WriteLine(string.Join("", decimalNum.Reverse()));
    }
}