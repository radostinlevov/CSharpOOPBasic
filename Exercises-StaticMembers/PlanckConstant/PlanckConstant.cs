using System;

public class Calculation
{
    private const double plankConstant = 6.62606896e-34;
    private const double piConstant = 3.14159;

    public static double ReducedPlanck()
    {
        return plankConstant / (2 * piConstant);
    }
}
public class StartUp
{
    public static void Main()
    {
        Console.WriteLine(Calculation.ReducedPlanck());
    }
}