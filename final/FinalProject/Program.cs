using System;

class Program

{
    static void Main(string[] args)
    {

        //NOTE: For any coordinates we will do row first and then column
        // AKA letter, than number.

        // first, display start message.
        string startMessage = "Welcome to the Console Chess game, written by John Francis. " 
        + "In this game, the white team pieces are represented by letters. k is king, q is queen, "
        + "n is knight, b is bishop, c is castle, and p is pon. For the black team, the pieces "
        + "are represented by symbols. ! is king, ? is queen, $ is knight, / is bishop, # is "
        + "castle, and + is pon. For the moment, there isn't a mechanism for detecting \"check\" "
        + "or \"checkmate,\" so the way to win is simply by killing the opposing team's king. "
        + "enjoy! (press enter to play): ";

        Console.Clear();
        Console.Write(startMessage);
        Console.ReadLine();

        Game g = new Game();
        Team winner = g.PlayGame();
        Console.WriteLine($"Congratulations, {winner._teamColor} team, you won!");

    }
}