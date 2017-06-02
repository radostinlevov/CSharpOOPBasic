using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public abstract class Shape
{
    public abstract void Draw();
}

public class CorDraw
{
    private Shape shape;

    public CorDraw(Shape shape)
    {
        this.shape = shape;
    }

    public void Draw(Shape shape)
    {
        shape.Draw();
    }
}

public class Rectangle : Shape
{
    private int width;
    private int lenght;

    public Rectangle(int width, int lenght)
    {
        this.width = width;
        this.lenght = lenght;
    }

    public override void Draw()
    {
        Console.WriteLine($"{'|'}{new string('-', width)}{'|'}");
        for (int i = 0; i < lenght - 2; i++)
        {
            Console.WriteLine($"{'|'}{new string(' ', width)}{'|'}");
        }
        Console.WriteLine($"{'|'}{new string('-', width)}{'|'}");
    }
}

public class Square : Shape
{
    private int side;

    public Square(int side)
    {
        this.side = side;
    }

    public override void Draw()
    {
        Console.WriteLine($"{'|'}{new string('-', side)}{'|'}");
        for (int i = 0; i < side - 2; i++)
        {
            Console.WriteLine($"{'|'}{new string(' ', side)}{'|'}");
        }
        Console.WriteLine($"{'|'}{new string('-', side)}{'|'}");
    }
}

public class DrawingTool
{
    public static void Main()
    {
        string shape = Console.ReadLine();

        if (shape == "Square")
        {
            int side = int.Parse(Console.ReadLine());
            Square square = new Square(side);
            square.Draw();
        }
        else if (shape == "Rectangle")
        {
            int width = int.Parse(Console.ReadLine());
            int lengh = int.Parse(Console.ReadLine());
            Rectangle rectangle = new Rectangle(width, lengh);
            rectangle.Draw();
        }
    }
}