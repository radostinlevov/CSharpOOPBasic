using System;
using System.Collections.Generic;
using System.Linq;

class Pokemon
{
    public string name;
    public string element;
    public int health;

    public Pokemon(string name, string element, int health)
    {
        this.name = name;
        this.element = element;
        this.health = health;
    }
}
class Trainer
{
    public string name;
    public int numberOfBadges;
    public List<Pokemon> pokemons;

    public Trainer(string name, List<Pokemon> pokemons)
    {
        this.name = name;
        this.pokemons = pokemons;
    }

    public bool ContainsElement(string command)
    {
        foreach (var pokemon in pokemons)
        {
            if (pokemon.element == command)
            {
                return true;
            }
        }
        return false;
    }

    public void DecreaseHealth()
    {
        foreach (var pokemon in pokemons)
        {
            pokemon.health -= 10;
        }
    }

    public void RemoveDeadPokemons()
    {
        pokemons = pokemons.Where(p => p.health > 0).ToList();
    }
}
class StartUp
{
    static void Main()
    {
        List<Trainer> trainers = new List<Trainer>();
        Dictionary<string, List<Pokemon>> pokemonsByTrainer = new Dictionary<string, List<Pokemon>>();

        string input = Console.ReadLine();

        while (input != "Tournament")
        {
            string[] inputInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string nameOfTrainer = inputInfo[0];
            string name = inputInfo[1];
            string element = inputInfo[2];
            int health = int.Parse(inputInfo[3]);

            Pokemon pokemon = new Pokemon(name, element, health);
            if (!pokemonsByTrainer.ContainsKey(nameOfTrainer))
            {
                pokemonsByTrainer.Add(nameOfTrainer, new List<Pokemon>());
                pokemonsByTrainer[nameOfTrainer].Add(pokemon);
            }
            else
            {
                pokemonsByTrainer[nameOfTrainer].Add(pokemon);
            }

            input = Console.ReadLine();
        }

        foreach (var pair in pokemonsByTrainer)
        {
            Trainer trainer = new Trainer(pair.Key, pair.Value);
            trainers.Add(trainer);
        }

        string command = Console.ReadLine();

        while (command != "End")
        {
            foreach (var trainer in trainers)
            {
                if (trainer.ContainsElement(command))
                {
                    trainer.numberOfBadges++;
                }
                else
                {
                    trainer.DecreaseHealth();
                    trainer.RemoveDeadPokemons();
                }
            }

            command = Console.ReadLine();
        }

        trainers.OrderByDescending(t => t.numberOfBadges)
                .ToList()
                .ForEach(t => Console.WriteLine($"{t.name} {t.numberOfBadges} {t.pokemons.Count}"));
    }
}