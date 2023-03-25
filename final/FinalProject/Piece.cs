/*This file contains each type of piece, so I don't have a ton of files 
floating around.*/

public abstract class Piece
{
    public string _symbol;
    public List<int> _position;
    public bool _canJump;
    // bool _dead = false;

    public Piece(int xpos, int ypos, string symbol="")
    {
        _symbol = symbol;
        _position = new List<int>{xpos,ypos};
        _canJump = false;
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

    public abstract List<List<int>> WhereCanMove();

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

    public override List<List<int>> WhereCanMove()
    {
        // a king can only move in the following ways:
        // (1,0),(1,1),(0,1),(-1,1),(-1,0),(-1,-1),(0,-1),(1,-1)
        
        List<List<int>> coordinates = new List<List<int>>();
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
                    coordinates.Add(new List<int>{i,j});
                }
            }
        }

        // now translate the coordinates to where the piece is.
        foreach(List<int> l in coordinates)
        {
            l[0] += _position[0];
            l[1] += _position[1];
        }

        // make sure the piece can't move off the board
        // NOTE: move this function in the game class.
        List<List<int>> outputList = new List<List<int>>();
    
        foreach(List<int> subList in coordinates)
        {
            bool containsNegative = false;

            foreach(int number in subList)
            {
                if(number < 0)
                {
                    containsNegative = true;
                    break;
                }
            }

            if(!containsNegative)
            {
                outputList.Add(subList);
            }
        }
        return outputList;
    }

    public bool CheckCheckMate()
    {
        // checks if the king is in checkmate
        // NOTE: this function also goes in the Game class
        List<List<int>> whereCanMove = WhereCanMove();
        if (whereCanMove.Count() == 0)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}

public class Queen : Piece
{
    public Queen(int xpos, int ypos, string symbol="q") : base(xpos,ypos,symbol)
    {
    }

    public override List<List<int>> WhereCanMove()
    {
        throw new NotImplementedException();
    }
}

public class Castle : Piece
{
    public Castle(int xpos, int ypos, string symbol="c") : base(xpos,ypos,symbol)
    {
    }
    public override List<List<int>> WhereCanMove()
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

    public override List<List<int>> WhereCanMove()
    {
        throw new NotImplementedException();
    }
}

public class Bishop : Piece
{
    public Bishop(int xpos, int ypos, string symbol="b") : base(xpos,ypos,symbol)
    {
    }

    public override List<List<int>> WhereCanMove()
    {
        throw new NotImplementedException();
    }
}

public class Pon : Piece
{
    public Pon(int xpos, int ypos, string symbol="p") : base(xpos,ypos,symbol)
    {
    }

    public override List<List<int>> WhereCanMove()
    {
        throw new NotImplementedException();
    }
}