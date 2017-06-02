using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Car
    {
        public string model;
        public Engine engine;
        public string weight = "n/a";
        public string color = "n/a";

        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
        }
    }

    public class Engine
    {
        public string model;
        public int power;
        public string displacement = "n/a";
        public string efficiency = "n/a";

        public Engine(string model, int power)
        {
            this.model = model;
            this.power = power;
        }
    }

    public class StartUp
    {
        public static void Main()
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int numberOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                Engine engine = new Engine(model, power);

                if (engineInfo.Length > 3)
                {
                    engine.efficiency = engineInfo[3];
                }
                if (engineInfo.Length > 2)
                {
                    try
                    {
                        int displacement = int.Parse(engineInfo[2]);
                        engine.displacement = displacement.ToString();
                    }
                    catch
                    {

                        engine.efficiency = engineInfo[2];
                    }
                }

                engines.Add(engine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                string modelOfEngine = carInfo[1];
                Engine engine = engines.First(e => e.model == modelOfEngine);

                Car car = new Car(model, engine);

                if (carInfo.Length > 3)
                {
                    car.color = carInfo[3];
                }

                if (carInfo.Length > 2)
                {
                    try
                    {
                        int weight = int.Parse(carInfo[2]);
                        car.weight = weight.ToString();
                    }
                    catch
                    {
                        car.color = carInfo[2];
                    }
                }

                cars.Add(car);
            }

            cars.ForEach(c =>
            {
                Console.WriteLine($"{c.model}:");
                Console.WriteLine($"  {c.engine.model}:");
                Console.WriteLine($"    Power: {c.engine.power}");
                Console.WriteLine($"    Displacement: {c.engine.displacement}");
                Console.WriteLine($"    Efficiency: {c.engine.efficiency}");
                Console.WriteLine($"  Weight: {c.weight}");
                Console.WriteLine($"  Color: {c.color}");
            });
        }
    }
}
