using System;
using System.Collections.Generic;

public abstract class Temperature
{
    private double convertedTemperature;
    private string convertedUnit;
    public abstract double ConvertUnit();

    public double ConvertedTemperature
    {
        get { return this.convertedTemperature; }
        set { this.convertedTemperature = value; }
    }
    public string ConvertedUnit
    {
        get { return this.convertedUnit; }
        set { this.convertedUnit = value; }
    }
}
public class Celsius : Temperature
{
    private int temperature;

    public Celsius(int temperature)
    {
        this.temperature = temperature;
    }

    public override double ConvertUnit()
    {
        return ((9.0 / 5.0) * this.temperature) + 32;
    }
}
public class Fahrenheit : Temperature
{
    private int temperature;

    public Fahrenheit(int temperature)
    {
        this.temperature = temperature;
    }

    public override double ConvertUnit()
    {
        return (5.0 / 9.0) * (this.temperature - 32);
    }
}

public class StartUp
{
    public static void Main()
    {
        List<Temperature> temperaturesWithUnits = new List<Temperature>();

        string inputLine = Console.ReadLine();

        while (inputLine != "End")
        {
            string[] inputInfo = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int temperature = int.Parse(inputInfo[0]);
            string unit = inputInfo[1];

            if (unit == "Celsius")
            {
                Temperature celsius = new Celsius(temperature);
                celsius.ConvertedTemperature = celsius.ConvertUnit();
                celsius.ConvertedUnit = "Fahrenheit";
                temperaturesWithUnits.Add(celsius);
            }
            else if (unit == "Fahrenheit")
            {
                Temperature fahrenheit = new Fahrenheit(temperature);
                fahrenheit.ConvertedTemperature = fahrenheit.ConvertUnit();
                fahrenheit.ConvertedUnit = "Celsius";
                temperaturesWithUnits.Add(fahrenheit);
            }

            inputLine = Console.ReadLine();
        }

        foreach (var temperature in temperaturesWithUnits)
        {
            Console.WriteLine($"{temperature.ConvertedTemperature:f} {temperature.ConvertedUnit}");
        }
    }
}