using System;
using System.Drawing;

class Program

{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        
        Square s1 = new Square("Green", 5);
        shapes.Add(s1);

        Rectangle r2 = new Rectangle(5, 2, "Red");
        shapes.Add(r2);

        Circle c3 = new Circle(7, "Blue");
        shapes.Add(c3);

        foreach (Shape s in shapes)
        {
            
            double area = s.GetArea();

            Console.WriteLine($"The {s.GetColor} shape has an area of {area}.");
        }


    }
}
    



