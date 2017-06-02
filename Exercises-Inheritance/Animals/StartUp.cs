using System;
using System.Collections.Generic;
using Animals.Classes.Classes;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();

            string firstLine = Console.ReadLine().Trim();

            while (firstLine != "Beast!")
            {
                string secondLine = Console.ReadLine();

                string[] objectTokens = secondLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string name = objectTokens[0];
                int age = int.Parse(objectTokens[1]);

                try
                {
                    switch (firstLine)
                    {
                        case "Dog":
                            string dogGender = objectTokens[2];

                            Animal dog = new Dog(name, age, dogGender);
                            animals.Add(dog);
                            break;
                        case "Cat":
                            string catGender = objectTokens[2];

                            Animal cat = new Cat(name, age, catGender);
                            animals.Add(cat);
                            break;
                        case "Frog":
                            string frogGender = objectTokens[2];

                            Animal frog = new Frog(name, age, frogGender);
                            animals.Add(frog);
                            break;
                        case "Kitten":
                            Animal kitten = new Kitten(name, age);
                            animals.Add(kitten);
                            break;
                        case "Tomcat":
                            Animal tomcat = new Tomcat(name, age);
                            animals.Add(tomcat);
                            break;
                    }
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }

                firstLine = Console.ReadLine().Trim();
            }

            foreach (var animal in animals)
            {
                Type type = animal.GetType();
                int index = type.ToString().LastIndexOf('.');

                Console.WriteLine(type.ToString().Substring(index + 1));
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }

        }
    }
}
