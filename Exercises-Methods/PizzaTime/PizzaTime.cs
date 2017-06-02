using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Pizza
{
    public static SortedDictionary<int, List<string>> GetPizzasByGroup(string[] pizzas)
    {
        var pizzasByGroup = new SortedDictionary<int, List<string>>();

        foreach (var pizza in pizzas)
        {
            string pattern = @"(\d+)(\w+)";

            Match match = Regex.Match(pizza, pattern);
            int group = int.Parse(match.Groups[1].Value);
            string name = match.Groups[2].Value;

            if (!pizzasByGroup.ContainsKey(group))
            {
                pizzasByGroup.Add(group, new List<string>());
                pizzasByGroup[group].Add(name);
            }
            else
            {
                pizzasByGroup[group].Add(name);
            }

        }
        return pizzasByGroup;
    }

    public static void Print( SortedDictionary<int, List<string>> pizzasByGroup)
    {
        foreach (var pair in pizzasByGroup)
        {
            Console.WriteLine($"{pair.Key} - {string.Join(", ", pair.Value)}");
        }
    }
}
public class StartUp
{
    public static void Main()
    {
        string[] pizzas = Console.ReadLine().Split();

        var pizzasByGroup = Pizza.GetPizzasByGroup(pizzas);

        Pizza.Print(pizzasByGroup);
    }
}
