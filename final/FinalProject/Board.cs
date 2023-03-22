public class Board
{
    // Holds all the tiles;
    private List<string> _numbers;
    private List<string> _letters;
    private List<List<Tile>> _tileList;
    public Board()
    {
        // the numbers and letters are for the edge of the board
        _numbers = new List<string>
        {"[1]","[2]","[3]","[4]","[5]","[6]","[7]","[8]"};
        _letters = new List<string>
        {"[A]","[B]","[C]","[D]","[E]","[F]","[G]","[H]"};
        _tileList = new List<List<Tile>>();

        // fill up the tileList:
        for (int i=0; i<_letters.Count(); i++)
        {
            List<Tile> row = new List<Tile>();
            for (int j=0; j<_numbers.Count(); j++)
            {
                Tile tile = new Tile();
                row.Add(tile);
            }
            _tileList.Add(row);
        }

    }
    public void DrawBoard()
    {
        // Draw the numbers;
        Console.Write("   "); // this is the top left corner space
        foreach (string num in _numbers)
        {
            Console.Write(num);
        }
        Console.WriteLine();

        // draw a letter followed by a row of tiles.
        for (int i=0; i<_letters.Count(); i++)
        {
            Console.Write(_letters[i]);
            for (int j=0; j<_numbers.Count(); j++)
            {
                Console.Write(_tileList[i][j].TileString());
            }
            Console.WriteLine();
        }
    }

    public void ClearBoard()
    {
        foreach (List<Tile> row in _tileList)
        {
            foreach (Tile tile in row)
            {
                tile._onTile.Clear();
            }
        }
    }

    public void PlacePiece(Piece p)
    {
        // step one: check if piece is already in list:
        // ...

        int letter = p._position[0];
        int number = p._position[1];

        // fill the correct tile
        _tileList[letter][number].AddPiece(p);
    }

    public void PlaceTeam(Team t)
    {
        foreach (Piece p in t._teamPieces)
        {
            PlacePiece(p);
        }
    }

  
}