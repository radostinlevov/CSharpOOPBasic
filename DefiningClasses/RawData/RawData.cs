using System;
using System.Collections.Generic;
using System.Linq;

class Car
{
    public string model;
    public Engine engine;
    public Cargo cargo;
    public List<Tire> tires = new List<Tire>();

    public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }
}
class Engine
{
    public int speed;
    public int power;

    public Engine(int speed, int power)
    {
        this.speed = speed;
        this.power = power;
    }
}
class Cargo
{
    public int weight;
    public string type;

    public Cargo(int weight, string type)
    {
        this.weight = weight;
        this.type = type;
    }
}
class Tire
{
    public double pressure;
    public int age;

    public Tire(double pressure, int age)
    {
        this.pressure = pressure;
        this.age = age;
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

            Engine engine = new Engine(int.Parse(carInfo[1]), int.Parse(carInfo[2]));
            Cargo cargo = new Cargo(int.Parse(carInfo[3]), carInfo[4]);
            List<Tire> tires = new List<Tire>();
            for (int t = 5; t < carInfo.Length; t += 2)
            {
                Tire tire = new Tire(double.Parse(carInfo[t]), int.Parse(carInfo[t + 1]));
                tires.Add(tire);
            }

            Car car = new Car(carInfo[0], engine, cargo, tires);
            cars.Add(car);
        }

        string command = Console.ReadLine();

        if (command == "fragile")
        {
            cars.Where(c => c.cargo.type == "fragile")
                  .Where(c => c.tires.Count(t => t.pressure < 1) != 0)
                  .ToList()
                  .ForEach(c => Console.WriteLine(c.model));
        }
        else if (command == "flamable")
        {
            cars.Where(c => c.cargo.type == "flamable" && c.engine.power > 250)
                .ToList().ForEach(c => Console.WriteLine(c.model));
        }
    }
}