/*This file contains each type of piece, so I don't have a ton of files 
floating around.*/

public abstract class Piece
{
    private string _symbol;
    private List<int> _position;
    private List<List<int>> _whereCanMove;
    protected string _pieceType;
    private bool _alive;

    protected Piece(int xpos, int ypos, string symbol="")
    {
        _symbol = symbol;
        _position = new List<int>{xpos,ypos};
        _whereCanMove = new List<List<int>>();
        _alive = true;
    }


    public List<int> GetPosition()
    {
        return _position;
    }

    public string GetPieceType()
    {
        return _pieceType;
    }

    public bool GetAliveStatus()
    {
        return _alive;
    }

    public void Move(List<int> destination)
    {
        _position[0] = destination[0];
        _position[1] = destination[1];
    }

    public abstract List<List<int>> GetWhereCanMove();

    public string GetSymbol()
    {
        return _symbol;
    }

    public virtual void CompleteFirstMove()
    {
        // only matters for pon
    }
    public void KillPiece()
    {
        _alive = false;
    }

}


public class King : Piece
{
    public King(int xpos, int ypos, string symbol="k") : base(xpos,ypos,symbol)
    {
        _pieceType = "King";
    }
    public override List<List<int>> GetWhereCanMove()
    {
        List<List<int>> whereCanMove = new List<List<int>>();
        // set where the king can move and put it in the _whereCanMove variable.
        // a king can only move in the following ways:
        // (1,0),(1,1),(0,1),(-1,1),(-1,0),(-1,-1),(0,-1),(1,-1)
        for (int i=-1;i<2;i++)
        {
            for(int j=-1;j<2;j++)
            {
                // make sure (0,0) doesnt get added
                if (i==0 && j==0)
                {
                    continue;
                }
                else
                {
                    whereCanMove.Add(new List<int>{i,j});
                }
            }
        }
        return whereCanMove;
    }
}

public class Queen : Piece
{
    public Queen(int xpos, int ypos, string symbol="q") : base(xpos,ypos,symbol)
    {
        _pieceType = "Queen";
    }

    public override List<List<int>> GetWhereCanMove()
    {
        // a queen can move anywhere horizontally, vertically, or diagonally.
        // the most a queen would need to move is 7 spaces.
        List<List<int>> whereCanMove = new List<List<int>>();
        for (int i=-7; i<8; i++)
        {
            // don't add where the piece is located.
            if (i!=0)
            {
                // vertical movement
                whereCanMove.Add(new List<int>{i,0});
                // horizontal movement
                whereCanMove.Add(new List<int>{0,i});
                // diagonal movement
                whereCanMove.Add(new List<int>{i,i});
                whereCanMove.Add(new List<int>{-i,i});
            }
        }

        return whereCanMove;
    }

}

public class Castle : Piece
{
    public Castle(int xpos, int ypos, string symbol="c") : base(xpos,ypos,symbol)
    {
        _pieceType = "Castle";
    }

    public override List<List<int>> GetWhereCanMove()
    {
        // a castle can only move horizontally and vertically.
        List<List<int>> whereCanMove = new List<List<int>>();
        for (int i=-7; i<8; i++)
        {
            // don't add where the piece is located.
            if (i!=0)
            {
                // vertical movement
                whereCanMove.Add(new List<int>{i,0});
                // horizontal movement
                whereCanMove.Add(new List<int>{0,i});
            }
        }

        return whereCanMove;
    }

    
}

public class Knight : Piece
{
    public Knight(int xpos, int ypos, string symbol="n") : base(xpos,ypos,symbol)
    {
        _pieceType = "Knight";
    }

    public override List<List<int>> GetWhereCanMove()
    {
        List<List<int>> whereCanMove = new List<List<int>>();
        whereCanMove.Add(new List<int>{2,1});
        whereCanMove.Add(new List<int>{2,-1});
        whereCanMove.Add(new List<int>{-2,1});
        whereCanMove.Add(new List<int>{-2,-1});
        whereCanMove.Add(new List<int>{1,2});
        whereCanMove.Add(new List<int>{1,-2});
        whereCanMove.Add(new List<int>{-1,2});
        whereCanMove.Add(new List<int>{1,-2});

        return whereCanMove;

    }
}


public class Bishop : Piece
{
    public Bishop(int xpos, int ypos, string symbol="b") : base(xpos,ypos,symbol)
    {
        _pieceType = "Bishop";
    }

    public override List<List<int>> GetWhereCanMove()
    {
        // a Bishop can only move diagonally.
        List<List<int>> whereCanMove = new List<List<int>>();

        for (int i=-7; i<8; i++)
        {
            // don't add where the piece is located.
            if (i!=0)
            {
                // diagonal movement
                whereCanMove.Add(new List<int>{i,i});
                whereCanMove.Add(new List<int>{-i,i});
            }
        }

        return whereCanMove;
    }

}

public class Pon : Piece
{
    private string _color;
    private bool _firstMove;
    public Pon(int xpos, int ypos, string symbol="p", string color="White") : base(xpos,ypos,symbol)
    {
        _pieceType = "Pon";
        _color = color;
        _firstMove = true;
    }

    public override List<List<int>> GetWhereCanMove()
    {
        // pons have extra rules to their moves. 
        // the first turn move allows the pon to move 2 spaces.
        // the rule that pons kill diagonally will be handeled in the Game class.
        // default movement is UP so for black pons we need to turn everything negative. !!!
        List<List<int>> whereCanMove = new List<List<int>>();
        if (_color == "White")
        {
            whereCanMove.Add(new List<int>{-1,0});
            if (_firstMove)
            {
                whereCanMove.Add(new List<int>{-2,0});
            }
        }
        else
        {
            // color is black
            whereCanMove.Add(new List<int>{1,0});
            if (_firstMove)
            {
                whereCanMove.Add(new List<int>{2,0});
            }
        }
        

        return whereCanMove;
    }

    public override void CompleteFirstMove()
    {
        _firstMove = false;
    }

}