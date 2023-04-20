public class Display
{
    private Board _board;
    // in charge of displaying everything
    public Display(Board b)
    {
        _board = b;
    }

    public void DisplayBoard()
    {
        _board.UpdateBoard();
        // the numbers and letters are for the edges of the board
        List<string> _numbers = new List<string>
        {"[1]","[2]","[3]","[4]","[5]","[6]","[7]","[8]"};
        List<string> _letters = new List<string>
        {"[A]","[B]","[C]","[D]","[E]","[F]","[G]","[H]"};

        // Draw the numbers;
        Console.Write("   "); // this is the top left corner space
        foreach (string num in _numbers)
        {
            Console.Write(num);
        }
        Console.WriteLine();

        // draw a letter followed by a row of tiles.
        for (int i=0; i<_board.GetBoardSize(); i++)
        {
            Console.Write(_letters[i]);
            for (int j=0; j<_board.GetBoardSize(); j++)
            {
                Tile tile = _board.GetTileList()[i][j];
                if (tile.TileFull())
                {
                    Console.Write($"[{tile.GetPiece().GetSymbol()}]");
                }
                else
                {
                    Console.Write($"[ ]");
                }
            }
            Console.WriteLine();
        }
    }

    // Getting inputs and stuff
    public string GetMovingPiece(Team t)
    {
        string teamColor = t.GetColor();
        Console.Write($"{teamColor} team, which piece would you like to move? (e.g. A1): ");
        return Console.ReadLine();
    }

    public string GetWhereToMove()
    {
        Console.Write($"Where would you like to move this piece to? (e.g. C3): ");
        return Console.ReadLine();
    }

    public void InvalidPiece()
    {
        Console.Write("Invalid entry. Make sure you entered in a coordinate of a piece on your team. (press enter): ");
        Console.ReadLine();
    }

    public void InvalidMove()
    {
        Console.Write("Invalid move. Please choose a different place to move. (press enter): ");
        Console.ReadLine();
    }

    public void PieceCantMove()

    {
        Console.Write("This piece can't move. Please choose a different piece. (press enter): ");
        Console.ReadLine();
    }
}