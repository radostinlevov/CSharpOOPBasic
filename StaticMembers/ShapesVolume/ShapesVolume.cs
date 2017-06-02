using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Shape
{
    public abstract double CalcVolume();
}
public class VolumeCalculator
{
    public static double CalcVolume(Shape shape)
    {
        return shape.CalcVolume();
    }
}
public class TriangularPrism : Shape
{
    private double side;
    private double height;
    private double length;

    public TriangularPrism(double side, double height, double length)
    {
        this.side = side;
        this.height = height;
        this.length = length;
    }

    public override double CalcVolume()
    {
        return (side * height * length) / 2;
    }
}
public class Cube : Shape
{
    private double sidelength;

    public Cube(double sidelength)
    {
        this.sidelength = sidelength;
    }

    public override double CalcVolume()
    {
        return Math.Pow(sidelength, 3);
    }
}
public class Cylinder : Shape
{
    private double radius;
    private double height;

    public Cylinder(double radius, double height)
    {
        this.radius = radius;
        this.height = height;
    }

    public override double CalcVolume()
    {
        return Math.PI * Math.Pow(radius, 2) * height;
    }
}
public class StartUp
{
    public static void Main()
    {
        string inputLine = Console.ReadLine();

        while (inputLine != "End")
        {
            string[] inputInfo = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string shapeName = inputInfo[0];

            switch (shapeName)
            {
                case "TrianglePrism":
                    double side = double.Parse(inputInfo[1]);
                    double height = double.Parse(inputInfo[2]);
                    double length = double.Parse(inputInfo[3]);

                    TriangularPrism triangularPrism = new TriangularPrism(side, height, length);
                    Console.WriteLine($"{VolumeCalculator.CalcVolume(triangularPrism):F3}");
                    break;
                case "Cube":
                    double sideLength = double.Parse(inputInfo[1]);
                    Cube cube = new Cube(sideLength);
                    Console.WriteLine($"{VolumeCalculator.CalcVolume(cube):F3}");
                    break;
                case "Cylinder":
                    double radius = double.Parse(inputInfo[1]);
                    double cylinderHeight = double.Parse(inputInfo[2]);
                    Cylinder cylinder = new Cylinder(radius, cylinderHeight);
                    Console.WriteLine($"{VolumeCalculator.CalcVolume(cylinder):F3}");
                    break;
            }

            inputLine = Console.ReadLine();
        }
    }
}