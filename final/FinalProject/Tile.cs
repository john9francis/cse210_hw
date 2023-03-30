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
        AddPiece(p);
    }

    public bool TileFull()
    {
        if (_onTile.Count() == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void AddPiece(Piece p)
    {
        _onTile.Add(p);
    }

    public Piece GetPiece()
    {
        return _onTile[0];
    }



}