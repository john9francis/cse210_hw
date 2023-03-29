/*This file contains each type of piece, so I don't have a ton of files 
floating around.*/

public abstract class Piece
{
    public string _symbol;
    public List<int> _position;
    public bool _canJump;
    // bool _dead = false;
    public List<List<int>> _whereCanMove;

    public Piece(int xpos, int ypos, string symbol="")
    {
        _symbol = symbol;
        _position = new List<int>{xpos,ypos};
        _canJump = false;
        _whereCanMove = new List<List<int>>();
    }


    public void SetPosition(int x, int y)
    {
        _position.Add(x);
        _position.Add(y);
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

}





public class King : Piece
{
    public King(int xpos, int ypos, string symbol="k") : base(xpos,ypos,symbol)
    {
        
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
        
    }

    public override List<List<int>> GetWhereCanMove()
    {
        // a queen can move anywhere horizontally, vertically, or diagonally.
        // the most a queen would need to move is 7 spaces.
        List<List<int>> whereCanMove = new List<List<int>>();
        // vertical movements:
        for (int i=-7; i<8; i++)
        {
            // don't add where the piece is located.
            if (i!=0)
            {
                whereCanMove.Add(new List<int>{i,0});
            }
        }

        return whereCanMove;
    }

}

public class Castle : Piece
{
    public Castle(int xpos, int ypos, string symbol="c") : base(xpos,ypos,symbol)
    {
    }

    public override List<List<int>> GetWhereCanMove()
    {
        throw new NotImplementedException();
    }
}

public class Knight : Piece
{
    public Knight(int xpos, int ypos, string symbol="n") : base(xpos,ypos,symbol)
    {
        _canJump = true;
    }

    public override List<List<int>> GetWhereCanMove()
    {
        throw new NotImplementedException();
    }
}


public class Bishop : Piece
{
    public Bishop(int xpos, int ypos, string symbol="b") : base(xpos,ypos,symbol)
    {
    }

    public override List<List<int>> GetWhereCanMove()
    {
        throw new NotImplementedException();
    }

}

public class Pon : Piece
{
    bool enemyNearby;
    bool firstTurn;
    public Pon(int xpos, int ypos, string symbol="p") : base(xpos,ypos,symbol)
    {
        // pons have extra rules to their moves. 
        // these will be handled by enemyNearby and firstTurn.
        enemyNearby = false;
        firstTurn = true;
    }

    public override List<List<int>> GetWhereCanMove()
    {
        throw new NotImplementedException();
    }

}