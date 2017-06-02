using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Car
{
    public string model;
    public decimal fuelAmount;
    public decimal fuelConsumptionPerKm;
    public decimal distanceTraveled;

    public Car(string model, decimal fuelAmount, decimal fuelConsumptionPerKm)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public void Drive(int amountOfKm)
    {
        if (amountOfKm <= fuelAmount / fuelConsumptionPerKm)
        {
            this.distanceTraveled += amountOfKm;
            this.fuelAmount -= amountOfKm * fuelConsumptionPerKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }

    }
}
class StartUp
{
    static void Main()
    {
        List<Car> cars = new List<Car>();

        int numberOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCars; i++)
        {
            string[] carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = carInfo[0];
            decimal fuelAmount = decimal.Parse(carInfo[1]);
            decimal fuelConsumptionPerKm = decimal.Parse(carInfo[2]);

            Car car = new Car(model, fuelAmount, fuelConsumptionPerKm);
            cars.Add(car);
        }

        string command = Console.ReadLine();

        while (command != "End")
        {
            string[] commandInfo = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string carModel = commandInfo[1];
            int amountOfKm = int.Parse(commandInfo[2]);

            Car currentCar = cars.First(c => c.model == carModel);

            currentCar.Drive(amountOfKm);

            command = Console.ReadLine();
        }

        cars.ForEach(c =>
        {
            Console.WriteLine($"{c.model} {c.fuelAmount:f2} {c.distanceTraveled}");
        });
    }
}