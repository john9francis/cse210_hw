using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("When you're done entering numbers, write zero.");
        
        // define lists and constants;
        int num = 0;
        int max = 0;
        List<int> numbers = new List<int>();

        do 
        {
            Console.Write("Enter number: ");
            num = int.Parse(Console.ReadLine());
            numbers.Add(num);
            //finding the largest number;
            if (num > max)
            {
                max = num;
            }

        } while (num != 0);

        //getting rid of the zero at the end;
        numbers.RemoveAt(numbers.Count - 1);
        
        //finding the sum;
        int sum = 0;
        for (int i=0;i<numbers.Count;i++)
        {
            sum += numbers[i];
        }

        //finding the average;
        float avg = sum / (numbers.Count);

        //output;
        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {max}");

    }
}