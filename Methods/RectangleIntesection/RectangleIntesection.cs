using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;


class Rectangle
{
    public string id;
    public Rect rectangle;

    public Rectangle(string id, Rect rectangle)
    {
        this.id = id;
        this.rectangle = rectangle;
    }

    public static bool IsIntersect(Rect firstRect, Rect secondRect)
    {
        return firstRect.IntersectsWith(secondRect);
    }
}
public class StartUp
{
    public static void Main()
    {
        List<Rectangle> rectanglesWithId = new List<Rectangle>();

        string[] inputLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int numberOfRectangles = int.Parse(inputLine[0]);
        int numberOfPairs = int.Parse(inputLine[1]);

        for (int i = 0; i < numberOfRectangles; i++)
        {
            string[] rectangleInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string id = rectangleInfo[0];
            double width = double.Parse(rectangleInfo[1]);
            double height = double.Parse(rectangleInfo[2]);
            double x = double.Parse(rectangleInfo[3]);
            double y = double.Parse(rectangleInfo[4]);

            Rect rectangle = new Rect(x, y, width, height);
            Rectangle rectangleWithId = new Rectangle(id, rectangle);
            rectanglesWithId.Add(rectangleWithId);

        }

        for (int i = 0; i < numberOfPairs; i++)
        {
            string[] pair = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstId = pair[0];
            string secondId = pair[1];

            var first = rectanglesWithId.First(x => x.id == firstId);
            var second = rectanglesWithId.First(x => x.id == secondId);

            Console.WriteLine(Rectangle.IsIntersect(first.rectangle, second.rectangle).ToString().ToLower());
        }
    }
}