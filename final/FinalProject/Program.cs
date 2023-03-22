using System;

class Program

{
    static void Main(string[] args)
    {

        //NOTE: For any coordinates we will do row first and then column
        // AKA letter, than number.
        
        Board b = new Board();
        Team wh = new Team();
        Team bl = new Team("black");
        /*
        b.PlaceTeam(wh);
        b.PlaceTeam(bl);
        b.DrawBoard();
        */

        
        King k = new King(0,0);
        b.PlacePiece(k);
        b.DrawBoard();
        b.CheckTile(new List<int>{0,0});
        b.CheckTile(new List<int>{6,6});
        foreach (Piece p in b._pieceList)
        {
            p.Move(new List<int>{6,6});
        }
        b.DrawBoard();
        b.CheckTile(new List<int>{0,0});
        b.CheckTile(new List<int>{6,6});

    }
}