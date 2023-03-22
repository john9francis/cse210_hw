using System;

class Program

{
    static void Main(string[] args)
    {
        Board b = new Board();
        Team wh = new Team();
        Team bl = new Team("black");
        //b.PlaceTeam(wh);
        //b.PlaceTeam(bl);

        King k = new King(0,0);
        b.PlacePiece(k);
        List<int> final = new List<int>{0,1};
        k.Move(final);
        b.ClearBoard();
        b.PlacePiece(k);
        b.DrawBoard();

    }
}