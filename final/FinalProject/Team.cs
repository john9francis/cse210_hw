public class Team
{
    private string _teamColor;
    private List<Piece> _teamPieces;
    // initialize all the pieces:
    private King _king;
    private Queen _queen;
    private Castle _c1;
    private Castle _c2;
    private Knight _n1;
    private Knight _n2;
    private Bishop _b1;
    private Bishop _b2;
    
    // we will initialize the pons upon initializing the class

    public Team(string color="White")
    {
        _teamColor = color;
        _teamPieces = new List<Piece>();
        if (_teamColor=="White")
        {
            // set up white team
            _king = new King(7,3);
            _queen = new Queen(7,4);

            _c1 = new Castle(7,0);
            _c2 = new Castle(7,7);

            _b1 = new Bishop(7,1);
            _b2 = new Bishop(7,6);

            _n1 = new Knight(7,2);
            _n2 = new Knight(7,5);

            for (int i=0; i<8; i++)
            {
                Pon p = new Pon(6,i);
                _teamPieces.Add(p);
            }
        } 
        else
        {
            // set up black team
            _king = new King(0,3,"!");
            _queen = new Queen(0,4,"?");

            _c1 = new Castle(0,0,"#");
            _c2 = new Castle(0,7,"#");

            _b1 = new Bishop(0,1,"/");
            _b2 = new Bishop(0,6,"/");

            _n1 = new Knight(0,2,"$");
            _n2 = new Knight(0,5,"$");

            for (int i=0; i<8; i++)
            {
                Pon p = new Pon(1,i,symbol:"+",color:"Black");
                _teamPieces.Add(p);
            }
        }

        _teamPieces.Add(_king);
        _teamPieces.Add(_queen);
        _teamPieces.Add(_c1);
        _teamPieces.Add(_c2);
        _teamPieces.Add(_b1);
        _teamPieces.Add(_b2);
        _teamPieces.Add(_n1);
        _teamPieces.Add(_n2);

    }

    public bool KingAlive()
    {
        if (_king.GetAliveStatus())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<Piece> GetTeamPieces()
    {
        return _teamPieces;
    }

    public string GetColor()
    {
        return _teamColor;
    }

    public void UpdateTeam()
    {
        // removes any unAlive pieces from the team.
        for (int i=0; i<_teamPieces.Count; i++)
        {
            if (!_teamPieces[i].GetAliveStatus())
            {
                _teamPieces.RemoveAt(i);
            }
        }
    }

    public Piece GetPiece(List<int> coordinate)
    {
        //Takes in a coordinate and returns the piece on there.
        int pieceIndex = 0;
        for (int i=0; i<_teamPieces.Count; i++)
        {
            if (_teamPieces[i].GetPosition().SequenceEqual(coordinate))
            {
                pieceIndex = i;
            }
        }
        return _teamPieces[pieceIndex];
    }


    
}