using System;

class Program

{
    static void Main(string[] args)
    {

        //NOTE: For any coordinates we will do row first and then column
        // AKA letter, than number.

        // first, display start message.
        string startMessage = 
        "Welcome to the Console Chess game, written by John Francis. \n" 
        + "In this game, the white team pieces are represented by letters, \n"
        + "and the black team pieces are represented by symbols. \n\n"
        + "White team:    Black team: \n"
        + "\"k\": King    \"!\": King   \n"
        + "\"q\": Queen   \"?\": Queen  \n"
        + "\"c\": Castle  \"#\": Castle \n"
        + "\"b\": Bishop  \"/\": Bishop \n"
        + "\"n\": Knight  \"$\": Knight \n"
        + "\"p\": Pon     \"+\": Pon    \n"
        + "\n"
        + "For the moment, there isn't a mechanism for detecting \"check\" or \"checkmate,\" \n"
        + "so the way to win is simply by killing the opposing team's king. \n"
        + "enjoy! (press enter to play): ";

        Console.Clear();
        Console.Write(startMessage);
        Console.ReadLine();

        Game g = new Game();
        Team winner = g.PlayGame();
        Console.WriteLine($"Congratulations, {winner.GetColor()} team, you won!");

    }
}