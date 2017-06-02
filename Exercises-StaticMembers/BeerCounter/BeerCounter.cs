using System;

public class BeerCounter
{
    private static int beerInStock;
    private static int beersDrankCount;

    public static void BuyBeer(int bottlesCount)
    {
        beerInStock += bottlesCount;
    }

    public static void DrinkBeer(int bottlesCount)
    {
        beersDrankCount += bottlesCount;
        beerInStock -= bottlesCount;
    }

    public static int BeerInStock => beerInStock;
    public static int BeersDrankCount => beersDrankCount;
}
public class StartUp
{
    public static void Main()
    {
        string inputLine = Console.ReadLine();

        while (inputLine != "End")
        {
            string[] inputInfo = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int boughtBeers = int.Parse(inputInfo[0]);
            int drankBeers = int.Parse(inputInfo[1]);

            BeerCounter.BuyBeer(boughtBeers);
            BeerCounter.DrinkBeer(drankBeers);

            inputLine = Console.ReadLine();
        }

        Console.WriteLine($"{BeerCounter.BeerInStock} {BeerCounter.BeersDrankCount}");
    }
}