public class Team
{
    public string _teamColor;
    public List<Piece> _teamPieces;
    // initialize all the pieces:
    public King _king;
    public Queen _queen;
    public Castle _c1;
    public Castle _c2;
    public Knight _n1;
    public Knight _n2;
    public Bishop _b1;
    public Bishop _b2;
    
    // we will initialize the pons upon initializing the class

    public Team(string color="white")
    {
        _teamColor = color;
        _teamPieces = new List<Piece>();
        if (_teamColor=="white")
        {
            // set up white team
            _king = new King(7,3);
            _queen = new Queen(7,4); // TEST!

            _c1 = new Castle(7,0); // TEST!
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


    
}