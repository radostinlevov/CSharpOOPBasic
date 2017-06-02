using System;

public class Car
{
    private decimal speed;
    private decimal fuelAmount;
    private decimal fuelConsumption;
    private decimal distancePassed;

    public Car(decimal speed, decimal fuelAmount, decimal fuelConsumption)
    {
        this.speed = speed;
        this.fuelAmount = fuelAmount;
        this.fuelConsumption = fuelConsumption;
    }

    public decimal DistancePassed => this.distancePassed;
    public decimal FuelAmount => this.fuelAmount;


    public void Travel(decimal distanceToTravel)
    {
        decimal fuelPerKm = this.fuelConsumption / 100;
        decimal fuelNeeded = distanceToTravel * fuelPerKm;

        if (fuelNeeded > this.fuelAmount)
        {
            decimal KmPerLiter = 100 / this.fuelConsumption;
            this.distancePassed += this.fuelAmount * KmPerLiter;
            this.fuelAmount = 0;
        }
        else
        {
            this.fuelAmount -= fuelNeeded;
            this.distancePassed += distanceToTravel;
        }
    }

    public void Refuel(decimal refuelLiters)
    {
        this.fuelAmount += refuelLiters;
    }

    public void Time()
    {

        decimal hours = Math.Truncate(this.distancePassed / this.speed);
        decimal minutes = Math.Truncate(this.distancePassed % this.speed);

        Console.WriteLine($"Total time: {hours} hours and {minutes:f0} minutes");
    }
}
public class StartUp
{
    public static void Main()
    {
        string[] carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        decimal speed = decimal.Parse(carInfo[0]);
        decimal fuelAmount = decimal.Parse(carInfo[1]);
        decimal fuelConsumption = decimal.Parse(carInfo[2]);

        Car car = new Car(speed, fuelAmount, fuelConsumption);

        string command = Console.ReadLine();
        while (command != "END")
        {
            string[] commandInfo = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string commandText = commandInfo[0];
            switch (commandText)
            {
                case "Travel":
                    decimal distanceToTravel = decimal.Parse(commandInfo[1]);
                    car.Travel(distanceToTravel);
                    break;
                case "Refuel":
                    decimal refuelLiters = decimal.Parse(commandInfo[1]);
                    car.Refuel(refuelLiters);
                    break;
                case "Distance":
                    Console.WriteLine($"Total distance: {car.DistancePassed:f1} kilometers");
                    break;
                case "Time":
                    car.Time();
                    break;
                case "Fuel":
                    Console.WriteLine($"Fuel left: {car.FuelAmount:F1} liters");
                    break;
            }

            command = Console.ReadLine();
        }
    }
}