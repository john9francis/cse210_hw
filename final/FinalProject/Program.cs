using System;

class Program

{
    static void Main(string[] args)
    {

        //NOTE: For any coordinates we will do row first and then column
        // AKA letter, than number.

        Game g = new Game();
        Team winner = g.PlayGame();
        Console.WriteLine($"Congratulations, {winner._teamColor} team, you won!");

    }
}