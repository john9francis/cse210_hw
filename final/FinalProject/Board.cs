public class Board
{
    // Holds all the tiles;
    private List<List<Tile>> _tileList;
    public List<Piece> _pieceList;
    public int _size;


    public Board()
    {
        
        _tileList = new List<List<Tile>>();
        _size = 8;

        // fill up the tileList:
        for (int i=0; i<_size; i++)
        {
            List<Tile> row = new List<Tile>();
            for (int j=0; j<_size; j++)
            {
                Tile tile = new Tile();
                row.Add(tile);
            }
            _tileList.Add(row);
        }

        _pieceList = new List<Piece>();

    }

    public void DrawBoard()
    {
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

        // Put the pieces from the piecelist into their respective tiles
        ClearBoard();
        foreach (Piece p in _pieceList)
        {
            int letter = p._position[0];
            int number = p._position[1];

            // fill the correct tile
            _tileList[letter][number].AddPiece(p);
        }


        // draw a letter followed by a row of tiles.
        for (int i=0; i<_size; i++)
        {
            Console.Write(_letters[i]);
            for (int j=0; j<_size; j++)
            {
                //Console.Write(_tileList[i][j].TileString());
                Tile tile = _tileList[i][j];
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
        _pieceList.Add(p);
    }

    public void PlaceTeam(Team t)
    {
        foreach (Piece p in t._teamPieces)
        {
            _pieceList.Add(p);
        }
    }

    public void CheckTile(List<int> coordinates)
    {
        //Takes in a coordinate and sees which piece is on there
        int row = coordinates[0];
        int column = coordinates[1];
        Tile tile = _tileList[row][column];
        if (tile.TileFull())
        {
            Console.WriteLine("There's a piece on this tile.");
        }
        else
        {
            Console.WriteLine("There's nothing here.");
        }
    }

  
}