public class Tile
{
    public List<Piece> _onTile;
    public Tile()
    {
        _onTile = new List<Piece>();
    }
    public Tile(Piece p)
    {
        _onTile = new List<Piece>();
        _onTile.Add(p);
    }
    public void AddPiece(Piece p)
    {
        _onTile.Add(p);
    }
    public string TileString()
    {
        if (_onTile.Count() > 0)
        {
           string _pieceSymbol = _onTile[0]._symbol;
            return $"[{_pieceSymbol}]"; 
        }
        else
        {
            return "[ ]";
        }
        
    }

}