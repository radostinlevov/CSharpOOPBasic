using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DateModifier
{
    public static int DiferenceOfDays(string firstDate, string secondDate)
    {
        int[] dateFirst = firstDate.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
        int[] dateSecond = secondDate.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();

        DateTime date1 = new DateTime(dateFirst[0], dateFirst[1], dateFirst[2]);
        DateTime date2 = new DateTime(dateSecond[0], dateSecond[1], dateSecond[2]);

        TimeSpan diference = date1.Subtract(date2);

        return diference.Days;
    }
}
public class StartUp
{
    public static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        var diferense = DateModifier.DiferenceOfDays(firstDate, secondDate);

        Console.WriteLine(Math.Abs(diferense));
    }
}