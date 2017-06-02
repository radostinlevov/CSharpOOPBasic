using System;
using Vehicles.Classes;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            string[] firstLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstTypeOfVehicle = firstLine[0];
            double firstFuelQuantity = double.Parse(firstLine[1]);
            double firstFuelConsumptionLittersPerKm = double.Parse(firstLine[2]);
            double firstTankCapacity = double.Parse(firstLine[3]);

            Vehicle car = new Car(firstTypeOfVehicle, firstFuelQuantity, firstFuelConsumptionLittersPerKm, firstTankCapacity);

            string[] secondLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string secondTypeOfVehicle = secondLine[0];
            double secondFuelQuantity = double.Parse(secondLine[1]);
            double secondFuelConsumptionLittersPerKm = double.Parse(secondLine[2]);
            double secondTankCapacity = double.Parse(firstLine[3]);

            Vehicle truck = new Truck(secondTypeOfVehicle, secondFuelQuantity, secondFuelConsumptionLittersPerKm, secondTankCapacity);

            string[] thirdLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string thirdTypeOfVehicle = thirdLine[0];
            double thirdFuelQuantity = double.Parse(thirdLine[1]);
            double thirdFuelConsumptionLittersPerKm = double.Parse(thirdLine[2]);
            double thirdTankCapacity = double.Parse(thirdLine[3]);

            Vehicle bus = new Bus(thirdTypeOfVehicle, thirdFuelQuantity, thirdFuelConsumptionLittersPerKm, thirdTankCapacity);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                try
                {
                    string[] commandTokens = Console.ReadLine()
                           .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string command = commandTokens[0];
                    string typeOfVehicle = commandTokens[1];

                    switch (command)
                    {
                        case "Drive":
                            double distanceToDrive = double.Parse(commandTokens[2]);
                            switch (typeOfVehicle)
                            {
                                case "Car":
                                    Console.WriteLine(car.Drive(distanceToDrive));
                                    break;
                                case "Truck":
                                    Console.WriteLine(truck.Drive(distanceToDrive));
                                    break;
                                case "Bus":
                                    Console.WriteLine(bus.Drive(distanceToDrive));
                                    break;
                            }
                            break;

                        case "DriveEmpty":
                            double driveDistance = double.Parse(commandTokens[2]);
                            Console.WriteLine(bus.DriveEmpty(driveDistance));
                            break;

                        case "Refuel":
                            double refuelInLitters = double.Parse(commandTokens[2]);
                            switch (typeOfVehicle)
                            {
                                case "Car":
                                    car.Refuel(refuelInLitters);
                                    break;
                                case "Truck":
                                    truck.Refuel(refuelInLitters);
                                    break;
                                case "Bus":
                                    bus.Refuel(refuelInLitters);
                                    break;
                            }
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
