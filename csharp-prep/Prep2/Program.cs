using System;

class Program
{
    static void Main(string[] args)
    {
        string letter = "";
        bool goodMessage = false;

        Console.Write("What is your grade percentage? ");
        int per = int.Parse(Console.ReadLine());
        if (per >= 90)
        {
            letter = "A";
            goodMessage = true;
        }
        else if (per >= 80)
        {
            letter = "B";
            goodMessage = true;
        }
        else if (per >= 70)
        {
            letter = "C";
            goodMessage = true;
        }
        else if (per >= 60)
        {
            letter = "D";
            goodMessage = false;
        }
        else
        {
            letter = "F";
            goodMessage = false;
        }

        // check if it's a + or - (STRETCH CHALLANGE 1);
        int lastDigit = per % 10;
        string sign = "";
        if (lastDigit >= 7)
        {
        
        // preventing the A+ grade
        if (letter != "A")
            {
                sign = "+";
            }
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }

        // preventing F+ or F- grades
        if (letter == "F")
        {
            sign = "";
        }

        // display the grade and the good or bad message;
        Console.WriteLine($"Grade: {letter}{sign}");
        if (goodMessage == true)
        {
            Console.WriteLine("Great job!");
        }
        else 
        {
            Console.WriteLine("Better luck next time");
        }
        }
        
    }
