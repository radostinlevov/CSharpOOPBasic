using System;
using System.Collections.Generic;

public class Animal
{
    public string name;
    public string breed;

    public Animal(string name, string breed)
    {
        this.name = name;
        this.breed = breed;
    }
}

public class AnimalClinic
{
    public static int patientId = 1;
    public static List<Animal> healedAnimals = new List<Animal>();
    public static List<Animal> rehabilitatedAnimals = new List<Animal>();
}

public class StartUp
{
    public static void Main()
    {
        string inputLine = Console.ReadLine();

        while (inputLine != "End")
        {
            string[] inputInfo = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = inputInfo[0];
            string breed = inputInfo[1];
            string manipulation = inputInfo[2];

            Animal animal = new Animal(name, breed);

            if (manipulation == "heal")
            {
                AnimalClinic.healedAnimals.Add(animal);
                Console.WriteLine($"Patient {AnimalClinic.patientId}: [{name} ({breed})] has been healed!");
                AnimalClinic.patientId++;
            }
            else if (manipulation == "rehabilitate")
            {
                AnimalClinic.rehabilitatedAnimals.Add(animal);
                Console.WriteLine($"Patient {AnimalClinic.patientId}: [{name} ({breed})] has been rehabilitated!");
                AnimalClinic.patientId++;
            }

            inputLine = Console.ReadLine();
        }

        string manipulationCommand = Console.ReadLine();

        Console.WriteLine($"Total healed animals: {AnimalClinic.healedAnimals.Count}");
        Console.WriteLine($"Total rehabilitated animals: {AnimalClinic.rehabilitatedAnimals.Count}");

        if (manipulationCommand == "heal")
        {
            AnimalClinic.healedAnimals.ForEach(a => Console.WriteLine($"{a.name} {a.breed}"));
        }
        else
        {
            AnimalClinic.rehabilitatedAnimals.ForEach(a => Console.WriteLine($"{a.name} {a.breed}"));
        }
    }
}