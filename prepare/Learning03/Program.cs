using System;

class Program
{
    static void Main(string[] args)
    {
        // testing the 1/1 fraction;
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
        
        // testing 5/1;
        f1.SetTop(5);
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        // testing 3/4;
        f1 = new Fraction(3,4);
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue()); 
        
        // testing 1/3 a different way;
        f1.SetTop(1);
        f1.SetBottom(3);
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());


    }
}

