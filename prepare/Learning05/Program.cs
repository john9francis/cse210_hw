using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");
        Square s1 = new Square();
        s1.SetColor("Blue");
        s1.SetSide(4.1);
        Console.WriteLine(s1.GetColor());
        Console.WriteLine(s1.GetArea());

        Rectangle r1 = new Rectangle();
        r1.SetColor("Red");
        r1.SetLengthAndWidth(2.1,5);
        Console.WriteLine(r1.GetColor());
        Console.WriteLine(r1.GetArea());

        Circle c1 = new Circle();
        c1.SetColor("Orange");
        c1.SetRadius(2);
        Console.WriteLine(c1.GetColor());
        Console.WriteLine(c1.GetArea());

        // Creating a list of shapes
        List<Shape> shapeList = new List<Shape>();
        shapeList.Add(s1);
        shapeList.Add(r1);
        shapeList.Add(c1);
        foreach (Shape s in shapeList)
        {
            string color = s.GetColor();
            double area = s.GetArea();
            Console.WriteLine($"{color} {s} with an area of {area}");
        }
        
    }
}