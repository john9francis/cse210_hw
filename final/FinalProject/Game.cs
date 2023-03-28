public class Game
{
    Team _team1;
    Team _team2;
    Board _board;
    public Game()
    {
        _team1 = new Team();
        _team2 = new Team("black");
        _board = new Board();
        _board.PlaceTeam(_team1);
        _board.PlaceTeam(_team2);

    }

    public void PlayGame()
    {
        // let one team take a turn and then the other one, loop
        // stop loop when the game is over.
        bool playing = true;
        while (playing)
        {
            Console.Clear();
            _board.DrawBoard();
            TakeTurn(_team1);
            Console.Clear();
            _board.DrawBoard();
            TakeTurn(_team2);


        }
        
    }
    public void TakeTurn(Team team)
    {
        // setup
        Console.WriteLine();
        string teamColor;
        if (team == _team1)
        {
            teamColor = "White";
        }
        else
        {
            teamColor = "Black";
        }

        // User inputs which piece they want to move. Checks if it's a valid piece on their own team.
        Piece movingPiece;
        bool validPiece = false;
        bool canMove = false;
        List<int> coord = new List<int>();

        while (!validPiece && !canMove)
        {
            Console.Write($"{teamColor} team, Which piece would you like to move? (e.g. A1): ");
            string input = Console.ReadLine();
            coord = InputToCoordinate(input);
            if (TileInRange(coord) && PieceOnTile(coord,team))
            {
                // Check if the piece even can move...
                // get the piece
                movingPiece = _board.GetPiece(coord);

                // if the piece can't move, give the user the option to try another piece.
                if (WherePieceCanMove(movingPiece, team).Count != 0)
                {
                    canMove = true;
                    validPiece = true;
                }
                else
                {
                    Console.WriteLine("This piece can't move. Try another piece. ");
                }

            }
            else
            {
                Console.Write("Invalid entry. Make sure you entered in a coordinate of a piece on your team. (press enter)");
                Console.ReadLine();
            }
        }

        // get the piece
        movingPiece = _board.GetPiece(coord);

        // User inputs where they want to move TO. checks if it's a valid move. 
        bool validMove = false;
        List<int> coord2 = new List<int>();
        List<List<int>> moveOptions = new List<List<int>>();

        while (!validMove)
        {
            Console.Write("Where would you like to move this piece to? (e.g. C1): ");
            string input = Console.ReadLine();
            coord2 = InputToCoordinate(input);

            // get the list of places the piece can move (for now this is translated to where the piece is)
            moveOptions = movingPiece.WhereCanMove();

            // now translate the coordinates to where the piece is.
            foreach(List<int> l in moveOptions)
            {
                l[0] += movingPiece._position[0];
                l[1] += movingPiece._position[1];
            }

            // make sure the piece can't move off the board
            // NOTE: move this function in the game class.
            List<List<int>> outputList = new List<List<int>>();

            foreach(List<int> subList in moveOptions)
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
            moveOptions = outputList;

            foreach(List<int> l in moveOptions)
            {
                Console.Write($"({l[0]},{l[1]})");
            }
            Console.WriteLine();

            // delete all the pieces from moveOptions that are occupied by same-team pieces
            List<List<int>> sameTeamOccupied = GetOccupiedTiles(team);
            moveOptions = DeleteIdenticalEntries(moveOptions,sameTeamOccupied);
            foreach(List<int> l in moveOptions)
            {
                Console.Write($"({l[0]},{l[1]})");
            }


            foreach(List<int> l in moveOptions)
            {
                if (l.SequenceEqual(coord2))
                {
                    // the coordinate is a place the piece can move!
                    validMove = true;
                    Console.Write("You can move here.(press enter): ");
                    Console.ReadLine();

                }
            }
            if (!validMove)
            {
                Console.Write("Invalid move. Please choose a different place to move. (press enter): ");
                Console.ReadLine();
            }
            // for each place...
            // see if the coordinate is off the board
            // see if there's a same team piece in the way
            // see if you will kill another piece
        }

    }

    public List<List<int>> WherePieceCanMove(Piece piece, Team team)
    {
        //returns a list of coordinates where the piece can move WITHOUT same-team pieces blocking it.

        // get the list of places the piece can move (for now this is translated to where the piece is)
        List<List<int>> wherePieceCanMove = piece.WhereCanMove();

        // delete all moveOptions that are occupied by same-team pieces
        List<List<int>> sameTeamOccupied = GetOccupiedTiles(team);
        wherePieceCanMove = DeleteIdenticalEntries(wherePieceCanMove,sameTeamOccupied);

        // if piece can't jump, delete any moveOptions further away than the piece block...

        return wherePieceCanMove;

    }

    public List<List<int>> DeleteIdenticalEntries(List<List<int>> list1, List<List<int>> list2)
    {
        // returns an updated list1 with only the entries that are NOT in list2. 
        List<List<int>> updatedList = new List<List<int>>();
        foreach(List<int> l1 in list1)
        {
            bool foundInList2 = false;

            foreach(List<int> l2 in list2)
            {
                if (!l1.SequenceEqual(l2))
                {
                    foundInList2 = true;
                }
            }

            if (!foundInList2)
            {
                updatedList.Add(l1);
            }
        }

        return updatedList;

    }

    public List<List<int>> GetOccupiedTiles(Team team)
    {
        // returns a list of coordinates occupied by tiles in the team.
        List<List<int>> occupiedTiles = new List<List<int>>();
        foreach(Piece p in _board._pieceList)
        {
            occupiedTiles.Add(p._position);
        }
        return occupiedTiles;
    }

    public bool TileInRange(List<int> coordinate)
    {
        if (coordinate[0] == -1||coordinate[1] == -1)
        {
            return false;
        }
        else 
        {
            return true;
        }
    }

    public void Clear2Lines()
    {
        Console.SetCursorPosition(0, Console.CursorTop - 2);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', Console.WindowWidth));
    }

    public bool PieceOnTile(List<int> coordinate, Team team)
    {
        // Check if there is a team piece on that coordinate
        bool existsPiece = false;
        foreach(Piece p in team._teamPieces)
        {
            if (p._position.SequenceEqual(coordinate))
            {
                existsPiece = true;
            }
        }
        return existsPiece;
    }

    

    public List<int> InputToCoordinate(string input)
    {
        // takes in users input (e.g. A1) and returns coordinate (e.g. [0,0])
        input.Split();
        try
        {
            string letter = input[0].ToString();
            string number = input[1].ToString();
            List<string> letters = new List<string>{"A","B","C","D","E","F","G","H"};
            List<string> numbers = new List<string>{"1","2","3","4","5","6","7","8"};

            int letterIndex = letters.FindIndex(a => a.Contains(letter));
            int numberIndex = numbers.FindIndex(a => a.Contains(number));
            return new List<int>{letterIndex,numberIndex};
        }
        catch (IndexOutOfRangeException)
        {
            return new List<int>{-1,-1};
        }
        

    }

    public void CheckWinner()
    {
        // check which team has won
        
    }

    public void MovePiece()
    {
        // ask user for which piece to move, where to move it, and then do that.

    }



}