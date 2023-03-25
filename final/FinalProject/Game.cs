public class Game
{
    Team _team1;
    Team _team2;
    Board _board;
    public Game()
    {
        _team1 = new Team();
        _team2 = new Team("black");
        _board = new Board();
        _board.PlaceTeam(_team1);
        _board.PlaceTeam(_team2);

    }

    public void PlayGame()
    {
        // let one team take a turn and then the other one, loop
        // stop loop when the game is over.
        bool playing = true;
        while (playing)
        {
            Console.Clear();
            _board.DrawBoard();
            Console.WriteLine("Where would you like to move?");
            string input = Console.ReadLine();
            if (input == "q")
            {
                playing = false;
            }
        }
        
    }

    public void CheckWinner()
    {
        // check which team has won
    }

    public void MovePiece()
    {
        // ask user for which piece to move, where to move it, and then do that.

    }



}