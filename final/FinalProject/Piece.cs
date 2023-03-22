/*This file contains each type of piece, so I don't have a ton of files 
floating around.*/

public abstract class Piece
{
    public string _symbol;
    public List<int> _position;
    bool _dead = false;

    public Piece(int xpos, int ypos, string symbol="")
    {
        _symbol = symbol;
        _position = new List<int>{xpos,ypos};
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
}





public class King : Piece
{
    public King(int xpos, int ypos, string symbol="k") : base(xpos,ypos,symbol)
    {

    }
}

public class Queen : Piece
{
    public Queen(int xpos, int ypos, string symbol="q") : base(xpos,ypos,symbol)
    {

    }
}

public class Castle : Piece
{
    public Castle(int xpos, int ypos, string symbol="c") : base(xpos,ypos,symbol)
    {
    }
}

public class Knight : Piece
{
    public Knight(int xpos, int ypos, string symbol="n") : base(xpos,ypos,symbol)
    {
    }
}

public class Bishop : Piece
{
    public Bishop(int xpos, int ypos, string symbol="b") : base(xpos,ypos,symbol)
    {
    }
}

public class Pon : Piece
{
    public Pon(int xpos, int ypos, string symbol="p") : base(xpos,ypos,symbol)
    {
    }
}