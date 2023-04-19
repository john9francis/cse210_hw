public class Board
{
    // All the information about the board.;
    private List<List<Tile>> _tileList;
    private List<Piece> _pieceList;
    private int _size;
    private Team _t1;
    private Team _t2;

    // Getters and setters for encapsulation:
    public void SetTeams(Team t1, Team t2)
    {
        _t1 = t1;
        _t2 = t2;
        UpdatePieceList();
    }

    public int GetBoardSize()
    {
        return _size;
    }

    public List<List<Tile>> GetTileList()
    {
        // this probably could be more private...
        return _tileList;
    }

    public Board()
    {
        
        _tileList = new List<List<Tile>>();
        _size = 8;

        // fill up the tileList with empty tiles:
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

    public void UpdateBoard()
    {
        // Put the pieces from the piecelist into their respective tiles
        ClearBoard();
        // update the piece list.
        UpdatePieceList();

        foreach (Piece p in _t1.GetTeamPieces())
        {
            int letter = p.GetPosition()[0];
            int number = p.GetPosition()[1];

            // fill the correct tile
            _tileList[letter][number].AddPiece(p);
        }
        foreach (Piece p in _t2.GetTeamPieces())
        {
            int letter = p.GetPosition()[0];
            int number = p.GetPosition()[1];

            // fill the correct tile
            _tileList[letter][number].AddPiece(p);
        }

    }

    private void ClearBoard()
    {
        foreach (List<Tile> row in _tileList)
        {
            foreach (Tile tile in row)
            {
                tile.ClearTile();
            }
        }
    }

    private void UpdatePieceList()
    {
        _pieceList.Clear();
        foreach (Piece p in _t1.GetTeamPieces())
        {
            _pieceList.Add(p);
        }
        foreach (Piece p in _t2.GetTeamPieces())
        {
            _pieceList.Add(p);
        }
    }

    public bool CheckTile(List<int> coordinate)
    {
        //Takes in a coordinate and sees if a piece is on there
        int row = coordinate[0];
        int column = coordinate[1];
        Tile tile = _tileList[row][column];
        if (tile.TileFull())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Piece GetPiece(List<int> coordinate)
    {
        //Takes in a coordinate and returns the piece on there.
        int row = coordinate[0];
        int column = coordinate[1];
        Tile tile = _tileList[row][column];
        return tile.GetPiece();
    }
}