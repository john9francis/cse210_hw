using System;

class Program
{
    static void Main(string[] args)
    {
        //getting random number;
        Random randomGenerator = new Random();
        int num = randomGenerator.Next(1, 101);

        int guess = 0;
        int guesses = 0;
        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            if (guess > num)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < num)
            {
                Console.WriteLine("Higher");
            }
            else if (guess == num)
            {
                Console.WriteLine("You guessed it!");
            }
            guesses += 1;
        } while (guess != num);

        // stretch challenge 1;
        Console.WriteLine($"Guesses: {guesses}");
        
    }
}