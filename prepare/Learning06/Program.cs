using System;

public class Program
{
    static void Main(string[] args)
    {
        // Square square1 = new Square("Green", 4.0);  
        // string color1 = square1.GetColor();
        // double area1 = square1.GetArea();

        // Rectangle rectangle2 = new Rectangle("Red", 8.0, 10.0);
        // string color2 = rectangle2.GetColor();
        // double area2 = rectangle2.GetArea();

        // Circle circle3 = new Circle("Yellow", 5.0);
        // string color3 = circle3.GetColor();
        // double area3 = circle3.GetArea();

        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("Green", 4.0));
        shapes.Add(new Rectangle("Red", 8.0, 10.0));
        shapes.Add(new Circle("Yellow", 5.0));

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"{color} {area}");
        }
    }
}
