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

        while (!validPiece)
        {
            Console.Write($"{teamColor} team, Which piece would you like to move? (e.g. A1): ");
            string input = Console.ReadLine();
            coord = InputToCoordinate(input);
            if (TileInRange(coord) && PieceOnTile(coord,team))
            {
                // get the piece
                movingPiece = _board.GetPiece(coord);
                validPiece = true;
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

            // get the list of places the piece can move 
            moveOptions = movingPiece.GetWhereCanMove();

            // now translate the coordinates to where the piece is.
            foreach(List<int> l in moveOptions)
            {
                l[0] += movingPiece._position[0];
                l[1] += movingPiece._position[1];
            }
            // now moveOptions contains the basic places the piece can move.
            // narrow down moveOptions even more by running it through the function:
            moveOptions = WherePieceCanMove(moveOptions, team);

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
        }

    }

    public void TestList(List<List<int>> list)
    {
        foreach(List<int> l in list)
            {
                Console.Write($"({l[0]},{l[1]})");
            }
            Console.WriteLine();
    }

    public List<List<int>> WherePieceCanMove(List<List<int>> whereCanMove, Team team)
    {
        // returns a list of coordinates where the piece can move WITHOUT same-team pieces blocking it.
        
        // Step 1: get rid of of all options off the board.
        List<List<int>> outputList = new List<List<int>>();
        foreach(List<int> subList in whereCanMove)
        {
            bool outOfRange = false;
            foreach(int number in subList)
            {
                if(number < 0)
                {
                    outOfRange = true;
                    break;
                }
                else if (number > 7)
                {
                    outOfRange = true;
                    break;
                }
            }

            if(!outOfRange)
            {
                outputList.Add(subList);
            }
        }

        whereCanMove = outputList;


        // Step 2: delete all moveOptions that are occupied by same-team pieces
        // SOMEWHERE IT"S MESSING UP...
        List<List<int>> teamPieces = GetOccupiedTiles(team);
        List<List<int>> updatedList = new List<List<int>>();
        List<List<int>> blockers = new List<List<int>>();
        foreach(List<int> option in whereCanMove)
        {
            bool block = false;

            foreach(List<int> piece in teamPieces)
            {
                if (option.SequenceEqual(piece))
                {
                    block = true;
                    // Save the index of the piece and the teampieces that are blocking it's movement.
                    blockers.Add(piece);

                }
            }

            if (!block)
            {
                updatedList.Add(option);
            }
        }

        whereCanMove = updatedList;
        TestList(whereCanMove);

        // Step 3: delete all moveOptions that are blocked by the pieces that were there...(HARDEST PART)


        
        return whereCanMove;

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
        foreach(Piece p in team._teamPieces)
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